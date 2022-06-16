using System;
using System.Collections;
using Baumax.Domain;

namespace Baumax.Dao
{
    public interface IWGRDao : IDao<WGR>
    {
        IList GetWgrFiltered(long HWGR_ID, DateTime? from, DateTime? to);
    }
}