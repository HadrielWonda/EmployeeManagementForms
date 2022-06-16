using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Baumax.Scheduler.Config
{
    public class ConfigElementCollection : ConfigurationElementCollection
    {
        public ConfigElementCollection()
        {
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigElement();
        }


        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            ConfigElement cfg = new ConfigElement();
            cfg.Name = elementName;
            return cfg;
        }


        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigElement)element).Name;
        }


        public new string AddElementName
        {
            get { return base.AddElementName; }
            set { base.AddElementName = value; }
        }

        public new string ClearElementName
        {
            get { return base.ClearElementName; }
            set { base.AddElementName = value; }
        }

        public new string RemoveElementName
        {
            get { return base.RemoveElementName; }
        }

        public new int Count
        {
            get { return base.Count; }
        }

        public ConfigElement this[int index]
        {
            get { return (ConfigElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public ConfigElement this[string Name]
        {
            get { return (ConfigElement)BaseGet(Name); }
        }

        public int IndexOf(ConfigElement cfg)
        {
            return BaseIndexOf(cfg);
        }

        public void Add(ConfigElement url)
        {
            BaseAdd(url);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(ConfigElement cfg)
        {
            if (BaseIndexOf(cfg) >= 0)
                BaseRemove(cfg.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }
}
