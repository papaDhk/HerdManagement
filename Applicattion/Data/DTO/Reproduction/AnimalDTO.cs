using Applicattion.Data.DTO.Herd;
using Applicattion.Data.DTO.SpecieBreed;
using HerdManagement.Domain.Reproduction.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Applicattion.Data.DTO.Reproduction
{
    public class AnimalDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public byte[] Picture { get; set; }

        [Required]
        public bool Bought { get; set; }

        public uint Weight { get; set; }

        public PresenceStatusEnum PresenceStatus { get; set; }

        [Required]
        public SexEnum Sex { get; set; }

        public DateTime DeathDate { get; set; }

        public BreedDTO Breed
        {
            get
            {
                return new BreedDTO { Id = BreedId};
            }
        }

        [Required]
        public int BreedId { get; set; }

        public HerdDTO Herd { get; set; }
        
        [Required]
        public int HerdId;

        public int AgeInDays => DateTime.UtcNow.Subtract(BirthDate).Days;
        
    }
}
