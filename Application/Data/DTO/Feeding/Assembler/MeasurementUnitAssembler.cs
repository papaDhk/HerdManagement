using System.Collections.Generic;
using System.Linq;
using HerdManagement.Domain.Feeding.Entities;

namespace Applicattion.Data.DTO.Feeding.Assembler
{
    public static class FoodAssembler
    {
        public static FoodDTO ToFoodDTO(this Food food)
        {
            return food != null ?
                    new FoodDTO
                    {
                        Id = food.Id,
                        Label = food.Label,
                        Description = food.Description,
                        MeasurementUnitCategory = food.MeasurementUnitCategory
                    } :
                    null;
        }

        public static Food ToFood(this FoodDTO foodDTO)
        {
            return foodDTO != null ?
                    new Food
                    {
                        Id = foodDTO.Id,
                        Label = foodDTO.Label,
                        Description = foodDTO.Description,
                        MeasurementUnitCategory = foodDTO.MeasurementUnitCategory
                    } :
                    null;
        }

        public static Food ToFood(this FoodUpdateDTO foodUpdateDTO, int id)
        {
            return foodUpdateDTO != null ?
                    new Food
                    {
                        Id = id,
                        Label = foodUpdateDTO.Label,
                        Description = foodUpdateDTO.Description,
                    } :
                    null;
        }

        public static IEnumerable<FoodDTO> ToFoodDTOList(this IEnumerable<Food> foods)
        {
            return foods != null && foods.Any() ?
                   foods.Select(food => food?.ToFoodDTO()) :
                   new List<FoodDTO>();

        }
    }
}
