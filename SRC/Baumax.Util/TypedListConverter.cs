using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Util
{
    public static class TypedListConverter<T>
    {
        public static List<T> ToTypedList(ICollection src)
        {
            if ((src == null) || (src.Count == 0))
            {
                return null;
            }
            List<T> result = new List<T>(src.Count);
            foreach (T t in src)
            {
                result.Add(t);
            }
            return result;
        }

        public static ArrayList ToUntypedList(ICollection<T> src)
        {
            
            if ((src == null) || (src.Count == 0))
            {
                return null;
            }

            ArrayList res = new ArrayList(src.Count);
            foreach (T t in src)
            {
                res.Add(t);
            }
            return res;
        }
    }
}
