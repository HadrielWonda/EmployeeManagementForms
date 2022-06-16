using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using System.Diagnostics;

namespace Baumax.Contract
{
    public class LongTimeAbsenceManager : ILongTimeAbsenceManager
    {
        Dictionary<long, LongTimeAbsence> _diction = new Dictionary<long, LongTimeAbsence>();
        ILongTimeAbsenceService _service = null;
        long _countryId = 0;
        public LongTimeAbsenceManager(ILongTimeAbsenceService service)
        {
            _service = service;
            if (_service == null)
            {
                throw new NullReferenceException();
            }
        }
        public LongTimeAbsenceManager(ILongTimeAbsenceService service, long countryid):this(service )
        {
            CountryId = countryid;
        }
        private void AddList(List<LongTimeAbsence> lst)
        {
            _diction.Clear();
            if (lst != null)
            {
                foreach (LongTimeAbsence absence in lst)
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
                AddList(_service.FindAllByCountry (CountryId));
        }

        public LongTimeAbsence this[long id]
        {
            get { return _diction[id]; }
        }


        public LongTimeAbsence GetById(long id)
        {
            LongTimeAbsence absence = null;
            _diction.TryGetValue(id, out absence);
            return absence;
        }
        public int? GetColor(long id)
        {
            LongTimeAbsence a = GetById(id);
            int ?s = null;
            if (a != null) s = a.Color;

            return s;
        }

        public string GetAbbreviation(long id)
        {
            LongTimeAbsence a = GetById(id);
            String s = String.Empty;
            if (a != null) s = a.CharID;

            return s;
        }

        public LongTimeAbsence GetByAbbreviation(string charid)
        {
            foreach (LongTimeAbsence absence in _diction.Values)
                if (charid == absence.CharID) return absence;
            return null;
        }
        public List<LongTimeAbsence> ToList
        {
            get
            {
                List<LongTimeAbsence> result = new List<LongTimeAbsence>();
                result.AddRange(_diction.Values);
                return result;
            }
        }

        public void FillEmployeelongAbsences(List<EmployeeLongTimeAbsence> list)
        {
            if (list != null)
            {
                foreach (EmployeeLongTimeAbsence absence in list)
                {
                    absence.Absence = GetById(absence.LongTimeAbsenceID);
                    Debug.Assert(absence.Absence != null);
                }
            }
        }
    }
}
