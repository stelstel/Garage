﻿using System;
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
                do
                {
                    Ui.Clear();
                    Ui.PrintLine("Choose option: ");
                    Ui.PrintLine("1: Register vehicle");
                    Ui.PrintLine("2: Create garage");
                    Ui.PrintLine("0: Exit");

                    firstChoice = Ui.GetInput();

                    switch (firstChoice)
                    {
                        case "1":
                        case "2":
                            correctFirstChoice = true;
                            break;
                        case "0":
                            System.Environment.Exit(1);
                            break;
                        default:
                            PrintIncorrectInputWarning("input");
                            break;
                    }
                } while (!correctFirstChoice);

                HandleInput(firstChoice);
            } while (true);
        }

        
        private static void HandleInput(string input)
        {
            switch (input)
            {
                    case "1":
                        CreateVehicle();
                        break;
                    case "2":
                        CreateGarage();
                        break;
                    default:
                        break;
            }
        }

        private static void CreateGarage()
        {
            Garage<Vehicle> garage = new Garage<Vehicle>(120); // TODO, get parking spaces from user input
            Ui.PrintLine($"A garage with 120 parking spaces created"); // TODO, get parking spaces from user input
            Ui.GetInput();
        }

        private static void CreateVehicle() // TODO dela upp
        {
            string vehicleType = "";
            double weight;
            string registrationNumber;
            string colour;
            int numberOfWheels;

            vehicleType = TypeOfVehicleMenu();

            bool correctWeight = false;

            do
            {
                Ui.Print($"Input weight of the {vehicleType}: ");

                if (!double.TryParse(Ui.GetInput(), out weight))
                {
                    PrintIncorrectInputWarning("input");
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
                    PrintIncorrectInputWarning("registration number");
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
                    PrintIncorrectInputWarning("colour");
                }

            } while (!correctColour);

            bool correctWheels = false;

            do
            {
                Ui.Print($"Input how many wheels the {vehicleType} has:");
                string wheels = Ui.GetInput();
                bool intOK = Int32.TryParse(wheels, out numberOfWheels);

                if (numberOfWheels > 100 || numberOfWheels < 0 || !intOK)
                {
                    PrintIncorrectInputWarning("number of wheels");
                }
                else
                {
                    correctWheels = true;
                }
            } while (!correctWheels);


            if (vehicleType == "Airplane")
            {
                bool correctPassengers = false;
                int numberOfPassengers;
                do
                {
                    Ui.Print($"Input how many passengers the {vehicleType} has:");
                    bool intOK = Int32.TryParse(Ui.GetInput(), out numberOfPassengers);

                    if (numberOfPassengers < 0 || !intOK)
                    {
                        PrintIncorrectInputWarning("number of passengers");
                    }
                    else
                    {
                        correctPassengers = true;
                    }
                } while (!correctPassengers);

                Airplane airplane = new Airplane(weight, registrationNumber, colour, numberOfWheels, numberOfPassengers);
                PrintCreatedVehicleSuccess(airplane);
            }
            else if (vehicleType == "Boat")
            {
                bool correctLength = false;
                double length;

                do
                {
                    Ui.Print($"Input the length of the {vehicleType}:");
                    bool doubleOK = Double.TryParse(Ui.GetInput(), out length);

                    if (length < 0 || !doubleOK)
                    {
                        PrintIncorrectInputWarning("length");
                    }
                    else
                    {
                        correctLength = true;
                    }
                } while (!correctLength);

                Boat boat = new Boat(weight, registrationNumber, colour, numberOfWheels, length);
                PrintCreatedVehicleSuccess(boat);
            }
            else if (vehicleType == "Bus")
            {
                bool correctSeats = false;
                int numberOfSeats;

                do
                {
                    Ui.Print($"Input the number of seats the {vehicleType} has:");
                    bool intOK = Int32.TryParse(Ui.GetInput(), out numberOfSeats);

                    if (numberOfSeats < 0 || !intOK)
                    {
                        PrintIncorrectInputWarning("number of seats");
                    }
                    else
                    {
                        correctSeats = true;
                    }
                } while (!correctSeats);

                Bus bus = new Bus(weight, registrationNumber, colour, numberOfWheels, numberOfSeats);
                PrintCreatedVehicleSuccess(bus);
            }
            else if (vehicleType == "Car")
            {
                bool correctDoors = false;
                int numberOfDoors;

                do
                {
                    Ui.Print($"Input the number of doors the {vehicleType} has:");
                    bool intOK = Int32.TryParse(Ui.GetInput(), out numberOfDoors);

                    if (numberOfDoors < 0 || !intOK)
                    {
                        PrintIncorrectInputWarning("number of doors");
                    }
                    else
                    {
                        correctDoors = true;
                    }
                } while (!correctDoors);

                Car car = new Car(weight, registrationNumber, colour, numberOfWheels, numberOfDoors);
                PrintCreatedVehicleSuccess(car);
            }
            else if (vehicleType == "Motorcycle")
            {
                bool correctVolume = false;
                int engineVolume;

                do
                {
                    Ui.Print($"Input the engine volumeof the {vehicleType}:");
                    bool intOK = Int32.TryParse(Ui.GetInput(), out engineVolume);

                    if (engineVolume < 0 || !intOK)
                    {
                        PrintIncorrectInputWarning("engine volume");
                    }
                    else
                    {
                        correctVolume = true;
                    }
                } while (!correctVolume);

                Motorcycle motorcycle = new Motorcycle(weight, registrationNumber, colour, numberOfWheels, engineVolume);
                PrintCreatedVehicleSuccess(motorcycle);
            }
        }

        /// <summary>
        /// Menu for the user to choose type of Vehicle
        /// </summary>
        /// <param name="vehicleType">Type of Vehicle</param>
        /// <returns></returns>
        private static string TypeOfVehicleMenu()
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
                        PrintIncorrectInputWarning("input");
                        break;
                }
            } while (!correctType);

            return vehicleType;
        }


        /// <summary>
        ///     Prints message to user when a vehicle has been created
        /// </summary>
        /// <param name="vehicle">The Vehicle that was created</param>
        static void PrintCreatedVehicleSuccess(Vehicle vehicle)
        {
            Ui.Print($"Created vehicle {vehicle.ToString()}");
            Ui.GetInput();
        }


        /// <summary>
        /// Prints message to user when inout was wrong
        /// </summary>
        /// <param name="msg">Text to add to default message</param>
        private static void PrintIncorrectInputWarning(String msg)
        {
            Ui.PrintLine();
            Ui.PrintLine($"Incorrect {msg}. Please try again!");
            Ui.PrintLine();
        }
        #endregion
    }
}
