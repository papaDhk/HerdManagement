using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerdManagement.Infrastructure.Persistence.Repository
{
    public class AnimalDbContext : DbContext
    {
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Male> Males { get; set; }

        public virtual DbSet<Female> Females { get; set; }

        public virtual DbSet<YoungAnimal> YoungAnimals { get; set; }

        public virtual DbSet<ReproductionState> ReproductionStates { get; set; }

        public virtual DbSet<Reproduction> Reproductions { get; set; }



    }
}
