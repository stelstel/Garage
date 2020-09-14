using System;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(100, "iop789", "Blue", 4);
            Vehicle vehicle2 = new Vehicle(1000, "iop889", "Blue", 4);

            Garage<Vehicle> garage = new Garage.Garage<Vehicle>(10);
            garage.parkVehicle(vehicle);
            garage.parkVehicle(vehicle2);
        }
    }
}
