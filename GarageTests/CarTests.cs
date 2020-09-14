using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Tests
{
    [TestClass()]
    public class CarTests
    {
        [TestMethod()]
        public void Car_constructor_Test()
        {
            // Arrange
            int expectedSeats = 4;
            double expectedWeight = 1500;
            string expectedRegistrationNumber = "222BNM";
            string expectedColour = "Svart";
            int expectedWheels = 4;

            // Act
            Car car = new Car(
                numberOfSeats: 4, 
                weight: 1500, 
                registrationNumber: "222BNM", 
                colour: "Svart", 
                numberOfWheels: 4
            );

            int actualSeats = car.NumberOfSeats;
            double actualWeight = car.Weight;
            string actualRegistrationNumber = car.RegistrationNumber;
            string actualColour = car.Colour;
            int actualWheels = car.NumberOfWheels;

            // Assert
            Assert.AreEqual(expectedSeats, actualSeats);
            Assert.AreEqual(expectedWeight, actualWeight);
            Assert.AreEqual(expectedRegistrationNumber, actualRegistrationNumber);
            Assert.AreEqual(expectedColour, actualColour);
            Assert.AreEqual(expectedWheels, actualWheels);
        }

        [TestMethod()]
        public void CarTest1()
        {
            Car car = new Car();
        }
    }
}