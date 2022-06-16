using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Baumax.Contract.TimePlanning
{
    [Serializable()]
    public class StoreDaysList : Dictionary<DateTime, StoreDay>, IStoreDaysList
    {
        private long m_StoreId = 0;
        private DateTime m_BeginTime ;
        private DateTime m_EndTime ;
        private double m_AvgWorkingDayInWeek = 0;
        private byte m_WarningDays = 0;
        private byte m_AlarmDays = 0;

        public long StoreId
        {
            get { return m_StoreId; }
            set { m_StoreId = value; }
        }

        public DateTime BeginTime
        {
            get { return m_BeginTime; }
            set { m_BeginTime = value; }
        }

        public DateTime EndTime
        {
            get { return m_EndTime; }
            set { m_EndTime = value; }
        }

        public double AvgDayInWeek
        {
            get { return m_AvgWorkingDayInWeek; }
            set { m_AvgWorkingDayInWeek = value; }
        }

        public bool IsUndefined()
        {
            bool result = true;
            foreach (StoreDay day in Values)
            {
                result &= day.Undefined;
            }
            return result;
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("sid", m_StoreId);
            info.AddValue("bw", m_BeginTime);
            info.AddValue("ew", m_EndTime);
            info.AddValue("vwdw", m_AvgWorkingDayInWeek);
            info.AddValue("wd", m_WarningDays);
            info.AddValue("ad", m_AlarmDays);
            base.GetObjectData(info, context);
        }

        public byte WarningDays
        {
            get { return m_WarningDays; }
            set { m_WarningDays = value; }
        }
        public byte AlarmDays
        {
            get { return m_AlarmDays; }
            set { m_AlarmDays = value; }
        }

        protected StoreDaysList(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            m_StoreId = info.GetInt64("sid");
            m_BeginTime = info.GetDateTime("bw");
            m_EndTime = info.GetDateTime("ew");
            m_AvgWorkingDayInWeek = info.GetDouble("vwdw");
            m_WarningDays = info.GetByte("wd");
            m_AlarmDays = info.GetByte("ad");
        }

        public StoreDaysList(long aStoreId, DateTime aBegin, DateTime aEnd)
        {
            m_StoreId = aStoreId;
            m_BeginTime = aBegin;
            m_EndTime = aEnd;
            BuildDays();
        }

        private void BuildDays()
        {
            DateTime dt = BeginTime;
            while (dt <= EndTime)
            {
                this[dt] = new StoreDay(dt);
                dt = dt.AddDays(1);
            }
        }

        public void ApplyClosedDays(ICollection lst)
        {
            if (lst != null && lst.Count > 0)
            {
                foreach (YearlyWorkingDay d in lst)
                {
                    if (ContainsKey(d.WorkingDay))
                        this[d.WorkingDay].ClosedDay = true;
                }
            }
        }
        //public void ApplyFeastDays(IList lst)
        public void ApplyFeastDays(ICollection lst)
        {
            if (lst != null && lst.Count > 0)
            {
                foreach (Feast d in lst)
                {
                    if (ContainsKey(d.FeastDate))
                        this[d.FeastDate].Feast = true;
                }
            }
        }

        public void ApplyOpenCloseTimes(IList lst)
        {
            if (lst != null && lst.Count > 0)
            {
                foreach (StoreWorkingTime swt in lst)
                {
                    ApplyOpenCloseTimes(swt);
                }
            }
        }

        public void ApplyOpenCloseTimes(StoreWorkingTime times)
        {
            foreach (StoreDay sd in Values)
            {
                if (times.BeginTime <= sd.Date && sd.Date <= times.EndTime)
                {
                    foreach (StoreWTWeekday weekday in times.StoreWTWeekdays)
                    {
                        if (weekday.Weekday == (byte)sd.Date.DayOfWeek)
                        {
                            sd.OpenTime = weekday.Opentime;
                            sd.CloseTime = weekday.Closetime;
                            sd.Undefined = false;
                        }
                    }
                }
            }
        }
        


        public int CountWorkingDayOnWeek
        {
            get
            {
                int result = 0;

                foreach (StoreDay sd in this.Values)
                    if (IsStoreWorkingDay(sd.Date)) result++;

                return result;
            }
        }

        public bool IsStoreWorkingDay(DateTime date)
        {
            StoreDay sd = null;

            if (this.TryGetValue(date, out sd))
            {
                return (!sd.ClosedDay) && (sd.CloseTime != 0);
            }

            throw new Exception("Invalid date " + date.ToShortDateString ());
        }
        public bool IsStoreFeastDay(DateTime date)
        {
            StoreDay sd = null;

            if (this.TryGetValue(date, out sd))
            {
                return sd.Feast;
            }
            throw new Exception("Invalid date " + date.ToShortDateString ());
        }
    }

    [Serializable ]
    public sealed class StoreDay
    {
        #region fields
        
        private DateTime m_Date = DateTime.Today;
        private bool m_ClosedDay = false;
        private bool m_Feast = false;
        private short m_OpenTime = 0;
        private short m_CloseTime = 0;
        private bool m_Undefined = true;
        
        #endregion 

        #region Properties

        public DateTime Date
        {
            get { return m_Date; }
        }
        
        public bool ClosedDay
        {
            get { return m_ClosedDay; }
            set { m_ClosedDay = value; }
        }
        public bool Feast
        {
            get { return m_Feast; }
            set { m_Feast = value; }
        }
        public bool Undefined
        {
            get { return m_Undefined; }
            set { m_Undefined = value; }
        }
        public short OpenTime
        {
            get { return m_OpenTime; }
            set { m_OpenTime = value; }
        }
        public short CloseTime
        {
            get { return m_CloseTime; }
            set { m_CloseTime = value; }
        }
        

        #endregion


        public StoreDay(DateTime aDate)
        {
            m_Date = aDate;
        }

        public bool IsOpeningTime(short time)
        {
            return (time >= OpenTime) && (time < CloseTime);
        }
        public bool IsWorkingDay
        {
            get
            {
                return !ClosedDay && !Undefined && (OpenTime > 0) && (CloseTime > 0);
            }
        }

    }
}
