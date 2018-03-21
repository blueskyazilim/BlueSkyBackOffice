namespace BlueSky.Common.Persistence.Core
{
    using BlueSky.Core;
    using BlueSky.Core.DesignByContract;
    using DomainModel;
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Serves as the base class for factory classes resolving repository
    /// interface dependencies of classes using 'dependency injection through fields' method.
    /// </summary>
    public abstract class FactoryBase
    {
        protected object CreateInstance(Type dependentType)
        {
            Require.That(dependentType, Is.NotNull);

            string dependentTypeFullName = dependentType.FullName;

            if (dependentType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Any())
            {
                ThrowInvalidDependentException(dependentTypeFullName);
            }

            var dependentTypePublicCtors = dependentType.GetConstructors(BindingFlags.Instance | BindingFlags.Public);

            if (dependentTypePublicCtors.Length < 1 || dependentTypePublicCtors.Length > 2)
            {
                ThrowInvalidDependentException(dependentTypeFullName);
            }

            var parameterlessCtor = dependentTypePublicCtors.SingleOrDefault(x => x.GetParameters().Length == 0);

            if (parameterlessCtor == null)
            {
                ThrowInvalidDependentException(dependentTypeFullName);
            }

            ConstructorInfo ctorWithDependencyArgs = null;
            if (dependentTypePublicCtors.Length == 2)
            {
                ctorWithDependencyArgs = dependentTypePublicCtors.SingleOrDefault(x => x.GetParameters().Length > 0);

                if (ctorWithDependencyArgs == null)
                {
                    ThrowInvalidDependentException(dependentTypeFullName);
                }
            }

            if (parameterlessCtor == ctorWithDependencyArgs)
            {
                throw new BlueSkyBugException();
            }

            var typeRepositoryDependencyFields = dependentType
                .GetFields(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => typeof(IRepository).IsAssignableFrom(x.FieldType));

            if (ctorWithDependencyArgs != null)
            {
                var ctorWithDependencyArgsParameters = ctorWithDependencyArgs.GetParameters();

                if (ctorWithDependencyArgsParameters.Any(x => !typeof(IRepository).IsAssignableFrom(x.ParameterType)))
                {
                    ThrowInvalidDependentException(dependentTypeFullName);
                }

                if (!ctorWithDependencyArgsParameters
                    .Select(x => x.ParameterType.FullName)
                    .OrderBy(x => x).SequenceEqual(typeRepositoryDependencyFields.Select(x => x.FieldType.FullName)
                    .OrderBy(x => x)))
                {
                    ThrowInvalidDependentException(dependentTypeFullName);
                }
            }

            object instance = Activator.CreateInstance(dependentType);

            foreach (var repositoryDependency in typeRepositoryDependencyFields)
            {
                var repositoryInstance = Re.po(repositoryDependency.FieldType);
                repositoryDependency.SetValue(instance, repositoryInstance);
            }

            return instance;
        }

        private void ThrowInvalidDependentException(string dependentTypeFullName)
        {
            throw new PersistenceException($"Invalid dependent class: '{dependentTypeFullName}'");
        }
    }
}
