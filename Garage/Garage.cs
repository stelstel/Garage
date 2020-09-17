﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Garage
{
    public class Garage<T> // TODO where LINQ
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
            string output = "Vehicles in garage:\n-------------------------------------------------------------\n";

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    output += vehicle.ToString();
                    output += "\n";
                }
            }
            return output;
        }

   
        public string ListParkedVehiclesByType()
        {
            string output = "Vehicles in garage, by type:\n-------------------------------------------------------------\n";
            SortedList<string, int> typeNumberList = new SortedList<string, int>();
            
            typeNumberList.Add("Airplane", 0);
            typeNumberList.Add("Boat", 0);
            typeNumberList.Add("Bus", 0);
            typeNumberList.Add("Car", 0);
            typeNumberList.Add("Motorcycle", 0);
            
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    for (int i = 0; i < typeNumberList.Count; i++)
                    {
                        if (String.Equals( vehicle.GetType().Name, typeNumberList.ElementAt(i).Key) )
                        {
                            typeNumberList[typeNumberList.ElementAt(i).Key] += typeNumberList.ElementAt(i).Value;
                        }
                    }
                }
            }

            int totalNumVehicles = 0;

            foreach (var typeNumber in typeNumberList)
            {
                totalNumVehicles += typeNumber.Value;
            }

            foreach (var typeNumber in typeNumberList)
            {
                output += $"{typeNumber.Key}(s): {typeNumber.Value}\n"; // TODO add stringbuilder 
            }

            output += $"-----------------------------------------\nTotal: {totalNumVehicles} vehicles";

            return output;
        }

        #endregion
    }
}
