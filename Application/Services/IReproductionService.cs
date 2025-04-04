﻿using System;
using System.Threading.Tasks;
using Applicattion.Data.DTO.Reproduction;
using Applicattion.Data.Messages;
using HerdManagement.Domain.Reproduction.Entities;

namespace Applicattion.Services
{
    public interface IReproductionService
    {
        Task<Animal> AddNewAnimalAsync(AnimalDTO animalDTO);
        Calving GetOrCreateParentRelationShip(int motherId, int fatherId, DateTime birthDate, DateTime inferredOriginReproductionDate, int childId=0);
        Task<Animal> UpdateAnimalAsync(Animal animal, int motherId, int fatherId);
        bool CanBeFatherOfAnimalBornIn(int maleId, DateTime birthDate);
        bool CanBeMotherOfAnimalBornIn(int femaleId, DateTime birthDate);
        Task<ReproductionCreationResponse> CreateOrUpdateReproductionAsync(Reproduction reproduction);
        Task<Animal> AddNewAnimalAsync(Animal animal);
    }
}