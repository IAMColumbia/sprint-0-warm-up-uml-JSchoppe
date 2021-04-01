using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up.AerialVehicles;
using Sprint_0_Warm_Up.Engines;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public sealed class DroneTests
    {
        Drone drone;

        [TestMethod]
        public void Constructor()
        {
            // Drone should cap altitude to 500.
            // Arrange.
            drone = new Drone(new Engine());
            // Act.
            int maxAltitude = drone.MaxAltitude;
            // Assert.
            Assert.AreEqual(500, maxAltitude);
        }
    }
}
