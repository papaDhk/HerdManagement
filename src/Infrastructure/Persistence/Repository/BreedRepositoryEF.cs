using System;
using HerdManagement.Domain.SpecieBreed.Entities;
using HerdManagement.Domain.SpecieBreed.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerdManagement.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class BreedRepositoryEf : IBreedRepository
    {
        private readonly HerdManagementDbContext _herdManagementDbContext;

        public BreedRepositoryEf(HerdManagementDbContext animalDbContext)
        {
            _herdManagementDbContext = animalDbContext ?? throw new ArgumentNullException(nameof(animalDbContext));
            _herdManagementDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;        
        }

        public async Task<Breed> CreateBreed(Breed breed)
        {
            if (breed is null)
                return null;

            //Avoid inserting specie. Entity framework. Dirty should use a correct DTO mapping
            breed.Specie = null;
            
            var entry = await _herdManagementDbContext.Breeds.AddAsync(breed); 
            
            await _herdManagementDbContext.SaveChangesAsync();

            _herdManagementDbContext.UntrackEntities();
            return entry.Entity;
        }

        public async Task<int> DeleteBreed(int breedId)
        {
            _herdManagementDbContext.Breeds.Remove(new Breed { Id = breedId });

            return await _herdManagementDbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Breed>> GetAllBreeds()
        {
            var results = await _herdManagementDbContext.Breeds
                                .Include(b => b.Specie)
                                .Select(breed => breed).ToArrayAsync();
            
            _herdManagementDbContext.UntrackEntities();
            return results;
        }


        public async Task<Breed> GetBreedById(int id)
        {
            var breed = await _herdManagementDbContext.Breeds
                .Where(x => x.Id == id)
                .Include(b => b.Specie)
                .Select(breed => breed).FirstOrDefaultAsync();
            
            _herdManagementDbContext.UntrackEntities();
            return breed;
        }


        public async Task<IEnumerable<Breed>> GetBreedByLabel(string label)
        {
            var results = await _herdManagementDbContext.Breeds
                .Where(b => b.Label == label)
                .Include(b => b.Specie)
                .Select(breed => breed).ToArrayAsync();
            
            _herdManagementDbContext.UntrackEntities();
            return results;
        }


        public async Task<IEnumerable<Breed>> GetBreedsBySpecie(int specieId)
        {
            var results = await _herdManagementDbContext.Breeds
                .Where(b => b.SpecieId == specieId)
                .Include(b => b.Specie)
                .Select(breed => breed).ToArrayAsync();
            
            _herdManagementDbContext.UntrackEntities();
            return results;
        }


        public async Task<int> UpdateBreed(Breed breed)
        {
            _herdManagementDbContext.Breeds.Update(breed);

            var result = await _herdManagementDbContext.SaveChangesAsync();
            
            _herdManagementDbContext.UntrackEntities();

            return result;
        }
    }
}
