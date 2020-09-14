using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public class Car : Vehicle
    {
        public int NumberOfSeats { get; set; }
        
        public Car() {}

        public Car(int numberOfSeats, double weight, string registrationNumber, string colour, int numberOfWheels) 
            : base(weight, registrationNumber, colour, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;   
        }
    }
}
