using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerdManagement.Domain.Feeding.Entities;
using HerdManagement.Domain.Feeding.Repository;
using HerdManagement.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace HerdManagement.Infrastructure.Persistence.Repository;

public class FoodRepositoryEf : IFoodRepository
{
    private readonly HerdManagementDbContext _herdManagementDbContext;

    public FoodRepositoryEf(HerdManagementDbContext herdManagementDbContext)
    {
        _herdManagementDbContext = herdManagementDbContext ?? throw new ArgumentNullException(nameof(herdManagementDbContext));
        _herdManagementDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public Task<Food> GetFoodUnitById(int id)
    {
        return Task.FromResult(_herdManagementDbContext.Foods.FirstOrDefault(m => m.Id == id));
    }

    public Task<Food> GetFoodByLabel(string label)
    {
        return Task.FromResult(string.IsNullOrWhiteSpace(label)
            ? null
            : _herdManagementDbContext.Foods.FirstOrDefault(m => m.Label == label));
        
    }

    public Task<IEnumerable<Food>> GetAllFoods()
    {
        return Task.FromResult<IEnumerable<Food>>(_herdManagementDbContext.Foods.Select(m => m));
    }

    public async Task<int> UpdateFood(Food food)
    {
        if (food is null)
            return 0;

        _herdManagementDbContext.Foods.Update(food);

        await _herdManagementDbContext.SaveChangesAsync();
            
        _herdManagementDbContext.UntrackEntities();

        return 1;
    }

    public async Task<int> DeleteFood(int foodId)
    {
        _herdManagementDbContext.Remove(new Food {Id = foodId});

        await _herdManagementDbContext.SaveChangesAsync();

        return 1;
    }

    public async Task<Food> CreateFood(Food food)
    {
        var createdFoodEntry = await _herdManagementDbContext.Foods.AddAsync(food);
            
        await _herdManagementDbContext.SaveChangesAsync();

        _herdManagementDbContext.UntrackEntities();
            
        return createdFoodEntry.Entity;
    }
}