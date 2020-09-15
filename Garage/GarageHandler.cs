using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public class GarageHandler
    {
        #region Properties **************************************************************

        static UI Ui { get; set; } = new UI();

        public Garage<Vehicle> Garage { get; set; }

        #endregion


        public void SeedParkVehicles(Garage.Garage<Vehicle> garage)
        {
            Vehicle vehicle = new Car(100, "iop789", "Blue", 4, 4);
            Vehicle vehicle2 = new Boat(1000, "iop889", "Yellow", 4, 8.25);
            Vehicle vehicle3 = new Bus(1100, "BEN789", "White", 4, 46);
            Vehicle vehicle4 = new Airplane(6250, "SAS14001", "Grey", 8, 510);
            Vehicle vehicle5 = new Motorcycle(250, "HJK412", "Black", 2, 900);

            garage.ParkVehicle(vehicle);
            garage.ParkVehicle(vehicle2);
            garage.ParkVehicle(vehicle3);
            garage.ParkVehicle(vehicle4);
            garage.ParkVehicle(vehicle5);
        }

        public Garage.Garage<Vehicle> CreateGarage(int parkingSpaces)
        {
            Garage<Vehicle> garage = new Garage<Vehicle>(parkingSpaces);
            Ui.PrintLine($"A garage with 120 parking spaces created"); // TODO, get parking spaces from user input
            Ui.GetInput();
            return garage;
        }
    }
}
