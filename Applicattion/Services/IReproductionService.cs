using Applicattion.Data.DTO.Reproduction;
using HerdManagement.Domain.Reproduction.Entities;
using System;
using System.Threading.Tasks;

namespace Applicattion.Services
{
    public interface IReproductionService
    {
        Task<Animal> AddNewAnimalAsync(AnimalDTO animalDTO);
        Calving GetOrCreateParentRelationShip(int motherId, int fatherId, DateTime birthDate);
        Task<Animal> UpdateAnimalAsync(Animal animal, int motherId, int fatherId);
        bool CanBeFatherOfAnimalBornIn(int maleId, DateTime birthDate);
        bool CanBeMotherOfAnimalBornIn(int femaleId, DateTime birthDate);
    }
}