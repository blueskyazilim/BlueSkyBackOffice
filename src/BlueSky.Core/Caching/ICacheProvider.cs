namespace BlueSky.Core.Caching
{
    /// <summary>
    /// Defines the contract for application level cache providers.
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// Returns the entry with the specified key from the cache.
        /// </summary>
        object Get(string key);

        /// <summary>
        /// Adds/updates the specified key/value pair on the cache.
        /// </summary>
        void Set(string key, object value, int lifetimeInMinutes);
    }
}
