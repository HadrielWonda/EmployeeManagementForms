using System;
using System.Runtime.Serialization;

namespace Baumax.Contract.Exceptions.EntityExceptions
{
    [Serializable]
    public class UpdateException : SaveOrUpdateException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateException"/> class.
        /// </summary>
        public UpdateException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected UpdateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateException"/> class.
        /// </summary>
        /// <param name="innerException">Inner exception or null.</param>
        public UpdateException(Exception innerException)
            : base(innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">Inner exception or null.</param>
        public UpdateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="ids">The entity IDs.</param>
        /// <param name="innerException">Inner exception or null.</param>
        public UpdateException(string message, long[] ids, Exception innerException)
            : base(message, ids, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateException"/> class with a specified entity IDs list.
        /// </summary>
        /// <param name="ids">The entity IDs.</param>
        /// <param name="innerException">Inner exception or null.</param>
        public UpdateException(long[] ids, Exception innerException)
            : base(ids, innerException)
        {
        }
    }
}