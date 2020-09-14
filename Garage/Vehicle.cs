using System;
using System.Collections.Generic;

namespace Garage
{
    public class Vehicle : IVehicle
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
                
                if (Char.IsLetter(regNum[0]) && Char.IsLetter(regNum[1]) && Char.IsLetter(regNum[2])
                        && Char.IsDigit(regNum[3]) && Char.IsDigit(regNum[4]) && Char.IsDigit(regNum[5]))
                {
                    registrationNumber = value.ToUpper(); // Reg number always uppercase
                }
                else
                {
                    throw new System.ArgumentException();
                }
            } 
        }

        public string Colour { get; set; }
        public int NumberOfWheels { get; set; }
        #endregion  

        #region constructors ***********************************************************************************
        //public Vehicle()
        //{

        //}
        public Vehicle(double weight, string registrationNumber, string colour, int numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Weight = weight;
            Colour = colour;
            NumberOfWheels = numberOfWheels;
        }
        #endregion

        #region methods *****************************************************************************************
        /// <summary>
        /// Creates a string containing values neeeded to find a parked vehicle
        /// </summary>
        /// <returns>String containing values neeeded to find a parked vehicle</returns>
        public override string ToString()
        {
            return $"{this.GetType().Name}, Regnummer: {RegistrationNumber}, Colour: {Colour}, ";
        }
        #endregion

    }
}
