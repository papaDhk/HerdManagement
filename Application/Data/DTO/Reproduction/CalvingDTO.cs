using System;
using System.ComponentModel.DataAnnotations;
using HerdManagement.Domain.Reproduction.Enumerations;

namespace Applicattion.Data.DTO.Reproduction
{
    public class CalvingDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public int BirthWeight { get; set; }

        [Required]
        public string NewBornName { get; set; }

        [Required]
        public int NewBornNumber { get; set; }

        public int NewBornId { get; set; }

        public PresenceStatusEnum PresenceStatus { get; set; } = PresenceStatusEnum.Alive;

        [Required]
        public int BreedId { get; set; }
        public string Commentary { get; set; }
        public int FemaleId { get; set; }
        public int MaleId { get; set; }

        public int HerdId { get; set; }

        public SexEnum Sex { get; set; }

        public int ReproductionId { get; set; }
    }
}
