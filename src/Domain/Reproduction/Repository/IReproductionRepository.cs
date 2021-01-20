using HerdManagement.Domain.Reproduction.Entities;
using System;
using System.Threading.Tasks;

namespace HerdManagement.Domain.Reproduction.Repository
{
    public interface IReproductionRepository
    {
        Entities.Reproduction GetReproductionByPartnersIdsAndDate(int femaleId, int maleId, DateTime datetime);
        Task<Entities.Reproduction> CreateOrUpdateReproductionAsync(Entities.Reproduction reproduction);
        Task<Calving> CreateOrUpdateCalvingAsync(Calving calving);
        Task DeleteCalving(int calvingId);
        Task DeleteReproduction(int reproductionId);
    }
}