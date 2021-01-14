using HerdManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public static void AttachGraphWithoutDuplicates(this DbContext dbContext, object entity)
        {
            Action<EntityEntryGraphNode> CheckState = (EntityEntryGraphNode entityNode) =>
            {

                try
                {
                    if (entityNode.Entry.IsKeySet)
                    {
                        entityNode.Entry.State = EntityState.Modified;
                    }
                    else
                    {
                        entityNode.Entry.State = EntityState.Added;
                    }
                }
                catch (InvalidOperationException)
                {
                    //TODO this is a general exeption. Find another way to no track already tracked entities with same Id
                }
            };

            dbContext.ChangeTracker.TrackGraph(entity, e => CheckState(e));
            
        }
        
        public static void AttachGraphForAdditionWithoutDuplicates(this DbContext dbContext, object entity)
        {
            Action<EntityEntryGraphNode> CheckState = (EntityEntryGraphNode entityNode) =>
            {

                try
                {
                    if (entityNode.Entry.IsKeySet == false)
                    {
                        entityNode.Entry.State = EntityState.Added;
                    }
                    else
                    {
                        entityNode.Entry.State = EntityState.Unchanged;
                    }
                }
                catch (InvalidOperationException)
                {
                    //TODO this is a general exeption. Find another way to no track already tracked entities with same Id
                }
            };

            dbContext.ChangeTracker.TrackGraph(entity, e => CheckState(e));
            
        }
    }
}