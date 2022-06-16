using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Baumax.Contract.Exceptions
{
    [Serializable]
    public class AccessDeniedException : ApplicationException
    {
        // Summary:
        //     Initializes a new instance of the AccessDeniedException class.
        public AccessDeniedException()
            : base()
        {}

        //
        // Summary:
        //     Initializes a new instance of the AccessDeniedException class with
        //     a specified error message.
        //
        // Parameters:
        //   message:
        //     A message that describes the error.
        public AccessDeniedException(string message)
            : base(message)
        { }
        //
        // Summary:
        //     Initializes a new instance of the AccessDeniedException class with
        //     serialized data.
        //
        // Parameters:
        //   context:
        //     The contextual information about the source or destination.
        //
        //   info:
        //     The object that holds the serialized object data.
        protected AccessDeniedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        //
        // Summary:
        //     Initializes a new instance of the AccessDeniedException class with
        //     a specified error message and a reference to the inner exception that is
        //     the cause of this exception.
        //
        // Parameters:
        //   message:
        //     The error message that explains the reason for the exception.
        //
        //   innerException:
        //     The exception that is the cause of the current exception. If the innerException
        //     parameter is not a null reference, the current exception is raised in a catch
        //     block that handles the inner exception.
        public AccessDeniedException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}