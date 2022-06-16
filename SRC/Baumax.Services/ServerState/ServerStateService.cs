using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using Baumax.AppServer.Environment;
using Baumax.ServerState;
using Common.Logging;
using Spring.Objects.Factory;

namespace Baumax.Services
{
    public sealed class ServerStateService : MarshalByRefObject, IServerStateService, IInitializingObject
    {
        static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        private bool _CanInteract;
        private bool _ServerReady;

        #region IInitializingObject Members

        public void AfterPropertiesSet()
        {
            CanInteract = true;
            log.Info("Initialized");
        }

        #endregion

        public bool CanInteract
        {
            get
            {
                lock (this)
                {
                    return _CanInteract;
                }
            }
            private set
            {
                lock (this)
                {
                    _CanInteract = value;
                }
            }
        }

        public bool ServerReady
        {
            get
            {
                lock (this)
                {
                    return _ServerReady;
                }
            }
            set
            {
                lock (this)
                {
                    _ServerReady = value;
                }
            }
        }

        public ServerStateData GetState()
        {
            ServerStateData state = new ServerStateData();
            state.TotalMemory = GC.GetTotalMemory(false);

            state.ServerVersion = ServerEnvironment.ServerVersion.ToString();

            state.DbVersion = ServerEnvironment.DbProperties.GetDbVersion();

            return state;
        }

        [SecurityPermission(SecurityAction.Demand,
            Flags = SecurityPermissionFlag.Infrastructure)]
        public override Object InitializeLifetimeService()
        {
            return null;
        }
    }
}
