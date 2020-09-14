using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Tests
{
    [TestClass()]
    public class VehicleTests
    {
        [TestMethod()]
        public void Construct_Vehicle_Test()
        {
            // Arrange
            string expectedColour = "Blå";
            int expectedNumberOfWheels = 4;
            string expectedRegNum = "ABC123";
            double expectedWeight = 100;

            //Act
            Vehicle vehicle = new Vehicle(100, "ABC123", "Blå", 4);
            string actualColour = vehicle.Colour;
            int actualNumberOfWheels = vehicle.NumberOfWheels;
            string actualRegNum = vehicle.RegistrationNumber;
            double actualWeight = vehicle.Weight;

            // Assert
            Assert.AreEqual(expectedColour, actualColour);
            Assert.AreEqual(expectedNumberOfWheels, actualNumberOfWheels);
            Assert.AreEqual(expectedRegNum, actualRegNum);
            Assert.AreEqual(expectedWeight, actualWeight);

        }
    }
}