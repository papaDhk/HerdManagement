﻿using Applicattion.Data.DTO.Herd.Assembler;
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
                    Bought = animalDTO.Bought,
                    Number = animalDTO.Number,
                    DeathDate = animalDTO.DeathDate,
                    Herd = animalDTO.Herd.ToHerd(),
                    Breed = new Breed { Id = animalDTO.BreedId },
                    Picture = animalDTO.Picture,
                    PresenceStatus = animalDTO.PresenceStatus,
                    Weight = animalDTO.Weight
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
                    Bought = animalDTO.Bought,
                    Number = animalDTO.Number,
                    DeathDate = animalDTO.DeathDate,
                    Herd = animalDTO.Herd.ToHerd(),
                    Picture = animalDTO.Picture,
                    PresenceStatus = animalDTO.PresenceStatus,
                    Weight = animalDTO.Weight
                };
            }
            else
            {
                return new Female();
            }
        }

        public static YoungFemale YoungFemale(this AnimalDTO animalDTO)
        {
            if (animalDTO != null)
            {
                return new YoungFemale
                {
                    Name = animalDTO.Name,
                    BirthDate = animalDTO.BirthDate,
                    Bought = animalDTO.Bought,
                    Number = animalDTO.Number,
                    DeathDate = animalDTO.DeathDate,
                    Herd = animalDTO.Herd.ToHerd(),
                    Picture = animalDTO.Picture,
                    PresenceStatus = animalDTO.PresenceStatus,
                    Weight = animalDTO.Weight
                };
            }
            else
            {
                return new YoungFemale();
            }
        }
        
        public static YoungMale YoungMale(this AnimalDTO animalDTO)
        {
            if (animalDTO != null)
            {
                return new YoungMale
                {
                    Name = animalDTO.Name,
                    BirthDate = animalDTO.BirthDate,
                    Bought = animalDTO.Bought,
                    Number = animalDTO.Number,
                    DeathDate = animalDTO.DeathDate,
                    Herd = animalDTO.Herd.ToHerd(),
                    Picture = animalDTO.Picture,
                    PresenceStatus = animalDTO.PresenceStatus,
                    Weight = animalDTO.Weight
                };
            }
            else
            {
                return new YoungMale();
            }
        }
    }
}
