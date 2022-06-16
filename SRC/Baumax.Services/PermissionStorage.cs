using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;

namespace Baumax.Services
{
    internal class PermissionStorage
    {
        private Dictionary<Guid, PermissionTypes> _Permissions = new Dictionary<Guid, PermissionTypes>(10);
        private List<RuntimeMethodHandle> _FreeAccess = new List<RuntimeMethodHandle>();
        private static readonly RuntimeMethodHandleComparer _Comparer = new RuntimeMethodHandleComparer();

        public PermissionStorage()
        {
            Assembly curAsm = Assembly.GetExecutingAssembly();
            Type[] types = curAsm.GetTypes();
            Type svcInterface = typeof (IService);
            
            foreach (Type type in types)
            {
                if (type.IsClass && !type.IsAbstract && !type.IsGenericType && type.IsPublic && svcInterface.IsAssignableFrom(type))
                {
                    AddService(type);
                }
            }
            _FreeAccess.Sort(_Comparer);
        }

        public AccessType FindMethodAccess(RuntimeMethodHandle rmh, Guid svcId)
        {
            if (_FreeAccess.BinarySearch(rmh, PermissionStorage._Comparer) >= 0)
                return AccessType.FreeAccess;

            PermissionTypes permission;
            if (_Permissions.TryGetValue(svcId, out permission))
            {
                return permission.FindMethodAccess(rmh);
            }

            return AccessType.None;
        }
        
        private void AddService(Type type)
        {
            PermissionTypes pt = new PermissionTypes();
            Guid svcId = GetSecuredMethodsList(type, pt);
            if (svcId != Guid.Empty)
            {
                pt.Sort();
                _Permissions.Add(svcId, pt);
            }
        }
        
        public List<Guid> GetServices()
        {
            List<Guid> res = new List<Guid>(_Permissions.Keys);
            return res;
        }
        
        private Guid GetSecuredMethodsList(Type type, PermissionTypes pTypes)
        {
            Guid res = Guid.Empty;
            Object[] attrs = type.GetCustomAttributes(typeof(ServiceIDAttribute), false);
            if (attrs == null || attrs.Length == 0)
                return Guid.Empty;
            res = new Guid(((ServiceIDAttribute) attrs[0]).ID);
            
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            for (int i = 0; i < methods.Length; i++)
            {
                MethodInfo mi = methods[i];
                attrs = mi.GetCustomAttributes(typeof(AccessTypeAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    AccessTypeAttribute ot = (AccessTypeAttribute)attrs[0];
                    if (ot.AccessType == AccessType.FreeAccess)
                        _FreeAccess.Add(mi.MethodHandle);
                    else
                    {
                        if ((ot.AccessType & AccessType.Read) != 0)
                            pTypes.ReadAccess.Add(mi.MethodHandle);
                        
                        if ((ot.AccessType & AccessType.Write) != 0)
                            pTypes.WriteAccess.Add(mi.MethodHandle);

                        if ((ot.AccessType & AccessType.Import) != 0)
                            pTypes.ImportAccess.Add(mi.MethodHandle);
                            
                    }
                }
            }
            return res;
        }
        
        private class RuntimeMethodHandleComparer : IComparer<RuntimeMethodHandle>
        {
            #region IComparer<RuntimeMethodHandle> Members

            public int Compare(RuntimeMethodHandle x, RuntimeMethodHandle y)
            {
                return x.Value.ToInt32() - y.Value.ToInt32();
            }

            #endregion
        }
        
        internal class PermissionTypes 
        {
            private List<RuntimeMethodHandle> _ReadAccess;
            private List<RuntimeMethodHandle> _WriteAccess;
            private List<RuntimeMethodHandle> _ImportAccess;
            
            public PermissionTypes()
            {
                _ReadAccess = new List<RuntimeMethodHandle>();
                _WriteAccess = new List<RuntimeMethodHandle>();
                _ImportAccess = new List<RuntimeMethodHandle>();
            }

            public List<RuntimeMethodHandle> ReadAccess
            {
                get { return _ReadAccess; }
                set { _ReadAccess = value; }
            }

            public List<RuntimeMethodHandle> WriteAccess
            {
                get { return _WriteAccess; }
                set { _WriteAccess = value; }
            }

            public List<RuntimeMethodHandle> ImportAccess
            {
                get { return _ImportAccess; }
                set { _ImportAccess = value; }
            }
            
            public void Sort()
            {
                _ReadAccess.Sort(PermissionStorage._Comparer);
                _WriteAccess.Sort(PermissionStorage._Comparer);
                _ImportAccess.Sort(PermissionStorage._Comparer);
            }
            
            public AccessType FindMethodAccess(RuntimeMethodHandle rmh)
            {
                AccessType res = AccessType.None;
                
                if (_ReadAccess.BinarySearch(rmh, PermissionStorage._Comparer) >= 0)
                    res |= AccessType.Read;
                
                if (_WriteAccess.BinarySearch(rmh, PermissionStorage._Comparer) >= 0)
                    res |= AccessType.Write;

                if (_ImportAccess.BinarySearch(rmh, PermissionStorage._Comparer) >= 0)
                    res |= AccessType.Import;

                return res;
            }
        }
    }
}
