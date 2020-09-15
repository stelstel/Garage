using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Tests
{
    [TestClass()]
    public class GarageTests
    {
        static GarageHandler garageHandler = new GarageHandler();

        [TestMethod()]
        public void GarageTest()
        {
            
        }

        [TestMethod()]
        public void ParkVehicleTest()
        {
            /*
            // Arrange
            double expectedWeight = 250;
            string expectedRegNum = "HJK812";
            string expectedColour = "Red";

            int expectedWheels = 4;
            int expectedDoors = 2;
            int expectedSize = 2;

            // Act
            Vehicle vehicle = new Motorcycle(250, "hjK812", "Red", 3, 950);
            garageHandler.Garage.ParkVehicle(vehicle);
            Vehicle vehicle2 = new Car(290, "HJK812", "Blue", 4, 2);
            garageHandler.Garage.ParkVehicle(vehicle2);

            double actualWeight = garageHandler.Garage.?????

            // Assert
            */
        }

        [TestMethod()]
        public void UnparkVehicleTest()
        {
            
        }

        [TestMethod()]
        public void ListParkedVehiclesTest()
        {
            // Arrange
            string expectedOutput = "Cars in garage:\n-------------------------------------------------------------\n";

            // Act
            Garage.Garage<Vehicle> garage = new Garage.Garage<Vehicle>(1); 
            string actualOutput = garage.ListParkedVehicles();

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
                
        }
    }
}