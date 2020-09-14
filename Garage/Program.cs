using System;

namespace Garage
{
    class Program
    {
        public static UI Ui { get; set; } = new UI();

        static void Main(string[] args)
        {
            Garage<Vehicle> garage = new Garage.Garage<Vehicle>(10);
            garage.seedParkVehicles();
            
            string parkedVehicles = garage.listParkedVihicles();
            Ui.Print(parkedVehicles);
            Ui.GetInput();
        }
    }
}
