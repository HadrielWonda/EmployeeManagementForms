using System.Collections;
using Baumax.Domain;
using System.Collections.Generic;

namespace Baumax.Dao
{
    public interface IBenchmarkDao : IDao<Benchmark>
    {
        IList GetBenchmarkFiltered(long storeID, short? yearFrom, short? yearTo);

        Benchmark GetBenchmark(long storeworldID, short year);
        List<Benchmark> GetBenchmarkByStoreWorld(long storeworldID);
    }
}