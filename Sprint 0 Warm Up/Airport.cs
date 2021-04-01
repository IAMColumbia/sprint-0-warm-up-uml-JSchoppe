using System;
using System.Collections.Generic;
using Sprint_0_Warm_Up.AerialVehicles;

namespace Sprint_0_Warm_Up
{
    /// <summary>
    /// A facility where aerial vehicles can land and takeoff.
    /// </summary>
    public sealed class Airport
    {
        #region Immutable Fields
        private readonly int maxVehicles;
        private readonly List<AerialVehicle> vehicles;
        #endregion
        #region Constructors
        /// <summary>
        /// Creates a new airport with given code and capacity.
        /// </summary>
        /// <param name="code">The identifier for the airport.</param>
        /// <param name="maxVehicles">The maximum number of vehicles at this airport.</param>
        public Airport(string code, int maxVehicles)
        {
            AirportCode = code;
            this.maxVehicles = maxVehicles;
            vehicles = new List<AerialVehicle>();
        }
        /// <summary>
        /// Creates a new airport with the given code and no capacity.
        /// </summary>
        /// <param name="code">The identifier for the airport.</param>
        public Airport(string code) : this(code, 0)
        {
            
        }
        #endregion
        #region Properties
        /// <summary>
        /// The identifying code for this airport.
        /// </summary>
        public string AirportCode { get; set; }
        #endregion
        #region Take Off Methods
        /// <summary>
        /// Makes the vehicle leave this airport.
        /// </summary>
        /// <param name="aerialVehicle">The vehicle to leave.</param>
        /// <returns>A message about whether the vehicle was able to leave.</returns>
        public string TakeOff(AerialVehicle aerialVehicle)
        {
            // Make sure the plane can take off.
            if (aerialVehicle is null)
                throw new ArgumentNullException("aerialVehicle", "Aerial vehicle cannot be null.");
            else if (!vehicles.Contains(aerialVehicle))
                return $"{aerialVehicle} can't takeoff because it is not at this airport.";
            else
            {
                // Get the takeoff message and remove
                // the vehicle from the airport.
                string message = aerialVehicle.TakeOff();
                if (aerialVehicle.IsFlying)
                    vehicles.Remove(aerialVehicle);
                return message;
            }
        }
        /// <summary>
        /// Takes off all vehicles at this airport.
        /// </summary>
        /// <returns>A message about which planes were able to take off.</returns>
        public string AllTakeOff()
        {
            // Return a message if no vehicles.
            if (vehicles.Count == 0)
                return $"No vehicles are at {this} with code {AirportCode}.";
            else
            {
                // Call take off for all vehicles.
                string messagesAccumulator = string.Empty;
                foreach (AerialVehicle vehicle in vehicles)
                    messagesAccumulator += TakeOff(vehicle) + Environment.NewLine;
                // Removes the final NewLine.
                return messagesAccumulator.Remove(messagesAccumulator.Length - Environment.NewLine.Length);
            }
        }
        #endregion
        #region Land Methods
        /// <summary>
        /// Makes the vehicle land at this airport.
        /// </summary>
        /// <param name="aerialVehicle">The vehicle to land.</param>
        /// <returns>A message about whether the vehicle was able to land.</returns>
        public string Land(AerialVehicle aerialVehicle)
        {
            // Make sure the plane can land.
            if (aerialVehicle is null)
                throw new ArgumentNullException("aerialVehicle", "Aerial vehicle cannot be null.");
            else if (vehicles.Count >= maxVehicles)
                return $"{aerialVehicle} can't land because the airport is full.";
            else
            {
                // Fly the plane down and stop the engine.
                aerialVehicle.FlyDown(aerialVehicle.CurrentAltitude);
                aerialVehicle.StopEngine();
                if (aerialVehicle.IsFlying)
                    return $"{aerialVehicle} was not able to land.";
                else
                {
                    // Add the vehicle to the airport.
                    vehicles.Add(aerialVehicle);
                    return $"{aerialVehicle} landed.";
                }
            }
        }
        /// <summary>
        /// Lands as many planes from the collection as this airport can hold.
        /// </summary>
        /// <param name="landingVehicles">The vehicles to land.</param>
        /// <returns>A message about which vehicles were able to land.</returns>
        public string Land(IList<AerialVehicle> landingVehicles)
        {
            // Make sure the collection is valid.
            if (landingVehicles is null)
                throw new ArgumentNullException("landingVehicles", "Landing vehicles cannot be null.");
            else if (landingVehicles.Count == 0)
                return string.Empty;
            else
            {
                // Call land for all vehicles.
                string messagesAccumulator = string.Empty;
                foreach (AerialVehicle aerialVehicle in landingVehicles)
                    messagesAccumulator += Land(aerialVehicle) + Environment.NewLine;
                // Removes the final NewLine.
                return messagesAccumulator.Remove(messagesAccumulator.Length - Environment.NewLine.Length);
            }
        }
        #endregion
    }
}
