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
    [DbContext(typeof(HerdManagementDbContext))]
    [Migration("20201230212855_charateristic_v1")]
    partial class charateristic_v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HerdManagement.Domain.Characteristic.Entities.BreedCharacteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BreedId")
                        .HasColumnType("int");

                    b.Property<string>("Commentary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.Property<string>("_ValueList")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ValueList");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("UnitId");

                    b.ToTable("BreedCharacteristics");
                });

            modelBuilder.Entity("HerdManagement.Domain.Characteristic.Entities.BreedCharacteristicValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BreedCharacteristicId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FemaleId")
                        .HasColumnType("int");

                    b.Property<int?>("MaleId")
                        .HasColumnType("int");

                    b.Property<int?>("YoungAnimalId")
                        .HasColumnType("int");

                    b.Property<string>("_SelectedValue")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SelectedValue");

                    b.HasKey("Id");

                    b.HasIndex("BreedCharacteristicId");

                    b.HasIndex("FemaleId");

                    b.HasIndex("MaleId");

                    b.HasIndex("YoungAnimalId");

                    b.ToTable("BreedCharacteristicValues");
                });

            modelBuilder.Entity("HerdManagement.Domain.Characteristic.Entities.SpecieCharacteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Commentary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecieId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.Property<string>("_ValueList")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ValueList");

                    b.HasKey("Id");

                    b.HasIndex("SpecieId");

                    b.HasIndex("UnitId");

                    b.ToTable("SpecieCharacteristics");
                });

            modelBuilder.Entity("HerdManagement.Domain.Characteristic.Entities.SpecieCharacteristicValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FemaleId")
                        .HasColumnType("int");

                    b.Property<int?>("MaleId")
                        .HasColumnType("int");

                    b.Property<int>("SpecieCharacteristicId")
                        .HasColumnType("int");

                    b.Property<int?>("YoungAnimalId")
                        .HasColumnType("int");

                    b.Property<string>("_SelectedValue")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SelectedValue");

                    b.HasKey("Id");

                    b.HasIndex("FemaleId");

                    b.HasIndex("MaleId");

                    b.HasIndex("SpecieCharacteristicId");

                    b.HasIndex("YoungAnimalId");

                    b.ToTable("SpecieCharacteristicValues");
                });

            modelBuilder.Entity("HerdManagement.Domain.Common.Entities.MeasurementUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Calving", b =>
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

                    b.Property<long>("NumberOfNewborn")
                        .HasColumnType("bigint");

                    b.Property<int>("ReproductionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FemaleId");

                    b.HasIndex("ReproductionId")
                        .IsUnique();

                    b.ToTable("Calvings");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Female", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BreedCharacteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BreedId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FromCalvingId")
                        .HasColumnType("int");

                    b.Property<int?>("FromCalvingId1")
                        .HasColumnType("int");

                    b.Property<int?>("HerdId")
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

                    b.HasIndex("FromCalvingId1");

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

                    b.Property<string>("BreedCharacteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BreedId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FromCalvingId")
                        .HasColumnType("int");

                    b.Property<int?>("FromCalvingId1")
                        .HasColumnType("int");

                    b.Property<int?>("HerdId")
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

                    b.HasIndex("FromCalvingId1");

                    b.HasIndex("HerdId");

                    b.ToTable("males");
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

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.YoungAnimal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BreedCharacteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BreedId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FromCalvingId")
                        .HasColumnType("int");

                    b.Property<int?>("HerdId")
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

                    b.HasIndex("FromCalvingId");

                    b.HasIndex("HerdId");

                    b.ToTable("YoungAnimals");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.ValueObjects.ReproductionState", b =>
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

            modelBuilder.Entity("HerdManagement.Domain.Characteristic.Entities.BreedCharacteristic", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Breed", null)
                        .WithMany("BreedCharacteristics")
                        .HasForeignKey("BreedId");

                    b.HasOne("HerdManagement.Domain.Common.Entities.MeasurementUnit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("HerdManagement.Domain.Characteristic.Entities.BreedCharacteristicValue", b =>
                {
                    b.HasOne("HerdManagement.Domain.Characteristic.Entities.BreedCharacteristic", null)
                        .WithMany("BreedCharacteristicValues")
                        .HasForeignKey("BreedCharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Female", null)
                        .WithMany("BreedCharacteristicValues")
                        .HasForeignKey("FemaleId");

                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Male", null)
                        .WithMany("BreedCharacteristicValues")
                        .HasForeignKey("MaleId");

                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.YoungAnimal", null)
                        .WithMany("BreedCharacteristicValues")
                        .HasForeignKey("YoungAnimalId");
                });

            modelBuilder.Entity("HerdManagement.Domain.Characteristic.Entities.SpecieCharacteristic", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Specie", null)
                        .WithMany("Characteristics")
                        .HasForeignKey("SpecieId");

                    b.HasOne("HerdManagement.Domain.Common.Entities.MeasurementUnit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("HerdManagement.Domain.Characteristic.Entities.SpecieCharacteristicValue", b =>
                {
                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Female", null)
                        .WithMany("SpecieCharacteristicValues")
                        .HasForeignKey("FemaleId");

                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Male", null)
                        .WithMany("SpecieCharacteristicValues")
                        .HasForeignKey("MaleId");

                    b.HasOne("HerdManagement.Domain.Characteristic.Entities.SpecieCharacteristic", null)
                        .WithMany("SpecieCharacteristicValues")
                        .HasForeignKey("SpecieCharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.YoungAnimal", null)
                        .WithMany("SpecieCharacteristicValues")
                        .HasForeignKey("YoungAnimalId");
                });

            modelBuilder.Entity("HerdManagement.Domain.Herd.Entities.Herd", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Specie", "Specie")
                        .WithMany()
                        .HasForeignKey("SpecieId");

                    b.Navigation("Specie");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Calving", b =>
                {
                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Female", "Female")
                        .WithMany("Calvings")
                        .HasForeignKey("FemaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Reproduction", "Reproduction")
                        .WithOne("Calving")
                        .HasForeignKey("HerdManagement.Domain.Reproduction.Entities.Calving", "ReproductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Female");

                    b.Navigation("Reproduction");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Female", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId");

                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Calving", "FromCalving")
                        .WithMany()
                        .HasForeignKey("FromCalvingId1");

                    b.HasOne("HerdManagement.Domain.Herd.Entities.Herd", "Herd")
                        .WithMany()
                        .HasForeignKey("HerdId");

                    b.Navigation("Breed");

                    b.Navigation("FromCalving");

                    b.Navigation("Herd");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Male", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId");

                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Calving", "FromCalving")
                        .WithMany()
                        .HasForeignKey("FromCalvingId1");

                    b.HasOne("HerdManagement.Domain.Herd.Entities.Herd", "Herd")
                        .WithMany()
                        .HasForeignKey("HerdId");

                    b.Navigation("Breed");

                    b.Navigation("FromCalving");

                    b.Navigation("Herd");
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

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.YoungAnimal", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId");

                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Calving", "FromCalving")
                        .WithMany("YoungAnimals")
                        .HasForeignKey("FromCalvingId");

                    b.HasOne("HerdManagement.Domain.Herd.Entities.Herd", "Herd")
                        .WithMany()
                        .HasForeignKey("HerdId");

                    b.Navigation("Breed");

                    b.Navigation("FromCalving");

                    b.Navigation("Herd");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.ValueObjects.ReproductionState", b =>
                {
                    b.HasOne("HerdManagement.Domain.Reproduction.Entities.Reproduction", null)
                        .WithMany("States")
                        .HasForeignKey("ReproductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HerdManagement.Domain.SpecieBreed.Entities.Breed", b =>
                {
                    b.HasOne("HerdManagement.Domain.SpecieBreed.Entities.Specie", "Specie")
                        .WithMany()
                        .HasForeignKey("SpecieId");

                    b.Navigation("Specie");
                });

            modelBuilder.Entity("HerdManagement.Domain.Characteristic.Entities.BreedCharacteristic", b =>
                {
                    b.Navigation("BreedCharacteristicValues");
                });

            modelBuilder.Entity("HerdManagement.Domain.Characteristic.Entities.SpecieCharacteristic", b =>
                {
                    b.Navigation("SpecieCharacteristicValues");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Calving", b =>
                {
                    b.Navigation("YoungAnimals");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Female", b =>
                {
                    b.Navigation("BreedCharacteristicValues");

                    b.Navigation("Calvings");

                    b.Navigation("Reproductions");

                    b.Navigation("SpecieCharacteristicValues");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Male", b =>
                {
                    b.Navigation("BreedCharacteristicValues");

                    b.Navigation("Reproductions");

                    b.Navigation("SpecieCharacteristicValues");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.Reproduction", b =>
                {
                    b.Navigation("Calving");

                    b.Navigation("States");
                });

            modelBuilder.Entity("HerdManagement.Domain.Reproduction.Entities.YoungAnimal", b =>
                {
                    b.Navigation("BreedCharacteristicValues");

                    b.Navigation("SpecieCharacteristicValues");
                });

            modelBuilder.Entity("HerdManagement.Domain.SpecieBreed.Entities.Breed", b =>
                {
                    b.Navigation("BreedCharacteristics");
                });

            modelBuilder.Entity("HerdManagement.Domain.SpecieBreed.Entities.Specie", b =>
                {
                    b.Navigation("Characteristics");
                });
#pragma warning restore 612, 618
        }
    }
}
