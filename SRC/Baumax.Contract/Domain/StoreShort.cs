using System;

namespace Baumax.Domain
{
    [Serializable]
    public sealed class StoreShort
    {
        private readonly long _id;
        private readonly string _name;
        private readonly long _regionID;
        private readonly long _countryID;

        public StoreShort(long id, string name, long regionID, long countryID)
        {
            _id = id;
            _name = name;
            _regionID = regionID;
            _countryID = countryID;
        }

        public long ID
        {
            get { return _id; }
        }

        public string StoreName
        {
            get { return _name; }
        }

        public long RegionID
        {
            get { return _regionID; }
        }

        public long CountryID
        {
            get { return _countryID; }
        }
    }
}