namespace Sprint_0_Warm_Up
{
    public sealed class Drone : AerialVehicle
    {
        private const int DRONE_MAX_ALTITUDE = 500;

        public Drone()
        {
            MaxAltitude = DRONE_MAX_ALTITUDE;
        }
    }
}
