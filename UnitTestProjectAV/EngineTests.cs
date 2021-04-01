using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up.Engines;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public sealed class EngineTests
    {
        private Engine engine;

        [TestMethod]
        public void IsStarted()
        {
            // Default state should be not started.
            // Arrange.
            engine = new Engine();
            // Act.
            bool isStarted = engine.IsStarted;
            // Assert.
            Assert.AreEqual(false, isStarted);

            // Start method should start engine.
            // Arrange.
            engine = new Engine();
            // Act.
            engine.Start();
            isStarted = engine.IsStarted;
            // Assert.
            Assert.AreEqual(true, isStarted);

            // Stop should remove started state.
            // Arrange.
            engine = new Engine();
            // Act.
            engine.Start();
            engine.Stop();
            isStarted = engine.IsStarted;
            // Assert.
            Assert.AreEqual(false, isStarted);
        }

        [TestMethod]
        public void About()
        {
            // About not started formatting check.
            // Arrange.
            engine = new Engine();
            // Act.
            string about = engine.About();
            // Assert.
            Assert.AreEqual($"{engine} is not started.", about);

            // About started formatting check.
            // Arrange.
            engine = new Engine();
            engine.Start();
            // Act.
            about = engine.About();
            // Assert.
            Assert.AreEqual($"{engine} is started.", about);
        }
    }
}
