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
    public class ChangeReceiver<T> : MarshalByRefObject, IChangeReceiver
        where T : BaseEntity
    {
        private event EntitiesChangedDelegate _entitiesChanged;

        private IBaseService<T> _remoteService;
        private ReaderWriterLock _lock = new ReaderWriterLock();
        private List<long> _changedIds = new List<long>();
        private static ILog log;

        public event EntitiesChangedDelegate EntitiesChanged
        {
            add
            {
                bool needSubscribe = !Utils.IsDelegateSubscribers(_entitiesChanged);
                _entitiesChanged += value;
                if (needSubscribe)
                {
                    _remoteService.SubscribeEntitiesChanged(this);
                }
            }
            remove
            {
                _entitiesChanged -= value;
                if (!Utils.IsDelegateSubscribers(_entitiesChanged))
                {
                    _remoteService.UnsubscribeEntitiesChanged(this);
                }
            }
        }

        public ChangeReceiver(IBaseService<T> remoteSvc)
        {
            log = LogManager.GetLogger(GetType());
            _remoteService = remoteSvc;
            //_remoteService.EntitiesChanged += new EntitiesChangedDelegate(_remoteService_EntitiesChanged);
        }

        public void ReceiveEntitiesChanged(IEnumerable<long> ids)
        {
            _lock.AcquireWriterLock(Timeout.Infinite);
            try
            {
                _changedIds.AddRange(ids);
                if(log.IsDebugEnabled)
                {
                    log.Debug(string.Format("{0} ReceiveEntitiesChanged : ", typeof (T).Name));
                    foreach (long value in ids)
                    {
                        log.Debug(string.Format("{0} ", value));
                    }
                }
            }
            finally
            {
                _lock.ReleaseWriterLock();
            }
            if (_entitiesChanged != null)
            {
                lock (_entitiesChanged)
                {
                    if (_entitiesChanged != null)
                    {
                        _entitiesChanged(ids);
                    }
                }
            }
        }

        #region IChangeReceiver Members

        public List<long> GetIds()
        {
            List<long> res;
            _lock.AcquireWriterLock(Timeout.Infinite);
            try
            {
                res = new List<long>(_changedIds);
                _changedIds.Clear();
            }
            finally
            {
                _lock.ReleaseWriterLock();
            }
            // delete dupes
            for (int i = 0; i < res.Count; i++)
            {
                int lastIndex = res.LastIndexOf(res[i]);
                while (lastIndex != i)
                {
                    res.RemoveAt(lastIndex);
                    lastIndex = res.LastIndexOf(res[i]);
                }
            }
            return res;
        }

        public bool HasChanges
        {
            get
            {
                bool res = false;
                _lock.AcquireReaderLock(Timeout.Infinite);
                try
                {
                    res = _changedIds.Count > 0;
                }
                finally
                {
                    _lock.ReleaseReaderLock();
                }
                return res;
            }
        }

        public bool IsInList(long id)
        {
            _lock.AcquireReaderLock(Timeout.Infinite);
            try
            {
                return (_changedIds.IndexOf(id) != -1);
            }
            finally
            {
                _lock.ReleaseReaderLock();
            }
        }

        public bool RemoveFromList(long id)
        {
            _lock.AcquireWriterLock(Timeout.Infinite);
            try
            {
                bool result = false;
                int index = _changedIds.IndexOf(id);
                while (index != -1)
                {
                    _changedIds.RemoveAt(index);
                    index = _changedIds.IndexOf(id);
                    if (!result)
                    {
                        result = true;
                    }
                }
                return result;
            }
            finally
            {
                _lock.ReleaseWriterLock();
            }
        }

        public void RemoveFromList(IEnumerable<long> idList)
        {
            _lock.AcquireWriterLock(Timeout.Infinite);
            try
            {
                foreach (long id in idList)
                {
                    int index = _changedIds.IndexOf(id);
                    while (index != -1)
                    {
                        _changedIds.RemoveAt(index);
                        index = _changedIds.IndexOf(id);
                    }
                }
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