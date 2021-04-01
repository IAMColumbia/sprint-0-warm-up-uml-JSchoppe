using Sprint_0_Warm_Up.Engines;

namespace Sprint_0_Warm_Up.AerialVehicles
{
    /// <summary>
    /// A remotely manned aerial vehicle.
    /// </summary>
    public sealed class Drone : AerialVehicle
    {
        #region Parameters
        /// <summary>
        /// The max altitude for drones.
        /// </summary>
        private const int DRONE_MAX_ALTITUDE = 500;
        #endregion
        #region Constructors
        /// <summary>
        /// Creates a new drone with the default max altitude.
        /// </summary>
        /// <param name="engine">The driving engine of the drone.</param>
        public Drone(IEngine engine) : base(engine)
        {
            MaxAltitude = DRONE_MAX_ALTITUDE;
        }
        #endregion
    }
}
