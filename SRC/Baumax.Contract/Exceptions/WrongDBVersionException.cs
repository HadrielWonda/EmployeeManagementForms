using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Baumax.Contract.Exceptions
{
    [Serializable]
    public class WrongDBVersionException: Exception
    {
        public WrongDBVersionException()
        { }
        public WrongDBVersionException(string message)
            : base(message)
        { }
        public WrongDBVersionException(SerializationInfo info, StreamingContext context)
            :base (info,context)
        { }
        public WrongDBVersionException(string message, Exception innerException)
            :base (message, innerException)
        { }

    }
}
