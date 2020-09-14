using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public static class Menu
    {
        static UI Ui { get; set; } = new UI();

        public static void Run()
        {
            PrintFirstChoice();
        }

        static void PrintFirstChoice() 
        {
            bool correctFirstChoice = false;
            string firstChoice;

            do
            {
                Ui.PrintLine("Choose: ");
                Ui.PrintLine("1: Register vehicle");
                Ui.PrintLine("0: Exit");

                firstChoice = Ui.GetInput();

                switch (firstChoice)
                {
                    case "1":
                        correctFirstChoice = true;
                        break;
                    case "0":
                        System.Environment.Exit(1);
                        break;
                    default:
                        break;
                }
            } while (!correctFirstChoice);

            HandleInput(firstChoice);


        }

        private static void HandleInput(string input)
        {
            bool mainChoiceCorrect = false;

            do
            {
                if (input.Length != 1)
                {
                    Ui.PrintLine("Incorrect choice. Try again");
                    //return;
                }
                else
                {
                    switch (input)
                    {
                            case "1":
                                CreateVehicle();
                                mainChoiceCorrect = true;
                                break;
                            default:
                                break;
                    }
                }
            } while (!mainChoiceCorrect);
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
                string registrationNumber = Ui.GetInput();
                char[] regNum = registrationNumber.ToCharArray();

                if (Char.IsLetter(regNum[0]) && Char.IsLetter(regNum[1]) && Char.IsLetter(regNum[2])
                        && Char.IsDigit(regNum[3]) && Char.IsDigit(regNum[4]) && Char.IsDigit(regNum[5]))
                {
                    correctRegNum = true;
                }
                else
                {
                    Ui.PrintLine("Incorrect registration number. try again");
                }
            } while (!correctRegNum);

            
            //string registrationNumber, string colour, int numberOfWheels
        }
    }
}
