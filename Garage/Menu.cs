using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage
{
    public static class Menu
    {
        #region Properties **************************************************************
        static UI Ui { get; set; } = new UI();
        static GarageHandler garageHandler = new GarageHandler();
        #endregion

        #region Methods *****************************************************************
        public static void Run()
        {
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

                    firstChoice = Ui.GetInput();

                    switch (firstChoice)
                    {
                        case "a": case "A": 
                        case "b": case "B": 
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
            Ui.Clear();
            Ui.PrintLine("Choose option:\n");
            Ui.PrintLine("a: DEV. SHORTCUT: Create garage, create vehicles");
            Ui.PrintLine("b: DEV. SHORTCUT: Create 15 vehicles and add them to the garage\n");
            Ui.PrintLine("1: Park new vehicle");
            Ui.PrintLine("2: Create the garage");
            Ui.PrintLine("3: List the vehicles in the garage");
            Ui.PrintLine("4: List number of vehicles in the garage by type");
            Ui.PrintLine("5: Remove car from garage");
            Ui.PrintLine("6: Filtered list of vehicles in garage");
            Ui.PrintLine("0: Exit");
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
                        //garageHandler.constructQuery();
                        break;
                default:
                        break;
            }
        }


        private static void FilteredList()
        {
            Ui.Print("Choose type(s) comma separated: ");
            string userSelectedTypes = Ui.GetInput();
            
            //Ui.Print($"{garageHandler.handleFilteredSearch(userSelectedTypes)}\nPress enter to continue!");
            //Ui.GetInput();

            Ui.Print("Choose colour(s) comma separated: ");
            string userSelectedColours = Ui.GetInput();

            Ui.Print($"\n{garageHandler.handleFilteredSearch(userSelectedTypes, userSelectedColours)}\nPress enter to continue!");
            Ui.GetInput();
        }


        /// <summary>
        /// Unpark car
        /// </summary>
        private static void RemoveVehicle()
        {
            bool regNumOK = false;
            string registrationNum;

            do
            {
                Ui.PrintLine("Input the registration number of the vehicle");
                registrationNum = Ui.GetInput().ToUpper();
                
                if (!garageHandler.ValidateRegNum(registrationNum))
                {
                    PrintIncorrectInputWarning("The registration number is invalid. Please try again!");
                }
                else if (garageHandler.Garage == null)
                {
                    PrintIncorrectInputWarning("No garage exists. Create a garage first");
                }
                else
                {
                    regNumOK = true;

                    if (garageHandler.Garage.UnparkVehicle(registrationNum) == true)
                    {
                        Ui.PrintLine($"\nThe vehicle with registration number {registrationNum} has been removed from the garage\nPress enter to continue!");
                        Ui.GetInput();

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
                Ui.Print($"\nGarage with {numberOfParkingSpaces} parking spaces created.\n15 vehicles have been parked in the garage\nPress enter to continue");
                Ui.GetInput();
            }
        }


        private static void ListTypes()
        {
            if (garageHandler.Garage != null)
            {
                Ui.PrintLine();
                Ui.Print(garageHandler.Garage.ListParkedVehiclesByType());
                Ui.PrintLine("\nPress enter to continue!");
                Ui.GetInput();
            }
            else
            {
                PrintIncorrectInputWarning("No garage exists. Create a garage");
            }
        }


        private static void ListVehicles()
        {
            if (garageHandler.Garage != null)
            {
                Ui.PrintLine();
                Ui.Print(garageHandler.Garage.ListParkedVehicles());
                Ui.PrintLine("\nPress enter to continue!");
                Ui.GetInput();
            }
            else
            {
                PrintIncorrectInputWarning(". No garage exists. Create a garage first");
            }
        }


        private static void ProduceGarage()
        {
            int parkingSpaces;
            bool correctSpaces = false;

            do
            {
                Ui.Print($"Input number of parking spaces for the garage: ");

                if (!int.TryParse(Ui.GetInput(), out parkingSpaces) && parkingSpaces > 0)
                {
                    PrintIncorrectInputWarning("input");
                }
                else
                {
                    correctSpaces = true;
                }
            } while (!correctSpaces);

            garageHandler.CreateGarage(parkingSpaces);
            Ui.PrintLine($"A garage with {parkingSpaces} spaces created");
            Ui.GetInput();
        }


        private static void CreateAndParkVehicles()
        {
            if (garageHandler.Garage != null)
            {
                if (garageHandler.SeedParkVehicles() == true)
                {
                    Ui.Print("Eight vehicles has been added to the garage");
                    Ui.GetInput();
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
            if (garageHandler.Garage != null)
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
                    Ui.Print($"Input how many passengers the {vehicleType} has:");
                    bool intOK = Int32.TryParse(Ui.GetInput(), out numberOfPassengers);

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
                    Ui.Print($"Input the length of the {vehicleType}:");
                    bool doubleOK = Double.TryParse(Ui.GetInput(), out length);

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
                    Ui.Print($"Input the number of seats the {vehicleType} has:");
                    bool intOK = Int32.TryParse(Ui.GetInput(), out numberOfSeats);

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
                    Ui.Print($"Input the number of doors the {vehicleType} has:");
                    bool intOK = Int32.TryParse(Ui.GetInput(), out numberOfDoors);

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
                    Ui.Print($"Input the engine volumeof the {vehicleType}:");
                    bool intOK = Int32.TryParse(Ui.GetInput(), out engineVolume);

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
        public static void PrintCreatedVehicleSuccess(Vehicle vehicle)
        {
            Ui.Print($"\nCreated vehicle {vehicle}\nPress enter to continue");
            Ui.GetInput();
        }


        /// <summary>
        /// Prints message to user when input is incorrect
        /// </summary>
        /// <param name="msg">Text to add to default message</param>
        public static void PrintIncorrectInputWarning(String msg)
        {
            Ui.PrintLine($"\nIncorrect input. {msg}. Please try again!\nPress enter to continue");
            Ui.GetInput();
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
                Ui.Print($"Input weight of the {vehicleType}: ");

                if (!double.TryParse(Ui.GetInput(), out weight))
                    { PrintIncorrectInputWarning("input"); }
                else
                    { correctWeight = true; }
            } while (!correctWeight);

            bool correctRegNum = false;

            do
            {
                Ui.Print($"Input the registration number of the {vehicleType}:");
                registrationNumber = Ui.GetInput();
                char[] regNum = registrationNumber.ToCharArray();

                if (garageHandler.ValidateRegNum(registrationNumber))
                    { correctRegNum = true; }
                else
                    { PrintIncorrectInputWarning("registration number"); }
            } while (!correctRegNum);

            bool correctColour = false;

            do
            {
                Ui.Print($"Input the colour of the {vehicleType}:");
                colour = Ui.GetInput();

                if (colour.Length >= 3 && !colour.Any(c => char.IsDigit(c)))
                    { correctColour = true; }
                else
                    { PrintIncorrectInputWarning("colour"); }
            } while (!correctColour);

            bool correctWheels = false;

            do
            {
                Ui.Print($"Input how many wheels the {vehicleType} has:");
                string wheels = Ui.GetInput();
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
