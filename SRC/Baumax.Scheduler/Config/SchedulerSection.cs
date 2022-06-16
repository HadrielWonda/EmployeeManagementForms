using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Baumax.Scheduler.Config
{
    internal sealed class SchedulerSection : ConfigurationSection
    {
        internal SchedulerSection()
        {
            Jobs = new ConfigElementCollection();
            Tasks = new ConfigElementCollection();
            Triggers = new ConfigElementCollection();
        }

        // Properties
        [ConfigurationProperty("Jobs")]
        public ConfigElementCollection Jobs
        {
            get { return (ConfigElementCollection)base["Jobs"]; }
            set { base["Jobs"] = value; }
        }

        [ConfigurationProperty("Tasks")]
        public ConfigElementCollection Tasks
        {
            get { return (ConfigElementCollection)base["Tasks"]; }
            set { base["Tasks"] = value; }
        }

        [ConfigurationProperty("Triggers")]
        public ConfigElementCollection Triggers
        {
            get { return (ConfigElementCollection)base["Triggers"]; }
            set { base["Triggers"] = value; }
        }

        // Properties
        [ConfigurationProperty("Login")]
        public string Login
        {
            get { return (string)base["Login"]; }
            set { base["Login"] = value; }
        }

        [ConfigurationProperty("Password")]
        public string Password
        {
            get { return (string)base["Password"]; }
            set { base["Password"] = value; }
        }
    }
}
