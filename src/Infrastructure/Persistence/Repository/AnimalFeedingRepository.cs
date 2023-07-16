using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerdManagement.Domain.Feeding.Entities;
using HerdManagement.Domain.Feeding.Repository;
using HerdManagement.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class AnimalFeedingRepository : IAnimalFeedingRepository
    {
        private readonly HerdManagementDbContext _herdManagementDbContext;

        public AnimalFeedingRepository(HerdManagementDbContext herdManagementDbContext)
        {
            _herdManagementDbContext = herdManagementDbContext;
            _herdManagementDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IEnumerable<AnimalFeeding> GetFeedingsByAnimalId(int animalId)
        {
            return _herdManagementDbContext.AnimalFeedings
                .Where(feeding => feeding.AnimalId == animalId)
                .Include(feeding => feeding.MeasurementUnit)
                .Include(feeding => feeding.Food);
        }

        public async Task<AnimalFeeding> CreateOrUpdateAnimalFeedingAsync(AnimalFeeding feeding)
        {
            if (feeding is null)
                return null;

            var entityEntry = _herdManagementDbContext.AnimalFeedings.Update(feeding);

            await _herdManagementDbContext.SaveChangesAsync();
            
            await entityEntry.Reference(animalFeeding => animalFeeding.MeasurementUnit).LoadAsync();
            await entityEntry.Reference(animalFeeding => animalFeeding.Food).LoadAsync();

            _herdManagementDbContext.UntrackEntities();

            return entityEntry.Entity;
        }

        public async Task DeleteAnimalFeeding(int id)
        {
            _herdManagementDbContext.Remove(new AnimalFeeding {Id = id});

            await _herdManagementDbContext.SaveChangesAsync();
        }
    }
}