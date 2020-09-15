using System;

namespace Garage
{
    class Program
    {
        public static UI Ui { get; set; } = new UI();
        //public static Garage<Vehicle> Garage { get; set; }

        static void Main(string[] args)
        {
            GarageHandler garageHandler = new GarageHandler();
            Menu.Run();

            //Garage<Vehicle> garage = new Garage.Garage<Vehicle>(10);
            //garage.SeedParkVehicles();
            
            //string parkedVehicles = garage.ListParkedVihicles();
            //Ui.Print(parkedVehicles);
            //Ui.GetInput();
        }
    }
}
