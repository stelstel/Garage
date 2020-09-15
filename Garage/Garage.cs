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

        public Vehicle[] Vehicles
        {
            get { return vehicles; }
            set { vehicles = value; }
        }
        #endregion


        #region Constructors ************************************************************

        public Garage(int numberOfParkingSpaces)
        {
            Vehicles = new Vehicle[numberOfParkingSpaces];
        }
        #endregion


        #region Methods *****************************************************************

        public void ParkVehicle(Vehicle vehicle)
        {
            int firstEmptyArraySpace = Array.IndexOf(Vehicles, null);
            Vehicles[firstEmptyArraySpace] = vehicle;
        }


        public void UnparkVehicle(Vehicle vehicle)
        {

            for (int i = 0; i < Vehicles.Length - 1; i++)
            {
                if (vehicle.RegistrationNumber == Vehicles[i]?.RegistrationNumber)
                {
                    Vehicles[i] = null;
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

            foreach (Vehicle vehicle in Vehicles)
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
