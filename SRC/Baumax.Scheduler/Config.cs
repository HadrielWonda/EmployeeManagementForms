using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Baumax.Scheduler
{
    public sealed class Config : ApplicationSettingsBase
    {
        [ApplicationScopedSetting]
        public String FormText
        {
            get { return (String)this["FormText"]; }
            set { this["FormText"] = value; }
        }
    }
}
