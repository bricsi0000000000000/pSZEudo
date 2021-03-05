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

        [DisplayName("Viselt név")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string WornName { get; set; }

        [DisplayName("Név előtag")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string NamePrefix { get; set; }

        [DisplayName("Családi név")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string LastName { get; set; }

        [DisplayName("Utónév")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string FirstName { get; set; }

        [DisplayName("Születési név")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string BirthName { get; set; }

        [DisplayName("Anyja neve")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string MotherName { get; set; }

        [DisplayName("Állampolgárság")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string Nationality { get; set; }

        [DisplayName("Születési hely")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string BirthPlace { get; set; }

        [DisplayName("Születési idő")]
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
        public int PersonalID { get; set; }
        public int TaxNumber { get; set; }
    }
}
