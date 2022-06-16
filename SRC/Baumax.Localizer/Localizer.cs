using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Localization
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


    public interface IUIProvider
    {
        string this[int idx]{get;}
        long LanguageId { get;}
    }

    public class UILocalizer
    {
        private Dictionary<int, string> _diction = new Dictionary<int, string>();
        private static UILocalizer _currentLocalizer = null;
        private long _languageid = -1;

        IUIProvider m_provider = null;

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

        public IUIProvider UIProvider
        {
            get
            {
                return m_provider;
            }
            set
            {
                m_provider = value;
            }
        }

        private string GetFromProvider(int idx)
        {
            if (UIProvider != null)
                return UIProvider[idx];

            return null;
        }
        private string GetDefaultValue(int idx)
        {
            return DefaultDiction.Item(idx);
        }

        private string GetValue(int idx)
        {
            string value = GetFromProvider (idx);
            if (value == null) value = GetDefaultValue(idx);
            return value;
        }
        public void Add(int id, string value)
        {
            _diction[id] = value;
        }


        public long LanguageID
        {
            get { return _languageid; }
            set { _languageid = value; }
        }


        public Dictionary<int, string> InnerDiction
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
                return GetValue(idx);
                /*string value = null;
                _diction.TryGetValue(idx, out value);
                if (value == null || value == String.Empty)
                {
                    return DefaultDiction.Item(idx);
                }
                else return value;*/
            }
        }

        public string this[string itemname]
        {
            get
            {
                int id = DefaultDiction.GetKeyByWord(itemname);

                if (id <= 0)
                    //throw new Exception();
                    return null;

                return this[id];
            }
        }

    }
}
