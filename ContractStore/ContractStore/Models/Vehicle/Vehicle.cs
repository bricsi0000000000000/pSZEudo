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

        public string VehicleType { get; set; }

        public string Manufacturer { get; set; }

        public string ManuType { get; set; }

        [DisplayName("Gyártás éve")]
        [Required(ErrorMessage = "Válassz gyártási évet!")]
        public int ProductYear { get; set; }
        public string Category { get; set; }
        public DateTime ValidityBegin { get; set; }
        public int Mass { get; set; }
        public int TransportablePeople { get; set; }
        public int NumberOfSeats { get; set; }
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
