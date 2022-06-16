using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Baumax.Contract.Exceptions
{
    [Serializable]
    public class WrongClientVersionException: Exception
    {
        public WrongClientVersionException()
        { }
        public WrongClientVersionException(string message)
            : base(message)
        { }
        public WrongClientVersionException(SerializationInfo info, StreamingContext context)
            :base (info,context)
        { }
        public WrongClientVersionException(string message, Exception innerException)
            :base (message, innerException)
        { }

    }
}
