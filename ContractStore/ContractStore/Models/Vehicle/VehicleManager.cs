using System.Collections.Generic;

namespace ContractStore.Models.Vehicle
{
    public static class VehicleManager
    {
        public static List<Vehicle> VehicleList { get; set; } = new List<Vehicle>();

        public static void addToList(Vehicle vehicle)
        {
            VehicleList.Add(vehicle);
        }

        public static void removeFromList(Vehicle vehicle)
        {
            VehicleList.Remove(vehicle);
        }

        public static List<Vehicle> getList()
        {
            return VehicleList;
        }

        // Finding methods
        public static bool findVehicleID(int ID)
        {
            foreach(Vehicle v in VehicleList)
            {
                if(v.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }
        
        public static bool findLicensePlate(string licensePlate)
        {
            foreach(Vehicle v in VehicleList)
            {
                if(v.LicencePlate == licensePlate)
                {
                    return true;
                }
            }
            return false;
        }


        // Filtering
        public static List<Vehicle> filterByVehicleType(string vType)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (Vehicle v in VehicleList)
            {
                if (v.VehicleType == vType)
                {
                    result.Add(v);
                }
            }
            return result;
        }

        public static List<Vehicle> filterByManufacturer(string manufacturer)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (Vehicle v in VehicleList)
            {
                if (v.Manufacturer == manufacturer)
                {
                    result.Add(v);
                }
            }
            return result;
        }

        public static List<Vehicle> filterByManuType(string manuType)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (Vehicle v in VehicleList)
            {
                if (v.ManuType == manuType)
                {
                    result.Add(v);
                }
            }
            return result;
        }

        public static List<Vehicle> filterByProductYear(int productYear)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (Vehicle v in VehicleList)
            {
                if (v.ProductYear == productYear)
                {
                    result.Add(v);
                }
            }
            return result;
        }

        public static List<Vehicle> filterByOlderThanValidityBegin(System.DateTime vBegin)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (Vehicle v in VehicleList)
            {
                if (v.ValidityBegin <= vBegin)
                {
                    result.Add(v);
                }
            }
            return result;
        }
        public static List<Vehicle> filterByYoungerThanValidityBegin(System.DateTime vBegin)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (Vehicle v in VehicleList)
            {
                if (v.ValidityBegin >= vBegin)
                {
                    result.Add(v);
                }
            }
            return result;
        }

        public static List<Vehicle> filterByLessThanMass(int mass)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (Vehicle v in VehicleList)
            {
                if (v.Mass <= mass)
                {
                    result.Add(v);
                }
            }
            return result;
        }
        
        public static List<Vehicle> filterByMoreThanMass(int mass)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (Vehicle v in VehicleList)
            {
                if (v.Mass >= mass)
                {
                    result.Add(v);
                }
            }
            return result;
        }
        
        public static List<Vehicle> filterByLessTranspAblePeopleThan(int tPeople)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (Vehicle v in VehicleList)
            {
                if (v.TransportablePeople <= tPeople)
                {
                    result.Add(v);
                }
            }
            return result;
        } 
        public static List<Vehicle> filterByMoreTranspAblePeopleThan(int tPeople)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (Vehicle v in VehicleList)
            {
                if (v.TransportablePeople >= tPeople)
                {
                    result.Add(v);
                }
            }
            return result;
        }
        

        // Sorting methods
        public static List<Vehicle> sortByVehicleType()
        {
            getList().Sort((x, y) => x.VehicleType.CompareTo(y.VehicleType));
            return getList();
        }

        public static List<Vehicle> sortByManufacturer()
        {
            getList().Sort((x, y) => x.Manufacturer.CompareTo(y.Manufacturer));
            return getList();
        }

        public static List<Vehicle> sortByManuType()
        {
            getList().Sort((x, y) => x.ManuType.CompareTo(y.ManuType));
            return getList();
        }

        public static List<Vehicle> sortByProductYear()
        {
            getList().Sort((x, y) => x.ProductYear.CompareTo(y.ProductYear));
            return getList();
        }
        
        public static List<Vehicle> sortByValidityBegin()
        {
            getList().Sort((x, y) => x.ValidityBegin.CompareTo(y.ValidityBegin));
            return getList();
        }
        public static List<Vehicle> sortByMass()
        {
            getList().Sort((x, y) => x.Mass.CompareTo(y.Mass));
            return getList();
        }

    }
}
