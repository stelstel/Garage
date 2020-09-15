using System;
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

        public void ParkVehicle(Vehicle vehicle)
        {
            int firstEmptyArraySpace = Array.IndexOf(vehicles, null);
            vehicles[firstEmptyArraySpace] = vehicle;
        }


        public void UnparkVehicle(Vehicle vehicle)
        {

            for (int i = 0; i < vehicles.Length - 1; i++)
            {
                if (vehicle.RegistrationNumber == vehicles[i]?.RegistrationNumber)
                {
                    vehicles[i] = null;
                }
            }
        }


        /// <summary>
        ///     Creates a string containing of parked vehicles
        /// </summary>
        /// <returns>String containing parked vehicles</returns>
        public string ListParkedVehicles()
        {
            string output = "";

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
        #endregion
    }
}
