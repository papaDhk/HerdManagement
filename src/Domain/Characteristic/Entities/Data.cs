﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerdManagement.Domain.Characteristic.Enumerations;

namespace HerdManagement.Domain.Characteristic.Entities
{
    public class Data
    {
        public string value { get; set; }
        public string unit { get; set; }
        public CharacteristicType type { get; set; }
    }
}
