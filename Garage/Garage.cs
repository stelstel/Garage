using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Garage<T>
    {
        private Vehicle[] vehicles;

        public Vehicle[] Vehicles
        {
            get { return vehicles; }
            set { vehicles = value; }
        }

        public void parkVehicle(Vehicle vehicle)
        {
            //TODO
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
