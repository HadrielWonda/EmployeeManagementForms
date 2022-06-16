using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;

namespace Baumax.Contract
{
    [Serializable]
    public class SessionId : ILogicalThreadAffinative 
    {
        private Guid _Id;

        public SessionId(Guid id)
        {
            _Id = id;
        }

        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    }
}
