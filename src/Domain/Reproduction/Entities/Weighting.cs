using HerdManagement.Domain.Common;
using HerdManagement.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerdManagement.Domain.Reproduction.Entities
{
    public class Weighting : Entity<Weighting>
    {
        protected override bool EqualsCore(Weighting obj)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }

        public int AnimalId { get; set; }

        public MeasurementUnit MeasurementUnit { get; set; }

        public int MeasurementUnitId { get; set; }

        public DateTime DateTime { get; set; }
    }
}
