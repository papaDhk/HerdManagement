using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.Repository;
using HerdManagement.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class ReproductionRepositoryEF : IReproductionRepository
    {
        private readonly HerdManagementDbContext _animalDbContext;

        public ReproductionRepositoryEF(HerdManagementDbContext animalDbContext)
        {
            _animalDbContext = animalDbContext ?? throw new ArgumentNullException(nameof(animalDbContext));
            _animalDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<IEnumerable<Animal>> GetAnimalTwins(int animalId)
        {
            var twins = await _animalDbContext.Animals.Where(a => a.Id == animalId)
                .Include(a => a.FromCalving)
                .ThenInclude(c => c.Reproduction)
                .ThenInclude(r => r.Calvings)
                .ThenInclude(c => c.Animal)
                .SelectMany(a => a.FromCalving.Reproduction.Calvings)
                    .Where( c => c.AnimalId != animalId)
                    .Select(c => c.Animal).ToListAsync();
            
            _animalDbContext.UntrackEntities();

            return twins;
        }

        public Task<IEnumerable<Animal>> GetProgeny(int animalId)
        {
            return Task.FromResult<IEnumerable<Animal>>(_animalDbContext.Reproductions.Where(r => r.FemaleId == animalId || r.MaleId == animalId)
                .Include(r => r.Calvings)
                .ThenInclude(c => c.Animal)
                .SelectMany(r => r.Calvings.Select(c => c.Animal)).ToList());
        }

        public async Task<Reproduction> CreateOrUpdateReproductionAsync(Reproduction reproduction)
        {
            if(reproduction is null)
            {
                return null;
            }

            _animalDbContext.AttachGraphWithoutDuplicates(reproduction);

            await _animalDbContext.SaveChangesAsync();

            _animalDbContext.UntrackEntities();

            return reproduction;
        }

        public Reproduction GetReproductionByPartnersIdsAndDate(int femaleId, int maleId, DateTime datetime)
        {
            var reproduction = _animalDbContext.Reproductions
                .Select(reproduction => reproduction)
                .Include(reproduction => reproduction.Calvings)
                .FirstOrDefault(reproduction => reproduction.FemaleId == femaleId && reproduction.MaleId == maleId &&
                                                reproduction.Date >= datetime.Date.AddDays(-10) &&
                                                reproduction.Date <= datetime.Date.AddDays(10));


            _animalDbContext.UntrackEntities();

            return reproduction;
        }

        public async Task<Calving> CreateOrUpdateCalvingAsync(Calving calving)
        {
            if (calving is null)
            {
                return null;
            }

            _animalDbContext.Update(calving);

            await _animalDbContext.SaveChangesAsync();

            await _animalDbContext.Entry(calving).Reference(r => r.Animal).LoadAsync();
            await _animalDbContext.Entry(calving.Animal).Reference(a => a.Breed).LoadAsync();
            await _animalDbContext.Entry(calving.Animal).Reference(a => a.Herd).LoadAsync();
            await _animalDbContext.Entry(calving.Animal.Breed).Reference(b => b.Specie).LoadAsync();

            _animalDbContext.UntrackEntities();

            return calving;
        }

        public async Task DeleteCalving(int calvingId)
        {
            if (calvingId == 0)
            {
                return;
            }
            
            _animalDbContext.Remove(new Calving{Id = calvingId});

            await _animalDbContext.SaveChangesAsync();
        }
        
        public async Task DeleteReproduction(int reproductionId)
        {
            if (reproductionId == 0)
            {
                return;
            }
            
            _animalDbContext.Remove(new Reproduction{Id = reproductionId});

            await _animalDbContext.SaveChangesAsync();
        }
    }
}
