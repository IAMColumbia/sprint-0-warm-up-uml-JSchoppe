namespace Sprint_0_Warm_Up.Engines
{
    /// <summary>
    /// Base class for engines.
    /// </summary>
    public class Engine : IEngine
    {
        #region Constructors
        /// <summary>
        /// Creates a new engine that is not started by default.
        /// </summary>
        public Engine()
        {
            IsStarted = false;
        }
        #endregion
        #region Engine Properties
        /// <summary>
        /// Whether the engine is currently started.
        /// </summary>
        public bool IsStarted { get; protected set; }
        #endregion
        #region Engine Base Method Implementations
        /// <summary>
        /// Starts the engine.
        /// </summary>
        public virtual void Start()
            => IsStarted = true;
        /// <summary>
        /// Stops the engine.
        /// </summary>
        public virtual void Stop()
            => IsStarted = false;
        /// <summary>
        /// Creates a message about this engine.
        /// </summary>
        /// <returns>A message containing engine state.</returns>
        public virtual string About()
            => $"{this} is {(IsStarted ? "started" : "not started")}.";
        #endregion
    }
}
