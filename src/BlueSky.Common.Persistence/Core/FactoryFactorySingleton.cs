namespace BlueSky.Common.Persistence.Core
{
    using BlueSky.Core.DesignByContract;
    using DomainModel;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class is a simple wrapper around <see cref="FactoryFactorySingleton" /> in
    /// order to shorten the number of chars required to get an
    /// <see cref="IFactory" /> impl instance.
    /// </summary>
    public class Fac
    {
        public static TFactory tory<TFactory>()
            where TFactory : IFactory
        {
            return FactoryFactorySingleton.Instance.GetFactory<TFactory>();
        }
    }

    /// <summary>
    /// Represents the factory class responsible for handing out instances of
    /// IFactory classes in the domain model.
    /// </summary>
    public sealed class FactoryFactorySingleton : FactoryBase
    {
        static FactoryFactorySingleton() { }

        private FactoryFactorySingleton()
        {
            this.factories = new Dictionary<string, object>();
        }

        public TFactory GetFactory<TFactory>()
            where TFactory : IFactory
        {
            return (TFactory)GetFactory(typeof(TFactory));
        }

        public IFactory GetFactory(Type factoryType)
        {
            Require.That(factoryType, Is.NotNull);

            if (!typeof(IFactory).IsAssignableFrom(factoryType))
            {
                throw new PersistenceException("Specified factory type must be an IFactory.");
            }

            var factoryInstance = GetFactory(factoryType.FullName);

            if (factoryInstance == null)
            {
                factoryInstance = CreateInstance(factoryType);

                if (factoryInstance != null)
                {
                    this.factories.Add(factoryType.FullName, factoryInstance);
                }
            }

            return (IFactory)factoryInstance;
        }

        public object GetFactory(string factoryTypeFullName)
        {
            object instance = null;

            if (this.factories.TryGetValue(factoryTypeFullName, out instance))
            {
                return instance;
            }

            return null;
        }

        private Dictionary<string, object> factories;

        internal static readonly FactoryFactorySingleton Instance = new FactoryFactorySingleton();
    }
}
