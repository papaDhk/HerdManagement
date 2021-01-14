using Application.Data.DTO.Herd.Assembler;
using Application.Data.DTO.SpecieBreed.Assembler;
using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.SpecieBreed.Entities;

namespace Application.Data.DTO.Reproduction.Assembler
{
    public static class AnimalAssembler
    {
        public static Male ToMale(this AnimalDTO animalDTO)
        {
            if(animalDTO != null)
            {
                return new Male
                {
                    Name = animalDTO.Name,
                    BirthDate = animalDTO.BirthDate,
                    Origin = animalDTO.Origin,
                    Number = animalDTO.Number,
                    DeathDate = animalDTO.DeathDate,
                    Herd = animalDTO.Herd?.ToHerd(),
                    Breed = animalDTO.Breed.ToBreed(),
                    Picture = animalDTO.Picture,
                    PresenceStatus = animalDTO.PresenceStatus,
                    Weight = animalDTO.Weight,
                    FromCalving = animalDTO.FromCalving
                };
            }
            else
            {
                return new Male();
            }
        }

        public static Female ToFemale(this AnimalDTO animalDTO)
        {
            if (animalDTO != null)
            {
                return new Female
                {
                    Name = animalDTO.Name,
                    BirthDate = animalDTO.BirthDate,
                    Origin = animalDTO.Origin,
                    Number = animalDTO.Number,
                    DeathDate = animalDTO.DeathDate,
                    Herd = animalDTO.Herd.ToHerd(),
                    Breed = animalDTO.Breed.ToBreed(),
                    Picture = animalDTO.Picture,
                    PresenceStatus = animalDTO.PresenceStatus,
                    Weight = animalDTO.Weight,
                    FromCalving = animalDTO.FromCalving
                };
            }
            else
            {
                return new Female();
            }
        }

        public static Animal ToAnimal(this AnimalDTO animalDTO)
        {
            if (animalDTO != null)
            {
                return new Animal
                {
                    Name = animalDTO.Name,
                    BirthDate = animalDTO.BirthDate,
                    Origin = animalDTO.Origin,
                    Number = animalDTO.Number,
                    DeathDate = animalDTO.DeathDate,
                    Herd = animalDTO.Herd?.ToHerd(),
                    Breed = animalDTO.Breed?.ToBreed(),
                    Picture = animalDTO.Picture,
                    PresenceStatus = animalDTO.PresenceStatus,
                    Weight = animalDTO.Weight,
                    FromCalving = animalDTO.FromCalving,
                    Sex = animalDTO.Sex,
                    HerdId = animalDTO.Herd?.Id ?? animalDTO.HerdId,
                    BreedId = animalDTO.Breed?.Id ?? animalDTO.BreedId
                };
            }
            else
            {
                return new Animal();
            }
        }

        public static AnimalDTO ToAnimalDTO(this Animal animal)
        {
            if (animal != null)
            {
                return new AnimalDTO()
                {
                    Name = animal.Name,
                    BirthDate = animal.BirthDate,
                    Origin = animal.Origin,
                    Number = animal.Number,
                    DeathDate = animal.DeathDate,
                    Herd = animal.Herd?.ToHerdDTO(),
                    Breed = animal.Breed?.ToBreedDTO(),
                    Picture = animal.Picture,
                    PresenceStatus = animal.PresenceStatus,
                    Weight = animal.Weight,
                    FromCalving = animal.FromCalving,
                    Sex = animal.Sex,
                    HerdId = animal.Herd?.Id ?? animal.HerdId,
                    BreedId = animal.Breed?.Id ?? animal.BreedId
                };
            }
            else
            {
                return new AnimalDTO();
            }
        }
        
        public static YoungAnimal ToYoungAnimal(this AnimalDTO animalDTO)
        {
            if (animalDTO != null)
            {
                return new YoungAnimal
                {
                    Name = animalDTO.Name,
                    BirthDate = animalDTO.BirthDate,
                    Origin = animalDTO.Origin,
                    Number = animalDTO.Number,
                    DeathDate = animalDTO.DeathDate,
                    Herd = animalDTO.Herd.ToHerd(),
                    Breed = animalDTO.Breed.ToBreed(),
                    Picture = animalDTO.Picture,
                    PresenceStatus = animalDTO.PresenceStatus,
                    Weight = animalDTO.Weight,
                    FromCalving = animalDTO.FromCalving
                };
            }
            else
            {
                return new YoungAnimal();
            }
        }
              
    }
}
