using System;

namespace Baumax.Services
{
    [AttributeUsageAttribute(AttributeTargets.Class, Inherited = false, AllowMultiple = false)] 
    public class ServiceIDAttribute : Attribute
    {
        private Guid _ID;

        public ServiceIDAttribute()
        {
            _ID = Guid.Empty;
        }

        public ServiceIDAttribute(Guid id)
        {
            _ID = id;
        }
        
        public ServiceIDAttribute(string id)
        {
            _ID = new Guid(id);
        }

        public byte[] ID
        {
            get { return _ID.ToByteArray(); }
            set { _ID = new Guid(value); }
        }
    }
}
