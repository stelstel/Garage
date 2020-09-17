namespace Garage
{
    public interface IVehicle
    {
        string Colour { get; set; }
        int NumberOfWheels { get; set; }
        string RegistrationNumber { get; set; }
        double Weight { get; set; }
    }
}