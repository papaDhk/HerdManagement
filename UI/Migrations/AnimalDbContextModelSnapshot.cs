﻿// <auto-generated />
using System;
using HerdManagement.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace UI.Migrations
{
    [DbContext(typeof(AnimalDbContext))]
    partial class AnimalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HerdManagement.Domain.Herd.Entities.Herd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LivingMembersNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecieId");

                    b.ToTable("Herd");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Female", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Bought")
                        .HasColumnType("bit");

                    b.Property<string>("BreedCharacteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BreedId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HerdId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PresenceStatus")
                        .HasColumnType("int");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("SpecieCharacteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Weight")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("HerdId");

                    b.ToTable("Females");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Male", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Bought")
                        .HasColumnType("bit");

                    b.Property<string>("BreedCharacteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BreedId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HerdId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PresenceStatus")
                        .HasColumnType("int");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("SpecieCharacteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Weight")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("HerdId");

                    b.ToTable("males");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.YoungAnimal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Bought")
                        .HasColumnType("bit");

                    b.Property<string>("BreedCharacteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BreedId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HerdId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PresenceStatus")
                        .HasColumnType("int");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("SpecieCharacteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Weight")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("HerdId");

                    b.ToTable("YoungAnimals");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.ValueObjects.Calving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Commentary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FemaleId")
                        .HasColumnType("int");

                    b.Property<long>("NumberOfNewborn")
                        .HasColumnType("bigint");

                    b.Property<int?>("ReproductionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FemaleId");

                    b.HasIndex("ReproductionId");

                    b.ToTable("Calvings");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.ValueObjects.Reproduction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Commentary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FemaleId")
                        .HasColumnType("int");

                    b.Property<int?>("MaleId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FemaleId");

                    b.HasIndex("MaleId");

                    b.ToTable("Reproductions");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.ValueObjects.ReproductionState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReproductionId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReproductionId");

                    b.ToTable("ReproductionStates");
                });

            modelBuilder.Entity("HerdManagement.Domain.SpecieBreed.Entities.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecieId");

                    b.ToTable("Breed");
                });

            modelBuilder.Entity("HerdManagement.Domain.SpecieBreed.Entities.Specie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<TimeSpan>("ChildhoodDuration")
                        .HasColumnType("time");

                    b.Property<int>("ChildhoodDurationInDays")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("MinimumTimeSpanBetweenCalvingAndHeat")
                        .HasColumnType("time");

                    b.Property<int>("MinimumTimeSpanBetweenCalvingAndHeatInDays")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("PregnancyDuration")
                        .HasColumnType("time");

                    b.Property<int>("PregnancyDurationInDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Specie");
                });

            modelBuilder.Entity("HerdManagement.Domain.Herd.Entities.Herd", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Specie", "Specie")
                        .WithMany()
                        .HasForeignKey("SpecieId");

                    b.Navigation("Specie");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Female", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId");

                    b.HasOne("HerdManagement.Domain.Herd.Entities.Herd", "Herd")
                        .WithMany()
                        .HasForeignKey("HerdId");

                    b.Navigation("Breed");

                    b.Navigation("Herd");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Male", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId");

                    b.HasOne("HerdManagement.Domain.Herd.Entities.Herd", "Herd")
                        .WithMany()
                        .HasForeignKey("HerdId");

                    b.Navigation("Breed");

                    b.Navigation("Herd");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.YoungAnimal", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId");

                    b.HasOne("HerdManagement.Domain.Herd.Entities.Herd", "Herd")
                        .WithMany()
                        .HasForeignKey("HerdId");

                    b.Navigation("Breed");

                    b.Navigation("Herd");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.ValueObjects.Calving", b =>
                {
                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Female", null)
                        .WithMany("Calvings")
                        .HasForeignKey("FemaleId");

                    b.HasOne("HerdManagement.Domain.Reproduction.ValueObjects.Reproduction", "Reproduction")
                        .WithMany()
                        .HasForeignKey("ReproductionId");

                    b.Navigation("Reproduction");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.ValueObjects.Reproduction", b =>
                {
                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Female", "Female")
                        .WithMany("reproductions")
                        .HasForeignKey("FemaleId");

                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Male", "Male")
                        .WithMany("reproductions")
                        .HasForeignKey("MaleId");

                    b.Navigation("Female");

                    b.Navigation("Male");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.ValueObjects.ReproductionState", b =>
                {
                    b.HasOne("HerdManagement.Domain.Reproduction.ValueObjects.Reproduction", null)
                        .WithMany("States")
                        .HasForeignKey("ReproductionId");
                });

            modelBuilder.Entity("HerdManagement.Domain.SpecieBreed.Entities.Breed", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Specie", "Specie")
                        .WithMany()
                        .HasForeignKey("SpecieId");

                    b.Navigation("Specie");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Female", b =>
                {
                    b.Navigation("Calvings");

                    b.Navigation("reproductions");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Male", b =>
                {
                    b.Navigation("reproductions");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.ValueObjects.Reproduction", b =>
                {
                    b.Navigation("States");
                });
#pragma warning restore 612, 618
        }
    }
}
