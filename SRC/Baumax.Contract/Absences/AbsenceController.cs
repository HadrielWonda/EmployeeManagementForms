using System;
using System.Collections.Generic;
using Baumax.Domain;
using System.Collections;
using System.ComponentModel;
using Baumax.Contract;
using System.Drawing;
using Baumax.Contract.Absences;
using Baumax.Contract.TimePlanning;
using Baumax.Contract.HolydayClasses;


namespace Baumax.Contract.Absences
{
    //public class AbsenceController
    //{
    //    protected Dictionary<long, List<AbsenceTimePlanning>> m_AbsencesTP = new Dictionary<long, List<AbsenceTimePlanning>>();
    //    protected Dictionary<long, List<AbsenceTimeRecording>> m_AbsencesTR = new Dictionary<long, List<AbsenceTimeRecording>>();
    //    protected Dictionary<long, List<EmployeeLongTimeAbsence>> m_LongAbsences = new Dictionary<long, List<EmployeeLongTimeAbsence>>();
    //    protected List<EmployeeRelation> m_EmployeesAnotherWorld = new List<EmployeeRelation>();
    //    protected List<Dictionary<long, AbsenceSourceWeek>> m_SumWeek = new List<Dictionary<long, AbsenceSourceWeek>>();
    //    protected List<Dictionary<long, AbsenceSource>> m_SumDay = new List<Dictionary<long, AbsenceSource>>();
    //    protected AbsenceManager m_Manager;
    //    protected long m_StoreWorldID = 0;
    //    protected List<long> m_EmployeeIDs;
    //    protected Dictionary<long, LongTimeAbsence> longTimeEntity = null;
    //    protected YearAppearance m_Props;
    //    protected AbsencePlanningServices m_Services;
    //    protected AbsencePlanningQuery m_Query;

        

    //    public AbsenceController(YearAppearance apperance, AbsencePlanningServices services, AbsencePlanningQuery query)
    //    {
    //        m_Props = apperance;
    //        m_Services = services;
    //        m_Query = query;
    //    }

    //    public long StoreWorldID
    //    {
    //        get { return m_StoreWorldID; }
    //        set { m_StoreWorldID = value; }
    //    }
        
    //    public List<Absence> AbsenceList 
    //    {
    //        get  { return m_Manager.ToList; }
    //    }
    //    public AbsenceManager AbsenceManager
    //    {
    //        get { return m_Manager; }
    //    }

    //    public AbsenceSourceWeek GetWeekAbsence(long employeeID, int weekNumber)
    //    {
    //        return m_SumWeek[weekNumber - 1][employeeID];
    //    }

    //    public AbsenceSource GetAbsenceSource(long employeeid, DateTime date)
    //    {
    //        return m_SumDay[GetIndex(date)][employeeid];
    //    }

    //    public virtual void Load(long[] emplIDs)
    //    {
    //        m_EmployeeIDs = new List<long>( emplIDs);
    //        longTimeEntity = new Dictionary<long, LongTimeAbsence>();

    //        if (m_Query.LongabsencesEntities != null)
    //            foreach (LongTimeAbsence absence in m_Query.LongabsencesEntities)
    //                longTimeEntity.Add(absence.ID, absence);

    //        if (m_Query.Longabsences != null)
    //            foreach (EmployeeLongTimeAbsence longAbsence in m_Query.Longabsences)
    //            {
    //                if (!m_LongAbsences.ContainsKey(longAbsence.EmployeeID))
    //                    m_LongAbsences.Add(longAbsence.EmployeeID, new List<EmployeeLongTimeAbsence>());
    //                m_LongAbsences[longAbsence.EmployeeID].Add(longAbsence);
    //                longAbsence.LongTimeAbsenceName = longTimeEntity[longAbsence.LongTimeAbsenceID].CharID;
    //            }
        
    //        m_Manager = new AbsenceManager(m_Query.Absences);
            
    //        if (m_Query.Plannings != null)
    //            foreach (AbsenceTimePlanning absence in m_Query.Plannings)
    //            {
    //                if (!m_AbsencesTP.ContainsKey(absence.EmployeeID))
    //                    m_AbsencesTP.Add(absence.EmployeeID, new List<AbsenceTimePlanning>());
    //                m_AbsencesTP[absence.EmployeeID].Add(absence);
    //                m_Manager.FillAbsencePlanningTimes(absence);
    //            }

    //        if (m_Props.Begin < DateTime.Today && m_Query.Recordings != null)
    //            foreach (AbsenceTimeRecording absence in m_Query.Recordings)
    //            {
    //                if (!m_AbsencesTR.ContainsKey(absence.EmployeeID))
    //                    m_AbsencesTR.Add(absence.EmployeeID, new List<AbsenceTimeRecording>());

    //                absence.Absence = m_Manager[absence.AbsenceID];
    //                m_AbsencesTR[absence.EmployeeID].Add(absence);

    //                if (m_AbsencesTP.ContainsKey(absence.EmployeeID))
    //                    m_AbsencesTP[absence.EmployeeID].RemoveAll(
    //                            delegate(AbsenceTimePlanning atp) 
    //                            {
    //                                return atp.Date == absence.Date;
    //                            });
    //            }

    //        ApplySummaryData();
    //    }


    //    public double GetSumWeekData(int weekNumber)
    //    {
    //        double result = 0;
    //        if (m_SumWeek.Count >= weekNumber)
    //            foreach (AbsenceSourceWeek source in  m_SumWeek[weekNumber-1].Values)
    //                if (source.AbsenceEnum == AbsenceEnum.Holyday)
    //                    result += source.Days;
    //        return result;
    //    }

    //    public int GetSumDayData(DateTime date)
    //    {
    //        int result = 0, index = GetIndex(date);
    //        if (m_SumDay.Count > index)
    //            foreach (AbsenceSource absence in m_SumDay[index].Values)
    //                if (absence.AbsenceEnum == AbsenceEnum.Holyday)
    //                    result += absence.Minutes;
    //        return result;
    //    }

    //    public void ApplySummaryData()
    //    {
    //        m_SumDay.Clear();
    //        m_SumWeek.Clear();

    //        int days = (m_Props.End - m_Props.Begin).Days;

    //        for (int i = 0; i <= days; i++)
    //        {
    //            m_SumDay.Add(new Dictionary<long, AbsenceSource>());
    //            foreach (long id in m_EmployeeIDs)
    //                m_SumDay[i][id] = new AbsenceSource(id, m_Props.GetDay(i), AbsenceEnum.Hollow);
    //        }

    //        for (int i = 0; i <= days / 7; i++)
    //        {
    //            m_SumWeek.Add(new Dictionary<long, AbsenceSourceWeek>());
    //            foreach (long id in m_EmployeeIDs)
    //                m_SumWeek[i][id] = new AbsenceSourceWeek(id, i+1, AbsenceEnum.Hollow);
    //        }

    //        if (m_Query.StoreDays != null)
    //        {
    //            foreach (DateTime date in m_Query.StoreDays.Keys)
    //                if (!m_Query.StoreDays.IsStoreWorkingDay(date))
    //                    ApplySummaryData(date, AbsenceEnum.CloseDay);
    //                else
    //                    if (m_Query.StoreDays.IsStoreFeastDay(date))
    //                        ApplySummaryData(date, AbsenceEnum.Feast);
    //        }
                

    //        foreach (List<EmployeeLongTimeAbsence> absences in m_LongAbsences.Values)
    //            foreach (EmployeeLongTimeAbsence absence in absences)
    //                if (m_StoreWorldID == 0 || m_EmployeeIDs.Contains(absence.EmployeeID))
    //                    ApplySummaryData(absence);

    //        foreach (List<AbsenceTimePlanning> absences in m_AbsencesTP.Values)
    //            foreach (AbsenceTimePlanning absence in absences)
    //                if (m_StoreWorldID == 0 || m_EmployeeIDs.Contains(absence.EmployeeID))
    //                    ApplySummaryData(absence);

    //        foreach (List<AbsenceTimeRecording> absences in m_AbsencesTR.Values)
    //            foreach (AbsenceTimeRecording absence in absences)
    //                if (m_StoreWorldID == 0 || m_EmployeeIDs.Contains(absence.EmployeeID))
    //                    ApplySummaryData(absence);

    //        //if (m_StoreWorldID != 0)
    //            foreach (EmployeeRelation relation in m_EmployeesAnotherWorld)
    //                ApplySummaryData(relation);
    //    }

    //    public int GetIndex(DateTime date)
    //    {
    //        return (date - m_Props.Begin).Days;
    //    }

    //    protected void ApplySummaryData(EmployeeRelation relation)
    //    {
    //        for (DateTime date = relation.BeginTime; date <= relation.EndTime; date = date.AddDays(1))
    //        {
    //            m_SumDay[GetIndex(date)][relation.EmployeeID] = (relation.WorldID == -100)
    //                    ? new AbsenceSource(relation.EmployeeID, date, AbsenceEnum.OutContract)
    //                    : new AbsenceSource(relation.EmployeeID, date, AbsenceEnum.InAnotherWorld);

    //            int week = WeekManager.GetWeekNumber(date);
    //            m_SumWeek[week - 1][relation.EmployeeID] = (relation.WorldID == -100)
    //                    ? new AbsenceSourceWeek(relation.EmployeeID, week, AbsenceEnum.OutContract)
    //                    : new AbsenceSourceWeek(relation.EmployeeID, week, AbsenceEnum.InAnotherWorld);
    //        }
    //    }

    //    protected void ApplySummaryData(EmployeeLongTimeAbsence absence)
    //    {
    //        LongTimeAbsence entity = longTimeEntity[absence.LongTimeAbsenceID];

    //        for (DateTime currentDate = absence.BeginTime >= m_Props.Begin ? absence.BeginTime : m_Props.Begin;
    //            currentDate <= absence.EndTime && currentDate <= m_Props.End; 
    //            currentDate = currentDate.AddDays(1))
    //        {
    //            m_SumDay[GetIndex(currentDate)][absence.EmployeeID] = new AbsenceSource(absence.EmployeeID, currentDate, entity);
    //            int week = WeekManager.GetWeekNumber(currentDate);
    //            if (!m_SumWeek[week - 1].ContainsKey(absence.EmployeeID) 
    //                || m_SumWeek[week - 1][absence.EmployeeID].AbsenceEnum != AbsenceEnum.LongTime)
    //                m_SumWeek[week-1][absence.EmployeeID] = new AbsenceSourceWeek(week, absence.EmployeeID, 0,entity);
    //            m_SumWeek[week-1][absence.EmployeeID].Days++; // сдеся
    //        }
    //    }

    //    protected void ApplySummaryData(DateTime date, AbsenceEnum type)
    //    {
    //        int index = GetIndex(date);
    //        foreach (long emplID in m_EmployeeIDs)
    //            m_SumDay[index][emplID] = new AbsenceSource(emplID, date, type);
    //    }

    //    protected void ApplySummaryData (IEmployeeTimeRange absence)
    //    {
    //        AbsenceEnum type = absence is AbsenceTimePlanning ? AbsenceEnum.Planning: AbsenceEnum.Recording;
    //        double hours = (absence.End - absence.Begin) / 60;
    //        int week = WeekManager.GetWeekNumber(absence.Date),
    //            index = GetIndex(absence.Date);
    //        m_SumDay[index][absence.EmployeeID] = new AbsenceSource(absence, m_Manager);

    //        if (!m_SumWeek[week - 1].ContainsKey(absence.EmployeeID) || (int)m_SumWeek[week - 1][absence.EmployeeID].AbsenceEnum > 3)
    //            m_SumWeek[week - 1][absence.EmployeeID] = new AbsenceSourceWeek(week, absence.EmployeeID, 0, m_Manager[absence.AbsenceID]);
    //        m_SumWeek[week-1][absence.EmployeeID].Days++;
    //    }

        

    //    public void SetFilteredEmployeeList(BindingList<EmployeeSource> employees, List<EmployeeRelation> anotherEmployees)
    //    {
    //        m_EmployeeIDs = new List<long>();
    //        foreach (EmployeeSource employee in employees)
    //            m_EmployeeIDs.Add(employee.ID);
    //        m_EmployeesAnotherWorld = anotherEmployees;

    //        ApplySummaryData();
    //    }

    //    public string GetStoreRangeString(DateTime monday)
    //    {
    //        if ((m_Query == null) || (m_Query.StoreDays == null))
    //            return String.Empty;

    //        StoreDay storeday = null;
    //        m_Query.StoreDays.TryGetValue(monday, out storeday);

    //        if (storeday == null)
    //            return String.Empty;
    //        return TextParser.TimeRangeToString(storeday.OpenTime, storeday.CloseTime);

    //         //return string.Format("{0}-{1}", TextParser.TimeToString(m_Query.StoreDays[monday].OpenTime),
    //         //                               TextParser.TimeToString(m_Query.StoreDays[monday].CloseTime));
    //    }

    //    public void SetNoContractRanges(List<EmployeeRelation> relations)
    //    {
    //        if (relations != null && relations.Count > 0)
    //        {
    //            foreach (EmployeeRelation employee in relations)
    //            {
    //                if (employee.WorldID < 0)
    //                    ApplySummaryData(employee);
    //            }
    //        }
    //    }
    //}
}
