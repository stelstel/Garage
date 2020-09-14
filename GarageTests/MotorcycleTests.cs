using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Tests
{
    [TestClass()]
    public class MotorcycleTests
    {
        [TestMethod()]
        public void Motorcycle_set_get_engine_volume_property_Test()
        {
            // Arrange
            double expectedVolume = 1100;

            // Act
            Motorcycle motorcycle = new Motorcycle(750, "RTY789", "Red", 2, 1200);
            motorcycle.EngineVolume = 1100;
            double actualVolume = motorcycle.EngineVolume;

            // Assert
            Assert.AreEqual(expectedVolume, actualVolume);
        }
    }
}