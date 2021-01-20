
using HerdManagement.Domain.Common.Entities;
using HerdManagement.Domain.Reproduction.Entities;
using Microsoft.EntityFrameworkCore;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class AnimalDbContext : DbContext
    {
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Male> Males { get; set; }

        public virtual DbSet<Female> Females { get; set; }

        public virtual DbSet<YoungAnimal> YoungAnimals { get; set; }

        public virtual DbSet<ReproductionState> ReproductionStates { get; set; }

        public virtual DbSet<Reproduction> Reproductions { get; set; }

        public virtual DbSet<Calving> Calvings { get; set; }
        
        public virtual DbSet<Weighing> Weighings { get; set; }
        
        public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calving>()
                .HasOne<Animal>(calving => calving.Animal)
                .WithOne(Animal => Animal.FromCalving);

            modelBuilder.Entity<Animal>()
                .HasDiscriminator(a => a.CategoryType)
                .HasValue<Animal>("animal")
                .HasValue<Female>("female")
                .HasValue<Male>("male")
                .HasValue<YoungAnimal>("young_animal");

            modelBuilder.Entity<Animal>()
                .Property(a => a.CategoryType)
                .HasColumnName("category_type");
            
        }

    }
}