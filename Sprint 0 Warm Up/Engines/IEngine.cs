namespace Sprint_0_Warm_Up.Engines
{
    /// <summary>
    /// Implements basic engine functionality and state.
    /// </summary>
    public interface IEngine : IAboutable
    {
        #region Property Requirements
        /// <summary>
        /// Whether the engine is currently started.
        /// </summary>
        bool IsStarted { get; }
        #endregion
        #region Method Requirements
        /// <summary>
        /// Starts the engine.
        /// </summary>
        void Start();
        /// <summary>
        /// Stops the engine.
        /// </summary>
        void Stop();
        #endregion
    }
}
