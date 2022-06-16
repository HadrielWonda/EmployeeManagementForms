using System;

namespace Baumax.Dao
{
    public interface IHibernatePKGenEntityDao
    {
        Int64 GetNextPK(string _domainName);
    }
}