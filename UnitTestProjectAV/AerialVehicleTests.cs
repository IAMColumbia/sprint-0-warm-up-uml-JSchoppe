using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up.AerialVehicles;
using Sprint_0_Warm_Up.Engines;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public class AerialVehicleTests
    {
        [TestMethod]
        [ExpectedException(typeof(MissingMethodException), "Cannot create an abstract class.")] //Since it's abstact it doesn't have constructor it will throw a MissingMethodException 
        public void AerialVehicleAstract_Throws()
        {
            Activator.CreateInstance<AerialVehicle>(); // Will throw
        }

        [TestMethod]
        public void AerialVehicleEngineTests()
        {
            //Arrange
            Airplane ap = new Airplane(new Engine());
            //Act 
            bool defaultEngine = ap.Engine.IsStarted;  //default should be off
            ap.StartEngine();
            bool startedEngine = ap.Engine.IsStarted;
            ap.StopEngine();
            bool stoppedEngine = ap.Engine.IsStarted;

            //Assert
            Assert.AreEqual(false, defaultEngine); // default is stopped
            Assert.AreEqual(true, startedEngine); // after start is called engine should be stated
            Assert.AreEqual(false, stoppedEngine); // after stop is called engine should be stopped
        }
    }
}
