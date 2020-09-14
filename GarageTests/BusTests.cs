using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Tests
{
    [TestClass()]
    public class BusTests
    {
        [TestMethod()]
        public void Bus_constructor_Test()
        {
            // Arrange
            int expectedSeats = 32;
            string expectedRegNum = "QWE789";

            // Act
            Bus bus = new Bus(2100, "qwe789", "Black", 6, 30);
            bus.NumberOfSeats = 32;

            // Assert
            Assert.AreEqual(expectedSeats, bus.NumberOfSeats);
            Assert.AreEqual(expectedRegNum, bus.RegistrationNumber);
        }
    }
}