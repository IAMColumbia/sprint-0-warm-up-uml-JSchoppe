using System;
using System.Collections.Generic;

namespace Sprint_0_Warm_Up
{
    public sealed class Airport
    {
        private readonly int maxVehicles;
        private readonly List<AerialVehicle> vehicles;

        public Airport(string code, int maxVehicles)
        {
            AirportCode = code;
            this.maxVehicles = maxVehicles;
            vehicles = new List<AerialVehicle>();
        }
        public Airport(string code) : this(code, 0)
        {
            
        }

        public string AirportCode { get; set; }

        public string TakeOff(AerialVehicle aerialVehicle)
        {
            if (aerialVehicle is null)
                throw new ArgumentNullException("aerialVehicle", "Aerial vehicle cannot be null.");
            else if (!vehicles.Contains(aerialVehicle))
                return $"{aerialVehicle} can't takeoff because it is not at this airport.";
            else
            {
                string message = aerialVehicle.TakeOff();
                if (aerialVehicle.IsFlying)
                    vehicles.Remove(aerialVehicle);
                return message;
            }
        }
        public string AllTakeOff()
        {
            if (vehicles.Count == 0)
                return $"No vehicles are at {this} with code {AirportCode}.";
            else
            {
                string messagesAccumulator = string.Empty;
                foreach (AerialVehicle vehicle in vehicles)
                    messagesAccumulator += TakeOff(vehicle) + Environment.NewLine;
                // Required to remove the final NewLine.
                return messagesAccumulator.Remove(messagesAccumulator.Length - Environment.NewLine.Length);
            }
        }

        public string Land(AerialVehicle aerialVehicle)
        {
            if (aerialVehicle is null)
                throw new ArgumentNullException("aerialVehicle", "Aerial vehicle cannot be null.");
            else if (vehicles.Count >= maxVehicles)
                return $"{aerialVehicle} can't land because the airport is full.";
            else
            {
                aerialVehicle.FlyDown(aerialVehicle.CurrentAltitude);
                aerialVehicle.StopEngine();
                if (aerialVehicle.IsFlying)
                    // This line is literally untestable because it
                    // implements a case that doesn't yet exist in
                    // any subclass of AerialVehicle.
                    return $"{aerialVehicle} was not able to land.";
                else
                {
                    vehicles.Add(aerialVehicle);
                    return $"{aerialVehicle} landed.";
                }
            }
        }
        public string Land(IList<AerialVehicle> landingVehicles)
        {
            if (landingVehicles is null)
                throw new ArgumentNullException("landingVehicles", "Landing vehicles cannot be null.");
            else if (landingVehicles.Count == 0)
                return string.Empty;
            else
            {
                string messagesAccumulator = string.Empty;
                foreach (AerialVehicle aerialVehicle in landingVehicles)
                    messagesAccumulator += Land(aerialVehicle) + Environment.NewLine;
                // Required to remove the final NewLine.
                return messagesAccumulator.Remove(messagesAccumulator.Length - Environment.NewLine.Length);
            }
        }
    }
}
