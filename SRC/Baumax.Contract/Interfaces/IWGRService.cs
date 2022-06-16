using System;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IWGRService : IBaseService<WGR>
    {
        List<WGR> GetWgrFiltered(long HWGR_ID, DateTime? from, DateTime? to);
    }
}