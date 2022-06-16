using System;

namespace Baumax.Contract.ZLib
{
    public interface IZEntity
    {
        Type Type { get; set; }
        byte[] Data { get; set; }
        int Size { get; set; }
    }
}
