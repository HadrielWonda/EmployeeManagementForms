using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.Estimate
{
    [Serializable]
    public class EstWorldDiffData
    {
        private short _Year;

        public short Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        private long _StoreID;

        public long StoreID
        {
            get { return _StoreID; }
            set { _StoreID = value; }
        }
        private long _WorldID;

        public long WorldID
        {
            get { return _WorldID; }
            set { _WorldID = value; }
        }
        private string _WorldName;

        public string WorldName
        {
            get { return _WorldName; }
            set { _WorldName = value; }
        }

        private decimal? _ContractWorkingHours;

        public decimal? ContractWorkingHours
        {
            get { return _ContractWorkingHours; }
            set { _ContractWorkingHours = value; }
        }
        private decimal? _AvgPersPeopleInYear;

        public decimal? AvgPersPeopleInYear
        {
            get { return _AvgPersPeopleInYear; }
            set { _AvgPersPeopleInYear = value; }
        }

        private decimal? _ContractWorkingHoursBuffH;

        public decimal? ContractWorkingHoursBuffH
        {
            get { return _ContractWorkingHoursBuffH; }
            set { _ContractWorkingHoursBuffH = value; }
        }
        private decimal? _ContractWorkingHoursNoBuffH;

        public decimal? ContractWorkingHoursNoBuffH
        {
            get { return _ContractWorkingHoursNoBuffH; }
            set { _ContractWorkingHoursNoBuffH = value; }
        }
        private short? _AvgRestingTime;

        public short? AvgRestingTime
        {
            get { return _AvgRestingTime; }
            set { _AvgRestingTime = value; }
        }
        private short? _AvgContractTime;

        public short? AvgContractTime
        {
            get { return _AvgContractTime; }
            set { _AvgContractTime = value; }
        }
        private short? _AvgWorkingTime;

        public short? AvgWorkingTime
        {
            get { return _AvgWorkingTime; }
            set { _AvgWorkingTime = value; }
        }
        private short? _PersonMin;

        public short? PersonMin
        {
            get { return _PersonMin; }
            set { _PersonMin = value; }
        }
        private short? _PersonMax;

        public short? PersonMax
        {
            get { return _PersonMax; }
            set { _PersonMax = value; }
        }

    }

    [Serializable]
    public class EstWorldWorkingHours
    {
        private DateTime? _date;

        public DateTime? Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private long _StoreID;

        public long StoreID
        {
            get { return _StoreID; }
            set { _StoreID = value; }
        }
        private long _WorldID;

        public long WorldID
        {
            get { return _WorldID; }
            set { _WorldID = value; }
        }
        private string _WorldName;

        public string WorldName
        {
            get { return _WorldName; }
            set { _WorldName = value; }
        }

        private byte? _Month;

        public byte? Month
        {
            get { return _Month; }
            set { _Month = value; }
        }
        private byte? _Week;

        public byte? Week
        {
            get { return _Week; }
            set { _Week = value; }
        }
        private byte? _WeekDay;

        public byte? WeekDay
        {
            get { return _WeekDay; }
            set { _WeekDay = value; }
        }
        #region Volumn
        private decimal? _VolumeBC; 

        public decimal? VolumeBC
        {
            get { return _VolumeBC; }
            set { _VolumeBC = value; }
        }
        private decimal? _VolumeCC;

        public decimal? VolumeCC
        {
            get { return _VolumeCC; }
            set { _VolumeCC = value; }
        }
        private decimal? _CVolumeBC;

        public decimal? CVolumeBC
        {
            get { return _CVolumeBC; }
            set { _CVolumeBC = value; }
        }
        private decimal? _CVolumeCC;

        public decimal? CVolumeCC
        {
            get { return _CVolumeCC; }
            set { _CVolumeCC = value; }
        }
        #endregion

        #region TargHours
        private decimal? _TargHoursBCBuffHph;

        public decimal? TargHoursBCBuffHph
        {
            get { return _TargHoursBCBuffHph; }
            set { _TargHoursBCBuffHph = value; }
        }
        private decimal? _TargHoursCCBuffHph;

        public decimal? TargHoursCCBuffHph
        {
            get { return _TargHoursCCBuffHph; }
            set { _TargHoursCCBuffHph = value; }
        }

        private decimal? _TargHoursBCNoBuffHph;

        public decimal? TargHoursBCNoBuffHph
        {
            get { return _TargHoursBCNoBuffHph; }
            set { _TargHoursBCNoBuffHph = value; }
        }
        private decimal? _TargHoursCCNoBuffHph;

        public decimal? TargHoursCCNoBuffHph
        {
            get { return _TargHoursCCNoBuffHph; }
            set { _TargHoursCCNoBuffHph = value; }
        }
        #endregion

        #region OpenHours Var
        private decimal? _OpenHoursBCVarMin;

        public decimal? OpenHoursBCVarMin
        {
            get { return _OpenHoursBCVarMin; }
            set { _OpenHoursBCVarMin = value; }
        }
        private decimal? _OpenHoursCCVarMin;

        public decimal? OpenHoursCCVarMin
        {
            get { return _OpenHoursCCVarMin; }
            set { _OpenHoursCCVarMin = value; }
        }
        private decimal? _OpenHoursBCVarMax;

        public decimal? OpenHoursBCVarMax
        {
            get { return _OpenHoursBCVarMax; }
            set { _OpenHoursBCVarMax = value; }
        }
        private decimal? _OpenHoursCCVarMax;

        public decimal? OpenHoursCCVarMax
        {
            get { return _OpenHoursCCVarMax; }
            set { _OpenHoursCCVarMax = value; }
        }
        #endregion 

        #region BCTH

        private decimal? _BCTH2;

        public decimal? BCTH2
        {
            get { return _BCTH2; }
            set { _BCTH2 = value; }
        }
        private decimal? _CCTH2;

        public decimal? CCTH2
        {
            get { return _CCTH2; }
            set { _CCTH2 = value; }
        }
        private decimal? _BCTH3;

        public decimal? BCTH3
        {
            get { return _BCTH3; }
            set { _BCTH3 = value; }
        }
        private decimal? _CCTH3;

        public decimal? CCTH3
        {
            get { return _CCTH3; }
            set { _CCTH3 = value; }
        }
        #endregion 

        private decimal? _HoursMin;

        public decimal? HoursMin
        {
            get { return _HoursMin; }
            set { _HoursMin = value; }
        }

        private decimal? _HoursMax;

        public decimal? HoursMax
        {
            get { return _HoursMax; }
            set { _HoursMax = value; }
        }

    }

    [Serializable ]
    public class EstWorldYearValues
    {
        private short _Year;

        public short Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        private long _StoreID;

        public long StoreID
        {
            get { return _StoreID; }
            set { _StoreID = value; }
        }
        private long _WorldID;

        public long WorldID
        {
            get { return _WorldID; }
            set { _WorldID = value; }
        }

        private string _WorldName;

        public string WorldName
        {
            get { return _WorldName; }
            set { _WorldName = value; }
        }


        #region Volume
        private decimal? _CVolumeBC;

        public decimal? CVolumeBC
        {
            get { return _CVolumeBC; }
            set { _CVolumeBC = value; }
        }
        private decimal? _CVolumeCC;

        public decimal? CVolumeCC
        {
            get { return _CVolumeCC; }
            set { _CVolumeCC = value; }
        }
        #endregion

        #region OpenHours Var
        private decimal? _OpenHoursBCVarMin;

        public decimal? OpenHoursBCVarMin
        {
            get { return _OpenHoursBCVarMin; }
            set { _OpenHoursBCVarMin = value; }
        }
        private decimal? _OpenHoursCCVarMin;

        public decimal? OpenHoursCCVarMin
        {
            get { return _OpenHoursCCVarMin; }
            set { _OpenHoursCCVarMin = value; }
        }
        private decimal? _OpenHoursBCVarMax;

        public decimal? OpenHoursBCVarMax
        {
            get { return _OpenHoursBCVarMax; }
            set { _OpenHoursBCVarMax = value; }
        }
        private decimal? _OpenHoursCCVarMax;

        public decimal? OpenHoursCCVarMax
        {
            get { return _OpenHoursCCVarMax; }
            set { _OpenHoursCCVarMax = value; }
        }
        #endregion 




        #region TargNetPerformance
        private decimal? _TargNetPerformanceBCBuffH;

        public decimal? TargNetPerformanceBCBuffH
        {
            get { return _TargNetPerformanceBCBuffH; }
            set { _TargNetPerformanceBCBuffH = value; }
        }
        private decimal? _TargNetPerformanceCCBuffH;

        public decimal? TargNetPerformanceCCBuffH
        {
            get { return _TargNetPerformanceCCBuffH; }
            set { _TargNetPerformanceCCBuffH = value; }
        }
        private decimal? _TargNetPerformanceBCNoBuffH;

        public decimal? TargNetPerformanceBCNoBuffH
        {
            get { return _TargNetPerformanceBCNoBuffH; }
            set { _TargNetPerformanceBCNoBuffH = value; }
        }
        private decimal? _TargNetPerformanceCCNoBuffH;

        public decimal? TargNetPerformanceCCNoBuffH
        {
            get { return _TargNetPerformanceCCNoBuffH; }
            set { _TargNetPerformanceCCNoBuffH = value; }
        }
        #endregion 

        #region AWH2
        private decimal? _BCAWH2;

        public decimal? BCAWH2
        {
            get { return _BCAWH2; }
            set { _BCAWH2 = value; }
        }
        private decimal? _CCAWH2;

        public decimal? CCAWH2
        {
            get { return _CCAWH2; }
            set { _CCAWH2 = value; }
        }
        #endregion


        #region NP2
        private decimal? _BCNP2;

        public decimal? BCNP2
        {
            get { return _BCNP2; }
            set { _BCNP2 = value; }
        }
        private decimal? _CCNP2;

        public decimal? CCNP2
        {
            get { return _CCNP2; }
            set { _CCNP2 = value; }
        }
        #endregion

        #region AWH3
        private decimal? _BCAWH3;

        public decimal? BCAWH3
        {
            get { return _BCAWH3; }
            set { _BCAWH3 = value; }
        }
        private decimal? _CCAWH3;

        public decimal? CCAWH3
        {
            get { return _CCAWH3; }
            set { _CCAWH3 = value; }
        }
        #endregion


        #region NP3
        private decimal? _BCNP3;

        public decimal? BCNP3
        {
            get { return _BCNP3; }
            set { _BCNP3 = value; }
        }
        private decimal? _CCNP3;

        public decimal? CCNP3
        {
            get { return _CCNP3; }
            set { _CCNP3 = value; }
        }
        #endregion
    }
}
