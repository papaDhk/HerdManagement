using System;
using HerdManagement.Domain.Common;
using HerdManagement.Domain.Common.Entities;
using HerdManagement.Domain.Reproduction.Entities;

namespace HerdManagement.Domain.Feeding.Entities
{
    public class AnimalFeeding : Entity<AnimalFeeding>
    {
        public Animal Animal { get; set; }
        public int AnimalId { get; set; }
        public DateTime DateTime { get; set; }
        public Food Food { get; set; }
        public int FoodId { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }
        public int MeasurementUnitId { get; set; }
        public decimal Quantity { get; set; }
        public decimal? Cost { get; set; }
        protected override bool EqualsCore(AnimalFeeding obj)
        {
            return AnimalId == obj.AnimalId && DateTime == obj.DateTime;
        }

        protected override int GetHashCodeCore()
        {
            return AnimalId.GetHashCode() ^ DateTime.GetHashCode();
        }
    }
}