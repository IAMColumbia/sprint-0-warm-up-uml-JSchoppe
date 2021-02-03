using System;

namespace Sprint_0_Warm_Up
{
    public abstract class AerialVehicle
    {
        private const int DEFAULT_FLY_HEIGHT = 1000;
        protected const string ELEVATION_UNIT = "ft";

        public AerialVehicle()
        {
            Engine = new Engine();
            CurrentAltitude = 0;
            IsFlying = false;
        }

        public Engine Engine { get; set; }
        public int CurrentAltitude { get; set; }
        public bool IsFlying { get; protected set; }
        public int MaxAltitude { get; set; }

        public virtual void StartEngine()
        {
            Engine.Start();
        }
        public virtual void StopEngine()
        {
            if (CurrentAltitude == 0)
            {
                Engine.Stop();
                IsFlying = false;
            }
        }

        public virtual string TakeOff()
        {
            if (Engine.IsStarted && !IsFlying)
                IsFlying = true;
            return IsFlying ? $"{this} is flying." : $"{this} can't take off. Its engine hasn't started.";
        }

        public void FlyDown() { FlyDown(DEFAULT_FLY_HEIGHT); }
        public void FlyDown(int howMuch)
        {
            int newAltitude = CurrentAltitude - howMuch;
            if (newAltitude >= 0)
                CurrentAltitude = newAltitude;
        }

        public void FlyUp() { FlyUp(DEFAULT_FLY_HEIGHT); }
        public void FlyUp(int howMuch)
        {
            int newAltitude = CurrentAltitude + howMuch;
            // 0 is a sentinel value for no max altitude.
            if (MaxAltitude == 0 || newAltitude <= MaxAltitude)
                CurrentAltitude = newAltitude;
        }

        public virtual string About()
        {
            return $"This {this} has a max altitude of {MaxAltitude} {ELEVATION_UNIT}." +
                Environment.NewLine +
                $"Its current altitude is {CurrentAltitude} {ELEVATION_UNIT}." +
                Environment.NewLine +
                Engine.About();
        }
    }
}