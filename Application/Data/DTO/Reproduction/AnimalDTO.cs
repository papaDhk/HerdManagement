using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;
using Application.Data.DTO.Herd;
using Application.Data.DTO.SpecieBreed;

namespace Application.Data.DTO.Reproduction
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
        public AnimalOrigin Origin { get; set; }

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

        public Calving FromCalving { get; set; }

        public int AgeInDays => DateTime.UtcNow.Subtract(BirthDate).Days;

        public int FatherId { get; set; }

        public int MotherId { get; set; }

        public override string ToString()
        {
            return $"{Number} - {Name} - {Breed.Label}";
        }
    }
}
