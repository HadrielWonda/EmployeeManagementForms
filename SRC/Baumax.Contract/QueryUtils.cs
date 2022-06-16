using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System;

namespace Baumax.Contract
{
    public static class QueryUtils
    {
        /// <summary>
        /// Generates the ID list (string and parameters for "FindByNamedParam"-like function).
        /// </summary>
        /// <param name="idList">The id list.</param>
        /// <param name="pNames">The parameter names.</param>
        /// <param name="pValues">The parameter values.</param>
        /// <returns>string with parametrically named IDs delimited by commas</returns>
        public static string GenIDList(IEnumerable<long> idList, List<string> pNames, List<object> pValues)
        {
            if(idList == null)
            {
                return null;
            }
            Debug.Assert((pNames != null) && (pValues != null),
                         "GenIDList: impossible to store parameters");
            
            StringBuilder result = new StringBuilder();
            IEnumerator<long> ie = idList.GetEnumerator();
            int i = 0;
            ie.Reset();
            if(ie.MoveNext())
            {
                string paramName = string.Format("internal_qutils_id{0}", i++);
                result.AppendFormat(":{0}", paramName);
                pNames.Add(paramName);
                pValues.Add(ie.Current);
                while(ie.MoveNext())
                {
                    paramName = string.Format("internal_qutils_id{0}", i++);
                    result.AppendFormat(",:{0}", paramName);
                    pNames.Add(paramName);
                    pValues.Add(ie.Current);
                }
            }
            
            if(result.Length == 0)
            {
                return null;
            }
            return result.ToString();
        }

        /// <summary>
        /// Generates the ID list "(10,11,12,13)"
        /// </summary>
        /// <param name="idList">The id list.</param>
        /// <returns>string format - (10,11,12,13,....25)</returns>
        public static string GetINString(IEnumerable<long> idList)
        {
            if (idList == null)
                throw new ArgumentNullException();

            StringBuilder sb = new StringBuilder(100);
            sb.Append('(');
            foreach (long value in idList)
            {
                if (sb.Length > 1)
                    sb.Append(',');

                sb.Append(value);
            }
            sb.Append(')');

            return sb.ToString ();
                
        }
    }
}