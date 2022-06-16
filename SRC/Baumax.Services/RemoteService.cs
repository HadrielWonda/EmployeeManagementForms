using System;
using System.Data.SqlClient;
using System.Security.Permissions;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Common.Logging;
using Spring.Objects.Factory;

namespace Baumax.Services
{
    public class RemoteService : /*MarshalByRefObject,*/ IService, IInitializingObject
    {
        private Guid _ServiceId;

        private ILog log;

        public RemoteService()
        {
            Type serviceIdType = typeof (ServiceIDAttribute);
            object[] attrs = GetType().GetCustomAttributes(serviceIdType, false);
            if (attrs != null && attrs.Length != 0)
            {
                _ServiceId = new Guid(((ServiceIDAttribute) attrs[0]).ID);
            }
        }

        public Guid ServiceId
        {
            [AccessType(AccessType.FreeAccess)]
            get { return _ServiceId; }
        }

        protected ILog Log
        {
            get
            {
                if (log == null)
                {
                    log = LogManager.GetLogger(GetType());
                }
                return log;
            }
        }

        public static void CheckForDBValidationException(long[] failedIDs, Exception ex)
        {
            Exception curEx = ex;
            while ((curEx != null) && !(curEx is SqlException))
            {
                curEx = curEx.InnerException;
            }
            if (curEx != null)
            {
                foreach (SqlError sqlEr in ((SqlException)curEx).Errors)
                {
                    if (sqlEr.Class > 0)
                    {
                        switch (sqlEr.Number)
                        {
                            // 2601 14 Cannot insert duplicate key row in object '%.*ls' with unique index '%.*ls'. 
                            case 2601:
                            // ? just in case 
                            // 2627 14 Violation of %ls constraint '%.*ls'. Cannot insert duplicate key in object '%.*ls'. 
                            case 2627:
                                throw new DBDuplicateKeyException(failedIDs, ex);
                            // 547 %ls statement conflicted with %ls %ls constraint '%.*ls'. The conflict occurred in database '%.*ls', table '%.*ls'%ls%.*ls%ls.
                            case 547:
                                throw new DBReferenceConstraintConflictedException(failedIDs, ex);
                        }
                    }
                }
            }
        }

        [AccessType(AccessType.FreeAccess)]
        public virtual void Init()
        {
        }

        /*/// <summary>
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
        }*/

        public virtual void AfterPropertiesSet()
        {
            Log.Info("Initialized.");
        }
    }
}