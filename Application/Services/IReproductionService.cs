using HerdManagement.Domain.Reproduction.Entities;
using System;
using System.Threading.Tasks;
using Application.Data.DTO.Reproduction;
using Application.Data.Messages;

namespace Application.Services
{
    public interface IReproductionService
    {
        Task<AddNewAnimalResult> AddNewAnimalAsync(AnimalDTO animalDTO);
        CalvingCreationResult GetOrCreateParentRelationShip(int motherId, int fatherId, DateTime birthDate, DateTime inferredOriginReproductionDate, int childId=0);
        Task<UpdateAnimalResult> UpdateAnimalAsync(Animal animal, int motherId, int fatherId);
        bool CanBeFatherOfAnimalBornIn(int maleId, DateTime birthDate);
        bool CanBeMotherOfAnimalBornIn(int femaleId, DateTime birthDate);
        Task<ReproductionCreationResponse> CreateOrUpdateReproductionAsync(Reproduction reproduction);
        Task<AddNewAnimalResult> AddNewAnimalAsync(Animal animal);
    }
}