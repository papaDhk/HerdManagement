using System;
using System.Linq;
using HerdManagement.Domain.SpecieBreed.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using HerdManagement.Domain.SpecieBreed.Repository;
using HerdManagement.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class SpecieRepositoryEF : ISpecieRepository
    {
        private readonly HerdManagementDbContext _herdManagementDbContext;
        public SpecieRepositoryEF(HerdManagementDbContext animalDbContext)
        {
            _herdManagementDbContext = animalDbContext ?? throw new ArgumentNullException(nameof(animalDbContext));
            _herdManagementDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;        }

        /// <summary>
        /// Create a specie
        /// </summary>
        /// <param name="specie"></param>
        /// <returns></returns>
        public async Task<Specie> CreateSpecie(Specie specie)
        {
            // Specie to be validated
            if (specie == null)
                return null;

            var entry = await _herdManagementDbContext.Species.AddAsync(specie);
            
            await _herdManagementDbContext.SaveChangesAsync();
            
            _herdManagementDbContext.UntrackEntities();

            return entry.Entity;
        }

        /// <summary>
        /// Delete a specie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteSpecie(int id)
        {
            _herdManagementDbContext.Remove(new Specie(){Id = id});

            return await _herdManagementDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get a specie by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Specie> GetSpecieById(int id)
        {
            var specie = await _herdManagementDbContext.Species.FirstOrDefaultAsync(s => s.Id == id);
            _herdManagementDbContext.UntrackEntities();
            return specie;
        }

        /// <summary>
        /// Get a specie by its label
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public async Task<Specie> GetSpecieByLabel(string label)
        {
            var specie = await _herdManagementDbContext.Species.FirstOrDefaultAsync(s => s.Label == label);
            _herdManagementDbContext.UntrackEntities();
            return specie;
        }

        /// <summary>
        /// Get all species
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Specie>> GetAllSpecies()
        {
            var species = _herdManagementDbContext.Species.Select(s => s);
            _herdManagementDbContext.UntrackEntities();
            return Task.FromResult<IEnumerable<Specie>>(species);
        }


        /// <summary>
        /// Update a specie
        /// </summary>
        /// <param name="specie"></param>
        /// <returns></returns>
        public async Task<int> UpdateSpecie(Specie specie)
        {
            _herdManagementDbContext.Species.Update(specie);

            var result = await _herdManagementDbContext.SaveChangesAsync();
            
            _herdManagementDbContext.UntrackEntities();

            return result;
        }
    }
}
