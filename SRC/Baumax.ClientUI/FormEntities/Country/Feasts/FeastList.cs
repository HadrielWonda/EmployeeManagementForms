using System;
using System.Collections;
using Baumax.Domain;
using Baumax.Templates;

namespace Baumax.ClientUI.FormEntities.Country
{

    class CountryFeastList:BindingTemplate <Feast>
    {
        private long _countryid = 0;
        public CountryFeastList(long countryid)
        {
            _countryid = countryid;
        }
        public long CountryID
        {
            get { return _countryid; }
        }

        public override void CopyList(IList lst)
        {
            if (lst != null)
            {
                foreach (Feast f in lst)
                {
                    if (f.CountryID == CountryID)
                        Add(f);
                }
            }
        }

        public bool IsExistsFeast(DateTime dt)
        {
            foreach (Feast f in this)
            {
				if (f.FeastDate == dt) return true;
            }
            return false;
        }
        
        public bool IsExistsFeast(string _onlyDate)
        {
            foreach (Feast f in this)
            {
                if (f.FeastDate.Date.ToString().Remove(10) == _onlyDate) return true;
            }
            return false;
        }
        public bool AddWithChecking(DateTime dt)
        {
            if (!IsExistsFeast(dt) && dt >= DateTime.Now.Date )//&& !UCCountryEdit.IsEstimationExist(dt, CountryID)
            {
                Add(new Feast(dt, CountryID));
                return true;
            }
            return false;
        }
    }
}
