using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up.AerialVehicles;
using Sprint_0_Warm_Up.Engines;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public sealed class HelicopterTests
    {
        Helicopter helicopter;

        [TestMethod]
        public void Constructor()
        {
            // Max altitude should be capped at 8000.
            // Arrange.
            helicopter = new Helicopter(new Engine());
            // Act.
            int maxAltitude = helicopter.MaxAltitude;
            // Assert.
            Assert.AreEqual(8000, maxAltitude);
        }
    }
}
