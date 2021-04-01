using Sprint_0_Warm_Up.Engines;
using Sprint_0_Warm_Up.AerialVehicles;
using Ninject.Modules;

namespace Sprint_0_Warm_Up.DIModules
{
    /// <summary>
    /// Dependency injection module for specifying engine implementation.
    /// </summary>
    public sealed class EngineModule : NinjectModule
    {
        #region Load Module
        /// <summary>
        /// Loads the bindings for engines.
        /// </summary>
        public override void Load()
        {
            Bind<IEngine>().To<JetEngine>().WhenInjectedExactlyInto<Airplane>();
            Bind<IEngine>().To<ReciprocatingEngine>().WhenInjectedInto<Helicopter>();
            Bind<IEngine>().To<RubberBandEngine>().WhenInjectedInto<ToyPlane>();
            Bind<IEngine>().To<UAVEngine>().WhenInjectedInto<Drone>();
        }
        #endregion
    }
}
