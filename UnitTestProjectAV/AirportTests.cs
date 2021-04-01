using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up;
using Sprint_0_Warm_Up.AerialVehicles;
using Sprint_0_Warm_Up.Engines;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public sealed class AirportTests
    {
        private Airport airport;

        [TestMethod]
        public void AirportConstructor()
        {
            // Code should reflect constructor parameter.
            // Arrange.
            airport = new Airport("ORD");
            // Act.
            string code = airport.AirportCode;
            // Assert.
            Assert.AreEqual(code, "ORD");
            // Arrange.
            airport = new Airport("YYZ", 0);
            // Act.
            code = airport.AirportCode;
            // Assert.
            Assert.AreEqual(code, "YYZ");
        }

        [TestMethod]
        public void Land()
        {
            // Airport should not allow landing at full capacity.
            // Arrange.
            airport = new Airport(string.Empty, 1);
            airport.Land(new Helicopter(new Engine()));
            // Act.
            Airplane airplane = new Airplane(new Engine());
            string message = airport.Land(airplane);
            // Assert.
            Assert.AreEqual($"{airplane} can't land because the airport is full.", message);

            // Null argument exceptions are thrown when null planes try to land.
            // Arrange.
            airport = new Airport(string.Empty, 2);
            // Assert.
            Assert.ThrowsException<ArgumentNullException>(()=>
            {
                // Act.
                airport.Land(default(Airplane));
            });
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                // Act.
                airport.Land(default(AerialVehicle[]));
            });

            // When no planes land an empty string should be returned.
            // Arrange.
            airport = new Airport(string.Empty, 2);
            // Act.
            message = airport.Land(new AerialVehicle[] { });
            // Assert.
            Assert.AreEqual(string.Empty, message);
        }

        [TestMethod]
        public void Takeoff()
        {
            // Null argument exception should be thrown if vehicle is null.
            // Arrange.
            airport = new Airport(string.Empty, 10);
            // Assert.
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                // Act.
                airport.TakeOff(null);
            });

            // Verify message formatting for no planes able to takeoff.
            // Arrange.
            airport = new Airport(string.Empty, 10);
            // Act.
            string message = airport.AllTakeOff();
            // Assert.
            Assert.AreEqual($"No vehicles are at {airport} with code {airport.AirportCode}.", message);

            // Verify that all planes that have landed take off.
            // Arrange.
            airport = new Airport(string.Empty, 10);
            // Act.
            airport.Land(new Airplane(new Engine()));
            airport.Land(new AerialVehicle[]
            {
                new Helicopter(new Engine()), new Drone(new Engine())
            });
            message = airport.AllTakeOff();
            // Assert.
            Assert.AreEqual(3, message.Split(Environment.NewLine).Length);

            // Vehicles not at the airport should not be able to take off.
            // Arrange.
            airport = new Airport(string.Empty, 10);
            Drone drone = new Drone(new Engine());
            airport.Land(new AerialVehicle[]
            {
                new Helicopter(new Engine()), new Drone(new Engine())
            });
            // Act.
            message = airport.TakeOff(drone);
            Assert.AreEqual($"{drone} can't takeoff because it is not at this airport.", message);

            // Vehicles at the airport should be able to take off.
            // Arrange.
            airport = new Airport(string.Empty, 10);
            drone = new Drone(new Engine());
            // Act.
            airport.Land(new AerialVehicle[]
            {
                new Helicopter(new Engine()), drone, new Drone(new Engine())
            });
            message = airport.TakeOff(drone);
            // Assert.
            Assert.AreNotEqual($"{drone} can't takeoff because it is not at this airport.", message);
        }
    }
}
