using System;
using System.Collections;
using Baumax.Domain;

namespace Baumax.Dao
{
    public interface ITrendCorrectionDao : IDao<TrendCorrection>
    {
        IList GetTrendCorrectionFiltered(long storeID, DateTime? dateFrom, DateTime? dateTo);
    }
}