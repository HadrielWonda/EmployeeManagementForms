using System;

namespace Baumax.Domain
{
    [Serializable]
    public class UserCountry : BaseEntity
    {
        //private long _userId;
        private long _countryId;
        private User _user;

        public UserCountry()
        {
        }
        
        /*public virtual long UserID
        {
            get { return _userId; }
            set { _userId = value; }
        }*/

        public virtual User User
        {
            get { return _user; }
            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Null value not allowed for User", value, "null");

                _user = value;
            }

        }

        public virtual long CountryID
        {
            get { return _countryId; }
            set { _countryId = value; }
        }
    }
}
