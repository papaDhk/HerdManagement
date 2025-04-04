﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Applicattion.Data.DTO.Reproduction;
using Applicattion.Data.DTO.Reproduction.Assembler;
using Applicattion.Data.DTO.SpecieBreed.Assembler;
using Applicattion.Data.Messages;
using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.Enumerations;
using HerdManagement.Domain.Reproduction.Repository;
using HerdManagement.Domain.SpecieBreed.Repository;

namespace Applicattion.Services
{
    public class ReproductionService : IReproductionService
    {
        private readonly IAnimalRepository _animalRepository;

        private readonly IBreedRepository _breedRepository;

        private readonly IReproductionRepository _reproductionRepository;

        public ReproductionService(IAnimalRepository animalRepository, IBreedRepository breedRepository, IReproductionRepository reproductionRepository)
        {
            _animalRepository = animalRepository ?? throw new ArgumentNullException(nameof(animalRepository));
            _breedRepository = breedRepository ?? throw new ArgumentNullException(nameof(breedRepository));
            _reproductionRepository = reproductionRepository ?? throw new ArgumentNullException(nameof(reproductionRepository));
        }

        public async Task<Animal> AddNewAnimalAsync(AnimalDTO animalDTO)
        {
            Animal animal = null;

            if (animalDTO is null)
                return animal;


            var breed = await _breedRepository.GetBreedById(animalDTO.BreedId);
            animalDTO.Breed = breed.ToBreedDTO();
            bool isYoungAnimal = breed.Specie.ChildhoodDurationInDays > animalDTO.AgeInDays;

            if (animalDTO.Origin == AnimalOrigin.BornInFarm && animalDTO.FatherId != 0 && animalDTO.MotherId != 0)
            {
                animal = animalDTO.ToAnimal();
                animal.Breed = breed;
                Calving animalOriginCalving = GetOrCreateParentRelationShip(animalDTO.MotherId, animalDTO.FatherId, animalDTO.BirthDate, animal.ApproximativeOriginReproductionDate);

                animalDTO.FromCalving = animalOriginCalving;
            }


            if (isYoungAnimal)
            {
                animal = await _animalRepository.AddNewYoungAnimalAsync(animalDTO.ToYoungAnimalUpdateDTO()).ContinueWith(youngAnimal => (Animal)youngAnimal.Result);
            }
            else
            {
                switch (animalDTO.Sex)
                {
                    case SexEnum.Male:
                        animal = await _animalRepository.AddNewMaleAsync(animalDTO.ToMaleUpdateDTO()).ContinueWith(male => (Animal)male.Result);
                        break;
                    case SexEnum.Female:
                        animal = await _animalRepository.AddNewFemaleAsync(animalDTO.ToFemaleUpdateDTO()).ContinueWith(female => (Animal)female.Result);
                        break;
                }
            }

            return animal;
        }

        public async Task<Animal> AddNewAnimalAsync(Animal animal)
        {
            return await AddNewAnimalAsync(animal?.ToAnimalDTO());
        }
        
        public Calving GetOrCreateParentRelationShip(int motherId, int fatherId, DateTime birthDate, DateTime inferredOriginReproductionDate, int childId = 0)
        {
            var mother = _animalRepository.GetFemaleById(motherId);

            var father = _animalRepository.GetMaleById(fatherId);

            if (mother?.CanBeParentOfAnimalBornIn(birthDate) == false || father?.CanBeParentOfAnimalBornIn(birthDate) == false)
            {
                return null;
            }

            Reproduction animalOriginReproduction = _reproductionRepository.GetReproductionByPartnersIdsAndDate(motherId, fatherId, inferredOriginReproductionDate);

            if (animalOriginReproduction == null)
            {
                //Set approximativeDate
                animalOriginReproduction = new Reproduction
                {
                    FemaleId = motherId,
                    MaleId = fatherId,
                    States = new List<ReproductionState> { new ReproductionState { State = ReproductionStateEnum.Complete, Date = birthDate } },
                    Date = inferredOriginReproductionDate
                };
            }

            return animalOriginReproduction.Calvings.Where(calving => calving.AnimalId == childId).FirstOrDefault() ?? new Calving
            {
                Date = birthDate,
                Reproduction = animalOriginReproduction,
                FemaleId = motherId,
                MaleId = fatherId
            };
        }

        public async Task<Animal> UpdateAnimalAsync(Animal animal, int motherId, int fatherId)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                Calving animalOriginCalving = null;
                if (fatherId != 0 && motherId != 0)
                {
                     animalOriginCalving = GetOrCreateParentRelationShip(motherId, fatherId, animal.BirthDate, animal.ApproximativeOriginReproductionDate, animal.Id);
                }

                if (animal.FromCalving != null && animalOriginCalving?.Id != animal.FromCalving?.Id)
                {
                    await _reproductionRepository.DeleteCalving(animal.FromCalving.Id);
                }

                animal.FromCalving = animalOriginCalving;

                animal = animal.CategoryType switch
                {
                    Animal.MALE_TYPE => await _animalRepository.UpdateMaleAsync(animal.ToMaleUpdateDTO())
                        .ContinueWith(male => (Animal) male.Result),
                
                    Animal.FEMALE_TYPE => await _animalRepository.UpdateFemaleAsync((Female) animal.ToFemaleUpdateDTO())
                        .ContinueWith(female => (Animal) female.Result),
                     
                    _ => await _animalRepository.UpdateYoungAnimalAsync(animal.ToYoungAnimalUpdateDTO())
                    .ContinueWith(youngAnimal => (Animal) youngAnimal.Result),
                };
                
                scope.Complete();
            }
            
            return animal;
        }

        public bool CanBeFatherOfAnimalBornIn(int maleId, DateTime birthDate)
        {
            var male = _animalRepository.GetMaleById(maleId);

            var result = male is null ? false : male.CanBeParentOfAnimalBornIn(birthDate);

            return result;
        }

        public bool CanBeMotherOfAnimalBornIn(int femaleId, DateTime birthDate)
        {
            var female = _animalRepository.GetFemaleById(femaleId);

            bool result = female is null ? false : female.CanBeParentOfAnimalBornIn(birthDate);

            return result;
        }

        public async Task<ReproductionCreationResponse> CreateOrUpdateReproductionAsync(Reproduction reproduction)
        {
            var response = new ReproductionCreationResponse();

            var male = _animalRepository.GetMaleById(reproduction.MaleId);

            var female = _animalRepository.GetFemaleWithReproductionsById(reproduction.FemaleId);

            if(female is null || male is null)
            {
                return response;
            }

            var canFemaleBeMated = female.CanBeMated(reproduction.Date);

            response = new ReproductionCreationResponse
            {
                CouldFemaleBeMated = canFemaleBeMated,
                WasMaleAdult = male.WasAdult(reproduction.Date),
            };

            if (canFemaleBeMated && response.WasMaleAdult)
            {
                Reproduction createdReproduction = await _reproductionRepository.CreateOrUpdateReproductionAsync(reproduction);

                response.IsSuccessful = true;

                response.Reproduction = createdReproduction;
            }

            return response;
        }
    }
}
