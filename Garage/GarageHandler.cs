using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public class GarageHandler
    {
        #region Properties **************************************************************

        public Garage<Vehicle> Garage { get; set; }

        #endregion

        #region methods *****************************************************************

        public void SeedParkVehicles()
        {
            Vehicle vehicle = new Car(100, "iop789", "Blue", 4, 4);
            Vehicle vehicle2 = new Boat(1000, "iop889", "Yellow", 4, 8.25);
            Vehicle vehicle3 = new Bus(1100, "BEN789", "White", 4, 46);
            Vehicle vehicle4 = new Airplane(6250, "SAS14001", "Grey", 8, 510);
            Vehicle vehicle5 = new Motorcycle(250, "HJK412", "Black", 2, 900);

            Garage.ParkVehicle(vehicle);
            Garage.ParkVehicle(vehicle2);
            Garage.ParkVehicle(vehicle3);
            Garage.ParkVehicle(vehicle4);
            Garage.ParkVehicle(vehicle5);
        }


        public void CreateGarage(int parkingSpaces)
        {
            Garage = new Garage<Vehicle>(parkingSpaces);
        }


        public void TryToPark(Vehicle vehicle)
        {
            try
            {
                Garage.ParkVehicle(vehicle);
                Menu.PrintCreatedVehicleSuccess(vehicle);
            }
            catch (Exception ex)
            {
                Menu.PrintIncorrectInputWarning($"{ex.Message}");
            }
        }

        #endregion
    }
}
