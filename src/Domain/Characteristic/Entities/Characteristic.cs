using HerdManagement.Domain.Common;
using HerdManagement.Domain.Characteristic.Enumerations;
using System.Collections.Generic;

namespace HerdManagement.Domain.Characteristic.Entities
{
    public class Characteristic : Entity<Characteristic>
    {

        public string Label { get; protected set; }

        public CharacteristicType Type { get; protected set; }

        public string Commentary { get; protected set; }

        protected override bool EqualsCore(Characteristic obj)
        {
            throw new System.NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new System.NotImplementedException();
        }
    }
}
