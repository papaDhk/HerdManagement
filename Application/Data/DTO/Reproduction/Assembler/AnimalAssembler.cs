using Application.Data.DTO.Herd.Assembler;
using Application.Data.DTO.SpecieBreed.Assembler;
using HerdManagement.Domain.Reproduction.Entities;

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
                    Id = animalDTO.Id,
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

            return new Male();
        }
        
        public static Male ToMaleUpdateDTO(this AnimalDTO animalDTO)
        {
            if (animalDTO != null)
            {
                return new Male
                {
                    Id = animalDTO.Id,
                    Name = animalDTO.Name,
                    BirthDate = animalDTO.BirthDate,
                    Origin = animalDTO.Origin,
                    Number = animalDTO.Number,
                    FromCalving = animalDTO.FromCalving,
                    DeathDate = animalDTO.DeathDate,
                    Picture = animalDTO.Picture,
                    PresenceStatus = animalDTO.PresenceStatus,
                    Weight = animalDTO.Weight,
                    Sex = animalDTO.Sex,
                    HerdId = animalDTO.Herd?.Id ?? animalDTO.HerdId,
                    BreedId = animalDTO.Breed?.Id ?? animalDTO.BreedId,
                    CategoryType = animalDTO.CategoryType ?? 
                                   Animal.GetCategory(animalDTO.Breed?.Specie?.ToSpecie(), animalDTO.Sex, animalDTO.BirthDate)                };
            }

            return new Male();
        }

        public static Female ToFemale(this AnimalDTO animalDTO)
        {
            if (animalDTO != null)
            {
                return new Female
                {
                    Id = animalDTO.Id,
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

            return new Female();
        }
        
        public static Female ToFemaleUpdateDTO(this AnimalDTO animalDTO)
        {
            if (animalDTO != null)
            {
                return new Female
                {
                    Id = animalDTO.Id,
                    Name = animalDTO.Name,
                    BirthDate = animalDTO.BirthDate,
                    Origin = animalDTO.Origin,
                    Number = animalDTO.Number,
                    FromCalving = animalDTO.FromCalving,
                    DeathDate = animalDTO.DeathDate,
                    Picture = animalDTO.Picture,
                    PresenceStatus = animalDTO.PresenceStatus,
                    Weight = animalDTO.Weight,
                    Sex = animalDTO.Sex,
                    HerdId = animalDTO.Herd?.Id ?? animalDTO.HerdId,
                    BreedId = animalDTO.Breed?.Id ?? animalDTO.BreedId,
                    CategoryType = animalDTO.CategoryType ?? 
                                   Animal.GetCategory(animalDTO.Breed?.Specie?.ToSpecie(), animalDTO.Sex, animalDTO.BirthDate)                };
            }

            return new Female();
        }

        public static Animal ToAnimal(this AnimalDTO animalDTO)
        {
            if (animalDTO != null)
            {
                return new Animal
                {
                    Id = animalDTO.Id,
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

            return new Animal();
        }
        
        public static Animal ToAnimalUpdateDTO(this AnimalDTO animalDTO)
        {
            if (animalDTO != null)
            {
                return new Animal
                {
                    Id = animalDTO.Id,
                    Name = animalDTO.Name,
                    BirthDate = animalDTO.BirthDate,
                    Origin = animalDTO.Origin,
                    FromCalving = animalDTO.FromCalving,
                    Number = animalDTO.Number,
                    DeathDate = animalDTO.DeathDate,
                    Picture = animalDTO.Picture,
                    PresenceStatus = animalDTO.PresenceStatus,
                    Weight = animalDTO.Weight,
                    Sex = animalDTO.Sex,
                    HerdId = animalDTO.Herd?.Id ?? animalDTO.HerdId,
                    BreedId = animalDTO.Breed?.Id ?? animalDTO.BreedId,
                    CategoryType = animalDTO.CategoryType ?? 
                                   Animal.GetCategory(animalDTO.Breed?.Specie?.ToSpecie(), animalDTO.Sex, animalDTO.BirthDate)
                };
            }

            return null;
        }

        public static Animal ToAnimalUpdateDTO(this Animal animal)
        {
            if (animal != null)
            {
                return new Animal
                {
                    Id = animal.Id,
                    Name = animal.Name,
                    BirthDate = animal.BirthDate,
                    Origin = animal.Origin,
                    Number = animal.Number,
                    FromCalving = animal.FromCalving,
                    DeathDate = animal.DeathDate,
                    Picture = animal.Picture,
                    PresenceStatus = animal.PresenceStatus,
                    Weight = animal.Weight,
                    Sex = animal.Sex,
                    HerdId = animal.Herd?.Id ?? animal.HerdId,
                    BreedId = animal.Breed?.Id ?? animal.BreedId,
                    CategoryType = animal.CategoryType,
                };
            }

            return null;
        }
        public static AnimalDTO ToAnimalDTO(this Animal animal)
        {
            if (animal != null)
            {
                return new AnimalDTO()
                {
                    Id = animal.Id,
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

            return new AnimalDTO();
        }
        
        public static YoungAnimal ToYoungAnimal(this AnimalDTO animalDTO)
        {
            if (animalDTO != null)
            {
                return new YoungAnimal
                {
                    Id = animalDTO.Id,
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

            return new YoungAnimal();
        }
        
        public static YoungAnimal ToYoungAnimalUpdateDTO(this AnimalDTO animalDTO)
        {
            if (animalDTO != null)
            {
                return new YoungAnimal
                {
                    Id = animalDTO.Id,
                    Name = animalDTO.Name,
                    BirthDate = animalDTO.BirthDate,
                    Origin = animalDTO.Origin,
                    FromCalving = animalDTO.FromCalving,
                    Number = animalDTO.Number,
                    DeathDate = animalDTO.DeathDate,
                    Picture = animalDTO.Picture,
                    PresenceStatus = animalDTO.PresenceStatus,
                    Weight = animalDTO.Weight,
                    Sex = animalDTO.Sex,
                    HerdId = animalDTO.Herd?.Id ?? animalDTO.HerdId,
                    BreedId = animalDTO.Breed?.Id ?? animalDTO.BreedId,
                    CategoryType = animalDTO.CategoryType ?? 
                                   Animal.GetCategory(animalDTO.Breed?.Specie?.ToSpecie(), animalDTO.Sex, animalDTO.BirthDate)
                };
            }

            return new YoungAnimal();
        }
        
        public static Female ToFemaleUpdateDTO(this Animal animal)
        {
            if (animal != null)
            {
                return new Female
                {
                    Id = animal.Id,
                    Name = animal.Name,
                    BirthDate = animal.BirthDate,
                    Origin = animal.Origin,
                    Number = animal.Number,
                    FromCalving = animal.FromCalving,
                    DeathDate = animal.DeathDate,
                    Picture = animal.Picture,
                    PresenceStatus = animal.PresenceStatus,
                    Weight = animal.Weight,
                    Sex = animal.Sex,
                    HerdId = animal.Herd?.Id ?? animal.HerdId,
                    BreedId = animal.Breed?.Id ?? animal.BreedId,
                    CategoryType = animal.CategoryType,
                };
            }

            return null;
        }
        
        public static Male ToMaleUpdateDTO(this Animal animal)
        {
            if (animal != null)
            {
                return new Male
                {
                    Id = animal.Id,
                    Name = animal.Name,
                    BirthDate = animal.BirthDate,
                    Origin = animal.Origin,
                    Number = animal.Number,
                    FromCalving = animal.FromCalving,
                    DeathDate = animal.DeathDate,
                    Picture = animal.Picture,
                    PresenceStatus = animal.PresenceStatus,
                    Weight = animal.Weight,
                    Sex = animal.Sex,
                    HerdId = animal.Herd?.Id ?? animal.HerdId,
                    BreedId = animal.Breed?.Id ?? animal.BreedId,
                    CategoryType = animal.CategoryType,
                };
            }

            return null;
        }
        
        
        public static YoungAnimal ToYoungAnimalUpdateDTO(this Animal animal)
        {
            if (animal != null)
            {
                return new YoungAnimal
                {
                    Id = animal.Id,
                    Name = animal.Name,
                    BirthDate = animal.BirthDate,
                    Origin = animal.Origin,
                    Number = animal.Number,
                    FromCalving = animal.FromCalving,
                    DeathDate = animal.DeathDate,
                    Picture = animal.Picture,
                    PresenceStatus = animal.PresenceStatus,
                    Weight = animal.Weight,
                    Sex = animal.Sex,
                    HerdId = animal.Herd?.Id ?? animal.HerdId,
                    BreedId = animal.Breed?.Id ?? animal.BreedId,
                    CategoryType = animal.CategoryType,
                };
            }

            return null;
        }
    }
}
