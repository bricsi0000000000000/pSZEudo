using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ContractStore.Models.People
{
    public static class PersonManager
    {
        public static List<Person> People { get; set; } = new List<Person>();

        public static void LoadPeople()
        {
            var database = new DatabaseContext();
            database.People.Load();
            People = database.People.ToList();
        }

        public static void addToList(Person person)
        {
            if (!findPersonID(person.PersonalID))
            {
                People.Add(person);

                var database = new DatabaseContext();
                database.People.Load();
                database.People.Add(person);
            }
            else
            {
                //TODO nem jó, már van ilyen
            }
        }

        public static void removeFromList(Person person)
        {
            People.Remove(person);

            var database = new DatabaseContext();
            database.People.Load();
            database.People.Remove(person);
        }

        public static List<Person> getList()
        {
            return People;
        }

        // Finding methods
        public static bool findPersonID(int ID)
        {
            foreach (Person p in People)
            {
                if (p.PersonalID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool findPersonPhoneNumber(string phoneNumber)
        {
            foreach (Person p in People)
            {
                if (p.PhoneNumber == phoneNumber)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool findPersonEmail(string email)
        {
            foreach (Person p in People)
            {
                if (p.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        // Filtering
        public static List<Person> filterByLastName(string lastName)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in People)
            {
                if (p.LastName == lastName)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public static List<Person> filterByFirstName(string firstName)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in People)
            {
                if (p.FirstName == firstName)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public static List<Person> filterByMotherName(string motherName)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in People)
            {
                if (p.MotherName == motherName)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public static List<Person> filterByNationality(string nationality)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in People)
            {
                if (p.Nationality == nationality)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public static List<Person> filterByBirthPlace(string birthPlace)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in People)
            {
                if (p.BirthPlace == birthPlace)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public static List<Person> filterByOlderThan(System.DateTime birthDate)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in People)
            {
                if (p.BirthDate < birthDate)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public static List<Person> filterByYoungerThan(System.DateTime birthDate)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in People)
            {
                if (p.BirthDate > birthDate)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public static List<Person> filterByPostCode(int postCode)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in People)
            {
                if (p.PostCode == postCode)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public static List<Person> filterByGender(string gender)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in People)
            {
                if (p.Gender == gender)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public static List<Person> filterByCity(string city)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in People)
            {
                if (p.City == city)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public static List<Person> filterByStreet(string street)
        {
            List<Person> result = new List<Person>();
            foreach (Person p in People)
            {
                if (p.Street == street)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        // Sorting methods
        public static List<Person> sortByFirstName()
        {
            getList().Sort((x, y) => x.FirstName.CompareTo(y.FirstName));
            return getList();
        }

        public static List<Person> sortByLastName()
        {
            getList().Sort((x, y) => x.LastName.CompareTo(y.LastName));
            return getList();
        }

        public static List<Person> sortByMotherName()
        {
            getList().Sort((x, y) => x.MotherName.CompareTo(y.MotherName));
            return getList();
        }

        public static List<Person> sortByNationality()
        {
            getList().Sort((x, y) => x.Nationality.CompareTo(y.Nationality));
            return getList();
        }

        public static List<Person> sortByEmail()
        {
            getList().Sort((x, y) => x.Email.CompareTo(y.Email));
            return getList();
        }
        public static List<Person> sortByBirthPlace()
        {
            getList().Sort((x, y) => x.BirthPlace.CompareTo(y.BirthPlace));
            return getList();
        }
        public static List<Person> sortByBirthDate()
        {
            getList().Sort((x, y) => x.BirthDate.CompareTo(y.BirthDate));
            return getList();
        }

    }
}
