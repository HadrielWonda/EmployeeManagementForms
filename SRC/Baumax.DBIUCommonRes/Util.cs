using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Baumax.DBIUCommon
{
    public static class Util
    {
        public static Stream GetResourceStream(string resourceName, string assemblyName)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            return Util.GetResourceStream(resourceName, assembly);
        }
        public static Stream GetResourceStream(string resourceName, Assembly assembly)
        {
            resourceName = string.Format("{0}.{1}", assembly.GetName().Name, resourceName.Replace('\\', '.'));
            return assembly.GetManifestResourceStream(resourceName);
        }

        public static ScriptInfo[] GetScriptsToRun(bool sp_udf_Only)
        {
            string[] sections;
            if (sp_udf_Only)
                sections = new string[] { "udf", "sp", "sp_rpt", "triggers" };
            else
                sections = new string[] { "drop", "db", "udf", "sp", "sp_rpt", "views", "triggers", "data", "run" };

            XmlDocument xmlDoc = new XmlDocument();
            using (StreamReader sr = new StreamReader(GetResourceStream("Scripts.xml", Assembly.GetExecutingAssembly())))
                xmlDoc.LoadXml(sr.ReadToEnd());
            List<ScriptInfo> scripts = new List<ScriptInfo>();
            for (int i = 0; i < sections.Length; i++)
            {
                XmlNode sec = xmlDoc["scripts"][sections[i]];
                if (sec == null)
                    continue;
                string assemblyName = sec.Attributes["assembly"].Value;
                System.Collections.IEnumerator ie = sec.GetEnumerator();
                XmlNode node;
                while (ie.MoveNext())
                {
                    node = (XmlNode)ie.Current;
                    if (node.Name == "script")
                        scripts.Add(new ScriptInfo(assemblyName, node.Attributes["path"].Value));
                }
            }
            return scripts.ToArray();
        }

        public static string[] GetBatchToRun(StreamReader sr, string[,] parameters)
        {
            List<string> batchList = new List<string>();
            string line;
            string batchText = "";
            Regex rx = new Regex(@"^\s*GO+(?:--|\/\*|$|\s| .*)", RegexOptions.IgnoreCase);
            Match m;
            while ((line = sr.ReadLine()) != null)
            {
                m = rx.Match(line);
                if (!m.Success)
                {
                    for (int i = 0; i < parameters.GetLength(0); i++)
                        line = Regex.Replace(line, parameters[i, 0], parameters[i, 1], RegexOptions.IgnoreCase);
                    batchText += string.Format("{0}\n", line);
                }
                else
                {
                    batchList.Add(batchText);
                    batchText = "";
                }
            }
            if (!string.IsNullOrEmpty(batchText))
                batchList.Add(batchText);
            return batchList.ToArray();
        }
        
    }
}
