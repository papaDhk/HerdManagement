using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerdManagement.Infrastructure.Persistence.Utils
{
    public static class EfExtensions
    {
        public static void UntrackEntities(this DbContext dbContext)
        {
            foreach (var trackedEntity in dbContext.ChangeTracker.Entries())
            {
                trackedEntity.State = EntityState.Detached;
            }
        }
    }
}
