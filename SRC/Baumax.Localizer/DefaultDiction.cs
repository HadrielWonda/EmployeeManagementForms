using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Baumax.Localization
{
    public class ItemResource
    {
        private int _key;
        private string _keyword = String.Empty;
        private string _value = String.Empty;

        public int Key
        {
            get { return _key; }
            set { _key = value; }
        }
        public string KeyWord
        {
            get { return _keyword; }
            set { _keyword = value; }
        }
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public ItemResource(int aKey, string aKeyWord, string aValue)
        {
            Key = aKey;
            KeyWord = aKeyWord;
            Value = aValue;
        }
    }

    public class DefaultDiction
    {
        private Dictionary<int, ItemResource> _intToString = new Dictionary<int, ItemResource>();
        private Dictionary<string, ItemResource> _strToString = new Dictionary<string, ItemResource>();


        private static DefaultDiction _instance = null;

        public static void BuildDefaultResource(Assembly assembly, LocaleType localeType)
        {
            _instance = new DefaultDiction(assembly, localeType);
        }
        public static void BuildDefaultResource(Assembly assembly)
        {
            _instance = new DefaultDiction(assembly);
        }

        public static ItemResource[] GetEnglishResource()
        {
            return Loader.LoadResourcesEnglish(typeof(DefaultDiction).Assembly);
        }

        public static void BuildDefaultResource(LocaleType localeType)
        {
            _instance = new DefaultDiction(typeof(DefaultDiction).Assembly, localeType);
        }

        public static void BuildDefaultResource()
        {
            _instance = new DefaultDiction(typeof(DefaultDiction).Assembly);
        }
        protected DefaultDiction(Assembly assembly, LocaleType localeType)
        {
            AddArrayItems(Loader.LoadResources(assembly,localeType));
        }
        protected DefaultDiction(Assembly assembly)
        {
            ItemResource[] ress = Loader.LoadResources(assembly);
            AddArrayItems(ress);
        }

        private void AddArrayItems(ItemResource[] resources)
        {
            if (resources != null)
            {
                foreach (ItemResource ir in resources)
                {
#if DEBUG
                    if (_intToString.ContainsKey(ir.Key)) throw new Exception("Key exists - " + ir.Key.ToString());
#endif

                    _intToString[ir.Key] = ir;

                    if (ir.KeyWord != null && ir.KeyWord.Length != 0)
                    {
#if DEBUG
                        if (_strToString.ContainsKey(ir.KeyWord)) throw new Exception("KeyWord exists - " + ir.KeyWord);
#endif

                        _strToString[ir.KeyWord] = ir;
                    }
                }
            }
        }

        public static string Item(int key)
        {
            ItemResource ir = null;
            if (_instance != null)
                _instance._intToString.TryGetValue(key, out ir);
            return (ir == null) ? null : ir.Value;
        }
        public static string Item(string key)
        {
            ItemResource ir = null;
            if (_instance != null)
                _instance._strToString.TryGetValue(key, out ir);
            return (ir == null) ? null : ir.Value;

        }
        public static int GetKeyByWord(string keyWord)
        {
            ItemResource ir = null;
            if (_instance != null)
                _instance._strToString.TryGetValue(keyWord.ToLower(), out ir);
            return (ir == null) ? -1 : ir.Key;
        }
        public static List<ItemResource> ListResource
        {
            get
            {
                List<ItemResource> lst = new List<ItemResource>();
                if (_instance != null)
                {
                    foreach (ItemResource ir in _instance._intToString.Values)
                        lst.Add(ir);
                }

                return lst;
            }
        }

    }

    public enum LocaleType { English, German }

    internal class Loader
    {

        public static ItemResource[] LoadResources(Assembly assembly)
        {
            LocaleType localeType;
#if DEBUG
            localeType = LocaleType.English; //comment for German
#else
            localeType = LocaleType.German;
#endif
            return LoadResources(assembly, localeType);
        }

        public static ItemResource[] LoadResources(Assembly assembly, LocaleType localeType)
        {
            string _Locale = localeType.ToString();
            string[] names = assembly.GetManifestResourceNames();

            List<string> lst = new List<string>();
            string locale = string.Format(".{0}.", _Locale);
            foreach (string s in names)
            {
                if (s.EndsWith(".lng") && s.Contains(locale))
                    lst.Add(s);
            }

            names = lst.ToArray();

            List<ItemResource> lstResult = new List<ItemResource>();

            foreach (String resourcename in names)
            {
                ItemResource[] res = LoadResourceByName(assembly, resourcename);
                lstResult.AddRange(res);
            }


            return lstResult.ToArray();

        }
        public static ItemResource[] LoadResourcesEnglish(Assembly assembly)
        {
            
            
            string[] names = assembly.GetManifestResourceNames();

            List<string> lst = new List<string>();
            //foreach (string s in names) if (s.EndsWith(".lng")) lst.Add(s);
            string locale = string.Format(".{0}.", "English");
            foreach (string s in names)
            {
                if (s.EndsWith(".lng") && s.Contains(locale)) 
                    lst.Add(s);
            }

            names = lst.ToArray();

            List<ItemResource> lstResult = new List<ItemResource>();

            foreach (String resourcename in names)
            {
                ItemResource[] res = LoadResourceByName(assembly, resourcename);
                lstResult.AddRange(res);
            }


            return lstResult.ToArray();

        }
        private static Stream getResourceStream(Assembly assembly, string resourcename)
        {
            return assembly.GetManifestResourceStream(resourcename);
        }
        private static ItemResource[] LoadResourceByName(Assembly assembly, string resourcename)
        {
            List<ItemResource> resList = new List<ItemResource>();

            XmlDocument xmlDoc = new XmlDocument();
            using (StreamReader sr = new StreamReader(getResourceStream(assembly, resourcename)))
                xmlDoc.LoadXml(sr.ReadToEnd());


            XmlNode sec = xmlDoc["items"];
            if (sec != null)
            {
                IEnumerator ie = sec.GetEnumerator();
                XmlNode node;
                while (ie.MoveNext())
                {
                    node = (XmlNode)ie.Current;
                    if (node.Name == "value")
                        resList.Add(new ItemResource(Convert.ToInt32(node.Attributes["key"].Value), node.Attributes["keyname"].Value.ToLower (), node.InnerText));
                }
            }

            return resList.ToArray();
        }

    }

}

