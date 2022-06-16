using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Baumax.Contract.Exceptions
{
    [Serializable]
    public class AnotherImportRunning: Exception
    {
        public AnotherImportRunning()
        { }
        public AnotherImportRunning(string message)
            : base(message)
        { }
        public AnotherImportRunning(SerializationInfo info, StreamingContext context)
            :base (info,context)
        { }
        public AnotherImportRunning(string message, Exception innerException)
            :base (message, innerException)
        { }

    }
}
