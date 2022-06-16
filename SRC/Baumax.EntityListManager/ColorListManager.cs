using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Templates;

namespace Baumax.EntityListManager
{
    public class ColorListManager: EntityCache<Colouring>
    {
        private List<Colouring> _list = new List<Colouring>();

        private ColorListManager _instance = null;

        public ColorListManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ColorListManager();
                }
                return _instance;
            }
        }

        private ColorListManager() { }

        protected override void OnAdded(Colouring entity)
        {
            _list.Add(entity);
            base.OnAdded(entity);

        }

        protected override void OnUpdated(Colouring entity)
        {
            int idx = GetListIndexbyId(entity.ID);
            _list[idx] = entity;
            base.OnUpdated(entity);
        }

        protected override void OnDeleted(Colouring entity)
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
            public bool FileterByCountry(Colouring color)
            {
               return (CountryID == color.ID);
            }
            public FilterByCountry(long id)
            {
                CountryID = id;
            }
        }

        public List<Colouring> GetColorListByCountry(long id)
        {
            FilterByCountry fbc = new FilterByCountry(id);
            return (List<Colouring>)GetFiltered(fbc.FileterByCountry);
        }

        public BindingTemplate<Colouring> GetBindingListByCountry(long id)
        {
            //List<Colouring>
            return new BindingTemplate<Colouring>(GetColorListByCountry(id));
        }
    }
}
