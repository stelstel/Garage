using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Garage
{
    public class GarageHandler
    {
        #region Properties **************************************************************

        private Garage<Vehicle> garage;
        public int VehiclesSeeded { get; set; } = 20;

        #endregion

        #region methods *****************************************************************

        public bool SeedParkVehicles()
        {
            bool success = false;

            Vehicle[] seededVehicles = new Vehicle[VehiclesSeeded];

            seededVehicles[0] = new Car(
                weight: 1490.2,
                registrationNumber: "iop789",
                colour: "Blue",
                numberOfWheels: 4,
                numberOfDoors: 4
            );

            seededVehicles[1] = new Boat(1000, "abc123", "Yellow", 0, 8.25);
            seededVehicles[2] = new Bus(1100, "BEN789", "White", 4, 46);
            seededVehicles[3] = new Airplane(6250, "SAS140", "Grey", 8, 510);
            seededVehicles[4] = new Motorcycle(250, "HJK412", "Black", 2, 900);
            seededVehicles[5] = new Motorcycle(300, "HKU412", "Red", 3, 1200);
            seededVehicles[6] = new Car(1500, "pop789", "Black", 4, 2);
            seededVehicles[7] = new Car(1604.54, "akl749", "Red", 4, 4);
            seededVehicles[8] = new Boat(2000, "axc129", "Black", 0, 10.25);
            seededVehicles[9] = new Bus(400, "BEK777", "Red", 3, 55);
            seededVehicles[10] = new Airplane(10250, "IBE159", "White", 6, 610);
            seededVehicles[11] = new Motorcycle(300, "AJL753", "Red", 2, 1200);
            seededVehicles[12] = new Motorcycle(400, "YUO453", "Grey", 3, 400);
            seededVehicles[13] = new Car(1500, "flo741", "Blue", 4, 3);
            seededVehicles[14] = new Car(1604.54, "RTY428", "Black", 4, 4);
            seededVehicles[15] = new Bus(2604.33, "FKO222", "Pink", 6, 92);
            seededVehicles[16] = new Boat(604.12, "LHA746", "Grey", 0, 6.54);
            seededVehicles[17] = new Airplane(2604.78, "SAS001", "Blue", 4, 402);
            seededVehicles[18] = new Car(1478.23, "POF488", "Black", 4, 4);
            seededVehicles[19] = new Car(1803.11, "LYQ972", "Yellow", 4, 2);

            foreach (var seededVehicle in seededVehicles)
            {
                success = TryToPark(vehicle: seededVehicle, printConfirmation: false);
            }

            return success;
        }


        public void CreateGarage(int parkingSpaces)
        {
            //garage = new Garage<Vehicle>(parkingSpaces);
            garage = new Garage<Vehicle>(parkingSpaces);

            //foreach (var vehicle in garage)
            //{

            //}

            //var rodaFordon = garage.Where(v => v.Colour == "Red");
        }


        public bool TryToPark(Vehicle vehicle, bool printConfirmation)
        {
            bool success = false;

            try
            {
                garage.ParkVehicle(vehicle);

                if (printConfirmation)
                {
                    Menu.PrintCreatedVehicleSuccess(vehicle);
                }

                success = true;
            }
            catch (Exception ex)
            {
                Menu.PrintIncorrectInputWarning($"{ex.Message}");
            }

            return success;
        }


        /// <summary>
        /// Validates registration number
        /// </summary>
        /// <param name="regNum">String containing registration number</param>
        /// <returns></returns>
        public bool ValidateRegNum(string regNum)
        {
            if (regNum.Length == 6 &&
                            Char.IsLetter(regNum[0]) && Char.IsLetter(regNum[1]) && Char.IsLetter(regNum[2]) &&
                            Char.IsDigit(regNum[3]) && Char.IsDigit(regNum[4]) && Char.IsDigit(regNum[5]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string HandleFilteredSearch(List<Type> userTypeList, string selectedColours, int minNumberOfWheels, int maxNumberOfWheels, string registrationNumber, double minWeight, double maxWeight)
        {
            // Remove all spaces
            selectedColours = Regex.Replace(selectedColours, @"\s+", "");
            string[] selColours = selectedColours.Split(",");

            if (selColours.First() != "*")
            {
                for (int i = 0; i < selColours.Count(); i++)
                {
                    // First letter uppercase
                    selColours[i] = UppercaseFirst(selColours[i]);
                }
            }

            return garage.ProduceAdvancedList
            (
                typeList: userTypeList,
                colourList: selColours,
                minWheels: minNumberOfWheels,
                maxWheels: maxNumberOfWheels,
                registrationNumber: registrationNumber,
                minWeight: minWeight,
                maxWeight: maxWeight
            );
        }


        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        internal bool IsCreated()
        {
            return garage != null;
        }

        internal string ListParkedVehiclesByType()
        {
            //var result = garage.GroupBy(v => v.GetType().Name)
            //            .Select(s => new CountDTO()
            //            {
            //                Name = s.Key,
            //                Count = s.Count()
            //            });

            StringBuilder output = new StringBuilder("Vehicles in garage, by type:\n-------------------------------------------------------------\n");
            Dictionary<string, int> typeNumberDict = new Dictionary<string, int>();

            typeNumberDict.Add("Airplane", 0);
            typeNumberDict.Add("Boat", 0);
            typeNumberDict.Add("Bus", 0);
            typeNumberDict.Add("Car", 0);
            typeNumberDict.Add("Motorcycle", 0);

            foreach (var vehicle in garage)
            {
                for (int i = 0; i < typeNumberDict.Count; i++)
                {
                    // Vehicle in garage == vehicle in the list counting different types of vehicles
                    if (String.Equals(vehicle.GetType().Name, typeNumberDict.ElementAt(i).Key))
                    {
                        typeNumberDict[typeNumberDict.ElementAt(i).Key] = typeNumberDict.ElementAt(i).Value + 1;
                    }
                }
            }

            int totalNumVehicles = 0;

            foreach (var typeNumber in typeNumberDict)
            {
                totalNumVehicles += typeNumber.Value;
            }

            foreach (var typeNumber in typeNumberDict)
            {
                if (typeNumber.Value > 0)
                {
                    output.Append($"{typeNumber.Key}(s): {typeNumber.Value}\n");
                }
            }

            output.Append($"-----------------------------------------\nTotal: {totalNumVehicles} vehicles");
            return output.ToString();
        }

        internal string ListParkedVehicles()
        {
            StringBuilder output = new StringBuilder("Vehicles in garage:\n-------------------------------------------------------------\n");

            foreach (var vehicle in garage)
            {
                output.Append(vehicle.ToString());
                output.Append("\n");
            }
            return output.ToString();
        }

        internal bool UnparkVehicle(string registrationNum)
        {
            var found = garage.FirstOrDefault(v => v.RegistrationNumber == registrationNum);
            if (found is null) return false;

            return garage.UnparkVehicle(found);
        }
        #endregion
    }
}
