using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Baumax.Util
{
	public static class EmbeddedResource
	{
        public static Stream GetResourceStream(Type resourceType, string resourceName)
        {
            Assembly assembly = resourceType.Assembly;
            return GetResourceStream(assembly, resourceName);
        }

        public static Stream GetResourceStream(Assembly assembly, string resourceName)
        {
            resourceName = string.Format("{0}.{1}", assembly.GetName().Name, resourceName.Replace('\\', '.'));
            return assembly.GetManifestResourceStream(resourceName);
        }

        public static void SaveResourceToFile(Type resourceType, string resourceName, string fileName)
        {
            SaveResourceToFile(resourceType, resourceName, fileName, Encoding.Unicode);
        }

        public static void SaveResourceToFile(Type resourceType, string resourceName, string fileName, Encoding encoding)
        {
            Assembly assembly = resourceType.Assembly;
            SaveResourceToFile(assembly, resourceName, fileName, encoding);
        }

        public static void SaveResourceToFile(Assembly assembly, string resourceName, string fileName)
        {
            SaveResourceToFile(assembly, resourceName, fileName, Encoding.Unicode);
        }
        
        public static void SaveResourceToFile(Assembly assembly, string resourceName, string fileName, Encoding encoding)
        {
            using (StreamReader sr = new StreamReader(GetResourceStream(assembly, resourceName)))
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, encoding))
                {
                    while (sr.Peek() >= 0)
                    {
                        sw.WriteLine(sr.ReadLine());
                    }
                }
            }
        }

    }
}
