using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up;

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
            drone = new Drone();
            // Act.
            int maxAltitude = drone.MaxAltitude;
            // Assert.
            Assert.AreEqual(500, maxAltitude);
        }
    }
}
