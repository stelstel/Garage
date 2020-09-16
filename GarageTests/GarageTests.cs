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

        [TestMethod()]
        public void ParkVehicleTest1()
        {
            // Arrange
            Garage.Garage<Vehicle> garage = new Garage.Garage<Vehicle>(10);
            Vehicle vehicle = new Vehicle(100, "qwe456", "Yellow", 4);
            string expectedOutput = 
                "Cars in garage:\n-------------------------------------------------------------\nVehicle, Regnummer: QWE456, Colour: Yellow\n";
            
            // Act
            garage.ParkVehicle(vehicle);
            string actualOutput = garage.ListParkedVehicles();

            /// Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}