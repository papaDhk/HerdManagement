using HerdManagement.Domain.Reproduction.Entities;
using System;
using System.Threading.Tasks;

namespace HerdManagement.Domain.Reproduction.Repository
{
    public interface IReproductionRepository
    {
        Calving GetCalvingByParentsIdsAndDate(int femaleId, int maleId, DateTime datetime);
        Task<Entities.Reproduction> CreateorUpdateReproductionAsync(Entities.Reproduction reproduction);
    }
}