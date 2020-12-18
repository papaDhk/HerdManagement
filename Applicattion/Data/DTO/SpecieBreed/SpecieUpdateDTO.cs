using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Applicattion.Data.DTO.SpecieBreed
{
    public class SpecieUpdateDTO
    {
        public string Label { get; set; }

        public int ChildhoodDurationInDays { get; set; }

        public int PregnancyDurationInDays { get; set; }

        public int MinimumTimeSpanBetweenCalvingAndHeatInDays { get; set; }
    }
}
