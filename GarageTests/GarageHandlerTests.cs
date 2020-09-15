using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Garage.Tests
{
    [TestClass()]
    public class GarageHandlerTests
    {
        public Garage<Vehicle> Garage { get; set; }

        [TestMethod()]
        public void SeedParkVehiclesTest()
        {
            // Arrange
            string expectedColour = "Blue";
            string expectedRegNum = "IOP789";
            double expectedWeight = 100;
            int expectedSize = 2;
            int expectedWheels = 0;

            // Act
            Vehicle vehicle = new Car(100, "iop789", "Blue", 4, 4);
            Vehicle vehicle2 = new Boat(1000, "iop889", "Yellow", 0, 8.25);
            Garage.ParkVehicle(vehicle);
            Garage.ParkVehicle(vehicle2);
            string expectedTypeName = "Boat";

            string actualColour = Garage.Vehicles.First().Colour;
            string actualRegNum = Garage.Vehicles.First().RegistrationNumber;
            double actualWeight = Garage.Vehicles.First().Weight;
            int actualSize = Garage.Vehicles.Length;
            int actualWheels = Garage.Vehicles.ElementAt(1).NumberOfWheels;
            string actualTypeName = Garage.Vehicles.ElementAt(1).GetType().Name;


            // Assert
            Assert.AreEqual(expectedColour, actualColour);
            Assert.AreEqual(expectedRegNum, actualRegNum);
            Assert.AreEqual(expectedWeight, actualWeight);
            Assert.AreEqual(expectedSize, actualSize);
            Assert.AreEqual(expectedWheels, actualWheels);
            Assert.AreEqual(expectedTypeName, actualTypeName);
        }

        [TestMethod()]
        public void CreateGarageTest()
        {
            Assert.Fail();
        }
    }
}