using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Garage
{
    public class GarageHandler
    {
        #region Properties **************************************************************

        public Garage<Vehicle> Garage { get; set; }

        #endregion

        #region methods *****************************************************************

        public bool SeedParkVehicles() // Todo seed more vehicles
        {
            bool success = false;
            Vehicle[] seededVehicles = new Vehicle[15];

            seededVehicles[0] = new Car(
                weight:             1490.2, 
                registrationNumber: "iop789", 
                colour:             "Blue", 
                numberOfWheels:     4, 
                numberOfDoors:      4
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

            foreach (var seededVehicle in seededVehicles)
            {
                success = TryToPark(vehicle: seededVehicle, printConfirmation: false);
            }

            return success;
        }

        public void CreateGarage(int parkingSpaces)
        {
            Garage = new Garage<Vehicle>(parkingSpaces);
        }

        public bool TryToPark(Vehicle vehicle, bool printConfirmation)
        {
            bool success = false;

            try
            {
                Garage.ParkVehicle(vehicle);

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
        public bool ValidateRegNum(string regNum) {
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


        public string handleFilteredSearch(string selectedTypes)
        {
            List<Type> typeList = new List<Type>();

            // Remove all spaces
            selectedTypes = Regex.Replace(selectedTypes, @"\s+", "");

            string[] selTypes = selectedTypes.Split(",");

            foreach (string typ in selTypes)
            {
                switch (typ.ToLower())
                {
                    case "airplane":
                        typeList.Add(Type.GetType("Garage.Airplane, Garage"));
                        break;
                    case "boat":
                        typeList.Add(Type.GetType("Garage.Boat, Garage"));
                        break;
                    case "bus":
                        typeList.Add(Type.GetType("Garage.Bus, Garage"));
                        break;
                    case "car":
                        typeList.Add(Type.GetType("Garage.Car, Garage"));
                        break;
                    case "motorcycle":
                        typeList.Add(Type.GetType("Garage.Motorcycle, Garage"));
                        break;
                    default:
                        break;
                }
            }


            string colour = "Black"; // Todo get from user

            return Garage.ProduceAdvancedList(
                colour: colour, 
                typeList: typeList, 
                minWheels: 0,
                maxWheels: int.MaxValue);
        }
        #endregion
    }
}
