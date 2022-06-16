using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public class WeeklyDaysSumView
    {
        WeeklyDaysSum _weeklysum = null;

        public WeeklyDaysSumView()
        {

        }

        public WeeklyDaysSumView(WeeklyDaysSum sums, bool bShow)
        {
            _weeklysum = sums;
            _bShowSign = bShow;
        }

        public WeeklyDaysSum WeeklySums
        {
            get { return _weeklysum; }
            set { _weeklysum = value; }
        }

        private bool _bShowSign = false;

        public bool ShowSign
        {
            get { return _bShowSign; }
            set { _bShowSign = value; }
        }


        public string this[DayOfWeek dayofweek]
        {
            get { return GetDaySum(dayofweek); }
        }

        public string WeekSum
        {
            get { return GetTotal(); }
        }

        private string GetDaySum(DayOfWeek day)
        {
            int dayValue = (WeeklySums!= null)?WeeklySums[day]:0;

            return GetTime(dayValue );
        }
        private string GetTotal()
        {
            return GetTime((WeeklySums!= null)?WeeklySums.TotalSum:0); 
        }

        private string GetTime(int time)
        {
            if (ShowSign)
               return TextParser.TimeToSignString(time);
            else
                return TextParser.TimeToString(time);

        }
    }
}
