namespace GeneratedControllers.Contracts
{
    /// <summary>
    /// Marker interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContract<T>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public T Id { get; set; }
    }
}
