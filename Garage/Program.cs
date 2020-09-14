using System;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage<Vehicle> garage = new Garage.Garage<Vehicle>(10);
            garage.seedParkVehicles();
            
            string parkedVehicles = garage.listParkedVihicles();
            Console.Write(parkedVehicles);
            Console.ReadLine();
        }
    }
}
