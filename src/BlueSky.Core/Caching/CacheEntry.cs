namespace BlueSky.Core.Caching
{
    using System;

    /// <summary>
    /// Represents a single cache entry.
    /// </summary>
    internal class CacheEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheEntry"/>
        /// class.
        /// </summary>
        public CacheEntry(int cacheVersion, object value)
        {
            this.CacheVersion = cacheVersion;
            this.Value = value;
        }

        /// <summary>
        /// Gets the cache version of the entry.
        /// </summary>
        public int CacheVersion { get; private set; }

        /// <summary>
        /// Gets the value of entry.
        /// </summary>
        public object Value { get; private set; }
    }
}
