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
        private AnimalDbContext _animalDbContext;

        public ReproductionRepository(AnimalDbContext animalDbContext)
        {
            _animalDbContext = animalDbContext ?? throw new ArgumentNullException(nameof(animalDbContext));
            _animalDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public Calving GetCalvingByParentsIdsdAndDate(int femaleId, int maleId, DateTime datetime)
        {
            var calving = _animalDbContext.Calvings
                .Select(calving => calving)
                .Where(calving => calving.Reproduction.FemaleId == femaleId && calving.Reproduction.MaleId == maleId && calving.Date.Date == datetime.Date)
                .Include(calving => calving.Reproduction).FirstOrDefault();

            _animalDbContext.UntrackEntities();

            return calving;
        }

    }
}
