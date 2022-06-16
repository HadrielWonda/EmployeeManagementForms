using System;
using Baumax.Domain;

namespace Baumax.Domain
{
    [Serializable]
    public class UserStore : BaseEntity
    {
        #region Private Members

        private User _user;
        private long _storeid;
        #endregion

        #region Constructor

        public UserStore()
        {
        }
        #endregion // End of Default ( Empty ) Class Constuctor

        #region Public Properties
        public virtual User User
        {
            get
            {
                return _user;
            }
            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for Userid", value, "null");

                _user = value;
            }

        }

        public virtual long StoreID
        {
            get
            {
                return _storeid;
            }
            set
            {
                _storeid = value;
            }

        }
        #endregion
    }
}
