using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using System.Collections;

namespace Baumax.Cache.QueryCacheClasses
{
    public class QueryCacheBVActualByYearInfo : QueryCacheWrapper<string, BVActualByYearInfo>
    {
        public QueryCacheBVActualByYearInfo(string query, IQueryCacheDao queryCacheDao)
            : base(query, queryCacheDao)
        {
        }

        public IList GetData(short beforeYear, long storeID)
        {
            return _Cache.FindByFilter(delegate(BVActualByYearInfo entity)
                                          {
                                              if (entity.Year < beforeYear && entity.StoreID == storeID)
                                                  return true;
                                              else
                                                  return false;
                                          }
            );
        }

        public IList GetData(short beforeYear)
        {
            return _Cache.FindByFilter(delegate(BVActualByYearInfo entity)
                                          {
                                              if (entity.Year < beforeYear)
                                                  return true;
                                              else
                                                  return false;
                                          }
            );
        }

        public void CopyData(short yearBegin, short yearEnd, long sourceStoreID, long destStoreID)
        {
            List<BVActualByYearInfo> result = CetDateBetweenYears(yearBegin, yearEnd, sourceStoreID);
            if (result.Count > 0)
            {
                BVActualByYearInfo[] newData = new BVActualByYearInfo[result.Count];
                for (int i = 0; i < result.Count; i++)
                {
                    newData[i] = new BVActualByYearInfo();
                    newData[i].StoreID = destStoreID;
                    newData[i].DateBegin = result[i].DateBegin;
                    newData[i].DateEnd = result[i].DateEnd;
                    newData[i].Year = result[i].Year;

                }
                _Cache.Add(newData);
            }
        }

        private List<BVActualByYearInfo> CetDateBetweenYears(short yearBegin, short yearEnd, long storeID)
        {
            return _Cache.FindByFilter(delegate(BVActualByYearInfo entity)
                                          {
                                              if (yearBegin <= entity.Year && entity.Year <= yearEnd && entity.StoreID == storeID)
                                                  return true;
                                              else
                                                  return false;
                                          }
            );
        }
    }

}
