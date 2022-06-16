using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using System.Drawing;

namespace Baumax.Contract.TimePlanning
{

    /*public class RecordingDayViewList : Dictionary<long, RecordingDayView>
    {
        private const int MAXRANGES = 4*24;

        private int[] sums = new int[MAXRANGES];
        
        public void CalculateSum()
        {
            for (int i = 0; i < MAXRANGES; i++)
            {
                sums[i] = 0;
            }

            foreach (RecordingDayView var in this.Values)
            {
                for (int i = 0; i < MAXRANGES; i++)
                {
                    if (var._recordingTimes[i].Worked) sums[i] += 15;
                }
            }
        }


        public int GetSumByView(short time, DailyViewStyle view)
        {
            
            int index = time / 15;

            if (index < 0 || index >= MAXRANGES)
                throw new Exception();

            if (view == DailyViewStyle.View15) return sums[index];

            int step = 2;
            if (view == DailyViewStyle.View60) step = 4;
            int result = 0;

            for (int i = index; i < step; i++)
            {
                result += sums[i];
            }
            return result;
        }
    }
    */

    public class RecordingDayView
    {
        private const int MAXRANGES = 4*24;
        private readonly Color EMPTYCOLOR = Color.White;
        private readonly Color WORKCOLOR = Color.Blue;
        private long _EmployeeId;
        private bool _Modified = false;
        
        protected internal _TimeRange[] _recordingTimes = new _TimeRange[MAXRANGES];

        private EmployeeDay _RecordingDay = null;

        public long EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }

        private string _FullName;

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }
        public bool Modified
        {
            get { return _Modified; }
            set {_Modified = value; }
        }

        public EmployeeDay RecordingDay
        {
            get { return _RecordingDay; }
            set 
            {
                if (_RecordingDay != value)
                {
                    _RecordingDay = value;

                    AssignRecordingDay(_RecordingDay);
                }
            }
        }

        public void AssignRecordingDay(EmployeeDay recday)
        {
            ClearRecording();
            if (recday != null)
            {
                List<EmployeeTimeRange> timeList = recday.TimeList;

                if (timeList != null)
                {
                    int index = 0;
                    foreach (EmployeeTimeRange var in timeList)
                    {
                        index = var.Begin / 15;
                        for (int i = var.Begin; i < var.End; i += 15, index++)
                        {
                            if (var.Absence == null)
                                _recordingTimes[index].Worked = true;
                            else
                                _recordingTimes[index].AbsenceEntity = var.Absence;
                        }
                    }
                }
            }
            else
            {
                ClearRecording();
            }
            Modified = false;
        }
        
        public bool IsEmpty(short time)
        {
            int index = time / 15;
            if (index >= 0 && index < MAXRANGES)
                return _recordingTimes[index].Empty;
            else return false;
        }

        public bool IsEmpty(short begintime, short endtime)
        {
            bool bEmpty = true;
            for (int i = begintime; i < endtime ; i+=15)
            {
                bEmpty &= IsEmpty((short)i);
            }
            return bEmpty;
        }

        public bool IsWorkingTime(short time)
        {
            int index = time / 15;
            if (index >= 0 && index < MAXRANGES)
                return _recordingTimes[index].Worked;
            else return false;
        }
        public bool IsAbsenceTime(short time)
        {
            int index = time / 15;
            if (index >= 0 && index < MAXRANGES)
                return _recordingTimes[index].Absenced;
            return false;
        }


        public bool ResetTimeRange(short begintime, short endtime)
        {
            int index = begintime / 15;

            for (int i = begintime; i < endtime; i += 15, index++)
            {
                if (!_recordingTimes[index].Empty) Modified = true;
                _recordingTimes[index].Empty = true;
            }
            return Modified;
        }
        public bool MarkAsWorkingTime(short begintime, short endtime)
        {
            int index = begintime / 15;

            for (int i = begintime; i < endtime; i += 15, index++)
            {
                if (!_recordingTimes[index].Worked) Modified = true;
                _recordingTimes[index].Worked  = true;
            }
            return Modified;
        }
        public bool MarkAsAbsenceTime(short begintime, short endtime, Absence absence)
        {
            int index = begintime / 15;

            for (int i = begintime; i < endtime; i += 15, index++)
            {
                if (_recordingTimes[index].AbsenceEntity != absence) Modified = true;
                _recordingTimes[index].AbsenceEntity = absence;
            }

            return Modified;
        }

        public Color GetColorByTime(short time)
        {
            int index = time / 15;
            if (_recordingTimes[index].Empty) return EMPTYCOLOR;
            if (_recordingTimes[index].Worked) return WORKCOLOR;

            if (_recordingTimes[index].AbsenceEntity != null)
                return Color.FromArgb(_recordingTimes[index].AbsenceEntity.Color);
            else throw new NullReferenceException();
        }
        
        public void UpdateRecordingDay()
        {
            if (RecordingDay != null)
            {
                RecordingDay.TimeList = GetRecordingTimeRanges(RecordingDay.EmployeeId, RecordingDay.Date);
                RecordingDay.Modified = true;
            }
        }

        private List<EmployeeTimeRange> GetRecordingTimeRanges(long employeeid, DateTime date)
        {
            List<EmployeeTimeRange> result = new List<EmployeeTimeRange> ();

            EmployeeTimeRange range = null;
            int i=0;
            while(i < MAXRANGES )
            {
                if (!_recordingTimes[i].Empty)
                {
                    range = new EmployeeTimeRange();
                    range.EmployeeID = employeeid;
                    range.Date = date;
                    range.Begin = (short)(i * 15);
                    range.End = (short)(range.Begin + 15) ;

                    if (_recordingTimes[i].Absenced)
                    {
                        
                        range.Absence = _recordingTimes[i].AbsenceEntity;
                        if (range.Absence != null)
                            range.AbsenceID = range.Absence.ID;
                        i++;
                        while (i < MAXRANGES)
                        {
                            if (range.Absence == _recordingTimes[i].AbsenceEntity)
                            {
                                range.End += 15;
                            }
                            else
                            {
                                range.Time = (short)(range.End - range.Begin);
                                result.Add(range);
                                range = null;
                                break;
                            }
                            i++;
                        }
                        continue;
                    }
                    else
                    {
                        i++;
                        while (i < MAXRANGES)
                        {
                            if (_recordingTimes[i].Worked)
                            {
                                range.End += 15;
                            }
                            else
                            {
                                range.Time = (short)(range.End - range.Begin);
                                result.Add(range);
                                range = null;
                                break;
                            }
                            i++;
                        }
                        continue;
                    }
                    
                }
                i++;
            }
            if (range != null)
            {
                range.Time = (short)(range.End - range.Begin);
                result.Add(range);
            }

            if (result.Count == 0) return null;

            return result;
        }

        public void ClearRecording()
        {
            for (int i = 0; i < MAXRANGES; i++)
            {
                _recordingTimes[i].Empty = true;
            }
        }


        public bool Compare(RecordingDayView view)
        {
            for (int i = 0; i < _recordingTimes.Length; i++)
            {
                if ((_recordingTimes[i].State != view._recordingTimes[i].State) ||
                    (_recordingTimes[i].AbsenceEntity != view._recordingTimes[i].AbsenceEntity)) return false;
            }
            return true;
        }

        public void CopyTo(RecordingDayView view)
        {
            for (int i = 0; i < MAXRANGES; i++)
            {
                if (_recordingTimes[i].AbsenceEntity != null)
                    view._recordingTimes[i].AbsenceEntity = _recordingTimes[i].AbsenceEntity;
                else
                    view._recordingTimes[i].State = _recordingTimes[i].State;
            }
        }
        #region helper structure

        protected internal struct _TimeRange
        {
            public CellState State;
            private Absence _AbsenceEntity;

            public bool Empty
            {
                get { return State == CellState.Empty; }
                set
                {
                    if (value)
                    {
                        State = CellState.Empty;
                        _AbsenceEntity = null;
                    }
                }
            }

            public Absence AbsenceEntity
            {
                get { return _AbsenceEntity; }
                set
                {
                    if (value == null)
                    {
                        _AbsenceEntity = null;
                        State = CellState.Empty;
                    }
                    else
                    {
                        _AbsenceEntity = value;
                        State = CellState.Absence;
                    }
                }
            }

            public bool Worked
            {
                get { return State == CellState.WorkingTime; }
                set
                {
                    if (value)
                    {
                        State = CellState.WorkingTime;
                        _AbsenceEntity = null;
                    }
                    else
                    {
                        State = CellState.Empty;
                        _AbsenceEntity = null;
                    }
                }
            }

            public bool Absenced
            {
                get { return State == CellState.Absence; }
            }
        }

        protected internal enum CellState
        {
            Empty =0,
            WorkingTime = 1,
            Absence = 2
        }

        #endregion


        #region Total rows data

        #endregion
    }


    
}
