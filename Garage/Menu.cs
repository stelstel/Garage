using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public static class Menu
    {
        static UI Ui { get; set; } = new UI();

        static void Run()
        {
            PrintChioces();
        }

        static void PrintChioces() 
        {
            Ui.PrintLine("Choose: ");
            Ui.PrintLine("1: Register vehicle");
            Ui.PrintLine("0: Exit");

            HandleInput(Ui.GetInput());
        }

        private static void HandleInput(string input)
        {
            if (input.Length != 1)
            {
                Ui.PrintLine("Incorrect choice. Try again");
                return;
            }

            switch (input)
            {
                case "1":
                    CreateVehicle();
                    break;
                default:
                    break;
            }
        }

        private static void CreateVehicle()
        {
            Ui.PrintLine("Input type of vehicle: ");
            Ui.PrintLine("1: Airplane");
            Ui.PrintLine("2: Boat");
            Ui.PrintLine("1: Bus");
            Ui.PrintLine("1: Car");
            Ui.PrintLine("1: Motorcycle");

            string type = Ui.GetInput();

            string vehicleType = "";

            switch (type)
            {
                case "1":
                    vehicleType = "Airplane";
                    break;
                case "2":
                    vehicleType = "Boat";
                    break;
                case "3":
                    vehicleType = "Bus";
                    break;
                case "4":
                    vehicleType = "Car";
                    break;
                case "5":
                    vehicleType = "Motorcycle";
                    break;
                default:
                    break;
            }

            Ui.Print($"Input weight of the {vehicleType}: ");
            double weight;
            double.TryParse(Ui.GetInput(), out weight);
            
            Ui.Print($"Input registration number of the {vehicleType}:");
            string regNum = Ui.GetInput();
            //string registrationNumber, string colour, int numberOfWheels
        }
    }
}
