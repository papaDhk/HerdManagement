using HerdManagement.Domain.Common;
using HerdManagement.Domain.Common.Entities;

namespace HerdManagement.Domain.Feeding.Entities
{
    public class Food : Entity<Food>
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public MeasurementUnitCategory MeasurementUnitCategory { get; set; }

        protected override bool EqualsCore(Food foodToCompareWith)
        {
            return (Label == foodToCompareWith.Label ) || Id == foodToCompareWith.Id;
        }

        protected override int GetHashCodeCore()
        {
            return Label.GetHashCode();
        }
    }
}
