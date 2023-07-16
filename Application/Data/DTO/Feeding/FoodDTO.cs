using HerdManagement.Domain.Common.Entities;

namespace Application.Data.DTO.Feeding;

public class FoodDTO
{
    public int Id { get; set; }
    public string Label { get; set; }
    public string Description { get; set; }
    public MeasurementUnitCategory MeasurementUnitCategory { get; set; }
}