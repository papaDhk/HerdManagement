using HerdManagement.Domain.Common;
using HerdManagement.Domain.SpecieBreed.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using HerdManagement.Domain.Characteristic.Entities;

namespace HerdManagement.Domain.SpecieBreed.Entities
{
    public class Breed : Entity<Breed>
    {
        public string Label { get; set; }

        public Specie Specie { get; set; }
        public int SpecieId { get; set; }

        public List<BreedCharacteristic> BreedCharacteristics { get; set; }

        protected override bool EqualsCore(Breed breedToCompareWith)
        {
            return (Label == breedToCompareWith.Label && Specie == breedToCompareWith.Specie) || Id == breedToCompareWith.Id;
        }

        protected override int GetHashCodeCore()
        {
            return Label.GetHashCode() ^ Specie.GetHashCode();
        }
    }
}
