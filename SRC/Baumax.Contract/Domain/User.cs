using System;
using System.Collections;

namespace Baumax.Domain
{
    #region User

    /// <summary>
    /// User object for NHibernate mapped table 'User'.
    /// </summary>
    [Serializable]
    public class User : BaseEntity
    {
        #region Member Variables

        protected string _loginName;
        protected string _password;
        protected long? _languageID;
        protected bool _active;
        protected long? _userRoleId;
        protected IList _userCountries;
        protected IList _userRegions;
        protected IList _userStores;
        private int _salt;
        private bool _imported;
        private bool _shouldChangePassword;

        #endregion

        #region Constructors

        public User()
        {
            _active = true;
        }

        public User(string loginName, string password, long? languageID, bool active, long? userRoleId)
        {
            _loginName = loginName;
            _password = password;
            _languageID = languageID;
            _active = active;
            _userRoleId = userRoleId;
        }

        #endregion

        #region Public Properties

        public virtual string LoginName
        {
            get { return _loginName; }
            set
            {
                if (value != null && value.Length > 50)
                    throw new ArgumentOutOfRangeException("Invalid value for LoginName", value, value.ToString());
                _loginName = value;
            }
        }

        public virtual string Password
        {
            get { return _password; }
            set
            {
                if (value != null && value.Length > 255)
                    throw new ArgumentOutOfRangeException("Invalid value for Password", value, value.ToString());
                _password = value;
            }
        }

        public virtual long? LanguageID
        {
            get { return _languageID; }
            set { _languageID = value; }
        }

        public virtual bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public virtual long? UserRoleID
        {
            get { return _userRoleId; }
            set { _userRoleId = value; }
        }

        public virtual IList UserCountryList
        {
            get
            {
                if (_userCountries == null)
                {
                    _userCountries = new ArrayList();
                }
                return _userCountries;
            }
            set { _userCountries = value; }
        }

        public virtual IList UserRegionList
        {
            get
            {
                if (_userRegions == null)
                {
                    _userRegions = new ArrayList();
                }
                return _userRegions;
            }
            set { _userRegions = value; }
        }

        public virtual IList UserStoreList
        {
            get
            {
                if (_userStores == null)
                {
                    _userStores = new ArrayList();
                }
                return _userStores;
            }
            set { _userStores = value; }
        }

        public virtual int Salt
        {
            get { return _salt; }
            set { _salt = value; }
        }

        public virtual bool Imported
        {
            get { return _imported; }
            set { _imported = value; }
        }

        public virtual bool ShouldChangePassword
        {
            get { return _shouldChangePassword; }
            set { _shouldChangePassword = value; }
        }

        #endregion
    }

    #endregion
}
