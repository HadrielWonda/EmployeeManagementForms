using System;
using System.Security.Permissions;
using Common.Logging;

namespace Baumax.Contract
{
    public class OperationCompleteReceiver : MarshalByRefObject, IOperationCompleteReceiver
    {
        private event OperationCompleteDelegate _OperationComplete;

        private static ILog log;

        public event OperationCompleteDelegate OperationComplete
        {
            add { _OperationComplete += value; }
            remove { _OperationComplete -= value; }
        }

        public OperationCompleteReceiver()
        {
            log = LogManager.GetLogger(GetType());
        }

        public void ReceiveOperationComplete(object sender, OperationCompleteEventArgs e)
        {
            if (_OperationComplete != null)
            {
                lock (_OperationComplete)
                {
                    if (_OperationComplete != null)
                    {
                        _OperationComplete(sender, e);
                    }
                }
            }
        }

        /// <summary>
        /// Obtains a lifetime service object to control the lifetime policy for this instance.
        /// </summary>
        /// <returns>
        /// An object of type <see cref="T:System.Runtime.Remoting.Lifetime.ILease"></see> used to control the lifetime policy for this instance. This is the current lifetime service object for this instance if one exists; otherwise, a new lifetime service object initialized to the value of the <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime"></see> property.
        /// </returns>
        /// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration, Infrastructure"/></PermissionSet>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
        public override Object InitializeLifetimeService()
        {
            return null;
        }
    }
}