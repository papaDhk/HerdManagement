using System.Collections.Generic;
using System.Threading.Tasks;
using HerdManagement.Domain.Feeding.Entities;

namespace HerdManagement.Domain.Feeding.Repository
{
    public interface IFoodRepository
    {
        Task<Food> GetFoodUnitById(int id);
        Task<Food> GetFoodByLabel(string label);
        Task<IEnumerable<Food>> GetAllFoods();
        Task<int> UpdateFood(Food food);
        Task<int> DeleteFood(int foodId);
        Task<Food> CreateFood(Food food);

    }
}