using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public class AirplaneTests
    {
        private Airplane airplane;

        [TestMethod]
        public void About()
        {
            // Confirm about message formatting.
            // Arrange.
            airplane = new Airplane();
            // Act.
            string about = airplane.About();
            // Assert.
            Assert.AreEqual(
                $"This {airplane} has a max altitude of 41000 ft." +
                $"{Environment.NewLine}Its current altitude is 0 ft." +
                $"{Environment.NewLine}{airplane.Engine} is not started.",
                about);
        }

        [TestMethod]
        public void AirplaneTakeoff()
        {
            // Airplane should not take off if its engine is not started.
            // Arrange.
            airplane = new Airplane();
            // Act.
            string message = airplane.TakeOff();
            // Assert.
            Assert.AreEqual($"{airplane} can't take off. Its engine hasn't started.", message);

            // This is the moment I stopped formatting these tests
            // because it is very boring.
            bool engineStartedDefault = airplane.Engine.IsStarted;
            airplane.StartEngine();
            string secondTakeoffMessage = airplane.TakeOff();
            bool engineStartedAfterTakeoff = airplane.Engine.IsStarted;
            Assert.AreEqual($"{airplane} is flying.", secondTakeoffMessage);
            Assert.AreEqual(false, engineStartedDefault);
            Assert.AreEqual(true, engineStartedAfterTakeoff);
        }

        [TestMethod]
        public void AirplaneFlyUp()
        {
            // Arrange.
            airplane = new Airplane();
            airplane.StartEngine();
            airplane.TakeOff();
            // Act.
            int altitude0 = airplane.CurrentAltitude;
            airplane.FlyUp();
            int altitude1 = airplane.CurrentAltitude;
            airplane.FlyUp(40000);
            int altitude2 = airplane.CurrentAltitude;
            // Assert.
            Assert.AreEqual(0, altitude0);
            Assert.AreEqual(1000, altitude1);
            Assert.AreEqual(41000, altitude2);
        }

        [TestMethod]
        public void AirplaneFlyDown()
        {
            // Arrange.
            airplane = new Airplane();
            airplane.StartEngine();
            airplane.TakeOff();
            // Act.
            int altitude0 = airplane.CurrentAltitude;
            airplane.FlyDown();
            int altitude1 = airplane.CurrentAltitude;
            airplane.TakeOff();
            airplane.FlyDown(1);
            airplane.TakeOff();
            int altitude2 = airplane.CurrentAltitude;
            airplane.FlyUp(2);
            airplane.FlyDown(1);
            int altitude3 = airplane.CurrentAltitude;
            // Assert.
            Assert.AreEqual(0, altitude0);
            Assert.AreEqual(0, altitude2);
            Assert.AreEqual(0, altitude1);
            Assert.AreEqual(1, altitude3);
        }
    }
}
