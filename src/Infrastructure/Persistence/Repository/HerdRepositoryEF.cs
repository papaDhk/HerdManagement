﻿using System;
using HerdManagement.Domain.Herd.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HerdManagement.Domain.SpecieBreed.Repository;
using HerdManagement.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class HerdRepositoryEF : IHerdRepository
    {
        private readonly HerdManagementDbContext _herdManagementDbContext;

        public HerdRepositoryEF(HerdManagementDbContext herdManagementDbContext)
        {
            _herdManagementDbContext = herdManagementDbContext ??
                                       throw new ArgumentNullException(nameof(herdManagementDbContext));
            _herdManagementDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Herd> CreateHerd(Herd herd)
        {
            // Herd to be validated
            if (herd is null)
            {
                return null;
            }
            
            var herdEntry = await _herdManagementDbContext.Herds.AddAsync(herd);

            await herdEntry.Reference(h => h.Specie).LoadAsync();
            
            await _herdManagementDbContext.SaveChangesAsync();
            
            _herdManagementDbContext.UntrackEntities();
            
            return herdEntry.Entity;
        }

        public async Task<int> DeleteHerd(int herdId)
        {
            _herdManagementDbContext.Remove(new Herd{Id = herdId});

            return await _herdManagementDbContext.SaveChangesAsync();
        }

        public Task<Herd> GetHerdById(int id)
        {
            return Task.FromResult(_herdManagementDbContext.Herds.Include(h => h.Specie)
                .FirstOrDefault(h => h.Id == id));
        }

        public Task<IEnumerable<Herd>> GetHerdByName(string name)
        {
            return Task.FromResult<IEnumerable<Herd>>(_herdManagementDbContext.Herds.Where(h => h.Name == name).Include(h => h.Specie));
        }

        public Task<IEnumerable<Herd>> GetAllHerds()
        {
            return Task.FromResult<IEnumerable<Herd>>(_herdManagementDbContext.Herds.Select(h => h).Include(h => h.Specie).ToArray());
        }

        public async Task<int> UpdateHerd(Herd herd)
        {
            if (herd is null)
            {
                return 0;
            }
            _herdManagementDbContext.Herds.Update(herd);

            var result = await _herdManagementDbContext.SaveChangesAsync();
            
            _herdManagementDbContext.UntrackEntities();

            return result;
        }
    }
}
