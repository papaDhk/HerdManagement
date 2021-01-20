using System;
using Dapper;
using HerdManagement.Domain.Common.Entities;
using HerdManagement.Domain.Common.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.Repository;
using HerdManagement.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class WeighingRepository : IWeighingRepository
    {
        private readonly HerdManagementDbContext _herdManagementDbContext;
        
        public WeighingRepository(HerdManagementDbContext animalDbContext)
        {
            _herdManagementDbContext = animalDbContext ?? throw new ArgumentNullException(nameof(animalDbContext));
            _herdManagementDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        public IEnumerable<Weighing> GetWeighingsByAnimalId(int animalId)
        {
            return _herdManagementDbContext.Weighings
                .Where(weighing => weighing.AnimalId == animalId)
                .Include(weighing => weighing.MeasurementUnit);
        }
        
        public async Task<Weighing> GetLatestWeighingByAnimalId(int animalId)
        {
            return await _herdManagementDbContext.Weighings
                .Where(weighing => weighing.AnimalId == animalId).Include(weighing => weighing.MeasurementUnit)
                .OrderByDescending(weighing => weighing.DateTime)
                .FirstOrDefaultAsync();
        }

        public async Task<Weighing> CreateOrUpdateWeighingAsync(Weighing weighing)
        {
            if (weighing is null)
                return null;

            var entityEntry = _herdManagementDbContext.Weighings.Update(weighing);

            await _herdManagementDbContext.SaveChangesAsync();
            
            await entityEntry.Reference(weighing => weighing.MeasurementUnit).LoadAsync();

            _herdManagementDbContext.UntrackEntities();

            return entityEntry.Entity;
        }
        
        public async Task DeleteWeighing(int id)
        {
            _herdManagementDbContext.Remove(new Weighing {Id = id});

            await _herdManagementDbContext.SaveChangesAsync();
        }
    }
}
