using System;
using System.Collections;

namespace Baumax.Domain
{
    #region PKGenEntity

    /// <summary>
    /// Reaction object for NHibernate mapped table 'PKGenEntity'.
    /// </summary>
    [Serializable]
    public class PKGenEntity
    {
        #region Member Variables

        protected string _domainName;
        protected Int64 _value;

        #endregion

        #region Constructors

        public PKGenEntity() { }

        #endregion

        #region Public Properties

        public virtual string DomainName
        {
            get { return _domainName; }
            set { _domainName = value; }
        }

        public virtual Int64 Value
        {
            get { return _value; }
            set { _value = value; }
        }

        #endregion
    }

    #endregion
}
