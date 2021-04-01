using System;
using Sprint_0_Warm_Up.Engines;

namespace Sprint_0_Warm_Up.AerialVehicles
{
    /// <summary>
    /// A toy model of an airplane.
    /// </summary>
    public sealed class ToyPlane : Airplane
    {
        #region Parameters
        /// <summary>
        /// The max altitude for toy planes.
        /// </summary>
        private const int TOY_PLANE_MAX_ALTITUDE = 50;
        #endregion
        #region State Fields
        private bool isWoundUp;
        #endregion
        #region Constructors
        /// <summary>
        /// Creates a new toy plane with the default max altitude.
        /// </summary>
        /// <param name="engine">The driving engine for the toy plane.</param>
        public ToyPlane(IEngine engine) : base(engine)
        {
            MaxAltitude = TOY_PLANE_MAX_ALTITUDE;
            isWoundUp = false;
        }
        #endregion
        #region Rubberband Winding State Methods
        /// <summary>
        /// Winds up the rubberband on the plane.
        /// </summary>
        public void WindUp()
            => isWoundUp = true;
        /// <summary>
        /// Unwinds the rubberband on the plane.
        /// </summary>
        public void UnWind()
            => isWoundUp = false;
        #endregion
        #region Flight State Method Overrides
        /// <summary>
        /// Starts the engine if the rubberband is wound up.
        /// </summary>
        public override void StartEngine()
        {
            if (isWoundUp && !Engine.IsStarted)
                Engine.Start();
        }
        /// <summary>
        /// Makes the toyplane take off.
        /// </summary>
        /// <returns>A message about whether the plane took off.</returns>
        public override string TakeOff()
        {
            if (!isWoundUp)
                return $"{this} can't take off. It's not wound up.";
            else
                return base.TakeOff();
        }
        #endregion
        #region About Overrides
        /// <summary>
        /// Creates a message about this toy plane.
        /// </summary>
        /// <returns>A string containing state about the toy plane.</returns>
        public override string About()
            => base.About() + Environment.NewLine +
                $"It's {(isWoundUp ? "wound up" : "unwound")}.";
        #endregion
    }
}
