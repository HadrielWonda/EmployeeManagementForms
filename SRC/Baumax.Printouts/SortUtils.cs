using System;
using System.Collections.Generic;
using System.Reflection;
using Baumax.Domain;
using DevExpress.Data;

namespace Baumax.Printouts
{
    public struct SortField
    {
        public string Name;
        public ColumnSortOrder SortOrder;

        public SortField(string _name, ColumnSortOrder _sortOrder)
        {
            Name = _name;
            SortOrder = _sortOrder;
        }
    }

    public static class SortUtils<T>
    {
        public static int CompareObjectValues(object aVal, object bVal)
        {
            // check for nulls
            if (aVal == null)
            {
                if (bVal == null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            if (bVal == null)
            {
                return -1;
            }

            Type oType = aVal.GetType();
            if (bVal.GetType() != oType)
            {
                return 0;
            }

            if (oType == typeof (string))
            {
                return string.Compare((string) aVal, (string) bVal);
            }
            else if (oType == typeof (int))
            {
                return ((int) aVal - (int) bVal);
            }
            else if (oType == typeof (int?))
            {
                if (!(((int?) aVal).HasValue))
                {
                    if (!(((int?) bVal).HasValue))
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                if (!(((int?) bVal).HasValue))
                {
                    return -1;
                }
                return (((int?) aVal).Value - ((int?) bVal).Value);
            }
            else if (oType == typeof(Int64))
            {
                Int64 value = ((Int64) aVal - (Int64) bVal);
                return (value > 0) ? 1 : (value < 0) ? -1 : 0;
            }
            else if (oType == typeof(Int64?))
            {
                if (!(((Int64?)aVal).HasValue))
                {
                    if (!(((Int64?)bVal).HasValue))
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                if (!(((Int64?)bVal).HasValue))
                {
                    return -1;
                }
                Int64 value = (((Int64?)aVal).Value - ((Int64?)bVal).Value);
                return (value > 0) ? 1 : (value < 0) ? -1 : 0;
            }

            return 0;
        }

        public static int CompareObjectFieldsOrProperties(object a, object b, string fieldOrPropertyName)
        {
            // check for nulls
            if (a == null)
            {
                if (b == null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            if (b == null)
            {
                return -1;
            }

            FieldInfo fi =
                a.GetType().GetField(fieldOrPropertyName,
                                     BindingFlags.NonPublic |
                                     BindingFlags.Instance |
                                     BindingFlags.Public);
            if (fi != null)
            {
                FieldInfo bFi = b.GetType().GetField(fieldOrPropertyName,
                                                     BindingFlags.NonPublic |
                                                     BindingFlags.Instance |
                                                     BindingFlags.Public);
                if(bFi == null)
                {
                    return 0;
                }
                return CompareObjectValues(fi.GetValue(a), bFi.GetValue(b));
            }
            else
            {
                PropertyInfo pi =
                    a.GetType().GetProperty(fieldOrPropertyName,
                                            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (pi != null)
                {
                    PropertyInfo bPi = b.GetType().GetProperty(fieldOrPropertyName,
                                                               BindingFlags.NonPublic | BindingFlags.Instance |
                                                               BindingFlags.Public);
                    if(bPi == null)
                    {
                        return 0;
                    }
                    return CompareObjectValues(pi.GetValue(a, null), bPi.GetValue(b, null));
                }
            }

            return 0;
        }

        public static List<T> Sort(List<T> list, SortField[] sortFields)
        {
            if ((list != null) && (list.Count > 0) && (sortFields != null) && (sortFields.Length > 0))
            {
                list.Sort(new Comparison<T>(delegate(T a, T b)
                                            {
                                                for (int i = 0; i < sortFields.Length; i++)
                                                {
                                                    int direction = 0;
                                                    if (sortFields[i].SortOrder == ColumnSortOrder.Ascending)
                                                    {
                                                        direction = 1;
                                                    }
                                                    else if (sortFields[i].SortOrder == ColumnSortOrder.Descending)
                                                    {
                                                        direction = -1;
                                                    }
                                                    if (direction != 0)
                                                    {
                                                        int result = direction*
                                                                     CompareObjectFieldsOrProperties(a, b,
                                                                                                     sortFields[i].Name);
                                                        if (result != 0)
                                                        {
                                                            return result;
                                                        }
                                                    }
                                                }
                                                return 0;
                                            }));
            }
            return list;
        }
    }
}