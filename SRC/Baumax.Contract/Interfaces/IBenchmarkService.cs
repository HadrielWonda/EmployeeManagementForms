using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IBenchmarkService : IBaseService<Benchmark>
    {
        List<Benchmark> GetBenchmarkFiltered(long storeID, short? yearFrom, short? yearTo);

        Benchmark GetBenchmark(long storeworldID, short year);
    }
}