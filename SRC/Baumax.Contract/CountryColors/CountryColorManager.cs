using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System.Drawing;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract
{
    public class CountryColorManager : ICountryColorManager
    {
        Dictionary<byte, Colouring> _diction = new Dictionary<byte, Colouring>();
        IColouringService _service = null;
        long _countryId = 0;
        public CountryColorManager(IColouringService service)
        {
            _service = service;
            if (_service == null)
            {
                throw new NullReferenceException();
            }
        }

        private void AddList(List<Colouring> lst)
        {
            _diction.Clear();
            if (lst != null)
            {
                foreach (Colouring entity in lst)
                {
                    _diction[entity.ColourType] = entity;
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
                    LoadEntity();
                }
            }
        }
        private void LoadEntity()
        {
            if (CountryId <= 0) _diction.Clear();
            else
                AddList(_service.GetCountryColouring (CountryId));
        }


        public Color GetByTypeAndValue(CountryColorValueType type, double value)
        {
            return GetByTypeAndValue(type, value, Color.Black);
        }
        public Color GetByTypeAndValue(CountryColorValueType type, double value, Color defColor)
        {
            Colouring c = null;
            if (_diction.TryGetValue((byte)type, out c))
            {

                defColor = Color.FromArgb(c.GetColor(value));
            }

            return defColor;
        }
        public Color GetColorByEmployeeAdditionalCharges(double value)
        {
            CountryColorValueType type = CountryColorValueType.SumOfAdditionalCharges;
            Color defColor = Color.Black;
            return GetByTypeAndValue (type, value, defColor );
        }
        public Color GetColorByEmployeePlusMinus(double value)
        {
            CountryColorValueType type = CountryColorValueType.SumOfStillAvailableWorkingHours;
            Color defColor = Color.Black;
            return GetByTypeAndValue(type, value, defColor);
        }
        public Color GetColorByEmployeeBalanceHours(double value)
        {
            CountryColorValueType type = CountryColorValueType.SumOfCurrentEmployeeBalanceHours;
            Color defColor = Color.Black;
            return GetByTypeAndValue(type, value, defColor);
        }
        public Color GetColorByEmployeeAdditionalChargesOverAllEmployee(double value)
        {
            CountryColorValueType type = CountryColorValueType.SumOfAdditionalChargesOverAllEmployee;
            Color defColor = Color.Black;
            return GetByTypeAndValue(type, value, defColor);
        }
        public Color GetColorByEmployeePlusMinusOverAllEmployee(double value)
        {
            CountryColorValueType type = CountryColorValueType.SumOfStillAvailableWorkingHoursOverAllEmployee;
            Color defColor = Color.Black;
            return GetByTypeAndValue(type, value, defColor);
        }
        public Color GetColorByEmployeeBalanceHoursOverAllEmployee(double value)
        {
            CountryColorValueType type = CountryColorValueType.SumOfCurrentEmployeeBalanceHoursOverAllEmployee;
            Color defColor = Color.Black;
            return GetByTypeAndValue(type, value, defColor);
        }
        public Color GetColorByDifferenceInPercentPlannedAndEstimatedHours(double value)
        {
            CountryColorValueType type = CountryColorValueType.DifferenceInPercentBetweenActualPlannedHoursAndEstimatedHours;
            Color defColor = Color.Black;
            return GetByTypeAndValue(type, value, defColor);
        }
    }
}
