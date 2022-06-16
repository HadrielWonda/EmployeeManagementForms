using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.Interfaces
{
    public interface IKey<T>
    {
        T GetKey();
    }
}
