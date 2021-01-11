using HerdManagement.Domain.Reproduction.Entities;
using System;
using System.Threading.Tasks;

namespace HerdManagement.Domain.Reproduction.Repository
{
    public interface IReproductionRepository
    {
        Entities.Reproduction GetReproductionByPartnersIdsAndDate(int femaleId, int maleId, DateTime datetime);
        Task<Entities.Reproduction> CreateorUpdateReproductionAsync(Entities.Reproduction reproduction);
        Task<Calving> CreateorUpdateCalvingAsync(Calving calving);
    }
}