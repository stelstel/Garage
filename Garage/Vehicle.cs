﻿using System;
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
            set { registrationNumber = value.ToUpper(); } // Reg number always uppercase
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

    }
}
