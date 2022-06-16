using System;
using Baumax.Contract;
using Baumax.Dao;

namespace Baumax.Services
{
    [AttributeUsageAttribute(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AccessTypeAttribute: Attribute
    {
        private AccessType _AccessType;

        public AccessTypeAttribute(AccessType ot)
        {
            _AccessType = ot;
        }

        public AccessType AccessType
        {
            get { return _AccessType; }
            set { _AccessType = value; }
        }
    }
}
