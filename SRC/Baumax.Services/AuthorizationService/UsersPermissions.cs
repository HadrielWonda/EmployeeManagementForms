using System;
using System.Collections.Generic;
using System.Threading;
using Baumax.Contract;
using Baumax.Dao;
using Baumax.Domain;

namespace Baumax.Services
{
    internal class UsersPermissions
    {
        private Dictionary<long, List<SvcAcess>> _UsersPermissions = new Dictionary<long, List<SvcAcess>>(10);
        private ReaderWriterLock _Sync = new ReaderWriterLock();
        
        public void AddRole(UserRole role, Dictionary<long, ServiceList> services)
        {
            try
            {
                _Sync.AcquireWriterLock(Timeout.Infinite);
                if (!_UsersPermissions.ContainsKey(role.ID))
                {
                    List<SvcAcess> permissions = new List<SvcAcess>();
                    foreach (UserRoleServiceList uo in role.UserRoleServiceList)
                    {
                        ServiceList svc = services[uo.ServiceListID];
                        permissions.Add(new SvcAcess(svc.ServiceID, (AccessType)uo.Operation));
                    }
                    permissions.Sort();
                    _UsersPermissions.Add(role.ID, permissions);
                }
            }
            finally
            {
                _Sync.ReleaseWriterLock();
            }
        }

        public AccessType GetOperation(long? roleId, Guid svcId)
        {
            if (roleId == null)
                return AccessType.None;
            
            long id = (long) roleId;
            try
            {
                _Sync.AcquireReaderLock(Timeout.Infinite);
                List<SvcAcess> sa;

                if (!_UsersPermissions.TryGetValue(id, out sa))
                    return AccessType.None;

                int index = sa.BinarySearch(new SvcAcess(svcId));
                if (index >= 0)
                    return sa[index].AccessType;
                else
                    return AccessType.None;
            }
            finally
            {
                _Sync.ReleaseReaderLock();
            }
        }
        
        private class SvcAcess : IComparable<SvcAcess>
        {
            private Guid _SvcId;
            private AccessType _AccessType;

            public SvcAcess(Guid id, AccessType op)
            {
                _SvcId = id;
                _AccessType = op;
            }

            public SvcAcess(Guid id)
            {
                _SvcId = id;
            }
            
            public Guid SvcId
            {
                get { return _SvcId; }
            }

            public AccessType AccessType
            {
                get { return _AccessType; }
            }

            #region IComparable<SvcAcess> Members

            public int CompareTo(SvcAcess other)
            {
                return _SvcId.CompareTo(other.SvcId);
            }

            #endregion
        }
    }
}
