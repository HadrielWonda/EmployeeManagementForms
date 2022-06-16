using System;
using System.Runtime.Serialization;

namespace Baumax.Contract.Exceptions.EntityExceptions
{
    public enum EntityExceptionDataKey
    {
        InnerTypeName, InnerMessage, InnerSource, InnerStackTrace, InnerString
    }
    
    [Serializable]
    public class EntityException : ApplicationException
    {
        private long[] _ids;

        public long[] IDs
        {
            get { return _ids; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityException"/> class.
        /// </summary>
        public EntityException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected EntityException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityException"/> class.
        /// </summary>
        /// <param name="innerException">Inner exception or null.</param>
        public EntityException(Exception innerException)
            : base()
        {
            AddInnerExceptionData(innerException);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">Inner exception or null.</param>
        public EntityException(string message, Exception innerException)
            : base(message)
        {
            AddInnerExceptionData(innerException);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="ids">The entity IDs.</param>
        /// <param name="innerException">Inner exception or null.</param>
        public EntityException(string message, long[] ids, Exception innerException)
            : base(message)
        {
            _ids = ids;
            AddInnerExceptionData(innerException);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityException"/> class with a specified entity IDs list.
        /// </summary>
        /// <param name="ids">The entity IDs.</param>
        /// <param name="innerException">Inner exception or null.</param>
        public EntityException(long[] ids, Exception innerException)
            : base()
        {
            _ids = ids;
            AddInnerExceptionData(innerException);
        }

        /// <summary>
        /// Adds the inner exception data. Avoid serialization of innerException, send details through Data property.
        /// </summary>
        /// <param name="ex">The inner exception.</param>
        private void AddInnerExceptionData(Exception ex)
        {
            if (ex != null)
            {
                this.Data.Add(EntityExceptionDataKey.InnerTypeName, ex.GetType().FullName);
                this.Data.Add(EntityExceptionDataKey.InnerMessage, ex.Message);
                this.Data.Add(EntityExceptionDataKey.InnerSource, ex.Source);
                this.Data.Add(EntityExceptionDataKey.InnerStackTrace, ex.StackTrace);
                this.Data.Add(EntityExceptionDataKey.InnerString, ex.ToString());
            }
        }
    }
}