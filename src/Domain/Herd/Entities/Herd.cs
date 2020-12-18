using HerdManagement.Domain.Common;
using HerdManagement.Domain.SpecieBreed.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HerdManagement.Domain.Herd.Entities
{
    public class Herd : Entity<Herd>
    {
        public Herd()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public uint LivingMembersNumber { get; set; }
        public Specie Specie { get; set; }

        protected override bool EqualsCore(Herd herdToCompareWith)
        {
            return Id == herdToCompareWith.Id;
        }

        protected override int GetHashCodeCore()
        {
            return Id.GetHashCode() ^ Name.GetHashCode() ^ Specie.GetHashCode();
        }
    }
}
