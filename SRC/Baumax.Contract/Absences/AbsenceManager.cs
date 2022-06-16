using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using System.Drawing;
using Baumax.Contract.Interfaces;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract
{
    public class AbsenceManager : IAbsenceManager
    {
        Dictionary<long, Absence> _diction = new Dictionary<long, Absence>();
        IAbsenceService _service = null;
        long _countryId = 0;

        public AbsenceManager(IAbsenceService service)
        {
            _service = service;
            if (_service == null)
            {
                throw new NullReferenceException();
            }
        }
        public AbsenceManager(IAbsenceService service, long countryid)
            : this(service)
        {
            CountryId = countryid;
        }
        public AbsenceManager(List<Absence> list)
        {
            AddList(list);
        }

        private void AddList(List<Absence> lst)
        {
            _diction.Clear();
            if (lst != null)
            {
                foreach (Absence absence in lst)
                {
                    _diction[absence.ID] = absence;
                }
            }
        }
        public int Count
        {
            get { return _diction.Count; }
        }

        public long CountryId
        {
            get { return _countryId; }
            set
            {
                if (_countryId != value)
                {
                    _diction.Clear();
                    _countryId = value;
                    LoadAbsence();
                }
            }
        }
        private void LoadAbsence()
        {
            if (CountryId <= 0) _diction.Clear();
            else
                AddList(_service.GetCountryAbsences(CountryId));
        }

        // only for Sergey Kasperovich
        public void LoadAll()
        {
            _countryId = 0;
            AddList(_service.FindAll());
        }
        public void AddToDiction(Absence absence)
        {
            _diction[absence.ID] = absence;
        }
        public Absence this[long id]
        {
            get { return _diction[id]; }
        }


        public Absence GetById(long id)
        {
            Absence absence = null;
            _diction.TryGetValue(id, out absence);
            return absence;
        }

        public string GetAbbreviation(long id)
        {
            Absence a = GetById(id);
            String s = String.Empty;
            if (a != null) s = a.CharID;

            return s;
        }
        public Color GetColor(long id, Color def)
        {
            Absence a = GetById(id);
            if (a != null) def = Color.FromArgb(a.Color);
            return def;
        }
        public Absence GetByAbbreviation(string charid)
        {
            foreach (Absence absence in _diction.Values)
                if (charid.Equals(absence.CharID, StringComparison.InvariantCultureIgnoreCase)) return absence;
            return null;
        }
        public List<Absence> ToList
        {
            get
            {
                List<Absence> result = new List<Absence>();
                result.AddRange(_diction.Values);
                return result;
            }
        }


        public void FillAbsencePlanningTimes(List<AbsenceTimePlanning> lst)
        {
            if (lst != null)
            {
                Absence a = null;
                foreach (AbsenceTimePlanning atp in lst)
                {
                    a = GetById(atp.AbsenceID);
                    if (a != null)
                        atp.Absence = a;
                    else throw new Exception();
                }
            }
        }
        public void FillAbsencePlanningTimes(AbsenceTimePlanning entity)
        {
            if (entity != null)
            {
                Absence a = GetById(entity.AbsenceID);
                if (a != null) entity.Absence = a;
            }
        }
        public void FillAbsenceRecordingTimes(List<AbsenceTimeRecording> lst)
        {
            if (lst != null)
            {
                Absence a = null;
                foreach (AbsenceTimeRecording atp in lst)
                {
                    a = GetById(atp.AbsenceID);
                    if (a != null)
                        atp.Absence = a;
                    else throw new Exception();
                }
            }
        }
        public void FillAbsenceRecordingTimes(AbsenceTimeRecording entity)
        {
            if (entity != null)
            {
                Absence a = GetById(entity.AbsenceID);
                if (a != null) entity.Absence = a;
            }
        }

        public void FillEmployeeWeek(List<EmployeeWeek> entities)
        {
            if (entities != null)
            {
                foreach (EmployeeWeek week in entities)
                    FillEmployeeWeek(week);
            }
        }
        public void FillEmployeeWeek(EmployeeWeek entity)
        {
            if (entity != null && entity.DaysList != null)
            {
                foreach (EmployeeDay day in entity.DaysList)
                    FillEmployeeDay(day);
            }
        }

        public void FillEmployeeDay(EmployeeDay emplday)
        {
            if (emplday != null && emplday.TimeList != null)
            {
                for (int i = 0; i < emplday.TimeList.Count; i++)
                {
                    if (emplday.TimeList[i].AbsenceID > 0)
                    {
                        emplday.TimeList[i].Absence = GetById(emplday.TimeList[i].AbsenceID);
                    }
                }
            }
        }

        public bool IsHoliday(long id)
        {
            Absence a = GetById(id);
            if (a != null) return a.AbsenceTypeID == AbsenceType.Holiday;

            return false;
        }

        public bool IsValidSystemId(long id, int? value)
        {
            if (value == null) return true;

            foreach (Absence absence in _diction.Values)
            {
                if (absence.ID != id && absence.SystemID == value) return false;
            }
            return true;
        }
        public bool IsValidCharId(long id, string value)
        {
            if (String.IsNullOrEmpty(value)) return false;

            foreach (Absence absence in _diction.Values)
            {
                if (absence.ID != id && absence.CharID == value) return false;
            }
            return true;
        }
        public void Delete(long id)
        {
            _service.DeleteByID(id);
            _diction.Remove(id);
        }
    }
}
