using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalBenchmarkService : LocalBaseCachingService<Benchmark>, IBenchmarkService
    {
        #region IBenchmarkService Members

        public List<Benchmark> GetBenchmarkFiltered(long storeID, short? yearFrom, short? yearTo)
        {
            return RemoteService.GetBenchmarkFiltered(storeID, yearFrom, yearTo);
        }


        public Benchmark GetBenchmark(long storeworldID, short year)
        {
            return RemoteService.GetBenchmark(storeworldID, year);
        }
        #endregion

        private IBenchmarkService RemoteService
        {
            get { return (IBenchmarkService)_remoteService; }
        }
    }
}
