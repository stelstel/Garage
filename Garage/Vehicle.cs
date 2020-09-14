using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Garage
{
    class Vehicle : IVehicle
    {
        #region properties ************************************************************************************
        public double Weight { get; set; }
        private string registrationNumber;

        public string RegistrationNumber
        {
            get { return registrationNumber; }

            set
            {
                char[] regNum = registrationNumber.ToCharArray();

                if (Char.IsLetter(regNum[0]) && Char.IsLetter(regNum[1]) && Char.IsLetter(regNum[2]) &&
                        Char.IsDigit(regNum[3]) && Char.IsDigit(regNum[4]) && Char.IsDigit(regNum[5]) )
                {
                    registrationNumber = value;
                }
                else
                {
                    throw new ArgumentException("Registration number is wrong. Try again!")
                }
                
            }
        }

        //public string RegistrationNumber { get; set; }
        public string Colour { get; set; }
        public int NumberOfWheels { get; set; }
        #endregion  

        #region constructors ***********************************************************************************
        public Vehicle()
        {

        }
        public Vehicle(double weight, string registrationNumber, string colour, int numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Weight = weight;
            Colour = colour;
            NumberOfWheels = numberOfWheels;
        }
        #endregion

    }
}
