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
        private readonly AnimalDbContext _animalDbContext;
        
        public MeasurementUnitRepositoryEF(AnimalDbContext animalDbContext)
        {
            _animalDbContext = animalDbContext ?? throw new ArgumentNullException(nameof(animalDbContext));
            _animalDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// Create a measurementUnit
        /// </summary>
        /// <param name="measurementUnit"></param>
        /// <returns></returns>
        public async Task<MeasurementUnit> CreateMeasurementUnit(MeasurementUnit measurementUnit)
        {
            var createdMeasurementUnitEntry = await _animalDbContext.MeasurementUnits.AddAsync(measurementUnit);
            
            await _animalDbContext.SaveChangesAsync();

            _animalDbContext.UntrackEntities();
            
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
           return _animalDbContext.MeasurementUnits.FirstOrDefault(m => m.Id == id);
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
                : _animalDbContext.MeasurementUnits.FirstOrDefault(m => m.Label == label);
        }

        /// <summary>
        /// Get all measurementUnits
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MeasurementUnit>> GetAllMeasurementUnits()
        {
            return _animalDbContext.MeasurementUnits.Select(m => m);
        }
        
        //TODO

        /// <summary>
        /// Get all measurementUnits
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MeasurementUnit> GetMeasurementUnitsByCategory(MeasurementUnitCategory measurementUnitCategory)
        {
            return _animalDbContext.MeasurementUnits.Where(m => m.Category == measurementUnitCategory);
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

            _animalDbContext.MeasurementUnits.Update(measurementUnit);

            await _animalDbContext.SaveChangesAsync();
            
            _animalDbContext.UntrackEntities();

            return 1;
        }
    }
}
