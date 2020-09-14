using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        
        //public Car() {}

        public Car(int numberOfDoors, double weight, string registrationNumber, string colour, int numberOfWheels) 
            : base(weight, registrationNumber, colour, numberOfWheels)
        {
            NumberOfDoors = numberOfDoors;   
        }
    }
}
