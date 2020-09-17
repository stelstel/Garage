using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Garage
{
    public class Garage<T> where T : Vehicle
    {
        #region Properties ***************************************************************

        private Vehicle[] vehicles;
        #endregion


        #region Constructors ************************************************************

        public Garage(int numberOfParkingSpaces)
        {
            vehicles = new Vehicle[numberOfParkingSpaces];
        }
        #endregion


        #region Methods *****************************************************************

        public void ParkVehicle(Vehicle vehicle) // TODO if no spaces left???
        {
            foreach (Vehicle veh in vehicles)
            {
                if (veh != null)
                {
                    // Vehicle with the same registration number is already parked
                    if (veh.RegistrationNumber == vehicle.RegistrationNumber)
                    {
                        throw new ArgumentException($"A vehicle with the registration number {veh.RegistrationNumber} is already parked in the garage");
                    }
                }
            } 
            
            int firstEmptyArraySpace = Array.IndexOf(vehicles, null);
            vehicles[firstEmptyArraySpace] = vehicle;
        }


        public bool UnparkVehicle(string regNum)
        {
            bool unparkingSuccess = false;

            for (int i = 0; i < vehicles.Length - 1; i++)
            {
                if (regNum == vehicles[i]?.RegistrationNumber)
                {
                    vehicles[i] = null;
                    unparkingSuccess = true;
                }
            }
            return unparkingSuccess;
        }


        /// <summary>
        ///     Creates a string containing of parked vehicles
        /// </summary>
        /// <returns>String containing parked vehicles</returns>
        public string ListParkedVehicles()
        {
            StringBuilder output = new StringBuilder("Vehicles in garage:\n-------------------------------------------------------------\n");

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    output.Append(vehicle.ToString());
                    output.Append("\n");
                }
            }
            return output.ToString();
        }

   
        public string ListParkedVehiclesByType()
        {
            StringBuilder output = new StringBuilder("Vehicles in garage, by type:\n-------------------------------------------------------------\n");
            Dictionary<string, int> typeNumberDict = new Dictionary<string, int>();


            typeNumberDict.Add("Airplane", 0);
            typeNumberDict.Add("Boat", 0);
            typeNumberDict.Add("Bus", 0);
            typeNumberDict.Add("Car", 0);
            typeNumberDict.Add("Motorcycle", 0);
            
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    for (int i = 0; i < typeNumberDict.Count; i++)
                    {
                        // Vehicle in garage == vehicle in the list counting different types of vehicles
                        if (String.Equals( vehicle.GetType().Name, typeNumberDict.ElementAt(i).Key) )
                        {
                            typeNumberDict[typeNumberDict.ElementAt(i).Key] = typeNumberDict.ElementAt(i).Value + 1;
                        }
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

        #endregion
    }
}
