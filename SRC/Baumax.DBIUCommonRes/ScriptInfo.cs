using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.DBIUCommon
{
    public class ScriptInfo
    {
        public readonly string Assembly;
        public readonly string Path;
        public ScriptInfo(string assembly, string path)
        {
            Assembly = assembly;
            Path = path;
        }
    }
}
