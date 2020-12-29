using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HerdManagement.Domain.Characteristic.Entities;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    class CharacteristicDbContext : DbContext
    {
        public virtual DbSet<SpecieCharacteristic> SpecieCharacteristics { get; set; }
        public virtual DbSet<BreedCharacteristic> BreedCharacteristics { get; set; }
        public virtual DbSet<SpecieCharacteristicValue> SpecieCharacteristicValues { get; set; }
        public virtual DbSet<BreedCharacteristicValue> BreedCharacteristicValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpecieCharacteristicValue>()
                .Property(s => s._Value).HasColumnName("Value");

            modelBuilder.Entity<BreedCharacteristicValue>()
                .Property(s => s._Value).HasColumnName("Value");
        }
    }
}
