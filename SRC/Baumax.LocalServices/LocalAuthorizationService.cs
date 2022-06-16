using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Environment;
using Belikov.GenuineChannels.Connection;
using Belikov.GenuineChannels.Security;

namespace Baumax.LocalServices
{
    public class LocalAuthorizationService : IAuthorizationService
    {
        private Guid _ServiceId;
        private IAuthorizationService _RemoteSvc;
        private User _LogonUser;
        private Dictionary<Guid, AccessType> _SvcAccess;
        
        #region IAuthorizationService Members

        public virtual void Init()
        {
        }

        public LoginResult Login(string login, string password, out User resultUser)
        {
            return LoginVersionCheck(login, password, out resultUser, null);
        }


        public LoginResult LoginVersionCheck(string login, string password, out User resultUser, Version clientVersion)
        {
            _SvcAccess = null;
            _LogonUser = null;
            LoginResult res;

            SecuritySessionParameters oldParams = SecuritySessionServices.SetCurrentSecurityContext(
                new SecuritySessionParameters("/BAUMAX/SES", SecuritySessionAttributes.ForceSync, TimeSpan.MinValue,
                                              GenuineConnectionType.Persistent, null, TimeSpan.FromSeconds(10)));

            try
            {
                res = _RemoteSvc.LoginVersionCheck(login, password, out resultUser, clientVersion);
                _LogonUser = resultUser;
            }
            finally
            {
                SecuritySessionServices.SetCurrentSecurityContext(oldParams);
            }
            
            return res;
        }

        public LoginResult ChangePassword(string oldPassword, string newPassword)
        {
            LoginResult res;
            SecuritySessionParameters oldParams = SecuritySessionServices.SetCurrentSecurityContext(
                new SecuritySessionParameters("/BAUMAX/SES", SecuritySessionAttributes.ForceSync, TimeSpan.MinValue,
                                              GenuineConnectionType.Persistent, null, TimeSpan.FromSeconds(10)));
            try
            {
                res = _RemoteSvc.ChangePassword(oldPassword, newPassword);
            }
            finally
            {
                SecuritySessionServices.SetCurrentSecurityContext(oldParams);
            }
            return res;
        }

        public bool IsUserHasPassword(string loginName)
        {
            return _RemoteSvc.IsUserHasPassword(loginName);
        }

        public void Logout()
        {
            _LogonUser = null;
            if (_SvcAccess != null)
            {
                _SvcAccess.Clear();
            }
            _RemoteSvc.Logout();
        }

        public User GetCurrentUser()
        {
            return _LogonUser;
        }

        public bool CanExecute(RuntimeMethodHandle rmh, Guid svcId)
        {
            //Dont change. This is server only method.
            throw new Exception("This is server only method.");
        }

        public AccessType GetAccess(IService svc)
        {
            if (_SvcAccess == null)
            {
                _SvcAccess = new Dictionary<Guid, AccessType>(30);
                if (_LogonUser != null && _LogonUser.UserRoleID.HasValue)
                {
                    UserRole ur = GetUserRole(_LogonUser.UserRoleID.Value);
                    foreach (UserRoleServiceList ursvc in ur.UserRoleServiceList)
                    {
                        _SvcAccess.Add(ursvc.Service.ServiceID, (AccessType)ursvc.Operation);
                    }
                }
            }
            
            AccessType res = AccessType.None;
            _SvcAccess.TryGetValue(svc.ServiceId, out res);
            return res;
        }

        public AccessType GetAccess(IService svc, UserRole role)
        {
            foreach (UserRoleServiceList ursvc in role.UserRoleServiceList)
            {
                if (ursvc.Service.ServiceID == svc.ServiceId)
                return (AccessType)ursvc.Operation;
            }
            return AccessType.None;
        }

        public UserRole GetUserRole(long roleId)
        {
            return ClientEnvironment.RoleService.FindById(roleId);
        }
        #endregion

        #region IService Members

        public Guid ServiceId
        {
            get
            {
                if (_ServiceId == Guid.Empty)
                    _ServiceId = _RemoteSvc.ServiceId;

                return _ServiceId;
            }
        }

        #endregion
    }
}
