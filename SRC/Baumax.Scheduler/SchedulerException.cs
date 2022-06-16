using System;
using System.Runtime.Serialization;

namespace Baumax.Scheduler
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SchedulerException : ApplicationException
    {
        //
        public SchedulerException() { }

        //
        public SchedulerException(string message) : base(message) { }

        //
        public SchedulerException(string message, Exception innerException) : base(message, innerException) { }

        //
        protected SchedulerException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}