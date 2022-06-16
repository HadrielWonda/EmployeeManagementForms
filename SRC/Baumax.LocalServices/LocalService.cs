using System;
using System.Security.Permissions;
using Baumax.Contract.Interfaces;
using Baumax.Environment.Interfaces;

namespace Baumax.LocalServices
{
    public class LocalService : MarshalByRefObject, IService, ILocalService
    {
        private Guid _ServiceId;

        private IService _remoteSvc;

#if DEBUG
        private bool _inited;
#endif

        #region Properties

        // because we cannot subscribe to events in constructor and after construction too
        // (all sigletons are created with AppContext creation, even before login)
        // perform subscription checking inside property implementation
        protected virtual IService _remoteService
        {
            get
            {
#if DEBUG
                if (!_inited)
                {
                    throw new ApplicationException("Service " + this.GetType().FullName + " is NOT initialized");
                }
#endif
                return _remoteSvc;
            }
            set { _remoteSvc = value; }
        }

        public Guid ServiceId
        {
            get
            {
                if (_ServiceId == Guid.Empty)
                {
                    _ServiceId = _remoteService.ServiceId;
                }
                return _ServiceId;
            }
        }

        #endregion

        public virtual void Init()
        {
            _remoteSvc.Init();
#if DEBUG
            _inited = true;
#endif
        }

        /// <summary>
        /// Obtains a lifetime service object to control the lifetime policy for this instance.
        /// </summary>
        /// <returns>
        /// An object of type <see cref="T:System.Runtime.Remoting.Lifetime.ILease"></see> used to control the lifetime policy for this instance. This is the current lifetime service object for this instance if one exists; otherwise, a new lifetime service object initialized to the value of the <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime"></see> property.
        /// </returns>
        /// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration, Infrastructure"/></PermissionSet>
        [SecurityPermission(SecurityAction.Demand,
            Flags = SecurityPermissionFlag.Infrastructure)]
        public override Object InitializeLifetimeService()
        {
            return null;
        }
    }
}