using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Garage
{
    public class Garage<T> // TODO where
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


        public void SeedParkVehicles()
        {
            Vehicle vehicle = new Car(100, "iop789", "Blue", 4, 4);
            Vehicle vehicle2 = new Boat(1000, "iop889", "Yellow", 4, 8.25);
            Vehicle vehicle3 = new Bus(1100, "BEN789", "White", 4, 46);
            Vehicle vehicle4 = new Airplane(6250, "SAS14001", "Grey", 8, 510);
            Vehicle vehicle5 = new Motorcycle(250, "HJK412", "Black", 2, 900);

            ParkVehicle(vehicle);
            ParkVehicle(vehicle2);
            ParkVehicle(vehicle3);
            ParkVehicle(vehicle4);
            ParkVehicle(vehicle5);

            //unparkVehicle(vehicle); // TODO
        }


        /// <summary>
        ///     Creates a string containing of parked vehicles
        /// </summary>
        /// <returns>String containing parked vehicles</returns>
        public string ListParkedVihicles() 
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
