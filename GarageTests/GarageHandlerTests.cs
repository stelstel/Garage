using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Tests
{
    [TestClass()]
    public class GarageHandlerTests
    {
        GarageHandler gh = new GarageHandler();

        [TestMethod()]
        public void SeedParkVehiclesTest()
        {

        }

        [TestMethod()]
        public void CreateGarage_with_p_spaces_Test()
        {
            int parkingSpaces = 10;
            gh.CreateGarage(parkingSpaces);

            // Expecting not fail
        }

        // TODO this test wo'nt run
        //[TestMethod()]
        //[ExpectedException(typeof(ArgumentException))]
        //public void TryToPark_2_vehicles_same_reg_num_ExceptionThrown_Test()
        //{
        //    // Arrange
        //    GarageHandler gh = new GarageHandler();
        //    Car car = new Car(1500, "QAZ456", "Red", 4, 4);
        //    Boat boat = new Boat(400, "QAZ456", "Grey", 0, 5);

        //    // Act
        //    gh.TryToPark(car);
        //    gh.TryToPark(boat);

        //    // Assert
        //    // Exception thrown
        //}
    }
}