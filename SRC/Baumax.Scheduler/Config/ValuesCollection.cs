using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Scheduler.Config
{
    public class ValuesCollection : Dictionary<string, string>
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in this)
            {
                sb.AppendFormat("{0}={1};", pair.Key, pair.Value);
            }
            return sb.ToString();
        }

        //TODO: remake with regexps
        public static ValuesCollection FromString(string values)
        {
            ValuesCollection vc = new ValuesCollection();
            string[] pairs = values.Split(';');
            foreach (string s in pairs)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    string[] pair = s.Split('=');
                    vc.Add(pair[0], pair[1]);
                }
            }
            return vc;
        }
    }
}
