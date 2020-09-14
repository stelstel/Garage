using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Garage : IGarage
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        public void parkVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void unparkVehicle(Vehicle vehicle)
        {
            vehicles.Remove(vehicle);
        }

        public void seedParkVehicles()
        {
            // TODO Vehicle vehicle1 = new Vehicle(100, "ABC123", "Vit", 4);
        }
    }
}
