using HerdManagement.Domain.Characteristic.Entities;
using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class HerdManagementDbContext : DbContext
    {
        public HerdManagementDbContext(DbContextOptions<HerdManagementDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Male> Males { get; set; }

        public virtual DbSet<Female> Females { get; set; }

        public virtual DbSet<YoungAnimal> YoungAnimals { get; set; }

        public virtual DbSet<ReproductionState> ReproductionStates { get; set; }

        public virtual DbSet<Reproduction> Reproductions { get; set; }

        public virtual DbSet<Calving> Calvings { get; set; }

        public virtual DbSet<SpecieCharacteristic> SpecieCharacteristics { get; set; }
        public virtual DbSet<BreedCharacteristic> BreedCharacteristics { get; set; }
        public virtual DbSet<SpecieCharacteristicValue> SpecieCharacteristicValues { get; set; }
        public virtual DbSet<BreedCharacteristicValue> BreedCharacteristicValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Female>()
                .HasMany<Calving>(s => s.Calvings)
                .WithOne(ad => ad.Female)
                .HasForeignKey(ad => ad.FemaleId);

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
