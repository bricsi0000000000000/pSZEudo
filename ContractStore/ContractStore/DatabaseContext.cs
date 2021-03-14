using ContractStore.Models.People;
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
        }

        public DbSet<Person> People { get; set; }
    }
}
