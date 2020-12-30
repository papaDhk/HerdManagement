using HerdManagement.Domain.Common;
using HerdManagement.Domain.Characteristic.Enumerations;
using System.Collections.Generic;
using HerdManagement.Domain.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HerdManagement.Domain.Characteristic.Entities
{
    public class Characteristic : Entity<Characteristic>
    {

        public string Label { get; protected set; }

        public CharacteristicType Type { get; protected set; }

        public MeasurementUnit Unit { get; set; }

        public string Commentary { get; protected set; }

        public string _ValueList { get; set; }

        [NotMapped]
        public string[] ValueList
        {
            get { return _ValueList == null ? null : JsonConvert.DeserializeObject<string[]>(_ValueList); }
            set { _ValueList = JsonConvert.SerializeObject(value); }
        }

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
