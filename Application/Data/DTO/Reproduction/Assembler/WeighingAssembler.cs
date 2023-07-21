using HerdManagement.Domain.Reproduction.Entities;

namespace Applicattion.Data.DTO.Reproduction.Assembler
{
    public static class WeighingAssembler
    {
        public static Weighing ToWeighingUpdateDTO(this Weighing weighing)
        {
            if (weighing != null)
            {
                return new Weighing
                {
                    Id = weighing.Id,
                    Value = weighing.Value,
                    MeasurementUnitId = weighing.MeasurementUnitId,
                    AnimalId = weighing.AnimalId,
                    DateTime = weighing.DateTime
                };
            }

            return null;
        }
    }
}
