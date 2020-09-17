using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Garage.Tests
{
    [TestClass()]
    public class GarageTests
    {
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
            string expectedOutput = "Vehicles in garage:\n-------------------------------------------------------------\n";

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
                "Vehicles in garage:\n-------------------------------------------------------------\nVehicle, Regnummer: QWE456, Colour: Yellow\n";

            // Act
            garage.ParkVehicle(vehicle);
            string actualOutput = garage.ListParkedVehicles();

            /// Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ListParkedVehiclesByType_duplicate_reg_num_exception_Test()
        {
            // Arrange 
            Garage.Garage<Vehicle> garage =new Garage<Vehicle>(10);

            Car car = new Car(10, "qwe789", "Blue", 4, 4);
            Bus bus = new Bus(10, "qwe789", "Blue", 4, 40);
            
            // Act
            garage.ParkVehicle(car);
            garage.ParkVehicle(car);
            

            // Assert
            // Exception

        }

        [TestMethod()]
        public void ListParkedVehiclesByType_Test()
        {
            //// Arrange 
            Garage.Garage<Vehicle> garage = new Garage<Vehicle>(10);

            Car car = new Car(10, "aaa456", "Blue", 4, 4);
            Bus bus = new Bus(10, "bbb123", "Blue", 4, 40);



            string expectedOutput = "Vehicles in garage, by type:\n-------------------------------------------------------------\n";
            expectedOutput += "Bus(s): 1\n";
            expectedOutput += "Car(s): 1\n";
            expectedOutput += "-----------------------------------------\nTotal: 2 vehicles";

            //// Act
            garage.ParkVehicle(car);
            garage.ParkVehicle(bus);
            string actualOutput = garage.ListParkedVehiclesByType();

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}