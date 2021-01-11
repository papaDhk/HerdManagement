using Applicattion.Data.DTO.Herd.Assembler;
using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.SpecieBreed.Entities;

namespace Applicattion.Data.DTO.Reproduction.Assembler
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
                    Herd = animalDTO.Herd.ToHerd(),
                    Breed = new Breed { Id = animalDTO.BreedId },
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
                    Breed = new Breed { Id = animalDTO.BreedId },
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
                    Herd = animalDTO.Herd.ToHerd(),
                    Breed = new Breed { Id = animalDTO.BreedId },
                    Picture = animalDTO.Picture,
                    PresenceStatus = animalDTO.PresenceStatus,
                    Weight = animalDTO.Weight,
                    FromCalving = animalDTO.FromCalving
                };
            }
            else
            {
                return new Animal();
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
                    Breed = new Breed { Id = animalDTO.BreedId },
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
