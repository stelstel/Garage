using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Garage : IGarage
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public List<Vehicle> Vehicles { get => vehicles; set => vehicles = value; }

        public void parkVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }

        public void unparkVehicle(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle);
        }

        public void seedParkVehicles()
        {
            // TODO Vehicle vehicle1 = new Vehicle(100, "ABC123", "Vit", 4);
        }

        // TODO listan får ej vara här
        /*
            char[] regNum = registrationNumber.ToCharArray();

                if (Char.IsLetter(regNum[0]) && Char.IsLetter(regNum[1]) && Char.IsLetter(regNum[2]) &&
                        Char.IsDigit(regNum[3]) && Char.IsDigit(regNum[4]) && Char.IsDigit(regNum[5]) 
                        && garage.Vehicles.R)
                {
                    registrationNumber = value;
                }
                else
                {
                    throw new ArgumentException("Registration number is wrong. Try again!");
                }
         */
    }
}
