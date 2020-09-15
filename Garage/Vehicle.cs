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
                // Reg number sholud always be uppercase
                registrationNumber = value.ToUpper(); // Reg number always uppercase
            } 
        }

        public string Colour { get; set; }
        public int NumberOfWheels { get; set; }
        #endregion  

        #region constructors ***********************************************************************************
       
        public Vehicle(double weight, string registrationNumber, string colour, int numberOfWheels)
        {
            Weight = weight;
            RegistrationNumber = registrationNumber;
            // string strB = String.Copy(strA); 
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
            return $"{this.GetType().Name}, Regnummer: {RegistrationNumber}, Colour: {Colour}";
        }
        #endregion

    }
}
