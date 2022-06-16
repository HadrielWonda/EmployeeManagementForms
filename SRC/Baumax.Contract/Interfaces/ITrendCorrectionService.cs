using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface ITrendCorrectionService : IBaseService<TrendCorrection>
    {
        List<TrendCorrection> GetTrendCorrectionFiltered(long storeID, System.DateTime? dateFrom, System.DateTime? dateTo);
    }
}