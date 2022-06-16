using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using Baumax.Contract;
using Baumax.Contract.Exceptions;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Util;
using Belikov.GenuineChannels;
using Belikov.GenuineChannels.DotNetRemotingLayer;
using Common.Logging;
using Spring.Objects.Factory;
using Spring.Transaction.Interceptor;
using Baumax.AppServer.Environment;
using Baumax.ServerState;

namespace Baumax.Services
{
    [ServiceID("3AFBC4A8-614E-47ac-B3D1-0DD3EFB5DD1F")]
    public class AuthorizationService : IAuthorizationService, IInitializingObject
    {
        public const string UserSlot = "User";
        static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Dictionary<Guid, UserItem> _AuthorizedUsers = new Dictionary<Guid, UserItem>(10);
        private readonly Dictionary<long, ServiceList> _Services = new Dictionary<long, ServiceList>(10);

        private readonly ReaderWriterLock _Sync = new ReaderWriterLock();

        private readonly PermissionStorage _PermissionStorage;
        private readonly UsersPermissions _UsersPermissions;
        private IServiceDao _ServiceDao;
        private IRoleService _RoleSvc;
        private IUserService _UserSvc;

        private readonly Guid _ServiceId;

        public AuthorizationService()
        {
            Type serviceIdType = typeof (ServiceIDAttribute);
            object[] attrs = GetType().GetCustomAttributes(serviceIdType, false);
            if (attrs != null && attrs.Length != 0)
            {
                _ServiceId = new Guid(((ServiceIDAttribute) attrs[0]).ID);
            }

            _PermissionStorage = new PermissionStorage();
            _UsersPermissions = new UsersPermissions();

            GenuineGlobalEventProvider.GenuineChannelsGlobalEvent +=
                GenuineGlobalEventProvider_GenuineChannelsGlobalEvent;
        }

        #region IAuthorizationManager Members

        [AccessType(AccessType.FreeAccess)]
        public virtual void Init()
        {
        }

        protected string GetLocalized(string key)
        {
            return Baumax.Localization.Localizer.GetLocalized(key);
        }

        private void CheckClientVersion(Version clientVersion)
        {
            if (clientVersion == null || clientVersion != ServerEnvironment.ServerVersion)
            {
                string cVersion = "";
                if (clientVersion != null)
                    cVersion = clientVersion.ToString();
                throw new Exception(string.Format(GetLocalized("WrongVersion"),cVersion, ServerEnvironment.ServerVersion.ToString()));
            }
        }

        [AccessType(AccessType.FreeAccess)]
        public LoginResult Login(string login, string password, out User resultUser)
        {
            return LoginVersionCheck(login, password, out resultUser, null);
        }
        
        [AccessType(AccessType.FreeAccess)]
        public LoginResult LoginVersionCheck(string login, string password, out User resultUser, Version clientVersion)
        {
            CheckClientVersion(clientVersion);
            // check if user already logged in and if Yes then logout before login
            Logout();

            resultUser = null;

            User user = _UserSvc.GetByLogin(login);
            if (user != null)
            {
                if (!user.Active)
                {
                    return LoginResult.UserIsInactive;
                }

                if (string.IsNullOrEmpty(user.Password))
                {
                    Guid id = RegisterUser(user);

                    resultUser = user;
                    if (log.IsDebugEnabled)
                    {
                        log.Debug(string.Format("User login: {0}, Session id:{1}", user.LoginName, id));
                    }
                    return LoginResult.Successful;
                }
                else
                {
                    if (CheckPassword(password, user))
                    {
                        Guid id = RegisterUser(user);

                        resultUser = user;
                        if (log.IsDebugEnabled)
                        {
                            log.Debug(string.Format("User login: {0}, Session id:{1}", user.LoginName, id));
                        }
                        return LoginResult.Successful;
                    }
                    else
                    {
                        if (log.IsDebugEnabled)
                        {
                            log.Debug(string.Format("Login failed: wrong password"));
                        }
                        return LoginResult.WrongPassword;
                    }
                }
            }
            else
            {
                return LoginResult.WrongLogin;
            }
        }

        public void Logout(SessionId sessionId)
        {
            if (sessionId != null)
            {
                try
                {
                    _Sync.AcquireWriterLock(Timeout.Infinite);
                    if (_AuthorizedUsers.ContainsKey(sessionId.Id))
                    {
                        _AuthorizedUsers.Remove(sessionId.Id);
                    }
                    //CallContext.FreeNamedDataSlot("id");
                    // session may be already destroyed here(?)
                    try
                    {
                        GenuineUtility.CurrentSession["id"] = null;
                    }
                    catch
                    {
                    }
                }
                finally
                {
                    _Sync.ReleaseWriterLock();
                }
            }
        }

        /// <summary>
        /// Logouts current user if he is logged in.
        /// </summary>
        [AccessType(AccessType.FreeAccess)]
        public void Logout()
        {
            try
            {
                LocalDataStoreSlot slot = Thread.GetNamedDataSlot(UserSlot);
                Thread.SetData(slot, null);

                // check if user already logged in
                SessionId sessionId = GenuineUtility.CurrentSession["id"] as SessionId;
                Logout(sessionId);
            }
            catch
            {
            }
        }

        [AccessType(AccessType.FreeAccess)]
        [Transaction]
        public LoginResult ChangePassword(string oldPassword, string newPassword)
        {
            LoginResult res = LoginResult.WrongLogin;

            User usr = GetCurrentUser();
            if (usr != null)
            {
                User dbUsr = _UserSvc.GetByLogin(usr.LoginName);
                if (dbUsr != null)
                {
                    if (!dbUsr.Active)
                    {
                        res = LoginResult.UserIsInactive;
                    }
                    else
                    {
                        string hashedPassword = SaltHashing.ComputeSaltedHash(oldPassword, usr.Salt);
                        if (string.IsNullOrEmpty(dbUsr.Password) || dbUsr.Password == hashedPassword)
                        {
                            if (string.IsNullOrEmpty(newPassword))
                                dbUsr.Password = "";
                            else
                                dbUsr.Password = '#' + newPassword;

                            dbUsr.ShouldChangePassword = false;
                            _UserSvc.Save(dbUsr);
                            res = LoginResult.Successful;
                        }
                        else
                        {
                            res = LoginResult.WrongPassword;
                        }
                    }
                }
            }
            return res;
        }

        [AccessType(AccessType.FreeAccess)]
        public bool IsUserHasPassword(string loginName)
        {
            User user = _UserSvc.GetByLogin(loginName);
            return user != null && !string.IsNullOrEmpty(user.Password);
        }

        public AccessType GetAccess(IService svc)
        {
            User usr = GetCurrentUser();
            return _UsersPermissions.GetOperation(usr.UserRoleID, svc.ServiceId);
        }

        public AccessType GetAccess(IService svc, UserRole role)
        {
            return _UsersPermissions.GetOperation(role.ID, svc.ServiceId);
        }

        public User GetUser(SessionId sessionId)
        {
            if (sessionId != null)
            {
                try
                {
                    _Sync.AcquireReaderLock(Timeout.Infinite);
                    UserItem ui;
                    if (_AuthorizedUsers.TryGetValue(sessionId.Id, out ui))
                    {
                        return ui.User;
                    }
                    else
                    {
                        return null;
                    }
                }
                finally
                {
                    _Sync.ReleaseReaderLock();
                }
            }
            return null;
        }

        public User GetCurrentUser()
        {
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(UserSlot);
            User usr = (User)Thread.GetData(slot);

            return usr;

            // check if user already logged in
            /*try
            {
                SessionId sessionId = GenuineUtility.CurrentSession["id"] as SessionId;
                return GetUser(sessionId);
            }
            catch
            {
                return null;
            }*/
        }

        public bool CanExecute(RuntimeMethodHandle rmh, Guid svcId)
        {
            UserItem ui;

            //if user not logged in then he cant do anything
            SessionId sessionId = GenuineUtility.CurrentSession["id"] as SessionId;
            if (sessionId != null)
            {
                try
                {
                    _Sync.AcquireReaderLock(Timeout.Infinite);
                    // if user alredy login
                    if (!_AuthorizedUsers.TryGetValue(sessionId.Id, out ui))
                    {
                        return false;
                    }
                    LocalDataStoreSlot slot = Thread.GetNamedDataSlot(UserSlot);
                    Thread.SetData(slot, ui.User);
                }
                finally
                {
                    _Sync.ReleaseReaderLock();
                }
            }
            else
            {
                return false;
            }

            AccessType op = _PermissionStorage.FindMethodAccess(rmh, svcId);
            if (op == AccessType.FreeAccess)
            {
                return true;
            }

            if (op == AccessType.None)
            {
                return false;
            }

            AccessType userAccess = _UsersPermissions.GetOperation(ui.User.UserRoleID, svcId);

            return (userAccess & op) != 0;
        }

        public Guid ServiceId
        {
            get { return _ServiceId; }
        }

        #endregion

        private Guid RegisterUser(User user)
        {
            Guid id = Guid.NewGuid();

            try
            {
                GenuineUtility.CurrentSession["id"] = new SessionId(id);
            }
            catch
            {}

            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(UserSlot);
            Thread.SetData(slot, user);

            user.Password = null;
            try
            {
                _Sync.AcquireWriterLock(Timeout.Infinite);
                _AuthorizedUsers.Add(id, new UserItem(user, null));
                if (user.UserRoleID != null)
                {
                    UserRole role = _RoleSvc.FindById((long)user.UserRoleID);
                    if (role != null)
                    {
                        _UsersPermissions.AddRole(role, _Services);
                    }
                }
            }
            finally
            {
                _Sync.ReleaseWriterLock();
            }
            
            return id;
        }
        
        private static bool CheckPassword(string password, User usr)
        {
            if (string.IsNullOrEmpty(usr.Password))
                return true;

            string hashedPassword = SaltHashing.ComputeSaltedHash(password, usr.Salt);
            return usr.Password == hashedPassword;
        }
        
        protected IServiceDao ServiceDao
        {
            get { return _ServiceDao; }
            set { _ServiceDao = value; }
        }

        #region IInitializingObject Members

        public void AfterPropertiesSet()
        {
            if (_Services.Count == 0)
            {
                IList svcs = _ServiceDao.FindAll();
                foreach (ServiceList svc in svcs)
                {
                    _Services.Add(svc.ID, svc);
                }
            }
            log.Info("Initialized.");
        }

        #endregion

        private void GenuineGlobalEventProvider_GenuineChannelsGlobalEvent(object sender, GenuineEventArgs e)
        {
            if (log.IsDebugEnabled)
            {
                if (e.SourceException == null)
                {
                    log.Debug(
                        string.Format("Global event: {0}\r\nUrl: {1}", e.EventType,
                                      e.HostInformation == null ? "<not specified>" : e.HostInformation.ToString()));
                }
                else
                {
                    log.Debug(
                        string.Format("Global event: {0}\r\nUrl: {1}\r\nException: {2}", e.EventType,
                                      e.HostInformation == null ? "<not specified>" : e.HostInformation.ToString(),
                                      e.SourceException));
                }
            }

            if (e.EventType == GenuineEventType.GeneralConnectionClosed)
            {
                // remove client session
                SessionId sessionId = e.HostInformation["id"] as SessionId;
                if (sessionId != null)
                {
                    // user can be actually logged out here, if client application was closed properly
                    // Logout handles this case
                    string userName = string.Empty;
                    try
                    {
                        userName = GetUser(sessionId).LoginName;
                    }
                        // have to logout even if name lookup fails
                    catch (Exception)
                    {
                    }
                    Logout(sessionId);
                    if (log.IsDebugEnabled)
                    {
                        log.Debug(
                            string.Format("Client {0} (url = {1}, session ID={2}) has been disconnected.", userName,
                                          e.HostInformation.PhysicalAddress == null
                                              ? "<not specified>"
                                              : e.HostInformation.PhysicalAddress.ToString(),
                                          sessionId.Id));
                    }
                }
            }
            else
            {
                // check if it was logout already - close connection
                // doesn't work. there is no session available after successfull logout.
                /*
                if (e.EventType == GenuineEventType.GeneralConnectionReestablishing)
                {
                    SessionId sessionId = e.HostInformation["id"] as SessionId;
                    if (sessionId != null)
                    {
                        try
                        {
                            // is user logged out?
                            if (GetCurrentUser(sessionId) == null)
                            {
                                string url = e.HostInformation.PhysicalAddress == null
                                                 ? "<not specified>"
                                                 : e.HostInformation.PhysicalAddress.ToString();
                                e.HostInformation.ITransportContext.KnownHosts.ReleaseHostResources(
                                    e.HostInformation,
                                    GenuineExceptions.Get_Receive_ConnectionClosed("user is logged out"));
                                if (log.IsDebugEnabled)
                                {
                                    log.Debug(
                                        string.Format(
                                            "Releasing host resources due to user logout (url = {0}, session ID = {1})",
                                            url, sessionId.Id));
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }*/
            }
        }
    }

    internal class UserItem
    {
        private User _User;
        private CultureInfo _ClientCulture;

        internal UserItem()
        {
            _ClientCulture = new CultureInfo("de-AT", false);
        }

        internal UserItem(User user, CultureInfo culture)
        {
            _ClientCulture = culture;
            _User = user;
        }

        internal User User
        {
            get { return _User; }
            set { _User = value; }
        }

        /// <summary>
        /// Gets or sets the client culture.
        /// </summary>
        /// <value>The culture use on the client machine. Used for getting localized strings.</value>
        internal CultureInfo ClientCulture
        {
            get { return _ClientCulture; }
            set { _ClientCulture = value; }
        }
    }
}