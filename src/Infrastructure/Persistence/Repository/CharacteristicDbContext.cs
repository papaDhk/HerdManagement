using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HerdManagement.Domain.Characteristic.Entities;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class CharacteristicDbContext : DbContext
    {
        public CharacteristicDbContext(DbContextOptions<CharacteristicDbContext> options) : base(options)
        {
        }

        public virtual DbSet<SpecieCharacteristic> SpecieCharacteristics { get; set; }
        public virtual DbSet<BreedCharacteristic> BreedCharacteristics { get; set; }
        public virtual DbSet<SpecieCharacteristicValue> SpecieCharacteristicValues { get; set; }
        public virtual DbSet<BreedCharacteristicValue> BreedCharacteristicValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpecieCharacteristicValue>()
                .Property(s => s._SelectedValue).HasColumnName("SelectedValue");

            modelBuilder.Entity<BreedCharacteristicValue>()
                .Property(s => s._SelectedValue).HasColumnName("SelectedValue");

            modelBuilder.Entity<BreedCharacteristic>()
                .Property(s => s._ValueList).HasColumnName("ValueList");

            modelBuilder.Entity<SpecieCharacteristic>()
                .Property(s => s._ValueList).HasColumnName("ValueList");

        }
    }
}
