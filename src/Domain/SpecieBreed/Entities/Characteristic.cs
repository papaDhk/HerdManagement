using HerdManagement.Domain.Common;
using HerdManagement.Domain.Common.Entities;
using HerdManagement.Domain.SpecieBreed.Enumerations;
using System.Collections.Generic;

namespace HerdManagement.Domain.SpecieBreed.ValueObjects
{
    public abstract class Characteristic : Entity<Characteristic>
    {
        public CharacteristicValueTypeEnum valueType { get; protected set; }

        public string Label { get; protected set; }

        public MeasurementUnit ValueUnit { get; protected set; }

        public string Commentary { get; protected set; }

    }
}
