using System;
using Sprint_0_Warm_Up.Engines;

namespace Sprint_0_Warm_Up.AerialVehicles
{
    /// <summary>
    /// Base class for all aerial vehicles.
    /// </summary>
    public abstract class AerialVehicle
    {
        #region Parameters
        /// <summary>
        /// The default argument for changing altitude.
        /// </summary>
        private const int DEFAULT_FLY_HEIGHT = 1000;
        /// <summary>
        /// The elevation unit used when printing messages.
        /// </summary>
        protected const string ELEVATION_UNIT = "ft";
        #endregion
        #region Constructors
        /// <summary>
        /// Creates a new aerial vehicle that is grounded.
        /// </summary>
        /// <param name="engine">The drive engine for the vehicle.</param>
        public AerialVehicle(IEngine engine)
        {
            Engine = engine;
            CurrentAltitude = 0;
            IsFlying = false;
        }
        #endregion
        #region Properties
        /// <summary>
        /// The engine used by this vehicle.
        /// </summary>
        public IEngine Engine { get; set; }
        /// <summary>
        /// Whether this vehicle is currently flying.
        /// </summary>
        public bool IsFlying { get; protected set; }
        /// <summary>
        /// The current altitude of this vehicle.
        /// </summary>
        public int CurrentAltitude { get; set; }
        /// <summary>
        /// The maximum flying altitude for this vehicle.
        /// </summary>
        public int MaxAltitude { get; set; }
        #endregion
        #region Elevation Adjustment Methods
        /// <summary>
        /// Flys the vehicle down by the default height step.
        /// </summary>
        public void FlyDown()
            => FlyDown(DEFAULT_FLY_HEIGHT);
        /// <summary>
        /// Flys down by a specific delta altitude.
        /// Will not fly down if delta will contact ground.
        /// </summary>
        /// <param name="howMuch">How much to fly down.</param>
        public void FlyDown(int howMuch)
        {
            int newAltitude = CurrentAltitude - howMuch;
            if (newAltitude >= 0)
                CurrentAltitude = newAltitude;
        }
        /// <summary>
        /// Flys the vehicle up by the default height step.
        /// </summary>
        public void FlyUp()
            => FlyUp(DEFAULT_FLY_HEIGHT);
        /// <summary>
        /// Flys up by a specific delta altitude.
        /// Will not fly up if delta will exceed height limit.
        /// </summary>
        /// <param name="howMuch">How much to fly up.</param>
        public void FlyUp(int howMuch)
        {
            int newAltitude = CurrentAltitude + howMuch;
            // 0 is a sentinel value for no max altitude.
            if (MaxAltitude == 0 || newAltitude <= MaxAltitude)
                CurrentAltitude = newAltitude;
        }
        #endregion
        #region Flight State Methods
        /// <summary>
        /// Starts the engine on the vehicle.
        /// </summary>
        public virtual void StartEngine()
            => Engine.Start();
        /// <summary>
        /// Stops the engine on the vehicle,
        /// only if the vehicle is grounded.
        /// </summary>
        public virtual void StopEngine()
        {
            // Only stop if the altitude is at zero.
            if (CurrentAltitude == 0)
            {
                Engine.Stop();
                IsFlying = false;
            }
        }
        /// <summary>
        /// Takes off the vehicle if the engine is started.
        /// </summary>
        /// <returns>A message about whether the vehicle took off.</returns>
        public virtual string TakeOff()
        {
            if (Engine.IsStarted && !IsFlying)
                IsFlying = true;
            return IsFlying ?
                $"{this} is flying." :
                $"{this} can't take off. Its engine hasn't started.";
        }
        #endregion
        #region About Methods
        /// <summary>
        /// A message about this vehicle.
        /// </summary>
        /// <returns>A string containing state about this vehicle.</returns>
        public virtual string About()
            => $"This {this} has a max altitude of {MaxAltitude} {ELEVATION_UNIT}." +
                Environment.NewLine +
                $"Its current altitude is {CurrentAltitude} {ELEVATION_UNIT}." +
                Environment.NewLine +
                Engine.About();
        #endregion
    }
}
