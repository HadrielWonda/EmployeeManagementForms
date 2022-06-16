using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Localization;

namespace Baumax.ClientUI.FormEntities.AbsencePlanning
{
    public class MonthsName
    {
        private static string[] _monthsname = new string[] 
                {
                    "january","february","march",
                    "april","may","june",
                    "july","august","september",
                    "october","november","december"
                };


        private static MonthsName _instance = null;

        private MonthsName()
        {

        }

        protected static MonthsName Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MonthsName();
                return _instance;
            }
        }
        public static string GetName(int index)
        {
            return Instance.GetMonthName(index);
        }
        public static string[] GetNames()
        {
            return Instance.GetMonthsName();
        }

        public string GetMonthName(int index)
        {
            if (index < 1 || index > 12)
                throw new IndexOutOfRangeException("month index (1-12) = " + index);

            return Localizer.GetLocalized(_monthsname[index-1]);
        }
        public string[] GetMonthsName()
        {
            string[] names = new string[12];

            for (int i = 1; i <= 12; i++)
            {
                names[i-1] = GetMonthName(i);
            }

            return names;
        }
    }
}
