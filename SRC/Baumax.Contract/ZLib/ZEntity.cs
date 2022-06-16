using System;

namespace Baumax.Contract.ZLib
{
    [Serializable]
    class ZEntity : IZEntity
    {
        private Type _type;
        private byte[] _data;
        private int _size;

        #region IZEntity Members

        public Type Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        #endregion
    }
}