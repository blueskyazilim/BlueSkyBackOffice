namespace BlueSky.Common.Persistence.Core
{
    using BlueSky.Core.Attributes;
    using BlueSky.Core.DesignByContract;
    using BlueSky.Core.Reflection;
    using DomainModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class is a simple wrapper around
    /// <see cref="RepositoryFactorySingleton" /> in order to shorten the number
    /// of chars required to get a repository impl instance.
    /// </summary>
    public class Re
    {
        public static TRepositoryInterface po<TRepositoryInterface>()
            where TRepositoryInterface : IRepository
        {
            return RepositoryFactorySingleton.Instance.GetRepository<TRepositoryInterface>();
        }

        internal static object po(Type repositoryInterfaceType)
        {
            return RepositoryFactorySingleton.Instance.GetRepository(repositoryInterfaceType);
        }
    }

    /// <summary>
    /// Represents the singleton that is responsible for harvesting, caching and
    /// handing out concrete repository instances.
    /// </summary>
    public sealed class RepositoryFactorySingleton
    {
        static RepositoryFactorySingleton() { }

        private RepositoryFactorySingleton()
        {
            this.repositoryInstances = new Dictionary<string, object>();

            var repositoryInterfaceTypes = AssemblyHarvester.GetLibrariesMarkedWith<DomainModelAssemblyAttribute>()
                .SelectMany(x => x.GetTypes())
                .Where(x =>
                    x.IsInterface
                    && typeof(IRepository).IsAssignableFrom(x)
                    && !x.ContainsGenericParameters
                    && x != typeof(IRepository));

            var persistenceTypes = AssemblyHarvester.GetLibrariesMarkedWith<PersistenceAssemblyAttribute>()
                .SelectMany(x=>x.GetTypes())
                .Where(x =>
                    x.IsClass
                    && typeof(IRepository).IsAssignableFrom(x)
                    && !x.ContainsGenericParameters
                    && !x.IsAbstract);

            foreach (var repositoryInterfaceType in repositoryInterfaceTypes)
            {
                var repositoryImplTypes = persistenceTypes
                    .Where(x => repositoryInterfaceType.IsAssignableFrom(x));

                if (repositoryImplTypes.Count() != 1)
                {
                    continue;
                }

                var instance = Activator.CreateInstance(repositoryImplTypes.ElementAt(0));

                if (instance != null)
                {
                    this.repositoryInstances.Add(repositoryInterfaceType.FullName, instance);
                }
            }
        }

        public TRepositoryInterface GetRepository<TRepositoryInterface>()
            where TRepositoryInterface : IRepository
        {
            return (TRepositoryInterface)GetRepository(typeof(TRepositoryInterface));
        }

        public object GetRepository(Type repositoryInterfaceType)
        {
            Require.That(repositoryInterfaceType, Is.NotNull);

            if (!typeof(IRepository).IsAssignableFrom(repositoryInterfaceType))
            {
                throw new PersistenceException("Specified repository type must be an IRepository");
            }

            return GetRepository(repositoryInterfaceType.FullName);
        }

        public object GetRepository(string repositoryInterfaceTypeFullName)
        {
            object instance;

            if (this.repositoryInstances.TryGetValue(repositoryInterfaceTypeFullName, out instance))
            {
                throw new PersistenceException("Specified repository type must be an IRepository");
            }

            return instance;
        }

        private Dictionary<string, object> repositoryInstances;

        internal static readonly RepositoryFactorySingleton Instance = new RepositoryFactorySingleton();
    }
}
