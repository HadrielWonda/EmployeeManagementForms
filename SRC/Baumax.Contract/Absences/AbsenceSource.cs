using System;
using System.Collections.Generic;
using System.Drawing;
using Baumax.Domain;

namespace Baumax.Contract.Absences
{
    //public interface IAbsenceSource
    //{
    //    Color Color             { get;    }
    //    long EmployeeID         { get;set;}
    //    AbsenceEnum AbsenceEnum { get;set;}
    //}

    //public class BaseAbsenceSource : IAbsenceSource
    //{
    //    protected long m_EmployeeID;
    //    protected AbsenceEnum m_AbsenceEnum;
    //    protected string m_Postfix;
    //    protected Color m_Color; 

    //    public virtual string  Postfix
    //    {
    //        get { return m_Postfix; }
    //        set { m_Postfix = value; }
    //    }

    //    public virtual AbsenceEnum AbsenceEnum
    //    {
    //        get { return m_AbsenceEnum; }
    //        set { m_AbsenceEnum = value; }
    //    }
    //    public virtual long EmployeeID
    //    {
    //        get { return m_EmployeeID; }
    //        set { m_EmployeeID = value; }
    //    }
    //    public virtual Color Color 
    //    {
    //        get { return m_Color; }
    //    }

    //    protected static AbsenceEnum Convert (AbsenceType type)
    //    {
    //        switch (type)
    //        {
    //            case AbsenceType.Absence:
    //                return AbsenceEnum.Absence;
    //                break;
    //            case AbsenceType.Holiday:
    //                return AbsenceEnum.Holyday;
    //                break;
    //            case AbsenceType.Illness:
    //                return AbsenceEnum.Illness;
    //                break;
    //            default:
    //                return AbsenceEnum.Absence;
    //                break;
    //        }
    //    }

    //    public BaseAbsenceSource (long employeeID, Absence absence) 
    //        : this (employeeID, Convert(absence.AbsenceTypeID))
    //    {
    //        m_Color = Color.FromArgb(absence.Color);
    //        CreatePostfix(absence.CharID);
    //    }

    //    public BaseAbsenceSource(long employeeID, LongTimeAbsence absence)
    //        : this(employeeID, AbsenceEnum.LongTime)
    //    {
    //        m_Color = Color.FromArgb(absence.Color);
    //        CreatePostfix(absence.CharID);
    //    }

    //    public BaseAbsenceSource(long employeeID, AbsenceEnum type)
    //    {
    //        m_EmployeeID = employeeID;
    //        m_AbsenceEnum = type;
    //        m_Color = PlanColor.GetColor(type);
    //    }

    //    protected void CreatePostfix (string abreviat)
    //    {
    //        int parsed;
    //        m_Postfix = int.TryParse(abreviat, out parsed) 
    //                    ? string.Concat("(", abreviat, ")")
    //                    : abreviat;
    //    }
    //}

    //public class AbsenceSourceWeek : BaseAbsenceSource
    //{
    //    private double m_Days = 0;
    //    private int m_Week;

    //    public int Week
    //    {
    //        get { return m_Week; }
    //        set { m_Week = value; }
    //    }
    //    public double Days
    //    {
    //        get { return m_Days; }
    //        set { m_Days = value; }
    //    }

    //    public AbsenceSourceWeek(int weekNumber, long employeeID, double days, Absence absence)
    //        : base (employeeID, absence)
    //    {
    //        m_Days = days;
    //        m_Week = weekNumber;
    //    }

    //    public AbsenceSourceWeek(int weekNumber, long employeeID, double days, LongTimeAbsence absence)
    //        : base (employeeID, absence)
    //    {
    //        m_Days = days;
    //        m_Week = weekNumber;
    //    }

    //    public AbsenceSourceWeek (long employeeID, int week, AbsenceEnum type):base(employeeID, type)
    //    {
    //        m_Week = week;
    //    }

    //    public override string ToString()
    //    {
    //       return (m_Days == 0) ? string.Empty : string.Format("{0} {1}", m_Days, m_Postfix);
    //    }
    //}

    //public class AbsenceSource : BaseAbsenceSource
    //{
    //    private short m_BeginTime;
    //    private short m_EndTime;
    //    private DateTime m_Date;
        
    //    public DateTime Date
    //    {
    //        get { return m_Date; }
    //        set { m_Date = value; }
    //    }
        
    //    public int Minutes
    //    {
    //        get { return m_EndTime - m_BeginTime; }
    //    }

    //    public AbsenceSource(IEmployeeTimeRange absence, AbsenceManager manager)
    //        : base (absence.EmployeeID, manager[absence.AbsenceID])
    //    {
    //        m_BeginTime = absence.Begin;
    //        m_EndTime = absence.End;
    //        m_Date = absence.Date;
    //    }

    //    public AbsenceSource(long employeeID, DateTime date, LongTimeAbsence absence) 
    //        : base(employeeID, absence)
    //    {
    //        m_Date = date;
    //    }

    //    public AbsenceSource(long employeeID, DateTime date, AbsenceEnum type) : base(employeeID, type)
    //    {
    //        m_Date = date;
    //    }

    //    public override string ToString()
    //    {
    //        if (m_AbsenceEnum == AbsenceEnum.LongTime)
    //            return m_Postfix;
    //        return (m_AbsenceEnum == AbsenceEnum.Hollow || m_BeginTime == 0)
    //            ? string.Empty
    //            : string.Format("{0:d2}:{1:d2}-{2:d2}:{3:d2} {4}", m_BeginTime / 60,
    //                                                               m_BeginTime % 60, 
    //                                                               m_EndTime / 60,
    //                                                               m_EndTime % 60, 
    //                                                               Postfix);
    //    }
    //}
}
