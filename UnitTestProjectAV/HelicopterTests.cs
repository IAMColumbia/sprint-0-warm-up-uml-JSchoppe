using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up;

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
            helicopter = new Helicopter();
            // Act.
            int maxAltitude = helicopter.MaxAltitude;
            // Assert.
            Assert.AreEqual(8000, maxAltitude);
        }
    }
}
