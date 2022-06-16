using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Baumax.Contract.Interfaces
{
    public interface IQueryCacheDao
    {
        IDataReader GetDataReader(string query);
    }
}
