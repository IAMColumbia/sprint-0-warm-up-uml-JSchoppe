using Sprint_0_Warm_Up.Engines;

namespace Sprint_0_Warm_Up.AerialVehicles
{
    /// <summary>
    /// A transit aerial vehicle that travels long distances.
    /// </summary>
    public class Airplane : AerialVehicle
    {
        #region Parameters
        /// <summary>
        /// The max altitude for airplanes.
        /// </summary>
        private const int AIRPLANE_MAX_ALTITUDE = 41000;
        #endregion
        #region Constructors
        /// <summary>
        /// Creates a new airplane with the default max altitude.
        /// </summary>
        /// <param name="engine">The driving engine of the airplane.</param>
        public Airplane(IEngine engine) : base(engine)
        {
            MaxAltitude = AIRPLANE_MAX_ALTITUDE;
        }
        #endregion
    }
}
