using System;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.ClientUI
{
    public static class Localizer
    {
        static public string GetLocalized(string s) 
        { 
            return UILocalizer.Current[s]; 
        }
        static public string GetLocalized(int id)
        {
            return UILocalizer.Current[id];
        }
    }

    public class ExceptionWordNotFound : Exception
    {
        string _word = String.Empty;
        
        public ExceptionWordNotFound(string word)
        {
            _word = word;
        }
        public override string Message
        {
            get
            {
                return String.Format("Word- {0} not found", _word); 
            }
        }
    }

    public class ExceptionUIIdNotFound : Exception
    {
        int _id = 0;

        public ExceptionUIIdNotFound(int id)
        {
            _id = id;
        }
        public override string Message
        {
            get
            {
                return String.Format("UiConst identificator {0} not found", _id);
            }
        }
    }

    

    public class UILocalizer
    {
        private Dictionary<int, UIResource> _diction = new Dictionary<int, UIResource>();

        private static UILocalizer _currentLocalizer = null;
        public static UILocalizer Current
        {
            get
            {
                if (_currentLocalizer == null)
                    _currentLocalizer = new UILocalizer();

                return _currentLocalizer;
            }
        }

        public UILocalizer()
        {

        }

        public UILocalizer(List<UIResource> lstWords)
        {
            AssignList(lstWords); 
        }

        public void AssignList(List<UIResource> lstWords)
        {
            _diction.Clear();
            if (lstWords != null)
            {
                foreach (UIResource item in lstWords)
                    _diction[item.ResourceID] = item;
            }
        }

        public Dictionary<int, UIResource> InnerDiction
        {
            get
            {
                return _diction;
            }
        }
        public string this[int idx]
        {
            get
            {
                UIResource value = null;
                _diction.TryGetValue(idx, out value);
                if (value == null)
                {
                    return DefaultDiction.Item (idx);
                }
                else return value.Resource;
            }
        }

        public string this[string itemname]
        {
            get
            {
                int id = DefaultDiction.GetKeyByWord (itemname);

                if (id <= 0)
                    return null;

                return this[id];
            }
        }


        public UIResource GetResourceItem(int resid)
        {
            return (_diction.ContainsKey (resid))? _diction[resid] : null;
        }

       

    }

    public class DictionaryWordToId : Dictionary<string, int>
    {
    }
}
