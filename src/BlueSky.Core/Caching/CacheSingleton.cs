namespace BlueSky.Core.Caching
{
    using Reflection;
    using System;
    using System.Linq;

    public class Cache
    {
        /// <summary>
        /// Returns the entry with the specified key and version, if any, from the cache.
        /// </summary>
        public static object Get(string key, int cacheVersion)
        {
            return CacheSingleton.Instance.Get(key, cacheVersion);
        }

        /// <summary>
        /// Sets the value of the entry corresponding to the specified key, on the cache.
        /// </summary>
        public static void Set(string key, object value, int cacheVersion, int lifetimeInMinutes)
        {
            CacheSingleton.Instance.Set(key, value, cacheVersion, lifetimeInMinutes);
        }
    }

    /// <summary>
    /// Singleton class which is responsible for harvesting/using the active cache provider.
    /// </summary>
    public sealed class CacheSingleton
    {
        static CacheSingleton() { }

        private CacheSingleton()
        {
            var cacheProviderTypes = ClassHarvester.GetConcreteSubclassesOf<ICacheProvider>();

            if (cacheProviderTypes.Count() != 1)
            {
                throw new CachingException("Exactly one cache provider must exist.");
            }

            this.cacheProvider = (ICacheProvider)Activator.CreateInstance(cacheProviderTypes.ElementAt(0));
        }

        public object Get(string key, int cacheVersion)
        {
            object cacheEntryObject = this.cacheProvider.Get(key);
            if (cacheEntryObject == null)
            {
                return null;
            }

            if (!(cacheEntryObject is CacheEntry))
            {
                throw new CachingException("Unexprected cache entry type.");
            }

            var cacheEntry = (CacheEntry)cacheEntryObject;

            if (cacheEntry.CacheVersion != cacheVersion)
            {
                return null;
            }

            return cacheEntry.Value;
        }

        public void Set(string key, object value, int cacheVersion, int lifetimeInMinutes)
        {
            this.cacheProvider.Set(key, new CacheEntry(cacheVersion, value), lifetimeInMinutes);
        }

        private ICacheProvider cacheProvider;

        internal static readonly CacheSingleton Instance = new CacheSingleton();
    }
}
