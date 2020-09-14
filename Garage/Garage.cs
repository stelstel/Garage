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
            //TODO
        }

        public void seedParkVehicles()
        {
            // TODO Vehicle vehicle1 = new Vehicle(100, "ABC123", "Vit", 4);
        }
    }
}
