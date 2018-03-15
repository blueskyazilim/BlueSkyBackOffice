namespace BlueSky.Core.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public class AssemblyHarvester
    {
        /// <summary>
        /// Harvests the libraries in the executing assembly's folder.
        /// </summary>
        public static IEnumerable<Assembly> GetAllLibraries()
        {
            IList<Assembly> libraries = new List<Assembly>();

            string folderPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            var dllFiles = Directory.GetFiles(folderPath, "*.dll");

            foreach (string dllFile in dllFiles)
            {
                string fileExtension = Path.GetExtension(dllFile);

                if (fileExtension.ToLowerInvariant() == ".dll")
                {
                    string assemblyString = Path.GetFileNameWithoutExtension(dllFile);
                    Assembly assembly;

                    try
                    {
                        assembly = Assembly.Load(assemblyString);
                    }
                    catch (BadImageFormatException)
                    {
                        continue;
                    }

                    libraries.Add(assembly);
                }
            }

            return libraries;
        }

        public static IEnumerable<Assembly> GetLibrariesMarkedWith<TAttribute>()
            where TAttribute : Attribute
        {
            var libraries = GetAllLibraries();
            IList<Assembly> markedLibraries = new List<Assembly>();

            foreach (Assembly library in libraries)
            {
                if (Attribute.GetCustomAttribute(library,typeof(TAttribute)) != null)
                {
                    markedLibraries.Add(library);
                }
            }

            return markedLibraries;
        }
    }
}
