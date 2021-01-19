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
        private readonly AnimalDbContext _animalDbContext;
        
        public WeighingRepository(AnimalDbContext animalDbContext)
        {
            _animalDbContext = animalDbContext ?? throw new ArgumentNullException(nameof(animalDbContext));
            _animalDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        public IEnumerable<Weighing> GetWeighingsByAnimalId(int animalId)
        {
            return _animalDbContext.Weighings
                .Where(weighing => weighing.AnimalId == animalId)
                .Include(weighing => weighing.MeasurementUnit);
        }

        public async Task<Weighing> CreateOrUpdateWeighingAsync(Weighing weighing)
        {
            if (weighing is null)
                return null;

            var entityEntry = _animalDbContext.Weighings.Update(weighing);

            await _animalDbContext.SaveChangesAsync();
            
            await entityEntry.Reference(weighing => weighing.MeasurementUnit).LoadAsync();

            _animalDbContext.UntrackEntities();

            return entityEntry.Entity;
        }
    }
}
