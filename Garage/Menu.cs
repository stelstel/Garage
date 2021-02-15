using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Garage
{
    public static class Menu
    {
        #region Properties **************************************************************
        private static UI ui;
        static GarageHandler garageHandler = new GarageHandler();
        #endregion

        #region Methods *****************************************************************
        public static void Run(UI ui)
        {
            Menu.ui = ui;
            FirstChoice();
        }


        static void FirstChoice()
        {
            bool correctFirstChoice = false;
            string firstChoice;

            do
            {
                do
                {
                    PrintFirstChoice();

                    firstChoice = ui.GetInput();

                    switch (firstChoice)
                    {
                        case "a":
                        case "A":
                        case "b":
                        case "B":
                        case "1":
                        case "2":
                        case "3":
                        case "4":
                        case "5":
                        case "6":
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

        /// <summary>
        /// Prints out the first choice menu
        /// </summary>
        private static void PrintFirstChoice()
        {
            ui.Clear();
            ui.PrintLine("Choose option:\n");
            ui.PrintLine("a: DEV. SHORTCUT: Create garage, create vehicles");
            ui.PrintLine("b: DEV. SHORTCUT: Create 15 vehicles and add them to the garage\n");
            ui.PrintLine("1: Park new vehicle");
            ui.PrintLine("2: Create the garage");
            ui.PrintLine("3: List the vehicles in the garage");
            ui.PrintLine("4: List number of vehicles in the garage by type");
            ui.PrintLine("5: Remove car from garage");
            ui.PrintLine("6: Advanced search of vehicles in garage");
            ui.PrintLine("0: Exit");
        }


        private static void HandleInput(string input)
        {
            switch (input)
            {
                case "a":
                    CreateGarageAndVehicles();
                    break;
                case "b":
                    CreateAndParkVehicles();
                    break;
                case "1":
                    ParkNewVehicle();
                    break;
                case "2":
                    ProduceGarage();
                    break;
                case "3":
                    ListVehicles();
                    break;
                case "4":
                    ListTypes();
                    break;
                case "5":
                    RemoveVehicle();
                    break;
                case "6":
                    FilteredList();
                    break;
                case "0":
                    Environment.Exit(1);
                    break;
                default:
                    PrintIncorrectInputWarning("input");
                    break;
            }
        }


        private static void FilteredList()
        {
            bool correctInput = false;
            bool correctType = false;
            string userSelectedTypes;
            List<Type> userTypeList = new List<Type>();

            do
            {
                ui.Print("Choose type(s) of vehicle, comma separated. Use * as wildcard: ");
                userSelectedTypes = ui.GetInput();

                // Remove all spaces
                userSelectedTypes = Regex.Replace(userSelectedTypes, @"\s+", "");

                string[] userSelTypes = userSelectedTypes.Split(",");

                foreach (string typ in userSelTypes)
                {
                    switch (typ.ToLower())
                    {
                        case "airplane":
                            userTypeList.Add(Type.GetType("Garage.Airplane, Garage"));
                            break;
                        case "boat":
                            userTypeList.Add(Type.GetType("Garage.Boat, Garage"));
                            break;
                        case "bus":
                            userTypeList.Add(Type.GetType("Garage.Bus, Garage"));
                            break;
                        case "car":
                            userTypeList.Add(Type.GetType("Garage.Car, Garage"));
                            break;
                        case "motorcycle":
                            userTypeList.Add(Type.GetType("Garage.Motorcycle, Garage"));
                            break;
                        default:
                            break;
                    }
                }

                IEnumerable<Type> vehicleTypes = garageHandler.getVehicleTypes();

                foreach (Type vehicleType in vehicleTypes)
                {
                    for (int i = 0; i < userTypeList.Count(); i++)
                    {
                        if (vehicleType.Name.Equals(userTypeList.ElementAt(i).Name, StringComparison.OrdinalIgnoreCase))
                        {
                            correctType = true;
                        }
                    }
                }

                if (correctType == false)
                {
                    PrintIncorrectInputWarning("No vehicle of that type in garage. ");
                }

                if (userSelectedTypes.Length > 0)
                {
                    correctInput = true;
                }
                else
                {
                    PrintIncorrectInputWarning("");
                }
            } while (!correctInput || !correctType);

            correctInput = false;
            string userSelectedColours;

            do
            {
                ui.Print("Choose colour(s) comma separated. Use * as wildcard: ");
                userSelectedColours = ui.GetInput();

                if (userSelectedColours.Length > 0)
                {
                    correctInput = true;
                }
                else
                {
                    PrintIncorrectInputWarning("");
                }
            } while (!correctInput);

            correctInput = false;
            int minWheels;

            do
            {
                ui.Print("Choose minimum number of wheels: ");

                string tempString = ui.GetInput();
                int.TryParse(tempString, out minWheels);

                if (tempString.Length > 0 && minWheels >= 0)
                {
                    correctInput = true;
                }
                else
                {
                    PrintIncorrectInputWarning("");
                }
            } while (!correctInput);

            correctInput = false;
            int maxWheels;

            do
            {
                ui.Print("Choose maximum number of wheels: ");
                string tempString = ui.GetInput();
                int.TryParse(tempString, out maxWheels);

                if (tempString.Length > 0 && maxWheels >= 0)
                {
                    correctInput = true;
                }
                else
                {
                    PrintIncorrectInputWarning("");
                }
            } while (!correctInput);

            correctInput = false;
            string regNum;

            do
            {
                ui.Print("Choose registration number. Use * as wildcard: ");
                regNum = ui.GetInput();

                if (garageHandler.ValidateRegNum(regNum) || regNum == "*")
                {
                    correctInput = true;
                }
                else
                {
                    PrintIncorrectInputWarning("");
                }
            } while (!correctInput);

            correctInput = false;
            double minWeight;

            do
            {
                ui.Print("Choose minimum weight: ");
                string tempString = ui.GetInput();
                double.TryParse(tempString, out minWeight);

                if (tempString.Length > 0 && minWeight >= 0)
                {
                    correctInput = true;
                }
                else
                {
                    PrintIncorrectInputWarning("");
                }
            } while (!correctInput);

            correctInput = false;
            double maxWeight;

            do
            {
                ui.Print("Choose maximum weight: ");
                string tempString = ui.GetInput();
                double.TryParse(tempString, out maxWeight);

                if (tempString.Length > 0 && maxWeight >= 0 && maxWeight < int.MaxValue)
                {
                    correctInput = true;
                }
                else
                {
                    PrintIncorrectInputWarning("");
                }
            } while (!correctInput);

            ui.Print($"\n{garageHandler.HandleFilteredSearch(userTypeList/*userSelectedTypes*/, userSelectedColours, minWheels, maxWheels, regNum, minWeight, maxWeight)}\nPress enter to continue!");
            ui.GetInput();
        }


        /// <summary>
        /// Unpark car
        /// </summary>
        public static void RemoveVehicle()
        {
            bool regNumOK = false;
            string registrationNum;

            do
            {
                ui.PrintLine("Input the registration number of the vehicle");
                registrationNum = ui.GetInput().ToUpper();

                if (!garageHandler.ValidateRegNum(registrationNum))
                {
                    PrintIncorrectInputWarning("The registration number is invalid. Please try again!");
                }
                else if (garageHandler.IsCreated())
                {
                    PrintIncorrectInputWarning("No garage exists. Create a garage first");
                }
                else
                {
                    regNumOK = true;

                    if (garageHandler.UnparkVehicle(registrationNum))
                    {
                        ui.PrintLine($"\nThe vehicle with registration number {registrationNum} has been removed from the garage\nPress enter to continue!");
                        ui.GetInput();

                    }
                    else
                    {
                        PrintIncorrectInputWarning("No vehicle with registration number {registrationNum} was found in the garage");
                    }
                }
            } while (!regNumOK);
        }


        public static void CreateGarageAndVehicles()
        {
            int numberOfParkingSpaces = 25;
            garageHandler.CreateGarage(numberOfParkingSpaces);

            if (garageHandler.SeedParkVehicles() == true)
            {
                ui.Print($"\nGarage with {numberOfParkingSpaces} parking spaces created.\n{garageHandler.VehiclesSeeded} vehicles have been parked in the garage\nPress enter to continue");
                ui.GetInput();
            }
        }


        private static void ListTypes()
        {
            if (garageHandler.IsCreated())
            {
                ui.PrintLine("");
                ui.Print(garageHandler.ListParkedVehiclesByType());
                ui.PrintLine("\nPress enter to continue!");
                ui.GetInput();
            }
            else
            {
                PrintIncorrectInputWarning("No garage exists. Create a garage");
            }
        }


        private static void ListVehicles()
        {
            if (garageHandler.IsCreated())
            {
                ui.PrintLine("");
                ui.Print(garageHandler.ListParkedVehicles());
                ui.PrintLine("\nPress enter to continue!");
                ui.GetInput();
            }
            else
            {
                PrintIncorrectInputWarning("No garage exists. Create a garage");
            }
        }


        private static void ProduceGarage()
        {
            int parkingSpaces;
            bool correctSpaces = false;

            do
            {
                ui.Print($"Input number of parking spaces for the garage: ");

                if (!int.TryParse(ui.GetInput(), out parkingSpaces) && parkingSpaces > 0)
                {
                    PrintIncorrectInputWarning("input");
                }
                else
                {
                    correctSpaces = true;
                }
            } while (!correctSpaces);

            garageHandler.CreateGarage(parkingSpaces);
            ui.PrintLine($"A garage with {parkingSpaces} spaces created");
            ui.GetInput();
        }


        private static void CreateAndParkVehicles()
        {
            if (garageHandler.IsCreated())
            {
                if (garageHandler.SeedParkVehicles() == true)
                {
                    ui.Print("Eight vehicles has been added to the garage");
                    ui.GetInput();
                }
            }
            else
            {
                PrintIncorrectInputWarning("No garage exists. Create a garage!");
            }
        }


        static double weight;
        static string registrationNumber;
        static string colour;
        static int numberOfWheels;
        static string vehicleType = "";

        private static void ParkNewVehicle()
        {
            if (garageHandler.IsCreated())
            {
                SetVehicleProps();
                SetUniqueProps();
            }
            else
            {
                PrintIncorrectInputWarning("No garage exists or garage is empty. \nCreate a garage or park a vehicle in the garage");
            }
        }


        /// <summary>
        /// Sets the unique properties of the subclasses of vehicle
        /// (Airplane, Boat, Bus, Car and Motorcycle)
        /// </summary>
        private static void SetUniqueProps()
        {
            if (vehicleType == "Airplane")
            {
                bool correctPassengers = false;
                int numberOfPassengers;
                do
                {
                    ui.Print($"Input how many passengers the {vehicleType} has:");
                    bool intOK = Int32.TryParse(ui.GetInput(), out numberOfPassengers);

                    if (numberOfPassengers < 0 || !intOK)
                    { PrintIncorrectInputWarning("number of passengers"); }
                    else { correctPassengers = true; }
                } while (!correctPassengers);

                Airplane airplane = new Airplane(weight, registrationNumber, colour, numberOfWheels, numberOfPassengers);
                try
                { garageHandler.TryToPark(airplane, true); }
                catch (NullReferenceException ex)
                { PrintIncorrectInputWarning($"{ex.Message}"); }
            }
            else if (vehicleType == "Boat")
            {
                bool correctLength = false;
                double length;

                do
                {
                    ui.Print($"Input the length of the {vehicleType}:");
                    bool doubleOK = Double.TryParse(ui.GetInput(), out length);

                    if (length < 0 || !doubleOK)
                    { PrintIncorrectInputWarning("length"); }
                    else
                    { correctLength = true; }
                } while (!correctLength);

                Boat boat = new Boat(weight, registrationNumber, colour, numberOfWheels, length);
                garageHandler.TryToPark(boat, true);
            }
            else if (vehicleType == "Bus")
            {
                bool correctSeats = false;
                int numberOfSeats;

                do
                {
                    ui.Print($"Input the number of seats the {vehicleType} has:");
                    bool intOK = Int32.TryParse(ui.GetInput(), out numberOfSeats);

                    if (numberOfSeats < 0 || !intOK)
                    { PrintIncorrectInputWarning("number of seats"); }
                    else
                    { correctSeats = true; }
                } while (!correctSeats);

                Bus bus = new Bus(weight, registrationNumber, colour, numberOfWheels, numberOfSeats);
                garageHandler.TryToPark(bus, true);
            }
            else if (vehicleType == "Car")
            {
                bool correctDoors = false;
                int numberOfDoors;

                do
                {
                    ui.Print($"Input the number of doors the {vehicleType} has:");
                    bool intOK = Int32.TryParse(ui.GetInput(), out numberOfDoors);

                    if (numberOfDoors < 0 || !intOK)
                    { PrintIncorrectInputWarning("number of doors"); }
                    else
                    { correctDoors = true; }
                } while (!correctDoors);

                Car car = new Car(weight, registrationNumber, colour, numberOfWheels, numberOfDoors);
                garageHandler.TryToPark(car, true);
            }
            else if (vehicleType == "Motorcycle")
            {
                bool correctVolume = false;
                int engineVolume;

                do
                {
                    ui.Print($"Input the engine volumeof the {vehicleType}:");
                    bool intOK = Int32.TryParse(ui.GetInput(), out engineVolume);

                    if (engineVolume < 0 || !intOK)
                    { PrintIncorrectInputWarning("engine volume"); }
                    else
                    { correctVolume = true; }
                } while (!correctVolume);

                Motorcycle motorcycle = new Motorcycle(weight, registrationNumber, colour, numberOfWheels, engineVolume);
                garageHandler.TryToPark(motorcycle, true);
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
                ui.PrintLine("Input type of vehicle: ");
                ui.PrintLine("1: Airplane");
                ui.PrintLine("2: Boat");
                ui.PrintLine("3: Bus");
                ui.PrintLine("4: Car");
                ui.PrintLine("5: Motorcycle");

                string type = ui.GetInput();

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
        public static void PrintCreatedVehicleSuccess(Vehicle vehicle)
        {
            ui.Print($"\nCreated vehicle {vehicle}\nPress enter to continue");
            ui.GetInput();
        }


        /// <summary>
        /// Prints message to user when input is incorrect
        /// </summary>
        /// <param name="msg">Text to add to default message</param>
        public static void PrintIncorrectInputWarning(String msg)
        {
            ui.PrintLine($"\nIncorrect input. {msg} Please try again!\nPress enter to continue");
            ui.GetInput();
        }

        /// <summary>
        /// Sets the properties of the vehicles
        /// </summary>
        private static void SetVehicleProps()
        {
            vehicleType = TypeOfVehicleMenu();
            bool correctWeight = false;

            do
            {
                ui.Print($"Input weight of the {vehicleType.ToLower()}: ");

                if (!double.TryParse(ui.GetInput(), out weight))
                { PrintIncorrectInputWarning("input"); }
                else
                { correctWeight = true; }
            } while (!correctWeight);

            bool correctRegNum = false;

            do
            {
                ui.Print($"Input the registration number of the {vehicleType.ToLower()}:");
                registrationNumber = ui.GetInput();
                char[] regNum = registrationNumber.ToCharArray();

                if (garageHandler.ValidateRegNum(registrationNumber))
                { correctRegNum = true; }
                else
                { PrintIncorrectInputWarning("registration number"); }
            } while (!correctRegNum);

            bool correctColour = false;

            do
            {
                ui.Print($"Input the colour of the {vehicleType.ToLower()}:");
                colour = ui.GetInput();

                if (colour.Length >= 3 && !colour.Any(c => char.IsDigit(c)))
                { correctColour = true; }
                else
                { PrintIncorrectInputWarning("colour"); }
            } while (!correctColour);

            bool correctWheels = false;

            do
            {
                ui.Print($"Input how many wheels the {vehicleType.ToLower()} has:");
                string wheels = ui.GetInput();
                bool intOK = Int32.TryParse(wheels, out numberOfWheels);

                if (numberOfWheels > 100 || numberOfWheels < 0 || !intOK)
                { PrintIncorrectInputWarning("number of wheels"); }
                else
                { correctWheels = true; }
            } while (!correctWheels);
        }

        #endregion
    }
}
