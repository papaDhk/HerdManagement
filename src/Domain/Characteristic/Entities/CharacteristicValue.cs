using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerdManagement.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HerdManagement.Domain.Characteristic.Entities
{
    public class CharacteristicValue : Entity<CharacteristicValue>
    {
        public string Label { get; set; }
        public string _Value { get; set; }

        [NotMapped]
        public Data Value
        {
            get { return _Value == null ? null : JsonConvert.DeserializeObject<Data>(_Value); }
            set { _Value = JsonConvert.SerializeObject(value); }
        }

        protected override bool EqualsCore(CharacteristicValue obj)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
