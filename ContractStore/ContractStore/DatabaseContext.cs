using ContractStore.Models;
using ContractStore.Models.People;
using ContractStore.Models.Vehicle;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractStore
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=ContractStore;Uid=root;Pwd=;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var people = new List<Person>() 
            { 
                new Person() { ID = 1, BirthDate = new DateTime(1998, 1, 2), BirthName = "Bálint", BirthPlace = "Győr", City = "Győr", Email="balint@gmail.com", FirstName="Valamilyen", LastName="Bálint", Gender="Férfi", HouseNumber=2, MotherName="Virág", NamePrefix="", Nationality="magyar", PersonalID=4, PhoneNumber="0620123456", PostCode=1234, Street="Nagy", TaxNumber=213213, WornName="Bálint"},
                new Person() { ID = 2, BirthDate = new DateTime(1996, 2, 4), BirthName = "Ádám", BirthPlace = "Győr", City = "Tiszalök", Email="adam@gmail.com", FirstName="Valamekkora", LastName="Ádám", Gender="Férfi", HouseNumber=3, MotherName="Evelin", NamePrefix="Dr.", Nationality="német", PersonalID=6, PhoneNumber="0620789123", PostCode=2345, Street="Kis", TaxNumber=543453, WornName="Ádám"},
                new Person() { ID = 3, BirthDate = new DateTime(1993, 5, 8), BirthName = "Zsolt", BirthPlace = "Budapest", City = "Győr", Email="zsolt@gmail.com", FirstName="Kovács", LastName="Zsolt", Gender="Férfi", HouseNumber=26, MotherName="Lilla", NamePrefix="", Nationality="magyar", PersonalID=4, PhoneNumber="0620123456", PostCode=1234, Street="Kovács", TaxNumber=213213, WornName="Zsolt"}
            };

            modelBuilder.Entity<Person>().HasData(people);

            var vehicles = new List<Vehicle>()
            {
                new Vehicle() { ID = 1, Capacity = 100, Category = "category1", ChassisNumber = "lx123456", Color = "kék", EngineData = "abc122", EngineNumber = "123456678", EnvironmentProtectionClass = "class1", GearBoxType = "automatic", LicencePlate = "abc123", Manufacturer = "bmw", ManuType = "type1", Mass = 1000, NumberOfSeats = 4, NumberOfStandingPlaces = 0, Performance = 1200, PlacedInTrafficDate = new DateTime(2018, 4,9), ProductYear = 2014, ProhibitionOfSelling = "yes", Propellant = "no", RateOfPerformance = 98.9, RegisterDate = new DateTime(2016,3,7), TechnicalValidity = new DateTime(2222,4,6), TractionData = "good", TransportablePeople = 5, ValidityBegin = new DateTime(2021,2,2), VehicleType = "BMW 1" },
                new Vehicle() { ID = 2, Capacity = 100, Category = "category2", ChassisNumber = "lr123456", Color = "piros", EngineData = "abc134", EngineNumber = "123456678", EnvironmentProtectionClass = "class2", GearBoxType = "manual", LicencePlate = "abc444", Manufacturer = "audi", ManuType = "type2", Mass = 1000, NumberOfSeats = 4, NumberOfStandingPlaces = 0, Performance = 1200, PlacedInTrafficDate = new DateTime(2018, 4,9), ProductYear = 2014, ProhibitionOfSelling = "yes", Propellant = "no", RateOfPerformance = 98.9, RegisterDate = new DateTime(2016,3,7), TechnicalValidity = new DateTime(2222,4,6), TractionData = "good", TransportablePeople = 5, ValidityBegin = new DateTime(2021,2,2), VehicleType = "audi 1" },
                new Vehicle() { ID = 3, Capacity = 100, Category = "category3", ChassisNumber = "lj123456", Color = "narancs", EngineData = "abc552", EngineNumber = "123456678", EnvironmentProtectionClass = "class3", GearBoxType = "fél automata", LicencePlate = "abc555", Manufacturer = "mercedes", ManuType = "type3", Mass = 1000, NumberOfSeats = 4, NumberOfStandingPlaces = 0, Performance = 1200, PlacedInTrafficDate = new DateTime(2018, 4,9), ProductYear = 2014, ProhibitionOfSelling = "yes", Propellant = "no", RateOfPerformance = 98.9, RegisterDate = new DateTime(2016,3,7), TechnicalValidity = new DateTime(2222,4,6), TractionData = "good", TransportablePeople = 5, ValidityBegin = new DateTime(2021,2,2), VehicleType = "w12" },
            };

            modelBuilder.Entity<Vehicle>().HasData(vehicles);

            var users = new List<User>()
            {
                new User() { ID = 1, Name = "Ricsi", Email = "ricsi@bolya.eu", PasswordHash = "NJSAj6vUdXexj54gYy+4DYmLpK1JNIno2W6P14JwMtccurNK"} // abc123456
            };

            modelBuilder.Entity<User>().HasData(users);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
