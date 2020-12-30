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
        public string _SelectedValue { get; set; }

        public DateTime Date { get; set; }

        [NotMapped]
        public string[] SelectedValue
        {
            get { return _SelectedValue == null ? null : JsonConvert.DeserializeObject<string[]>(_SelectedValue); }
            set { _SelectedValue = JsonConvert.SerializeObject(value); }
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
