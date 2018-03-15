namespace BlueSky.Core.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class ClassHarvester
    {
        /// <summary>
        /// Harvests the concrete subclasses of <typeparamref name="T"/> in 
        /// the executing assembly's folder.
        /// </summary>
        public static IEnumerable<Type> GetConcreteSubclassesOf<T>()
        {
            try
            {
                IList<Type> concreteSubclasses = new List<Type>();
                string folderPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);

                var dllAssemblyStrings = Directory.GetFiles(folderPath, "*.dll")
                    .Where(x => Path.GetExtension(x).ToLowerInvariant() == ".dll")
                    .Select(x => Path.GetFileNameWithoutExtension(x));

                var exeAssemblyStrings = Directory.GetFiles(folderPath, "*.exe")
                    .Where(x => Path.GetExtension(x).ToLowerInvariant() == ".exe")
                    .Select(x => Path.GetFileNameWithoutExtension(x));

                var assemblyStrings = dllAssemblyStrings.Concat(exeAssemblyStrings);

                foreach (string assemblyString in assemblyStrings)
                {
                    Assembly assembly;

                    try
                    {
                        assembly = Assembly.Load(assemblyString);
                    }
                    catch (FileLoadException)
                    {
                        continue;
                    }
                    catch (BadImageFormatException)
                    {
                        continue;
                    }

                    try
                    {
                        var types = assembly.GetTypes()
                            .Where(x => x.IsClass && !x.IsAbstract && typeof(T).IsAssignableFrom(x));

                        foreach (Type type in types)
                        {
                            concreteSubclasses.Add(type);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ClassHarvesterException("Exception throw while harvesting concrete subclasses.", ex);
                    }
                }

                return concreteSubclasses;
            }
            catch (ClassHarvesterException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ClassHarvesterException("Exception throw while harvesting concrete subclasses.", ex);
            }
        }

        public static IEnumerable<Type> GetConcreteSubclassesOf<T>(Assembly assembly)
        {
            try
            {
                var types = assembly.GetTypes()
                    .Where(x => x.IsClass && !x.IsAbstract && typeof(T).IsAssignableFrom(x));

                return types;
            }
            catch (Exception ex)
            {
                throw new ClassHarvesterException("Exception throw while harvesting concrete subclasses.", ex);
            }
        }
    }
}
