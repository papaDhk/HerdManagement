using HerdManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerdManagement.Domain.SpecieBreed.Entities
{
    public class Specie : Entity<Specie>
    {
        public string Label { get; set; }

        public TimeSpan ChildhoodDuration { get; set; }

        public int ChildhoodDurationInDays 
        {
            get { return ChildhoodDuration.Days; }
            set { ChildhoodDuration = new TimeSpan(value, 0, 0, 0); }
        }

        public TimeSpan PregnancyDuration { get; set; }

        public int PregnancyDurationInDays
        {
            get { return PregnancyDuration.Days; }
            set { PregnancyDuration = new TimeSpan(value, 0, 0, 0); }
        }

        public TimeSpan MinimumTimeSpanBetweenCalvingAndHeat { get; set; }

        public int MinimumTimeSpanBetweenCalvingAndHeatInDays
        {
            get { return MinimumTimeSpanBetweenCalvingAndHeat.Days; }
            set { MinimumTimeSpanBetweenCalvingAndHeat = new TimeSpan(value, 0, 0, 0); }
        }

        protected override bool EqualsCore(Specie specieToCompareWith)
        {
            return Id == specieToCompareWith.Id;
        }

        protected override int GetHashCodeCore()
        {
            return Id.GetHashCode() ^ Label.GetHashCode();
        }
    }
}
