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
        public double RateOfPerformance { get; set; }
        public string TractionData { get; set; }
        public DateTime TechnicalValidity{ get; set; }
        public DateTime RegisterDate{ get; set; }
        public DateTime PlacedInTrafficDate{ get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public double Capacity { get; set; }
        public double Performance { get; set; }
        public string Propellant { get; set; }
        public string EnvironmentProtectionClass { get; set; }
        public string GearBoxType { get; set; }
        public string EngineData { get; set; }
        public string Color { get; set; }
        public string LicencePlate { get; set; }
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
