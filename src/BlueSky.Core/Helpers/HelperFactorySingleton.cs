namespace BlueSky.Core.Helpers
{
    using Reflection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Hel
    {
        public static THelper per<THelper>()
            where THelper : IHelper
        {
            return HelperFactorySingleton.Instance.GetHelper<THelper>();
        }
    }

    public sealed class HelperFactorySingleton
    {
        static HelperFactorySingleton() { }

        private HelperFactorySingleton()
        {
            this.helperInstances = new Dictionary<string, object>();

            var helperTypes = ClassHarvester.GetConcreteSubclassesOf<IHelper>();

            foreach (Type helperType in helperTypes)
            {
                if (helperType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Any())
                {
                    throw new HelperFactorySingletonException($"Invalid dependent class: '{helperType.FullName}'");
                }

                var helperTypeCtors = helperType.GetConstructors(BindingFlags.Instance | BindingFlags.Public);

                if (helperTypeCtors.Length != 1)
                {
                    throw new HelperFactorySingletonException($"Invalid dependent class: '{helperType.FullName}'");
                }

                var parameterlessCtor = helperTypeCtors.SingleOrDefault(x => x.GetParameters().Length == 0);

                if (parameterlessCtor == null)
                {
                    throw new HelperFactorySingletonException($"Invalid dependent class: '{helperType.FullName}'");
                }

                try
                {
                    object instance = Activator.CreateInstance(helperType);

                    if (instance == null)
                    {
                        throw new HelperFactorySingletonException($"Invalid dependent class: '{helperType.FullName}'");
                    }

                    this.helperInstances.Add(helperType.FullName, instance);
                }
                catch (Exception ex)
                {
                    throw new HelperFactorySingletonException($"Invalid dependent class: '{helperType.FullName}'", ex);
                }
            }
        }

        public THelper GetHelper<THelper>()
            where THelper : IHelper
        {
            return (THelper)GetHelper(typeof(THelper));
        }

        public IHelper GetHelper(Type helperType)
        {
            if (!typeof(IHelper).IsAssignableFrom(helperType))
            {
                throw new HelperFactorySingletonException("Specified helper type must be an IHelper");
            }

            return (IHelper)GetHelper(helperType.FullName);
        }

        public object GetHelper(string helperTypeFullName)
        {
            object instance;

            if (!this.helperInstances.TryGetValue(helperTypeFullName, out instance))
            {
                throw new HelperFactorySingletonException("Specified helper type must be an IHelper");
            }

            return instance;
        }

        private Dictionary<string, object> helperInstances;

        internal static readonly HelperFactorySingleton Instance = new HelperFactorySingleton();
    }
}
