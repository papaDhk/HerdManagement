using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HerdManagement.Domain.Common.Entities
{
    public class MeasurementUnit : Entity<MeasurementUnit>
    {
        public string Label { get; set; }

        public string Symbol { get; set; }

        public string Commentary { get; set; }

        public MeasurementUnitCategory Category { get; set; }
        protected override bool EqualsCore(MeasurementUnit obj)
        {
            return Label == obj.Label || Symbol == obj.Symbol;
        }

        protected override int GetHashCodeCore()
        {
            return Label.GetHashCode() ^ Symbol.GetHashCode();
        }
        
        public override string ToString()
        {
            return $"{Label}({Symbol})";
        }

    }

    public enum MeasurementUnitCategory
    {
        [Display(Name = "Longueur")]
        Length,
        [Display(Name = "Masse")]
        Mass,
        [Display(Name = "Superficie")]
        Area,
        [Display(Name = "Volume")]
        Volume
    }
}
