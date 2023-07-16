using HerdManagement.Domain.Feeding.Entities;

namespace HerdManagement.Domain.Feeding.Assembler
{
    public static class AnimalFeedingAssembler
    {
        public static AnimalFeeding ToAnimalFeedingUpdateDTO(this AnimalFeeding animalFeeding)
        {
            if (animalFeeding != null)
            {
                return new AnimalFeeding
                {
                    Id = animalFeeding.Id,
                    Cost = animalFeeding.Cost,
                    Quantity = animalFeeding.Quantity,
                    MeasurementUnitId = animalFeeding.MeasurementUnitId,
                    AnimalId = animalFeeding.AnimalId,
                    FoodId = animalFeeding.FoodId,
                    DateTime = animalFeeding.DateTime
                };
            }

            return null;
        }
    }
}