namespace Sprint_0_Warm_Up
{
    public sealed class Engine
    {
        public Engine()
        {
            IsStarted = false;
        }

        public bool IsStarted { get; private set; }

        public void Start()
        {
            IsStarted = true;
        }
        public void Stop()
        {
            IsStarted = false;
        }
        public string About()
        {
            return $"{this} is {(IsStarted ? "started" : "not started")}.";
        }
    }
}
