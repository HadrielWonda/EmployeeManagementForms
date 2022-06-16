using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;

namespace Baumax.Services
{
    [ServiceID("8C287495-43F0-4d64-8958-D495F53BF150")]
    public class BenchmarkService : BaseService<Benchmark>, IBenchmarkService
    {
        #region IBenchmarkService Members

        [AccessType(AccessType.Read)]
        public List<Benchmark> GetBenchmarkFiltered(long storeID, short? yearFrom, short? yearTo)
        {
            try
            {
                return GetTypedListFromIList(((IBenchmarkDao) Dao).GetBenchmarkFiltered(storeID, yearFrom, yearTo));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public Benchmark GetBenchmark(long storeworldID, short year)
        {
            try
            {
                return((IBenchmarkDao)Dao).GetBenchmark(storeworldID, year);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        

        public List<Benchmark> GetBenchmarkByStoreWorld(long storeworldID)
        {
            try
            {
                return ((IBenchmarkDao)Dao).GetBenchmarkByStoreWorld(storeworldID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        #endregion
    }
}