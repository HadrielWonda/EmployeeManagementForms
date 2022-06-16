using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain ;
using Baumax.Templates;


namespace Baumax.EntityListManager
{
    public class CountryListManager : EntityCache<Country>
    {
        private List<Country> _list = new List<Country>();


        private CountryListManager _instance = null;

        public CountryListManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CountryListManager();
                }
                return _instance;
            }
        }

        private CountryListManager() { }

        protected override void OnAdded(Country entity)
        {
            _list.Add(entity);
            base.OnAdded(entity);

        }

        protected override void OnUpdated(Country entity)
        {
            int idx = GetListIndexbyId(entity.ID);
            _list[idx] = entity;
            base.OnUpdated(entity);
        }

        protected override void OnDeleted(Country entity)
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


        public string GetCountryName(long id)
        {
            if (Contains(id))
            {
                return this[id].Name;
            }
            return String.Empty;
        }


        public List<Country> GetCountryList()
        {
            return (List<Country>)GetAll();
        }

        public BindingTemplate<Country> GetBindingList()
        {
            return new BindingTemplate<Country>(GetCountryList());
        }
    }
}
