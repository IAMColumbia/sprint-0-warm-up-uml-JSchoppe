using System;

namespace Sprint_0_Warm_Up
{
    public sealed class ToyPlane : Airplane
    {
        private const int TOY_PLANE_MAX_ALTITUDE = 50;

        private bool isWoundUp;

        public ToyPlane()
        {
            MaxAltitude = TOY_PLANE_MAX_ALTITUDE;
        }

        public override void StartEngine()
        {
            if (isWoundUp && !Engine.IsStarted)
                Engine.Start();
        }

        public void WindUp()
        {
            isWoundUp = true;
        }

        public void UnWind()
        {
            isWoundUp = false;
        }

        public override string TakeOff()
        {
            if (!isWoundUp)
                return $"{this} can't take off. It's not wound up.";
            else
                return base.TakeOff();
        }

        public override string About()
        {
            return base.About() + Environment.NewLine +
                $"It's {(isWoundUp ? "wound up" : "unwound")}.";
        }
    }
}
