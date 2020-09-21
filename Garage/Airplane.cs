namespace Garage
{
    class Airplane : Vehicle
    {
        public int NumberOfPassengers { get; set; }

        public Airplane(double weight, string registrationNumber, string colour, int numberOfWheels, int numberOfPassengers) 
            : base(weight, registrationNumber, colour, numberOfWheels)
        {
            NumberOfPassengers = numberOfPassengers;           
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Number of passengers: {NumberOfPassengers}";
        }
    }
}
