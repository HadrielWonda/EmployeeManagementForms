using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Common.Logging;

namespace Baumax.Contract
{
    public class InvalidateWholeCacheReceiver<T> : MarshalByRefObject, IInvalidateWholeCacheReceiver
        where T : BaseEntity
    {
        private event InvalidateWholeCacheDelegate _invalidateWholeCache;

        private IBaseService<T> _remoteService;
        private ReaderWriterLock _lock = new ReaderWriterLock();
        private bool _isInvalid = true;
        private static ILog log;

        public event InvalidateWholeCacheDelegate InvalidateWholeCache
        {
            add
            {
                bool needSubscribe = !Utils.IsDelegateSubscribers(_invalidateWholeCache);
                _invalidateWholeCache += value;
                if (needSubscribe)
                {
                    _remoteService.SubscribeInvalidateWholeCache(this);
                }
            }
            remove
            {
                _invalidateWholeCache -= value;
                if (!Utils.IsDelegateSubscribers(_invalidateWholeCache))
                {
                    _remoteService.SubscribeInvalidateWholeCache(this);
                }
            }
        }

        public InvalidateWholeCacheReceiver(IBaseService<T> remoteSvc)
        {
            log = LogManager.GetLogger(GetType());
            _remoteService = remoteSvc;
            //_remoteService.InvalidateWholeCache += new InvalidateWholeCacheDelegate(_remoteService_InvalidateWholeCache);
        }

        public void ReceiveInvalidateWholeCache()
        {
            _lock.AcquireWriterLock(Timeout.Infinite);
            try
            {
                _isInvalid = true;
#if DEBUG
                log.Debug(string.Format("{0} ReceiveInvalidateWholeCache : ", typeof (T).Name));
#endif
            }
            finally
            {
                _lock.ReleaseWriterLock();
            }
            if (_invalidateWholeCache != null)
            {
                lock (_invalidateWholeCache)
                {
                    if (_invalidateWholeCache != null)
                    {
                        _invalidateWholeCache();
                    }
                }
            }
        }

        #region IInvalidateWholeCacheReceiver Members

        public bool IsInvalid
        {
            get
            {
                bool res = false;
                _lock.AcquireReaderLock(Timeout.Infinite);
                try
                {
                    res = _isInvalid;
                }
                finally
                {
                    _lock.ReleaseReaderLock();
                }
                return res;
            }
        }

        public void Reset()
        {
            _lock.AcquireWriterLock(Timeout.Infinite);
            try
            {
                _isInvalid = false;
            }
            finally
            {
                _lock.ReleaseWriterLock();
            }
        }

        #endregion

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