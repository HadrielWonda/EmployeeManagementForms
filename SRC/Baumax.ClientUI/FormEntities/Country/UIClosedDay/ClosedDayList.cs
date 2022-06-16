using System;
using System.Collections;
using Baumax.Domain;
using Baumax.Templates;

namespace Baumax.ClientUI.FormEntities.Country
{
    class ClosedDayList : BindingTemplate <YearlyWorkingDay>
    {
        private long _countryid = 0;

        public ClosedDayList(long countryid)
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
                foreach (YearlyWorkingDay f in lst)
                {
                    if (f.CountryID == CountryID)
                        Add(f);
                }
            }
        }

        public bool IsExistsYearlyWorkingDay(DateTime dt)
        {
            foreach (YearlyWorkingDay f in this)
            {
				if (f.WorkingDay == dt) return true;
            }
            return false;
        }

        public bool IsExistsYearlyWorkingDay(string _onlyDate)
        {
            foreach (YearlyWorkingDay f in this)
            {
                if (f.WorkingDay.Date.ToString().Remove(10) == _onlyDate) return true;
            }
            return false;
        }
        
        public bool AddWithChecking(DateTime dt)
        {
            if (!IsExistsYearlyWorkingDay(dt) && dt >= DateTime.Now.Date && !UCCountryEdit.IsEstimationExist(dt, CountryID))
            {
                Add(new YearlyWorkingDay(dt, CountryID));
                return true;
            }
            return false;
        }
    }
   
}
