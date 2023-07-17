using HerdManagement.Domain.Reproduction.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HerdManagement.Domain.Reproduction.Repository
{
    public interface IReproductionRepository
    {
        Entities.Reproduction GetReproductionByPartnersIdsAndDate(int femaleId, int maleId, DateTime datetime);
        Task<IEnumerable<Animal>> GetAnimalTwins(int animalId);
        Task<IEnumerable<Animal>> GetProgeny(int animalId);

        Task<Entities.Reproduction> CreateOrUpdateReproductionAsync(Entities.Reproduction reproduction);
        Task<Calving> CreateOrUpdateCalvingAsync(Calving calving);
        Task DeleteCalving(int calvingId);
        Task DeleteReproduction(int reproductionId);
    }
}