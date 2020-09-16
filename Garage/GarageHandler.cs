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
            Vehicle[] seededVehicles = new Vehicle[8];

            seededVehicles[0] = new Car(
                weight:             1490.2, 
                registrationNumber: "iop789", 
                colour:             "Blue", 
                numberOfWheels:     4, 
                numberOfDoors:      4
            );

            seededVehicles[1] = new Boat(1000, "iop889", "Yellow", 4, 8.25);
            seededVehicles[2] = new Bus(1100, "BEN789", "White", 4, 46);
            seededVehicles[3] = new Airplane(6250, "SAS14001", "Grey", 8, 510);
            seededVehicles[4] = new Motorcycle(250, "HJK412", "Black", 2, 900);
            seededVehicles[5] = new Motorcycle(300, "HKU412", "Red", 3, 1200);
            seededVehicles[6] = new Car(1500, "pop789", "Black", 4, 2);
            seededVehicles[7] = new Car(1604.54, "akl749", "Red", 4, 4);

            foreach (var seededVehicle in seededVehicles)
            {
                Garage.ParkVehicle(seededVehicle);
            }
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
