using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public class Garage<T>
    {
        private Vehicle[] vehicles;

        public Vehicle[] Vehicles
        {
            get { return vehicles; }
            set { vehicles = value; }
        }

        public Garage(int numberOfParkingSpaces)
        {
            Vehicles = new Vehicle[numberOfParkingSpaces];
        }

        public void parkVehicle(Vehicle vehicle)
        {
            int firstEmptyArraySpace = Array.IndexOf(Vehicles, null);
            Vehicles[firstEmptyArraySpace] = vehicle;
        }

        public void unparkVehicle(Vehicle vehicle)
        {

            for (int i = 0; i < Vehicles.Length - 1; i++)
            {
                if (vehicle.RegistrationNumber == Vehicles[i]?.RegistrationNumber)
                {
                    Vehicles[i] = null;
                }
            }
        }

        public void seedParkVehicles()
        {
            Vehicle vehicle = new Vehicle(100, "iop789", "Blue", 4);
            Vehicle vehicle2 = new Vehicle(1000, "iop889", "Blue", 4);
            Vehicle vehicle3 = new Vehicle(1100, "BEN789", "White", 4);

            parkVehicle(vehicle);
            parkVehicle(vehicle2);
            parkVehicle(vehicle3);
            unparkVehicle(vehicle);
        }
    }
}
