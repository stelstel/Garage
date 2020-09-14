using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Tests
{
    [TestClass()]
    public class BoatTests
    {
        [TestMethod()]
        public void Boat_constructor_Test()
        {
            // Arrange
            double expectedWeight = 540.3;
            string expectedRegNum = "ASD456";
            string expectedColour = "Yellow";
            int expectedWheels = 0;
            double expectedLength = 5.45;

            // Act
            Boat boat = new Boat(
                weight: 540.3,
                registrationNumber: "asd456",
                colour: "Yellow",
                numberOfWheels: 0,
                length: 5.45);

            // Assert
            Assert.AreEqual(expectedWeight, boat.Weight);
            Assert.AreEqual(expectedRegNum, boat.RegistrationNumber);
            Assert.AreEqual(expectedColour, boat.Colour);
            Assert.AreEqual(expectedWheels, boat.NumberOfWheels);
            Assert.AreEqual(expectedLength, boat.Length);

        }
    }
}