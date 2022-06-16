using System;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Printouts
{
    public class WorldComparer : IComparer<StoreToWorld>
    {
        public int Compare(StoreToWorld x, StoreToWorld y)
        {
            return x.WorldName.CompareTo (y.WorldName);
        }
    }
}
