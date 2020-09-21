using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public class Boat : Vehicle
    {
        public double Length { get; set; }

        public Boat(double weight, string registrationNumber, string colour, int numberOfWheels, double length) 
            : base(weight, registrationNumber, colour, numberOfWheels)
        {
            Length = length;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Length: {Length}";
        }
    }
}
