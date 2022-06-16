using System;

namespace Baumax.Contract
{
    [Serializable][Flags]
    public enum AccessType: uint
    {
        None = 0,
        Read = 1,
        Write = 2,
        Import = 4,
        FreeAccess = 0xFFFFFFFF
    }
}