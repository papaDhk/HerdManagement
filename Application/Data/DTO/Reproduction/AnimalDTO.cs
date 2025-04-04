﻿using System;
using System.ComponentModel.DataAnnotations;
using Applicattion.Data.DTO.Herd;
using Applicattion.Data.DTO.SpecieBreed;
using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.Enumerations;

namespace Applicattion.Data.DTO.Reproduction
{
    public class AnimalDTO
    {
        public int Id { get; set; }
        
        private BreedDTO _breedDto;
        
        private HerdDTO _herdDto;
        
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
            get => _breedDto ?? new BreedDTO{Id = BreedId};

            set => _breedDto = value;
        }

        [Required]
        public int BreedId { get; set; }

        public HerdDTO Herd
        {
            get => _herdDto ?? new HerdDTO{Id = HerdId};

            set => _herdDto = value;
        }
        
        
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

        public string CategoryType { get; set; }
    }
}
