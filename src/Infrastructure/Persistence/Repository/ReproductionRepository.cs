using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.Repository;
using HerdManagement.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class ReproductionRepository : IReproductionRepository
    {
        private readonly AnimalDbContext _animalDbContext;

        public ReproductionRepository(AnimalDbContext animalDbContext)
        {
            _animalDbContext = animalDbContext ?? throw new ArgumentNullException(nameof(animalDbContext));
            _animalDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
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
    }
}
