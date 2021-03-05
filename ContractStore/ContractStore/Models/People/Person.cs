using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContractStore.Models.People
{
    public class Person
    {
        public int ID { get; set; }

        [DisplayName("First name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string LastName { get; set; }

        public string BirthName { get; set; }
        public string MotherName { get; set; }
        public string Nationality { get; set; }
        public string BirthPlace { get; set; }

        [DisplayName("Birth date")]
        [Required(ErrorMessage = "Birth date is required")]
        public DateTime BirthDate { get; set; }
        public enum GenderType { female, male }
        public GenderType Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string PersonalID { get; set; }
        public int TaxNumber { get; set; }
    }
}
