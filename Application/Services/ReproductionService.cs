using Application.Data.DTO.Reproduction.Assembler;
using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.Enumerations;
using HerdManagement.Domain.Reproduction.Repository;
using HerdManagement.Domain.SpecieBreed.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Application.Data.DTO.Reproduction;
using Application.Data.DTO.SpecieBreed.Assembler;
using Application.Data.Messages;

namespace Application.Services
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

        public async Task<AddNewAnimalResult> AddNewAnimalAsync(AnimalDTO animalDTO)
        {
            AddNewAnimalResult addNewAnimalResult = new();
            Animal animal = null;

            if (animalDTO is null)
                return addNewAnimalResult;


            var breed = await _breedRepository.GetBreedById(animalDTO.BreedId);
            animalDTO.Breed = breed.ToBreedDTO();
            var isYoungAnimal = breed.Specie.ChildhoodDurationInDays > animalDTO.AgeInDays;

            if (animalDTO.Origin == AnimalOrigin.BornInFarm && animalDTO.FatherId != 0 && animalDTO.MotherId != 0)
            {
                animal = animalDTO.ToAnimal();
                animal.Breed = breed;
                
                CalvingCreationResult animalOriginCalvingResult = GetOrCreateParentRelationShip(animalDTO.MotherId, animalDTO.FatherId, animalDTO.BirthDate, animal.ApproximativeOriginReproductionDate);

                if (animalOriginCalvingResult.IsNotSuccessful)
                {
                    addNewAnimalResult.CannotBeFatherOf = animalOriginCalvingResult.CannotBeFatherOf;
                    addNewAnimalResult.CannotBeMotherOf = animalOriginCalvingResult.CannotBeMotherOf;
                    return addNewAnimalResult;
                }

                animalDTO.FromCalving = animalOriginCalvingResult.Calving;
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

            addNewAnimalResult.Animal = animal;
            return addNewAnimalResult;
        }

        public async Task<AddNewAnimalResult> AddNewAnimalAsync(Animal animal)
        {
            return await AddNewAnimalAsync(animal?.ToAnimalDTO());
        }
        
        public CalvingCreationResult GetOrCreateParentRelationShip(int motherId, int fatherId, DateTime birthDate, DateTime inferredOriginReproductionDate, int childId = 0)
        {
            CalvingCreationResult calvingCreationResult = new();
            
            var mother = _animalRepository.GetFemaleById(motherId);

            var father = _animalRepository.GetMaleById(fatherId);

            calvingCreationResult.CannotBeFatherOf = father?.CanBeParentOfAnimalBornIn(birthDate) == false;
            calvingCreationResult.CannotBeMotherOf = mother?.CanBeParentOfAnimalBornIn(birthDate) == false;

            if (calvingCreationResult.IsNotSuccessful)
            {
                return calvingCreationResult;
            }

            var animalOriginReproduction = _reproductionRepository.GetReproductionByPartnersIdsAndDate(motherId, fatherId, inferredOriginReproductionDate) ??
            new Reproduction
            {
                FemaleId = motherId,
                MaleId = fatherId,
                States = new List<ReproductionState> { new() { State = ReproductionStateEnum.Complete, Date = birthDate } },
                Date = inferredOriginReproductionDate
            };

            calvingCreationResult.Calving = animalOriginReproduction.Calvings.FirstOrDefault(calving => calving.AnimalId == childId) ?? new Calving
            {
                Date = birthDate,
                Reproduction = animalOriginReproduction,
                FemaleId = motherId,
                MaleId = fatherId
            };

            return calvingCreationResult;
        }

        public async Task<UpdateAnimalResult> UpdateAnimalAsync(Animal animal, int motherId, int fatherId)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            
            Calving animalOriginCalving = null;
            
            if (fatherId != 0 && motherId != 0)
            {
                var result = GetOrCreateParentRelationShip(motherId, fatherId, animal.BirthDate, animal.ApproximativeOriginReproductionDate, animal.Id);

                if (result.IsNotSuccessful)
                {
                    return new UpdateAnimalResult
                    {
                        CannotBeFatherOf = result.CannotBeFatherOf,
                        CannotBeMotherOf = result.CannotBeMotherOf
                    };
                }

                animalOriginCalving = result.Calving;
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
                
                Animal.FEMALE_TYPE => await _animalRepository.UpdateFemaleAsync(animal.ToFemaleUpdateDTO())
                    .ContinueWith(female => (Animal) female.Result),
                     
                _ => await _animalRepository.UpdateYoungAnimalAsync(animal.ToYoungAnimalUpdateDTO())
                    .ContinueWith(youngAnimal => (Animal) youngAnimal.Result),
            };
                
            scope.Complete();
            
            return new UpdateAnimalResult{Animal = animal};
        }

        public bool CanBeFatherOfAnimalBornIn(int maleId, DateTime birthDate)
        {
            var male = _animalRepository.GetMaleById(maleId);

            var result = male?.CanBeParentOfAnimalBornIn(birthDate) ?? false;

            return result;
        }

        public bool CanBeMotherOfAnimalBornIn(int femaleId, DateTime birthDate)
        {
            var female = _animalRepository.GetFemaleById(femaleId);

            var result = female?.CanBeParentOfAnimalBornIn(birthDate) ?? false;

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

            if (!canFemaleBeMated || !response.WasMaleAdult) return response;
            
            var createdReproduction = await _reproductionRepository.CreateOrUpdateReproductionAsync(reproduction);

            response.IsSuccessful = true;

            response.Reproduction = createdReproduction;

            return response;
        }
    }

    public class CalvingCreationResult
    {
        public bool CannotBeFatherOf { get; set; }
        public bool CannotBeMotherOf { get; set; }
        public Calving Calving { get; set; }

        public bool IsNotSuccessful => CannotBeFatherOf || CannotBeMotherOf;
    }

    public class AddNewAnimalResult
    {
        public Animal Animal { get; set; }
        public bool CannotBeFatherOf { get; set; }
        public bool CannotBeMotherOf { get; set; }
        public bool IsNotSuccessful => CannotBeFatherOf || CannotBeMotherOf;

    }
    public class UpdateAnimalResult
    {
        public Animal Animal { get; set; }
        public bool CannotBeFatherOf { get; set; }
        public bool CannotBeMotherOf { get; set; }
        public bool IsNotSuccessful => CannotBeFatherOf || CannotBeMotherOf;

    }
}
