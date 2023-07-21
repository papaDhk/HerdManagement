using HerdManagement.Domain.Common.Entities;

namespace Applicattion.Data.DTO.MeasurementUnit
{
    public class MeasurementUnitDTO
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Symbol { get; set; }

        public string Commentary { get; set; }

        public MeasurementUnitCategory MeasurementUnitCategory { get; set; }
    }
}
