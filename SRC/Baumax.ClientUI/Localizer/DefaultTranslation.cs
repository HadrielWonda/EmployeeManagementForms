using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Baumax.ClientUI
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

        public static void BuildDefaultResource(Assembly assembly)
        {
            _instance = new DefaultDiction(assembly);
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
                _instance._strToString.TryGetValue(keyWord, out ir);
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


    internal class Loader
    {
        
        public static ItemResource[] LoadResources(Assembly assembly)
        {
            string[] names = assembly.GetManifestResourceNames();

            List<string> lst = new List<string>();
            foreach (string s in names) if (s.EndsWith(".lng")) lst.Add(s);

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
                        resList.Add(new ItemResource(Convert.ToInt32(node.Attributes["key"].Value), node.Attributes["keyname"].Value, node.InnerText));
                }
            }

            return resList.ToArray();
        }

    }

}
