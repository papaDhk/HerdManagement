using System;
using System.ComponentModel.DataAnnotations;

namespace Applicattion.Data.DTO.SpecieBreed
{
    public class SpecieDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field should not be empty")]
        public string Label { get; set; }

        private TimeSpan ChildhoodDuration { get; set; }

        [Display(Name = "Duree de l'enfance (J)")]
        [Required(ErrorMessage = "Field should not be empty")]
        public int ChildhoodDurationInDays
        {
            get { return ChildhoodDuration.Days; }
            set { ChildhoodDuration = new TimeSpan(value, 0, 0, 0); }
        }

        private TimeSpan PregnancyDuration { get; set; }

        [Display(Name = "Duree de la grossesse (J)")]
        [Required(ErrorMessage = "Field should not be empty")]
        public int PregnancyDurationInDays
        {
            get { return PregnancyDuration.Days; }
            set { PregnancyDuration = new TimeSpan(value, 0, 0, 0); }
        }

        private TimeSpan MinimumTimeSpanBetweenCalvingAndHeat { get; set; }

        [Display(Name = "Duree entre velage et insemination (J)")]
        [Required(ErrorMessage = "Field should not be empty")]
        public int MinimumTimeSpanBetweenCalvingAndHeatInDays
        {
            get { return MinimumTimeSpanBetweenCalvingAndHeat.Days; }
            set { MinimumTimeSpanBetweenCalvingAndHeat = new TimeSpan(value, 0, 0, 0); }
        }
    }
}
