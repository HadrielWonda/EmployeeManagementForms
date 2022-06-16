using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;

namespace Baumax.Scheduler.Config
{
    public class ConfigElement : ConfigurationElement
    {
        public ConfigElement()
        {
        }

        [ConfigurationProperty("Name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string) this["Name"]; }
            set {this["Name"] = value; }
        }

        [ConfigurationProperty("TypeName", IsRequired = true)]
        public string TypeName
        {
            get { return (string)this["TypeName"]; }
            set { this["TypeName"] = value; }
        }

        [ConfigurationProperty("Config", IsRequired = true, IsDefaultCollection = false)]
        public string Config
        {
            get { return (string)this["Config"]; }
            set { this["Config"] = value; }
        }
    }
}
