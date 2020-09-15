using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage
{
    public static class Menu
    {
        #region Properties **************************************************************
        static UI Ui { get; set; } = new UI();
        #endregion

        #region Methods *****************************************************************
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
                        Ui.PrintLine(); // TODO bryta ut
                        Ui.PrintLine("Incorrect choice. Try again!");
                        Ui.PrintLine();
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


        private static void CreateVehicle() // TODO dela upp
        {
            string vehicleType = "";
            double weight;
            string registrationNumber;
            string colour;
            int numberOfWheels;

            
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
                        Ui.PrintLine();
                        Ui.PrintLine("Incorrect input. Try again!");
                        Ui.PrintLine();

                        break;
                }
            } while (!correctType);        

            bool correctWeight = false;

            do
            {
                Ui.Print($"Input weight of the {vehicleType}: ");
                //double weight;

                if (!double.TryParse(Ui.GetInput(), out weight))
                {
                    Ui.PrintLine();
                    Ui.PrintLine("Incorrect input. Try again!");
                    Ui.PrintLine();
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
                registrationNumber = Ui.GetInput();
                char[] regNum = registrationNumber.ToCharArray();

                if (registrationNumber.Length == 6 && 
                        Char.IsLetter(regNum[0]) && Char.IsLetter(regNum[1]) && Char.IsLetter(regNum[2]) && 
                        Char.IsDigit(regNum[3]) && Char.IsDigit(regNum[4]) && Char.IsDigit(regNum[5]))
                {
                    correctRegNum = true;
                }
                else
                {
                    Ui.PrintLine();
                    Ui.PrintLine("Incorrect registration number. try again");
                    Ui.PrintLine();
                }
            } while (!correctRegNum);

            bool correctColour = false;

            do
            {
                Ui.Print($"Input the colour of the {vehicleType}:");
                colour = Ui.GetInput();

                if (colour.Length >= 3 && !colour.Any(c => char.IsDigit(c)))
                {
                    correctColour = true;
                }
                else
                {
                    Ui.PrintLine();
                    Ui.PrintLine("Incorrect colour. try again");
                    Ui.PrintLine();
                }

            } while (!correctColour);

            bool correctWheels = false;

            do
            {
                Ui.Print($"Input how many wheels the {vehicleType} has:");
                string wheels = Ui.GetInput();
                bool intOK = Int32.TryParse(wheels, out numberOfWheels);

                if (numberOfWheels > 100 || !intOK)
                {
                    Ui.PrintLine();
                    Ui.PrintLine("Incorrect number of wheels. Try again");
                    Ui.PrintLine();
                }
                else
                {
                    correctWheels = true;
                }
            } while (!correctWheels);

            Vehicle vehicle = new Vehicle(weight, registrationNumber, colour, numberOfWheels);
            //double weight, string registrationNumber, string colour, int numberOfWheels
        }
        #endregion
    }
}
