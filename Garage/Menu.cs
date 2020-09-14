﻿using System;
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
            string vehicleType = "";
            bool correctType = false;

            do
            {
                Ui.PrintLine("Input type of vehicle: ");
                Ui.PrintLine("1: Airplane");
                Ui.PrintLine("2: Boat");
                Ui.PrintLine("3: Bus");
                Ui.PrintLine("4: Car");
                Ui.PrintLine("5: Motorcycle");

                string type = Ui.GetInput();

                switch (type)
                {
                    case "1":
                        vehicleType = "Airplane";
                        correctType = true;
                        break;
                    case "2":
                        vehicleType = "Boat";
                        correctType = true;
                        break;
                    case "3":
                        vehicleType = "Bus";
                        correctType = true;
                        break;
                    case "4":
                        vehicleType = "Car";
                        correctType = true;
                        break;
                    case "5":
                        vehicleType = "Motorcycle";
                        correctType = true;
                        break;
                    default:
                        break;
                }
            } while (!correctType);        

            bool correctWeight = false;

            do
            {
                Ui.Print($"Input weight of the {vehicleType}: ");
                double weight;

                if (!double.TryParse(Ui.GetInput(), out weight))
                {
                    Ui.PrintLine("Incorrect weight. Try again!");
                }
                else
                {
                    correctWeight = true;
                }
            } while (!correctWeight);

            bool correctRegNum = false;

            do
            {
                Ui.Print($"Input registration number of the {vehicleType}:");
                string regNum = Ui.GetInput();
            } while (!correctRegNum);

            
            //string registrationNumber, string colour, int numberOfWheels
        }
    }
}
