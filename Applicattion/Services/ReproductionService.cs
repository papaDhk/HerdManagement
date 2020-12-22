using Applicattion.Data.DTO.Reproduction;
using Applicattion.Data.DTO.Reproduction.Assembler;
using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.Enumerations;
using HerdManagement.Domain.Reproduction.Repository;
using HerdManagement.Domain.SpecieBreed.Repository;
using HerdManagement.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicattion.Services
{
    public class ReproductionService : IReproductionService
    {
        private IAnimalRepository _animalRepository;

        private IBreedRepository _breedRepository;

        private IReproductionRepository _reproductionRepository;

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

            bool isYoungAnimal = breed.Specie.ChildhoodDurationInDays > animalDTO.AgeInDays;
            
            if(animalDTO.Origin == AnimalOrigin.BornInFarm && animalDTO.FatherId != 0 && animalDTO.MotherId != 0)
            {
                Calving animalOriginCalving = _reproductionRepository.GetCalvingByParentsIdsdAndDate(animalDTO.MotherId, animalDTO.FatherId, animalDTO.BirthDate);
                
                if (animalOriginCalving == null)
                {
                    Reproduction reproduction = new Reproduction
                    {
                        FemaleId = animalDTO.MotherId,
                        MaleId = animalDTO.FatherId,                       
                    };

                    animalOriginCalving = new Calving
                    {
                        NumberOfNewborn = 1,
                        Date = animalDTO.BirthDate,
                        Reproduction = reproduction,
                    };
                }

                animalDTO.FromCalving = animalOriginCalving;
            }
            

            if (isYoungAnimal)
            {
                animal = await _animalRepository.AddNewYoungAnimalAsync(animalDTO.ToYoungAnimal()).ContinueWith(youngAnimal => (Animal)youngAnimal.Result);
            }
            else
            {
                switch (animalDTO.Sex)
                {
                    case SexEnum.Male:
                        animal = await _animalRepository.AddNewMaleAsync(animalDTO.ToMale()).ContinueWith(male => (Animal)male.Result);
                        break;
                    case SexEnum.Female:
                        animal = await _animalRepository.AddNewFemaleAsync(animalDTO.ToFemale()).ContinueWith(female => (Animal)female.Result);
                        break;
                }
            }
         
            return animal;
        }
    }
}
