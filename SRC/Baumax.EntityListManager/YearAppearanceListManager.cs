using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Templates;

namespace Baumax.EntityListManager
{
    public class YearAppearanceListManager : EntityCache<AvgAmount>
    {
        private List<AvgAmount> _list = new List<AvgAmount>();


        private YearAppearanceListManager _instance = null;

        public YearAppearanceListManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new YearAppearanceListManager();
                }
                return _instance;
            }
        }

        private YearAppearanceListManager() { }

        protected override void OnAdded(AvgAmount entity)
        {
            _list.Add(entity);
            base.OnAdded(entity);

        }

        protected override void OnUpdated(AvgAmount entity)
        {
            int idx = GetListIndexbyId(entity.ID);
            _list[idx] = entity;
            base.OnUpdated(entity);
        }

        protected override void OnDeleted(AvgAmount entity)
        {
            int idx = GetListIndexbyId(entity.ID);
            _list.RemoveAt(idx);
            base.OnDeleted(entity);
        }

        private int GetListIndexbyId(long id)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i].ID == id) return i;
            }
            return -1;
        }

        private class FilterByCountry
        {
            public long CountryID = -1;
            public short Year = -1;
            public bool FileterByCountry(AvgAmount weeks)
            {
                return (CountryID == weeks.CountryID);
            }
            public bool FileterByCountryAndYear(AvgAmount weeks)
            {
                return (CountryID == weeks.CountryID && Year == weeks.Year);
            }
            public FilterByCountry(long id)
            {
                CountryID = id;
            }

            public FilterByCountry(long id, short y)
            {
                CountryID = id;
                Year = y; 
            }


        }


        public List<AvgAmount> GetWeeksListByCountry(long id)
        {
            FilterByCountry fbc = new FilterByCountry (id);

            List<AvgAmount> lst = (List<AvgAmount>)GetFiltered(fbc.FileterByCountry);

            return lst;
        }

        public BindingTemplate<AvgAmount> GetBindingListByCountry(long id)
        {
            return new BindingTemplate<AvgAmount>(GetWeeksListByCountry(id));
        }

        public AvgAmount GetWeeksByCountryAndYear(long id, short year)
        {
            FilterByCountry fbc = new FilterByCountry(id, year);

            List<AvgAmount> lst = (List<AvgAmount>)GetFiltered(fbc.FileterByCountryAndYear);
            
            return (lst.Count > 0)?lst[0]:null;
        }

        public Dictionary<short, byte> GetReadOnlyIndexYearlyByCountry(long id)
        {
            List<AvgAmount> lst = GetWeeksListByCountry(id);
            Dictionary<short, byte> dict = new Dictionary<short, byte>();
            for (int i = 0; i < lst.Count; i++)
            {
                dict.Add(lst[i].Year, lst[i].AvgWeeks);
            }
            return dict;
        }

    }
}
