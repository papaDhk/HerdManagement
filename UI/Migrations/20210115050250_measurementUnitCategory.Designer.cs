﻿// <auto-generated />
using System;
using HerdManagement.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace UI.Migrations
{
    [DbContext(typeof(AnimalDbContext))]
    [Migration("20210115050250_measurementUnitCategory")]
    partial class measurementUnitCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HerdManagement.Domain.Common.Entities.MeasurementUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Commentary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MeasurementUnit");
                });

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

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BreedCharacteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BreedId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("category_type");

                    b.Property<DateTime>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HerdId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Origin")
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

                    b.ToTable("Animals");

                    b.HasDiscriminator<string>("CategoryType").HasValue("animal");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Calving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("Commentary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FemaleId")
                        .HasColumnType("int");

                    b.Property<int>("MaleId")
                        .HasColumnType("int");

                    b.Property<int>("ReproductionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId")
                        .IsUnique();

                    b.HasIndex("FemaleId");

                    b.HasIndex("ReproductionId");

                    b.ToTable("Calvings");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Reproduction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Commentary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FemaleId")
                        .HasColumnType("int");

                    b.Property<int>("MaleId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FemaleId");

                    b.HasIndex("MaleId");

                    b.ToTable("Reproductions");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.ReproductionState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReproductionId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReproductionId");

                    b.ToTable("ReproductionStates");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Weighing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MeasurementUnitId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("MeasurementUnitId");

                    b.ToTable("Weighings");
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

                    b.Property<int>("ChildhoodDurationInDays")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinimumTimeSpanBetweenCalvingAndHeatInDays")
                        .HasColumnType("int");

                    b.Property<int>("PregnancyDurationInDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Specie");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Female", b =>
                {
                    b.HasBaseType("HerdManagement.Domain.Reproduction.Entities.Animal");

                    b.HasDiscriminator().HasValue("female");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Male", b =>
                {
                    b.HasBaseType("HerdManagement.Domain.Reproduction.Entities.Animal");

                    b.HasDiscriminator().HasValue("male");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.YoungAnimal", b =>
                {
                    b.HasBaseType("HerdManagement.Domain.Reproduction.Entities.Animal");

                    b.HasDiscriminator().HasValue("young_animal");
                });

            modelBuilder.Entity("HerdManagement.Domain.Herd.Entities.Herd", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Specie", "Specie")
                        .WithMany()
                        .HasForeignKey("SpecieId");

                    b.Navigation("Specie");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Animal", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HerdManagement.Domain.Herd.Entities.Herd", "Herd")
                        .WithMany()
                        .HasForeignKey("HerdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breed");

                    b.Navigation("Herd");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Calving", b =>
                {
                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Animal", "Animal")
                        .WithOne("FromCalving")
                        .HasForeignKey("HerdManagement.Domain.Reproduction.Entities.Calving", "AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Female", null)
                        .WithMany("Calvings")
                        .HasForeignKey("FemaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Reproduction", "Reproduction")
                        .WithMany("Calvings")
                        .HasForeignKey("ReproductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Reproduction");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Reproduction", b =>
                {
                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Female", "Female")
                        .WithMany("Reproductions")
                        .HasForeignKey("FemaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Male", "Male")
                        .WithMany("Reproductions")
                        .HasForeignKey("MaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Female");

                    b.Navigation("Male");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.ReproductionState", b =>
                {
                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Reproduction", null)
                        .WithMany("States")
                        .HasForeignKey("ReproductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Weighing", b =>
                {
                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HerdManagement.Domain.Common.Entities.MeasurementUnit", "MeasurementUnit")
                        .WithMany()
                        .HasForeignKey("MeasurementUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("MeasurementUnit");
                });

            modelBuilder.Entity("HerdManagement.Domain.SpecieBreed.Entities.Breed", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Specie", "Specie")
                        .WithMany()
                        .HasForeignKey("SpecieId");

                    b.Navigation("Specie");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Animal", b =>
                {
                    b.Navigation("FromCalving");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Reproduction", b =>
                {
                    b.Navigation("Calvings");

                    b.Navigation("States");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Female", b =>
                {
                    b.Navigation("Calvings");

                    b.Navigation("Reproductions");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Male", b =>
                {
                    b.Navigation("Reproductions");
                });
#pragma warning restore 612, 618
        }
    }
}
