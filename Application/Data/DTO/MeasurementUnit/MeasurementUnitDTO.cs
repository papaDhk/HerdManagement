using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Data.DTO.MeasurementUnit
{
    public class MeasurementUnitDTO
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Symbol { get; set; }

        public string Commentary { get; set; }
    }
}
