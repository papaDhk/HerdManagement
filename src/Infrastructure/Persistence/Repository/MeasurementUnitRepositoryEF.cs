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
using HerdManagement.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class MeasurementUnitRepositoryEF : IMeasurementUnitRepository
    {
        private readonly HerdManagementDbContext _herdManagementDbContext;
        
        public MeasurementUnitRepositoryEF(HerdManagementDbContext animalDbContext)
        {
            _herdManagementDbContext = animalDbContext ?? throw new ArgumentNullException(nameof(animalDbContext));
            _herdManagementDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// Create a measurementUnit
        /// </summary>
        /// <param name="measurementUnit"></param>
        /// <returns></returns>
        public async Task<MeasurementUnit> CreateMeasurementUnit(MeasurementUnit measurementUnit)
        {
            var createdMeasurementUnitEntry = await _herdManagementDbContext.MeasurementUnits.AddAsync(measurementUnit);
            
            await _herdManagementDbContext.SaveChangesAsync();

            _herdManagementDbContext.UntrackEntities();
            
            return createdMeasurementUnitEntry.Entity;
        }

        /// <summary>
        /// Delete a measurementUnit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteMeasurementUnit(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a measurementUnit by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MeasurementUnit> GetMeasurementUnitById(int id)
        {
           return _herdManagementDbContext.MeasurementUnits.FirstOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// Get a measurementUnit by its label
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public async Task<MeasurementUnit> GetMeasurementUnitByLabel(string label)
        {
            return string.IsNullOrWhiteSpace(label)
                ? null
                : _herdManagementDbContext.MeasurementUnits.FirstOrDefault(m => m.Label == label);
        }

        /// <summary>
        /// Get all measurementUnits
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MeasurementUnit>> GetAllMeasurementUnits()
        {
            return _herdManagementDbContext.MeasurementUnits.Select(m => m);
        }
        
        //TODO

        /// <summary>
        /// Get all measurementUnits
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MeasurementUnit> GetMeasurementUnitsByCategory(MeasurementUnitCategory measurementUnitCategory)
        {
            return _herdManagementDbContext.MeasurementUnits.Where(m => m.Category == measurementUnitCategory);
        }

        /// <summary>
        /// Update a measurementUnit
        /// </summary>
        /// <param name="measurementUnit"></param>
        /// <returns></returns>
        public async Task<int> UpdateMeasurementUnit(MeasurementUnit measurementUnit)
        {
            if (measurementUnit is null)
                return 0;

            _herdManagementDbContext.MeasurementUnits.Update(measurementUnit);

            await _herdManagementDbContext.SaveChangesAsync();
            
            _herdManagementDbContext.UntrackEntities();

            return 1;
        }
    }
}
