using HerdManagement.Domain.Reproduction.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HerdManagement.Domain.Reproduction.Repository
{
    public interface IWeighingRepository
    {
        IEnumerable<Weighing> GetWeighingsByAnimalId(int animalId);
        Task<Entities.Weighing> CreateOrUpdateWeighingAsync(Weighing weighing);
        Task DeleteWeighing(int id);
        Task<Weighing> GetLatestWeighingByAnimalId(int animalId);
    }
}