using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ContractStore.Models.Vehicle
{
    public class Vehicle
    {
        public int ID { get; set; }

        [DisplayName("Jármű típusa")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Válasszon típust!")]
        public string VehicleType { get; set; }


        [DisplayName("Gyártó")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Válasszon gyártót!")]
        public string Manufacturer { get; set; }


        [DisplayName("Gyártmány")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Válasszon gyártmányt!")]
        public string ManuType { get; set; }

        [DisplayName("Gyártás éve")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Válasszon gyártási évet!")]
        public int ProductYear { get; set; }

        [DisplayName("Jármű kategóriája")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Válasszon kategóriát!")]
        public string Category { get; set; }

        [DisplayName("Érvényesség ideje")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Válassza ki az érvényesség idejét!")]
        public DateTime ValidityBegin { get; set; }

        [DisplayName("Össztömeg")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Válassza ki a jármű tömegét!")]
        public int Mass { get; set; }

        [DisplayName("Szállítható személyek száma")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Válassza ki a szállítható személyek számát!")]
        public int TransportablePeople { get; set; }

        [DisplayName("Ülések száma")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Válassza ki az ülések számát!")]
        public int NumberOfSeats { get; set; }

        [DisplayName("Állóhelyek száma")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Válassza ki az állóhelyek számát!")]
        public int NumberOfStandingPlaces { get; set; }

        [DisplayName("Teljesítmény-tömeg arány")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a teljesítmény-tömeg arányt!")]
        public double RateOfPerformance { get; set; }

        [DisplayName("Vontatási adatok")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a vontatási adatokat!")]
        public string TractionData { get; set; }

        [DisplayName("Műszaki érvényesség")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a műszaki érvényesség dátumát!")]
        public DateTime TechnicalValidity{ get; set; }

        [DisplayName("Nyilvántartásba vétel")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a nyilvántartásba vétel dátumát!")]
        public DateTime RegisterDate{ get; set; }

        [DisplayName("Forgalomba helyezés")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a forgalomba helyezés dátumát!")]
        public DateTime PlacedInTrafficDate{ get; set; }

        [DisplayName("Alvázszám")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg az alvázszámot")]
        public string ChassisNumber { get; set; }

        [DisplayName("Motorszám")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a motorszámot!")]
        public string EngineNumber { get; set; }

        [DisplayName("Hengerűrtartalom")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a hengerűrtartalmat!")]
        public double Capacity { get; set; }

        [DisplayName("Teljesítmény")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a ???!")]
        public double Performance { get; set; }

        [DisplayName("Hajtóanyag")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a hajtóanyag típusát!")]
        public string Propellant { get; set; }

        [DisplayName("Környezetvédelmi osztályba sorolási kód")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a környezetvédelmi osztályba sorolás kódját!")]
        public string EnvironmentProtectionClass { get; set; }

        [DisplayName("Sebességváltó típusa")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a sebességváltó típusát!")]
        public string GearBoxType { get; set; }

        [DisplayName("Motor adatok")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a motor adatokat!")]
        public string EngineData { get; set; }

        [DisplayName("Szín (színkód)")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a jármű színkódját!")]
        public string Color { get; set; }

        [DisplayName("Rendszám")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg a jármű rendszámát!")]
        public string LicencePlate { get; set; }

        [DisplayName("Elidegenítési tilalom")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adja meg hogy vonatkozik e a járműre elidegenítési tilalom!")]
        public string ProhibitionOfSelling { get; set; }
        public class TrafficData
        {
            public string ReasonForWithdrawal { get; set; }
            public DateTime WithDrawalDateStart { get; set; }
            public DateTime WithDrawalDateEnd { get; set; }
            public bool TempWithDrawal { get; set; }
        }

        public class TrunkBookData {
            public DateTime CreationDate { get; set; }
            public double KilometreHour { get; set; }
        }
        class DocumentData
        {
            public string VehicleType { get; set; }
            public int Number { get; set; }
            public string State { get; set; }
            public DateTime CreationDate { get; set; }
            public string CreatorName { get; set; }
            public DateTime WithDrawDate { get; set; }
            public string WithDrawReason { get; set; }
            public string WithDrawerName { get; set; }
        }
    }
}
