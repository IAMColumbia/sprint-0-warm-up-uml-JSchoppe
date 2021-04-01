namespace Sprint_0_Warm_Up
{
    /// <summary>
    /// Implements an about method returning a describing message.
    /// </summary>
    public interface IAboutable
    {
        #region Method Requirements
        /// <summary>
        /// A message about this object.
        /// </summary>
        /// <returns>An instance of the message as a string.</returns>
        string About();
        #endregion
    }
}
