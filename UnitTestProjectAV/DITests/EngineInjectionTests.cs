using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up.AerialVehicles;
using Sprint_0_Warm_Up.Engines;
using Sprint_0_Warm_Up.DIModules;
using Ninject;

namespace UnitTestProjectAV.DITests
{
    [TestClass]
    public sealed class EngineInjectionTests
    {
        private readonly IKernel kernel;

        public EngineInjectionTests()
        {
            // Arrange.
            kernel = new StandardKernel();
            kernel.Load(new EngineModule());
        }

        [TestMethod]
        public void Airplane()
        {
            // Act.
            Airplane airplane = kernel.Get<Airplane>();
            // Assert.
            Assert.IsInstanceOfType(airplane.Engine, typeof(JetEngine));
        }

        [TestMethod]
        public void Helicopter()
        {
            // Act.
            Helicopter helicopter = kernel.Get<Helicopter>();
            // Assert.
            Assert.IsInstanceOfType(helicopter.Engine, typeof(ReciprocatingEngine));
        }

        [TestMethod]
        public void ToyPlane()
        {
            // Act.
            ToyPlane toyPlane = kernel.Get<ToyPlane>();
            // Assert.
            Assert.IsInstanceOfType(toyPlane.Engine, typeof(RubberBandEngine));
        }

        [TestMethod]
        public void Drone()
        {
            // Act.
            Drone drone = kernel.Get<Drone>();
            // Assert.
            Assert.IsInstanceOfType(drone.Engine, typeof(UAVEngine));
        }
    }
}
