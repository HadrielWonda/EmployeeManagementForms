using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.ServerState
{
    [Serializable]
    public sealed class ServerStateData
    {
        private long _TotalMemory;
        private string _DbVersion;
        private string _ServerVersion;
        private List<object> _Parameters;
        
        public long TotalMemory
        {
            get { return _TotalMemory; }
            set { _TotalMemory = value; }
        }

        public string DbVersion
        {
            get { return _DbVersion; }
            set { _DbVersion = value; }
        }

        public string ServerVersion
        {
            get { return _ServerVersion; }
            set { _ServerVersion = value; }
        }

        public List<object> Parameters
        {
            get { return _Parameters; }
            set { _Parameters = value; }
        }
    }
}
