using HerdManagement.Domain.Common;
using HerdManagement.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerdManagement.Domain.Reproduction.Entities
{
    public class Weighing : Entity<Weighing>
    {
        protected override bool EqualsCore(Weighing obj)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            return AnimalId.GetHashCode() ^ MeasurementUnitId.GetHashCode() ^ DateTime.GetHashCode();
        }

        public int AnimalId { get; set; }
        
        public Animal Animal { get; set; }

        public MeasurementUnit MeasurementUnit { get; set; }

        public int MeasurementUnitId { get; set; }

        public DateTime DateTime { get; set; }

        public int Value { get; set; }
    }
}
