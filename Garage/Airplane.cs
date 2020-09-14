using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Airplane : Vehicle
    {
        public int NumberOfPassengers { get; set; }

        public Airplane(double weight, string registrationNumber, string colour, int numberOfWheels, int numberOfPassangers) 
            : base(weight, registrationNumber, colour, numberOfWheels)
        {
            NumberOfPassengers = numberOfPassangers;           
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Number of passangers: {NumberOfPassengers}";
        }
    }
}
