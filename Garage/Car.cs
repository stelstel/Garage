namespace Garage
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        
        public Car(double weight, string registrationNumber, string colour, int numberOfWheels, int numberOfDoors) 
            : base(weight, registrationNumber, colour, numberOfWheels)
        {
            NumberOfDoors = numberOfDoors;   
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Number of doors: {NumberOfDoors}";
        }
    }
}
