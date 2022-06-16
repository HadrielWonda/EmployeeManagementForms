using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace Baumax.Import.Scheduler
{
    [Serializable]
    public class AnotherDeleteFilesOutOfDateRunning: Exception
    {
        public AnotherDeleteFilesOutOfDateRunning()
        { }
        public AnotherDeleteFilesOutOfDateRunning(string message)
            : base(message)
        { }
        public AnotherDeleteFilesOutOfDateRunning(SerializationInfo info, StreamingContext context)
            :base (info,context)
        { }
        public AnotherDeleteFilesOutOfDateRunning(string message, Exception innerException)
            :base (message, innerException)
        { }
    }
}
