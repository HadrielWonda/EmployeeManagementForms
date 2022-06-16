using System;

namespace Baumax.Domain
{
    public interface IDepartment
    {
        long StoreID       { get;set; }
        long ID            { get;set; }
        DateTime EndTime   { get;set; }
        DateTime BeginTime { get;set; }
        long ParentID { get;set;}
        long SectorID { get;set;}
    }
}
