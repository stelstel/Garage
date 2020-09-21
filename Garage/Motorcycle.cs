namespace Garage
{
    public class Motorcycle : Vehicle
    {
        public double EngineVolume { get; set; }

        public Motorcycle(double weight, string registrationNumber, string colour, int numberOfWheels, int engineVolume)
            : base(weight, registrationNumber, colour, numberOfWheels)
        {
            EngineVolume = engineVolume;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Engine volume: {EngineVolume}";
        }
    }
}
