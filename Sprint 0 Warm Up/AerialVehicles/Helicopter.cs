using Sprint_0_Warm_Up.Engines;

namespace Sprint_0_Warm_Up.AerialVehicles
{
    /// <summary>
    /// An aerial vehicle that is driven by rotor blades.
    /// </summary>
    public sealed class Helicopter : AerialVehicle
    {
        #region Parameters
        /// <summary>
        /// The max altitude for helicopters.
        /// </summary>
        private const int HELICOPTER_MAX_ALTITUDE = 8000;
        #endregion
        #region Constructors
        /// <summary>
        /// Creates a new helicopter with the default max altitude.
        /// </summary>
        /// <param name="engine">The driving engine of the helicopter.</param>
        public Helicopter(IEngine engine) : base(engine)
        {
            MaxAltitude = HELICOPTER_MAX_ALTITUDE;
        }
        #endregion
    }
}
