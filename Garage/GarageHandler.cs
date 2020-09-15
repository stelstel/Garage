using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class GarageHandler
    {
        public void SeedParkVehicles()
        {
            Vehicle vehicle = new Car(100, "iop789", "Blue", 4, 4);
            Vehicle vehicle2 = new Boat(1000, "iop889", "Yellow", 4, 8.25);
            Vehicle vehicle3 = new Bus(1100, "BEN789", "White", 4, 46);
            Vehicle vehicle4 = new Airplane(6250, "SAS14001", "Grey", 8, 510);
            Vehicle vehicle5 = new Motorcycle(250, "HJK412", "Black", 2, 900);

            ParkVehicle(vehicle);
            ParkVehicle(vehicle2);
            ParkVehicle(vehicle3);
            ParkVehicle(vehicle4);
            ParkVehicle(vehicle5);

            //unparkVehicle(vehicle); // TODO
        }
    }
}
