using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up.AerialVehicles;
using Sprint_0_Warm_Up.Engines;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public sealed class ToyPlaneTests
    {
        private ToyPlane toyPlane;

        [TestMethod]
        public void ToyPlaneConstructor()
        {
            // Default constructor should cap max
            // altitude and intializes engine and
            // flight state to false.
            // Arrange.
            toyPlane = new ToyPlane(new Engine());
            // Act.
            int maxAltitude = toyPlane.MaxAltitude;
            // Assert.
            Assert.AreEqual(50, maxAltitude);
            Assert.AreEqual(false, toyPlane.Engine.IsStarted);
            Assert.AreEqual(false, toyPlane.IsFlying);
        }

        [TestMethod]
        public void StartEngine()
        {
            // Engine should not start when the
            // toy plane is in unwound state.
            // Arrange.
            toyPlane = new ToyPlane(new Engine());
            // Act.
            toyPlane.StartEngine();
            bool engineStarted = toyPlane.Engine.IsStarted;
            // Assert.
            Assert.AreEqual(false, engineStarted);

            // Engine should start when the toy
            // plane is in the wound up state.
            // Arrange.
            toyPlane = new ToyPlane(new Engine());
            toyPlane.WindUp();
            // Act.
            toyPlane.StartEngine();
            engineStarted = toyPlane.Engine.IsStarted;
            // Assert.
            Assert.AreEqual(true, engineStarted);

            // If the plane is unwound again, the engine
            // should not start.
            // Arrange.
            toyPlane = new ToyPlane(new Engine());
            toyPlane.WindUp();
            toyPlane.UnWind();
            // Act.
            toyPlane.StartEngine();
            engineStarted = toyPlane.Engine.IsStarted;
            // Assert.
            Assert.AreEqual(false, engineStarted);
        }

        [TestMethod]
        public void TakeOff()
        {
            // Should not take off when the plane
            // is unwound.
            // Arrange.
            toyPlane = new ToyPlane(new Engine());
            toyPlane.StartEngine();
            // Act.
            string message = toyPlane.TakeOff();
            // Assert.
            Assert.AreEqual($"{toyPlane} can't take off. It's not wound up.", message);

            // Should take off if wound up.
            // Arrange.
            toyPlane = new ToyPlane(new Engine());
            toyPlane.WindUp();
            toyPlane.StartEngine();
            // Act.
            message = toyPlane.TakeOff();
            // Assert.
            Assert.AreNotEqual($"{toyPlane} can't take off. It's not wound up.", message);
        }

        [TestMethod]
        public void About()
        {
            // The toy plane, unwound by default should state in its
            // final about string that it is unwound.
            // Arrange.
            toyPlane = new ToyPlane(new Engine());
            // Act.
            string[] messages = toyPlane.About().Split(Environment.NewLine);
            // Assert.
            Assert.AreEqual("It's unwound.", messages[messages.Length - 1]);

            // Final about message should reflect wound state.
            // Arrange.
            toyPlane = new ToyPlane(new Engine());
            // Act.
            toyPlane.WindUp();
            messages = toyPlane.About().Split(Environment.NewLine);
            // Assert.
            Assert.AreEqual("It's wound up.", messages[messages.Length - 1]);
        }
    }
}
