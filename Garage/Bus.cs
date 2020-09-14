using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public class Bus : Vehicle, IVehicle 
    {
        public int NumberOfSeats { get; set; }

        public Bus(double weight, string registrationNumber, string colour, int numberOfWheels, int numberOfSeats) 
            : base(weight, registrationNumber, colour, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Number of seats: {NumberOfSeats}";
        }
    }
}
