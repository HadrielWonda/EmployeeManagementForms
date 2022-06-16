using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace Baumax.Import.Scheduler
{
    [Serializable]
    public class ImportCompleteWithErrors: Exception
    {
        public ImportCompleteWithErrors()
        { }
        public ImportCompleteWithErrors(string message)
            : base(message)
        { }
        public ImportCompleteWithErrors(SerializationInfo info, StreamingContext context)
            :base (info,context)
        { }
        public ImportCompleteWithErrors(string message, Exception innerException)
            :base (message, innerException)
        { }
    }
}
