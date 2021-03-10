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

        [DisplayName("Neme")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string Gender { get; set; }

        [DisplayName("Telefonszám")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string PhoneNumber { get; set; }

        [DisplayName("E-mail cím")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string Email { get; set; }

        [DisplayName("Irányítószám")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public int PostCode { get; set; }

        [DisplayName("Város")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string City { get; set; }

        [DisplayName("Utca")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public string Street { get; set; }

        [DisplayName("Házszám")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public int HouseNumber { get; set; }

        [DisplayName("Személyi igazolvány száma")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public int PersonalID { get; set; }

        [DisplayName("Adószám")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "required")]
        public int TaxNumber { get; set; }
    }
}
