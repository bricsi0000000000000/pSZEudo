﻿// <auto-generated />
using System;
using ContractStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContractStore.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210311144241_AddPeopleDatabase")]
    partial class AddPeopleDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ContractStore.Models.People.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("BirthName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MotherName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NamePrefix")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PersonalID")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PostCode")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TaxNumber")
                        .HasColumnType("int");

                    b.Property<string>("WornName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BirthDate = new DateTime(1998, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BirthName = "Bálint",
                            BirthPlace = "Győr",
                            City = "Győr",
                            Email = "balint@gmail.com",
                            FirstName = "Valamilyen",
                            Gender = "Férfi",
                            HouseNumber = 2,
                            LastName = "Bálint",
                            MotherName = "Virág",
                            NamePrefix = "",
                            Nationality = "magyar",
                            PersonalID = 4,
                            PhoneNumber = "0620123456",
                            PostCode = 1234,
                            Street = "Nagy",
                            TaxNumber = 213213,
                            WornName = "Bálint"
                        },
                        new
                        {
                            ID = 2,
                            BirthDate = new DateTime(1996, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BirthName = "Ádám",
                            BirthPlace = "Győr",
                            City = "Tiszalök",
                            Email = "adam@gmail.com",
                            FirstName = "Valamekkora",
                            Gender = "Férfi",
                            HouseNumber = 3,
                            LastName = "Ádám",
                            MotherName = "Evelin",
                            NamePrefix = "Dr.",
                            Nationality = "német",
                            PersonalID = 6,
                            PhoneNumber = "0620789123",
                            PostCode = 2345,
                            Street = "Kis",
                            TaxNumber = 543453,
                            WornName = "Ádám"
                        },
                        new
                        {
                            ID = 3,
                            BirthDate = new DateTime(1993, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BirthName = "Zsolt",
                            BirthPlace = "Budapest",
                            City = "Győr",
                            Email = "zsolt@gmail.com",
                            FirstName = "Kovács",
                            Gender = "Férfi",
                            HouseNumber = 26,
                            LastName = "Zsolt",
                            MotherName = "Lilla",
                            NamePrefix = "",
                            Nationality = "magyar",
                            PersonalID = 4,
                            PhoneNumber = "0620123456",
                            PostCode = 1234,
                            Street = "Kovács",
                            TaxNumber = 213213,
                            WornName = "Zsolt"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
