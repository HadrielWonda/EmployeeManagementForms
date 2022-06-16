using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Baumax.Contract;
using Baumax.Domain;

namespace Baumax.Contract.TimePlanning
{
    public class TextParser
    {
        public static List<__TimeRange> ParseText(string text)
        {
            if (String.IsNullOrEmpty(text)) return null;

            StringBuilder sb = new StringBuilder(text.Trim());
            sb.Replace(System.Environment.NewLine, " ");
            sb.Replace("\t", " ");
            List<string> lstValues = new List<string>();

            char c;
            StringBuilder sb_number = new StringBuilder(8);
            for (int i = 0; i < sb.Length; i++)
            {
                c = sb[i];
                if (Char.IsNumber(c))
                {
                    sb_number.Append(c);
                }
                else
                {
                    if (sb_number.Length == 8)
                    {
                        lstValues.Add(sb_number.ToString());
                        sb_number.Length = 0;
                    }
                    else
                    {
                        if (sb_number.Length > 0)
                            throw new Exception("Invalid string - " + sb_number.ToString ());
                    }
                }
            }
            if (sb_number.Length == 8)
            {
                lstValues.Add(sb_number.ToString());
                sb_number.Length = 0;
            }
            else
            {
                if (sb_number.Length > 0)
                    throw new Exception("Invalid string - " + sb_number.ToString());
            }


            List<__TimeRange> result = null;
            foreach (string s in lstValues)
            {
                __TimeRange tr = StringToTimeRange(s);
                if (result == null) result = new List<__TimeRange>();
                result.Add(tr);
            }

            return result;
        }
        public static List<__TimeRange> ParseText2(StoreDay storeday, string text)
        {
            if (String.IsNullOrEmpty(text)) return null;

            StringBuilder sb = new StringBuilder(PrepareString(text));

            if (sb.Length == 0) return null;

            string[] values = sb.ToString().Split(' ');

            List<__TimeRange> result = new List<__TimeRange> ();
            __TimeRange tr = null;
            if (values.Length == 1)
            {
                if (IsNumber(values[0]) && values[0].Length == 8)
                {
                    tr = StringToTimeRange(values[0]);
                    if (tr != null)   result.Add(tr);
                }
                else if (IsNumber(values[0]) && values[0].Length < 3)
                {
                    double v = Convert.ToDouble(values[0]);

                    int endtime = (int)(v * 60 + storeday.OpenTime);
                    if (endtime > Utills.MinutesInDay) endtime = Utills.MinutesInDay;
                    tr = new __TimeRange(storeday.OpenTime, (short)endtime);
                    result.Add(tr);
                }
                else
                {
                    //tr = new __TimeRange(storeday.OpenTime, storeday.CloseTime, values[0]);
                    tr = new __TimeRange(0, 0, values[0]);
                    result.Add(tr);
                }
            }
            else
            {
                foreach (string str in values)
                {
                    if (IsNumber(str))
                    {
                        if (str.Length == 8)
                        {
                            tr = StringToTimeRange(str);
                            if (tr != null)
                                result.Add(tr);
                        }
                        else
                        {
                            double v = Convert.ToDouble(values[0]);

                            int endtime = (int)(v * 60 + storeday.OpenTime);
                            if (endtime > Utills.MinutesInDay) endtime = Utills.MinutesInDay;
                            tr = new __TimeRange(storeday.OpenTime, (short)endtime);
                            result.Add(tr);
                        }
                        
                    }
                    else
                    {
                        if (tr != null)
                        {
                            tr.AbsenceCode = str;
                            tr = null;
                        }
                        else
                        {
                            //tr = new __TimeRange(storeday.OpenTime, storeday.CloseTime, str);
                            tr = new __TimeRange(0, 0, str);
                            result.Add(tr);
                            tr = null;
                        }
                    }
                }
            }

            if (result.Count == 0) result = null;

            return result;
            
        }

        /*public static List<__TimeRange> ParseText(string text, short opentime, short closetime, IAbsenceManager absencemanager)
        {
            if (String.IsNullOrEmpty(text))
                return null;

            string[] lines = text.Split(Environment.NewLine);

            List<__TimeRange> resultList = new List<__TimeRange>();

            if (lines.Length == 1)
            {
                string line = PrepareString(lines[0]);
                char nextChar;
                StringBuilder sb = new StringBuilder();
                List<String> items = new List<string>();
                for (int i = 0; i < line.Length; i++)
                {
                    nextChar = line[0];

                    if (nextChar == '+' || nextChar == '-' || nextChar == ' ')
                    {
                        items.Add(sb.ToString());
                        sb.Length = 0;
                    }
                    else sb.Append(nextChar);

                }
                items.Add(sb.ToString());




                return;
            }
        }
        private static void ProcessItems(List<string> items, short opentime, short closetime, IAbsenceManager absencemanager, List<__TimeRange> ranges)
        {
            List<string> clearItems = new List<string>();
            foreach (string s in items)
                if (s != " ") clearItems.Add(s);

            __TimeRange tr = null;
            int nextIndex = 0;
            string s;
            while (true)
            {
                if (nextIndex < clearItems.Count)
                {
                    s = clearItems[nextIndex];
                    nextIndex++;
                }
                else s = null;
            }
            foreach (string s in clearItems)
            {
                if (IsNumber(s))
                {
                    if (s.Length == 8)
                    {
                        tr = StringToTimeRange(s);
                    }
                }
            }

        }*/
        private static string PrepareString(string value)
        {
            if (String.IsNullOrEmpty(value)) return null;

            StringBuilder sb = new StringBuilder(value);
            sb.Replace(System.Environment.NewLine, " ");
            sb.Replace("\n", " ");
            sb.Replace("\t", " ");
            sb.Replace("\r", " ");
            string returnString = sb.ToString().Trim();
            if (String.IsNullOrEmpty(returnString)) return null;
            return returnString;
        }
        public static bool IsNumber(string value)
        {
            double result = 0;
            return Double.TryParse(value, out result);
        }

        public static __TimeRange StringToTimeRange(string text)
        {
            string a_hour, a_minute, b_hour, b_minute;

            a_hour = text.Substring(0, 2);
            a_minute = text.Substring(2, 2);

            b_hour = text.Substring(4, 2);
            b_minute = text.Substring(6, 2);

            short a, b;

            a = (short)(Convert.ToInt32(a_hour) * 60 + Convert.ToInt32(a_minute));
            b = (short)(Convert.ToInt32(b_hour) * 60 + Convert.ToInt32(b_minute));
            if (a > Utills.MinutesInDay) return null;
            if (b > Utills.MinutesInDay) b = (short)(Utills.MinutesInDay);

            if (a == b) return null;
            //if (a >= b) throw new Exception("Invalid time range (" + TimeRangeToString (a,b) + ")");

            return new __TimeRange(a, b);
        }

        public static string TimeRangeToString(short a, short b)
        {
            return String.Format("{0}-{1}", TimeToString(a), TimeToString(b));
        }

        public static string TimeToString(short a)
        {
            int h = (a / 60);
            int m = Math.Abs (a % 60);
            return String.Format("{0}:{1}", h.ToString ("00"), m.ToString ("00"));
        }
        public static string TimeToString(int a)
        {
            int h = (a / 60);
            int m = Math.Abs(a % 60);
            return String.Format("{0}:{1}", h.ToString("00"), m.ToString("00"));
        }
        public static string TimeRangeToEditString(short a, short b)
        {
            return String.Format("{0}{1}", TimeToEditString(a), TimeToEditString(b));
        }

        public static string AbsenceTimeRangeToEditString(short a, short b, string abbrev)
        {
            return String.Format("{0}{1} {2}", TimeToEditString(a), TimeToEditString(b), abbrev);
        }

        public static string TimeToEditString(short a)
        {
            int h = (a / 60);
            int m = Math.Abs(a % 60);
            return String.Format("{0}{1}", h.ToString("00"), m.ToString("00"));
        }
        public static string AbsenceTimeRangeToString(short a, short b, string abbr)
        {
            if (abbr == null) abbr = String.Empty;
            return String.Format("{0}-{1} ({2})", TimeToString(a), TimeToString(b), abbr);
        }
        public static string EmployeeTimeToString(EmployeeTimeRange range)
        {
            if (range.Absence != null)
                return AbsenceTimeRangeToString(range.Begin, range.End, range.Absence.CharID);
            else
                return TimeRangeToString(range.Begin, range.End);
        }

        public static string TimeToSignString(int time)
        {
            if (time == 0)
                return "00:00";

            int h = Math.Abs(time / 60);
            int m = Math.Abs(time % 60);
            if (time >= 0)
                return String.Format("+{0:D2}:{1:D2}", h, m);
            else
                return String.Format("-{0:D2}:{1:D2}", h, m);
        }

        public static string ToPercent(double value)
        {
            return String.Format("{0:F2}%", value);
        }
        public static string ToSignPercent(double value)
        {
            if (value > 0)
                return String.Format("+{0:F2}%", value);
            else
                return String.Format("{0:F2}%", value);
        }
        public static string ToRoundSignPercent(double value)
        {
            if (value > 0)
                return String.Format("+{0}%", Math.Round (value));
            else
                return String.Format("{0}%", Math.Round(value));
        }
        //public static string BuildDifferenceAbsoluteSum(int abs_sum, int pos_sum, int neg_sum)
        //{
        //    StringBuilder sb = new StringBuilder(20);

        //    sb.Append(TimeToString(abs_sum));
        //    sb.Append(" (");

           
        //    sb.Append(TimeToSignString(pos_sum));
        //    sb.Append(" / ");

        //    //sb.Append(TimeToSignString(Math.Abs(neg_sum)));
        //    sb.Append(TimeToSignString(neg_sum));

        //    sb.Append(")");
        //    return sb.ToString();

        //}

        public static string BuildDifferenceAbsoluteSumInPercent(double abs_sum, double pos_sum, double neg_sum)
        {
            StringBuilder sb = new StringBuilder(20);

            sb.Append(ToRoundSignPercent(abs_sum));
            sb.Append(" (");
            sb.Append(ToRoundSignPercent(pos_sum));
            sb.Append(" / ");
            sb.Append(ToRoundSignPercent(neg_sum));
            sb.Append(")");

            return sb.ToString();

        }


        public static string BuildColumnCaption(int hours, int minutes, int step)
        {
            int endhours = hours;
            int endminutes = minutes;
//
            endminutes += step;
            if (endminutes == 60)
            {
                endhours++;
                endminutes = 0;
            }

            return String.Format("{0:D2}:{1:D2}-\n{2:D2}:{3:D2}", new object[] { hours, minutes, endhours, endminutes });
        }

    }

    public class __TimeRange:IComparable<__TimeRange >
    {
        public short BeginTime = 0;
        public short EndTime = 0;
        public long AbsenceId = 0;
        public string AbsenceCode = String.Empty;
        public Color BeginColor = Color.Black;
        public Color EndColor = Color.Black;

        public __TimeRange()
        {

        }
        public __TimeRange(short a, short b)
        {
            BeginTime = a;
            EndTime = b;
            //Rounded();
        }

        public __TimeRange(short a, short b, long absenceId):this(a,b)
        {
            AbsenceId = absenceId;
        }
        public __TimeRange(short a, short b, string code, bool round)
        {
            BeginTime = a;
            EndTime = b;
            AbsenceCode = code;
            if (round)
                Rounded();
        }
        public __TimeRange(short a, short b, string code)
            : this(a, b)
        {
            AbsenceCode = code;
        }
        public __TimeRange(short a, short b, string code, Color color)
            : this(a, b)
        {
            AbsenceCode = code;
            BeginColor = color;
        }
        public __TimeRange(short a, short b, string code, Color color, bool round)
        {
            BeginTime = a;
            EndTime = b;
            AbsenceCode = code;
            if (round)
                Rounded();
            BeginColor = color;
        }
        public void Rounded()
        {
            short s = (short)(BeginTime % 15);

            if (s != 0)
            {
                if (s < 8) BeginTime -= s;
                else BeginTime += (short)(15 - s);
            }

            s = (short)(EndTime % 15);

            if (s != 0)
            {
                if (s < 8) EndTime -= s;
                else EndTime += (short)(15 - s);
            }
        }

        public bool Validation()
        {
            return BeginTime < EndTime;
        }
        public int CompareTo(__TimeRange t)
        {
            return BeginTime - t.BeginTime;
        }

        public bool IsIntersect(__TimeRange t)
        {
            return DateTimeHelper.IsIntersectInc(BeginTime, EndTime, t.BeginTime, t.EndTime); 
        }

        public string AsTimeString
        {
            get 
            {
                if (!String.IsNullOrEmpty (AbsenceCode))
                    return TextParser.TimeRangeToString(BeginTime, EndTime) + " (" + AbsenceCode + ")";
                else
                    return TextParser.TimeRangeToString(BeginTime, EndTime); 
            }
        }
        public string AsTimeEditString
        {
            get
            {
                if (!String.IsNullOrEmpty(AbsenceCode))
                    return TextParser.AbsenceTimeRangeToEditString(BeginTime, EndTime, AbsenceCode );
                else
                    return TextParser.TimeRangeToEditString(BeginTime, EndTime);
            }
        }

    }

    public class TimeRangeValidator
    {
        List<__TimeRange> _ranges = new List<__TimeRange>();

        public List<__TimeRange> Ranges
        {
            get { return _ranges; }
        }

        public void AddAndValidate(List<__TimeRange> list)
        {
            Ranges.Clear();

            if (list == null || list.Count == 0) return;

            foreach (__TimeRange range in list)
            {
                if (range.Validation ())
                    AddRange(range);
            }

            list.Clear();

            Checking();
            JoinEqualRanges();
            list.AddRange(Ranges);
        }
        private void Checking()
        {
            for (int i = Ranges.Count - 1; i >= 0; i--)
            {
                if (!Ranges[i].Validation()) Ranges.RemoveAt(i);
            }
        }
        private void JoinEqualRanges()
        {
            if (Ranges.Count <= 1) return;
            __TimeRange range = Ranges[Ranges.Count - 1];

            for (int i = Ranges.Count - 2; i >= 0; i--)
            {
                if (Ranges[i].EndTime == range.BeginTime && range.AbsenceId == Ranges[i].AbsenceId)
                {
                    range.BeginTime = Ranges[i].BeginTime;
                    Ranges.RemoveAt(i);
                }
                else
                {
                    range = Ranges[i];
                }
            }
             
        }
        private void AddRange(__TimeRange range)
        {
            if (range.Validation())
            {
                Ranges.Add(range);
                Ranges.Sort();
                short end = Ranges[0].EndTime;
                for (int i = 1; i < Ranges.Count; i++)
                {
                    if (Ranges[i].BeginTime < end && end <= Ranges[i].EndTime)
                    {
                        Ranges[i].BeginTime = end;
                    }
                    end = Ranges[i].EndTime;
                }
            }
        }
    }


    public class ParserEx
    {
        IAbsenceManager _manager = null;

        int _opentime = 0;
        int _closetime = 0;
        int _daytime = 0;

        List<__TimeRange> _ranges = new List<__TimeRange>();
        __TimeRange _lastRange = null;

        string _lastLeksem = null;
        StringBuilder _lastValue = new StringBuilder(10);
        List<string> _values = new List<string>();
        int _lastIndex = -1;

        public ParserEx(IAbsenceManager manager, int opentime, int closetime, int daytime)
        {
            _manager = manager;
            _opentime = opentime;
            _closetime = closetime;
            _daytime = daytime;
        }

        public IAbsenceManager Manager
        {
            get { return _manager; }
        }
        public int OpenTime
        {
            get { return _opentime; }
        }

        public int CloseTime
        {
            get { return _closetime; }
        }
        public int DayTime
        {
            get { return _daytime; }
        }

        public List<__TimeRange> Ranges
        {
            get { return _ranges; }
        }
        public void ParserText(string text)
        {
            string prepare_text = PrepareString(text);

            if (String.IsNullOrEmpty(prepare_text)) return;

            _values.Clear();
            _lastIndex = -1;
            _ranges.Clear();
            _lastRange = null;
            _lastLeksem = null;
            _lastValue.Length = 0;
            _ranges.Clear();
            foreach (char c in prepare_text)
            {
                ProcessChar(c);
            }
            ProcessChar(' ');
            if (_values.Count == 0) return;

            ProcessLeksems();

            if (_ranges != null)
            {
                foreach (__TimeRange r in _ranges)
                {
                    if (String.IsNullOrEmpty(r.AbsenceCode))
                    {
                        r.Rounded();
                    }
                    else
                    {
                        Absence absence = Manager.GetByAbbreviation(r.AbsenceCode);
                        if (absence != null && !absence.IsFixed)
                        {
                            r.Rounded();
                        }
                    }
                }
            }

            TimeRangeValidator v = new TimeRangeValidator();
            v.AddAndValidate(_ranges);

        }
        private bool IsNumber(string value)
        {
            int number = 0;
            return Int32.TryParse(value, out number);
        }
        private bool IsAbsence(string value)
        {
            return Manager.GetByAbbreviation(value) != null;
        }
        private void ProcessLeksems()
        {
            foreach (string s in _values)
            {
                if (IsAbsence(s))
                {
                    ProcessAbsence(s);
                }
                else
                {
                    ProcessTimeRange(s);
                }
            }
        }

        private void ProcessTimeRange(string s)
        {
            int d = 0;

            if (Int32.TryParse(s, out d))
            {
                if (d > 0 && d <= 24)
                {
                    _lastRange = new __TimeRange ((short)OpenTime, (short)(OpenTime + d*60));
                    if (_lastRange.EndTime > Utills.MinutesInDay)
                        _lastRange.EndTime = Utills.MinutesInDay;
                    _ranges.Add(_lastRange);
                    return;
                }
                if (s.Length == 8)
                {
                    _lastRange = TextParser.StringToTimeRange(s);
                    if (_lastRange.EndTime > Utills.MinutesInDay)
                        _lastRange.EndTime = Utills.MinutesInDay;
                    _ranges.Add(_lastRange);
                }

            }
        }

        private void ProcessAbsence(string s)
        {
            Absence absence = Manager.GetByAbbreviation(s);
            if (absence != null)
            {
                if (absence.IsFixed)
                {
                    if (_lastRange == null)
                    {
                        _lastRange = new __TimeRange((short)OpenTime, (short)(OpenTime + DayTime), s, false);
                        _ranges.Add(_lastRange);
                    }
                    else
                    {
                        _lastRange.AbsenceCode = s;
                        
                    }
                    _lastRange = null;
                    
                }
                else if (absence.Value > 0)
                {
                    if (_lastRange == null)
                    {
                        _lastRange = new __TimeRange((short)OpenTime, (short)(OpenTime + absence.Value * 60), s);
                        _ranges.Add(_lastRange);
                    }
                    else
                    {
                        _lastRange.AbsenceCode = s;
                    }
                    
                    _lastRange = null;
                }
                else
                {
                    if (_lastRange != null)
                    {
                        _lastRange.AbsenceCode = s;
                        //_ranges.Add(_lastRange);
                        //_lastRange = null;
                    }
                    _lastRange = null;
                }
            }
        }
        private void ProcessChar(char c)
        {
            
            if (Char.IsLetterOrDigit(c))
            {
                _lastValue.Append(c);
            }
            else
            {
                if (_lastValue.Length > 0)
                    ProcessLeksem();
            }
        }

        private void ProcessLeksem()
        {
            _lastLeksem = _lastValue.ToString();
            _lastValue.Length = 0;
            _values.Add(_lastLeksem);
        }
        private string PrepareString(string value)
        {
            if (String.IsNullOrEmpty(value)) return null;

            StringBuilder sb = new StringBuilder(value);
            sb.Replace(System.Environment.NewLine, " ");
            sb.Replace("\n", " ");
            sb.Replace("\t", " ");
            sb.Replace("\r", " ");
            string returnString = sb.ToString().Trim();
            if (String.IsNullOrEmpty(returnString)) return null;
            return returnString;
        }
    }
}
