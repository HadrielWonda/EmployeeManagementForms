using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Baumax.Contract.Exceptions.EntityExceptions
{
    [Serializable]
    public enum EmployeeMergeError: int { UnknownInternalEmployee, UnknownExternalEmployee, NotSameNames, CantMerge, UnknownError};

    [Serializable]
    public class EmployeeMergeException: EntityException
    {
        EmployeeMergeError _EmployeeMergeError;

        public EmployeeMergeError EmployeeMergeError
        {
            get { return _EmployeeMergeError; }
            set { _EmployeeMergeError = value; }
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_EmployeeMergeError", _EmployeeMergeError);
        }

        /// Initializes a new instance of the <see cref="EmployeeMergeException"/> class.
        /// </summary>
        public EmployeeMergeException()
            : base()
        {
            _EmployeeMergeError = EmployeeMergeError.UnknownError;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeMergeException"/> class.
        /// </summary>
        /// <param name="employeeMergeError">The object that holds type of the merge error.</param>
        public EmployeeMergeException(EmployeeMergeError employeeMergeError)
            : this()
        {
            this._EmployeeMergeError = employeeMergeError;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeMergeException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected EmployeeMergeException(SerializationInfo info, StreamingContext context)
        {
            _EmployeeMergeError = (EmployeeMergeError)info.GetInt32("_EmployeeMergeError");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeMergeException"/> class.
        /// </summary>
        /// <param name="innerException">Inner exception or null.</param>
        public EmployeeMergeException(Exception innerException)
            : base(innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeMergeException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">Inner exception or null.</param>
        public EmployeeMergeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeMergeException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="ids">The entity IDs.</param>
        /// <param name="innerException">Inner exception or null.</param>
        public EmployeeMergeException(string message, long[] ids, Exception innerException)
            : base(message, ids, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeMergeException"/> class with a specified entity IDs list.
        /// </summary>
        /// <param name="ids">The entity IDs.</param>
        /// <param name="innerException">Inner exception or null.</param>
        public EmployeeMergeException(long[] ids, Exception innerException)
            : base(ids, innerException)
        {
        }
    }
}
