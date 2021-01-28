using System;

namespace Sprint_0_Warm_Up
{
    public class ToyPlane : Airplane
    {
        private const int TOY_PLANE_MAX_ALTITUDE = 50;

        private bool isWoundUp;

        public ToyPlane()
        {
            MaxAltitude = TOY_PLANE_MAX_ALTITUDE;
        }

        public override void StartEngine()
        {
            throw new NotImplementedException();
        }

        public void WindUp()
        {
            throw new NotImplementedException();
        }

        public void UnWind()
        {
            throw new NotImplementedException();
        }

        public override string TakeOff()
        {
            throw new NotImplementedException();
        }

        public override string About()
        {
            throw new NotImplementedException();
        }
    }
}
