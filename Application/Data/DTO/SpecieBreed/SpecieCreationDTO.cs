﻿namespace Applicattion.Data.DTO.SpecieBreed
{
    public class SpecieCreationDTO
    {
        public string Label { get; set; }

        public int ChildhoodDurationInDays { get; set; }

        public int PregnancyDurationInDays { get; set; }

        public int MinimumTimeSpanBetweenCalvingAndHeatInDays { get; set; }
    }
}
