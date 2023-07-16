using System.Collections.Generic;
using System.Threading.Tasks;
using HerdManagement.Domain.Feeding.Entities;

namespace HerdManagement.Domain.Feeding.Repository
{
    public interface IAnimalFeedingRepository
    {
        IEnumerable<AnimalFeeding> GetFeedingsByAnimalId(int animalId);
        Task<AnimalFeeding> CreateOrUpdateAnimalFeedingAsync(AnimalFeeding feeding);
        Task DeleteAnimalFeeding(int id);
    }
}