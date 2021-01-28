using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void EngineIsStarted()
        {
            //Arrange
            Engine e = new Engine();
            //Act 
            bool defaultEngineStarted = e.IsStarted;
            e.Start();
            bool startEngineStarted = e.IsStarted;
            e.Stop();
            bool stopEngineStarted = e.IsStarted;
            //Assert
            Assert.AreEqual(false, defaultEngineStarted);
            Assert.AreEqual(true, startEngineStarted);
            Assert.AreEqual(false, stopEngineStarted);
        }

        [TestMethod]
        public void EngineAbout()
        {
            //Arrange
            Engine e = new Engine();
            //Act 
            string defaultEngineAbout = e.About();
            e.Start();
            string startedAbout = e.About();
            e.Stop();
            string stoppedAbout = e.About();
            //Assert
            Assert.AreEqual($"{e.ToString()} is not started.", defaultEngineAbout);
            Assert.AreEqual($"{e.ToString()} is started.", startedAbout);
            Assert.AreEqual($"{e.ToString()} is not started.", stoppedAbout);
        }
    }
}
