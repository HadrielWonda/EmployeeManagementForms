using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.ClientUI.FormEntities.TimePlanning;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;

namespace Baumax.ClientUI.FormEntities.TimeRecording
{
    public partial class UCActualCashDeskWeeklyInfo : UCBaseEntity 
    {
        private string PlannedCashDeskPeopleUnitsPerWeek;
        private string AvgPlannedCashDeskPeopleUnitsPerDay;

        private string TargetedCashDeskPeopleUnitsPerWeek;
        private string AvgTargetedCashDeskPeopleUnitsPerDay;

        private string AvgDiffPerDayTotalPercent;
        private string AvgAbsDiffPerDayTotalPercent;

        private string __MinimumPresence = "Minimum presence:";
        private string __MaximumPresence = "Maximum presence:";
        private string __AvailableWorldBufferHours = "Available world-buffer hours:";

        private List<CashDeskInfoItem> _cashdeskItems = new List<CashDeskInfoItem>();
        private CashDeskWeeklyPlanningCalculator3 _calculator = new CashDeskWeeklyPlanningCalculator3();
        private CashDeskPlanningInfo _cashdeskinfo = null;

        private ICountryColorManager _colormanager = null;



        public ICountryColorManager ColorManager
        {
            get { return _colormanager; }
            set { _colormanager = value; }
        }

        public UCActualCashDeskWeeklyInfo()
        {
            InitializeComponent();
            BuildRows();
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {
                BuildRows();

                PlannedCashDeskPeopleUnitsPerWeek = GetLocalized("ATRActualCashDeskPeopleUnitsPerWeek");
                AvgPlannedCashDeskPeopleUnitsPerDay = GetLocalized("ATRAvgActualCashDeskPeopleUnitsPerDay");

                TargetedCashDeskPeopleUnitsPerWeek = GetLocalized("ATRPlannedCashDeskPeopleUnitsPerWeek");
                AvgTargetedCashDeskPeopleUnitsPerDay = GetLocalized("ATRAvgPlannedCashDeskPeopleUnitsPerDay");

                AvgDiffPerDayTotalPercent = GetLocalized("AvgDiffPerDayTotalPercent");
                AvgAbsDiffPerDayTotalPercent = GetLocalized("AvgAbsDiffPerDayTotalPercent");

                __MinimumPresence = GetLocalized("MinimumPresence");
                __MaximumPresence = GetLocalized("MaximumPresence");

                __AvailableWorldBufferHours = GetLocalized("AvailableWorldBufferHours");

                UpdateStoreWorldInfo();
            }
        }

        private void BuildRows()
        {
            gridControl.DataSource = null;

            _cashdeskItems.Clear();

            _cashdeskItems.Add(new CashDeskInfoItem(GetLocalized("ATRSummActualWorkingHours"), CashDeskItemType.PlannedCashDeskUnits));
            _cashdeskItems[0].SetDatas(_calculator.PlannedUnits);

            _cashdeskItems.Add(new CashDeskInfoItem(GetLocalized("PlannedHours"), CashDeskItemType.TargetedCashDeskUnits));
            _cashdeskItems[1].SetDatas(_calculator.TargetUnits);
            _cashdeskItems.Add(new CashDeskInfoItem(GetLocalized("DiffInPercent"), CashDeskItemType.DifferenceTargetedPlannedPercent));
            _cashdeskItems[2].SetDatas(_calculator.DiffTargetPlannedPercent);

            gridControl.DataSource = _cashdeskItems;
        }

        

        public CashDeskPlanningInfo CashDeskInfo
        {
            get { return _cashdeskinfo; }

            set
            {
                if (value != _cashdeskinfo)
                {
                    _cashdeskinfo = value;
                    Clear();
                }

            }
        }
        private string GetPlannedCashDeskUnitsTotalAsString()
        {
            double totalUnits = _calculator.PlannedUnits.Sum;
            return String.Format("{1:F2} - {0}", PlannedCashDeskPeopleUnitsPerWeek, totalUnits);
        }
        private string GetTargetedCashDeskUnitsTotalAsString()
        {
            double totalUnits = _calculator.TargetUnits.Sum;
            return String.Format("{1:F2} - {0}", TargetedCashDeskPeopleUnitsPerWeek, totalUnits);

        }
        

        private string GetDiffPerDayTotalPercentAsString()
        {
            
            double absAvgUnits = _calculator.DiffTargetPlannedPercent.AbsAverage;

            return String.Format("{1}% - {0}", AvgAbsDiffPerDayTotalPercent, Math.Round (absAvgUnits));

        }


        //public void SetPlannedCashDeskUnits(int[] unitPerDay)
        //{
        //    _calculator.AssignTargetedInfo(unitPerDay);
        //}

        public void SetPlannedCashDeskUnits(int[] unitPerDay, int[][] hoursPerhours)
        {
            _calculator.AssignTargetedInfo(unitPerDay, hoursPerhours);
        }

        //public void SetActualCashDeskUnits(int[] unitPerDay)
        //{
        //    _calculator.AssignActualInfo(unitPerDay);
        //    gridView.RefreshData();
        //    UpdateStoreWorldInfo();
        //}
        public void SetActualCashDeskUnits(int[] unitPerDay, int[][] hoursPerhours)
        {
            _calculator.AssignActualInfo(unitPerDay, hoursPerhours);
            gridView.RefreshData();
            UpdateStoreWorldInfo();
        }

        public void Clear()
        {
            _calculator.Clear();
            gridView.RefreshData();
            UpdateStoreWorldInfo();
        }

        private void UpdateStoreWorldInfo()
        {
            short min = 0;
            short max = 0;
            int available = 0;

            if (CashDeskInfo != null)
            {
                min = CashDeskInfo.MinimumPresence;
                max = CashDeskInfo.MaximumPresence;
                available = CashDeskInfo.CurrentBufferHours;
                lblAvailableWorldBufferHours.Visible = CashDeskInfo.ExistBufferHours;
            }

            lblMinimumPresence.Text = String.Format("{0} {1}", __MinimumPresence, min);
            lblMaximumPresence.Text = String.Format("{0} {1}", __MaximumPresence, max);

            lblAvailableWorldBufferHours.Text = String.Format("{0}  {1}", __AvailableWorldBufferHours, TextParser.TimeToString(available));
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            
            if (gcResult == e.Column)
            {
                CashDeskInfoItem item = (CashDeskInfoItem)gridView.GetRow(e.RowHandle);
                switch (item.Type)
                {
                    case CashDeskItemType.PlannedCashDeskUnits:
                        {
                            e.Value = GetPlannedCashDeskUnitsTotalAsString();
                            break;
                        }
                    case CashDeskItemType.TargetedCashDeskUnits:
                        {
                            e.Value = GetTargetedCashDeskUnitsTotalAsString();
                            break;
                        }
                    case CashDeskItemType.DifferenceTargetedPlannedPercent:
                        {
                            e.Value = GetDiffPerDayTotalPercentAsString();
                            break;
                        }
                    default:
                        throw new ArgumentException();
                }
            }
                
            

        }
        private void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.Tag != null)
            {
                // hours cells
                int columnDay = Convert.ToInt32(e.Column.Tag);
                CashDeskInfoItem item = (CashDeskInfoItem)gridView.GetRow(e.RowHandle);
                if (item.Type == CashDeskItemType.DifferenceTargetedPlannedPercent)
                {
                    double value = _calculator.DiffTargetPlannedPercent.Elements[columnDay];
                    if (ColorManager != null)
                    {
                        Color color = ColorManager.GetColorByDifferenceInPercentPlannedAndEstimatedHours(value);
                        e.Appearance.ForeColor = color;
                    }
                }
            }
        }

        #region helper classes

        class CashDeskInfoItem
        {
            private string _ItemName;

            DblArray _datas = null;

            public void SetDatas(DblArray datas)
            {
                _datas = datas;
            }

            private double GetValueByDay(DayOfWeek dayofweek)
            {
                double v = 0;
                if (_datas != null && _datas.Elements != null)
                {
                    if (_datas.Elements.Length >= 7)
                    {
                        v = _datas.Elements[(int)dayofweek];
                    }
                }
                return v;
            }
            private string GetValueAsString(DayOfWeek dayofweek)
            {
                if (Type != CashDeskItemType.DifferenceTargetedPlannedPercent )
                    return String.Format ("{0:F2}", GetValueByDay (dayofweek ));
                else
                    return String.Format("{0}%", Math.Round (GetValueByDay(dayofweek)));
            }

            public string ItemName
            {
                get { return _ItemName; }
                set { _ItemName = value; }
            }

            private CashDeskItemType _type;

            public CashDeskItemType Type
            {
                get { return _type; }
                set { _type = value; }
            }

            public CashDeskInfoItem(string name, CashDeskItemType type)
            {
                _ItemName = name;
                _type = type;
            }

            

            public string Monday
            {
                get { return GetValueAsString(DayOfWeek.Monday ); }
            }


            public string Tuesday
            {
                get { return GetValueAsString(DayOfWeek.Tuesday ); }
            }

            public string Wednesday
            {
                get { return GetValueAsString(DayOfWeek.Wednesday);  }
            }
            public string Thursday
            {
                get { return GetValueAsString(DayOfWeek.Thursday ); }
            }
            public string Friday
            {
                get { return GetValueAsString(DayOfWeek.Friday); ; }
            }
            public string Saturday
            {
                get { return GetValueAsString(DayOfWeek.Saturday ); ; }
            }
            public string Sunday
            {
                get { return GetValueAsString(DayOfWeek.Sunday ); ; }
            }
        }

        enum CashDeskItemType
        {
            PlannedCashDeskUnits,
            TargetedCashDeskUnits,
            DifferenceTargetedPlannedPercent

        }

        #endregion

    }
}
