﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContractStore.Models.People
{
    public class Person
    {
        public int ID { get; set; }

        [DisplayName("Viselt név")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        public string WornName { get; set; } = "";

        [DisplayName("Név előtag")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        public string NamePrefix { get; set; }

        [DisplayName("Családi név")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        public string LastName { get; set; }

        [DisplayName("Utónév")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        public string FirstName { get; set; }

        [DisplayName("Születési név")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        public string BirthName { get; set; } = "";

        [DisplayName("Anyja neve")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        public string MotherName { get; set; }

        [DisplayName("Állampolgárság")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        public string Nationality { get; set; }

        [DisplayName("Születési hely")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        public string BirthPlace { get; set; }

        [DisplayName("Születési idő")]
        [Required(ErrorMessage = "Válassz születési dátumot!")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Neme")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        public string Gender { get; set; }

        [DisplayName("Telefonszám")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        [RegularExpression(@"\+[0-9]{11}$", ErrorMessage = "A telefonszám nem megfelelő formátumú. Megfelelő formátum: +36201234567")]
        public string PhoneNumber { get; set; }

        [DisplayName("E-mail cím")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        [RegularExpression(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+", ErrorMessage = "Az email cim nem megfelelő formátumú.")]
        public string Email { get; set; }

        [DisplayName("Irányítószám")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Az irányitószám nem megfelelő formátumú.")]
        public int PostCode { get; set; }

        [DisplayName("Város")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        public string City { get; set; }

        [DisplayName("Utca")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        public string Street { get; set; }

        [DisplayName("Házszám")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        [RegularExpression(@"[0-9]", ErrorMessage = "A házszám nem megfelelő formátumú.")]
        public int HouseNumber { get; set; }

        [DisplayName("Személyi igazolvány száma")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        public int PersonalID { get; set; }

        [DisplayName("Adószám")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        [RegularExpression(@"[0-9]", ErrorMessage = "Az adószám nem megfelelő formátumú.")]
        public int TaxNumber { get; set; }
    }
}
