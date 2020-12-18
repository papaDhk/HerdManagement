using HerdManagement.Domain.Common;
using HerdManagement.Domain.Reproduction.Enumerations;
using HerdManagement.Domain.SpecieBreed.Entities;
using HerdManagement.Domain.SpecieBreed.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerdManagement.Domain.Reproduction.Entities
{
    public abstract class Animal : Entity<Animal>
    {
        public virtual string Name { get; set; }
        public virtual int Number { get; set; }
        public virtual SexEnum Sex { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual byte[] Picture { get; set; }
        public virtual bool Bought { get; set; }
        public virtual uint Weight { get; set; }
        public virtual PresenceStatusEnum PresenceStatus { get; set; }
        public virtual DateTime DeathDate { get; set; }
        public virtual Breed Breed { get; set; }
        public virtual Herd.Entities.Herd Herd { get; set; }
        public virtual string BreedCharacteristics { get; set; }
        public virtual string SpecieCharacteristics { get; set; }

        protected override bool EqualsCore(Animal animalToCompareWith)
        {
            return Id == animalToCompareWith.Id && Number == animalToCompareWith.Number;
        }

        protected override int GetHashCodeCore()
        {
            return Id.GetHashCode() ^ Number.GetHashCode();
        }
    }
}
