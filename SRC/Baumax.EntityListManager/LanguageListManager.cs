using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Templates ;

namespace Baumax.EntityListManager
{
    public class LanguageListManager : EntityCache<Language>
    {
        private List<Language> _list = new List<Language>();

        
        private LanguageListManager _instance = null;

        public LanguageListManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LanguageListManager();
                }
                return _instance;
            }
        }

        private LanguageListManager() {}

        protected override void OnAdded(Language entity)
        {
            _list.Add(entity);
            base.OnAdded(entity);

        }

        protected override void OnUpdated(Language entity)
        {
            int idx = GetListIndexbyId(entity.ID);
            _list[idx] = entity;
            base.OnUpdated(entity);
        }

        protected override void OnDeleted(Language entity)
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


        public string GetLanguageName(long id)
        {
            if (Contains(id))
            {
                return this[id].Name;
            }
            return String.Empty;
        }


        public List<Language> GetLanguageList()
        {
            return (List<Language>)GetAll();
        }

        public BindingTemplate<Language> GetBindingList()
        {
            return new BindingTemplate<Language>(GetLanguageList());
        }
    }
}
