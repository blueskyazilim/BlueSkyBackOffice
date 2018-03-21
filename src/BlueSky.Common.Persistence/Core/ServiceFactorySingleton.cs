namespace BlueSky.Common.Persistence.Core
{
    using BlueSky.Core.DesignByContract;
    using DomainModel;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class is a simple wrapper around <see cref="ServiceFactory" /> in
    /// order to shorten the number of chars required to get an
    /// <see cref="IService" /> impl instance.
    /// </summary>
    public class Ser
    {
        public static TService vice<TService>()
            where TService : IService
        {
            return ServiceFactorySingleton.Instance.GetService<TService>();
        }
    }

    /// <summary>
    /// Represents the service class responsible for handing out instances of
    /// IService classes in the domain model.
    /// </summary>
    public sealed class ServiceFactorySingleton : FactoryBase
    {
        static ServiceFactorySingleton() { }

        private ServiceFactorySingleton()
        {
            this.services = new Dictionary<string, object>();
        }

        public TService GetService<TService>()
            where TService : IService
        {
            return (TService)GetService(typeof(TService));
        }

        public IService GetService(Type serviceType)
        {
            Require.That(serviceType, Is.NotNull);

            if (!typeof(IService).IsAssignableFrom(serviceType))
            {
                throw new PersistenceException("Specified factory type must be an IService.");
            }

            var serviceInstance = GetService(serviceType.FullName);

            if (serviceInstance == null)
            {
                serviceInstance = CreateInstance(serviceType);

                if (serviceInstance != null)
                {
                    this.services.Add(serviceType.FullName, serviceInstance);
                }
            }

            return (IService)serviceInstance;
        }

        public object GetService(string serviceTypeFullName)
        {
            object instance = null;

            if (this.services.TryGetValue(serviceTypeFullName, out instance))
            {
                return instance;
            }

            return null;
        }

        private Dictionary<string, object> services;

        internal static readonly ServiceFactorySingleton Instance = new ServiceFactorySingleton();
    }
}
