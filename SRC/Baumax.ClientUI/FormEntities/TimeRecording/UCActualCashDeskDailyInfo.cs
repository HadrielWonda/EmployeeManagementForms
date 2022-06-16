using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Baumax.Contract.TimePlanning;
using Baumax.ClientUI.FormEntities.TimePlanning;
using DevExpress.XtraGrid.Columns;
using System.Diagnostics;

namespace Baumax.ClientUI.FormEntities.TimeRecording
{
    public partial class UCActualCashDeskDailyInfo : UCBaseEntity
    {
        #region fields 

        private string PlannedCashDeskPeopleUnitsPerDay = "Currently actual Cash Desk People Units per day:";
        private string PlannedCashDeskPeopleUnitsPerHour = "Currently actual Cash Desk People Units per hour:";

        private string TargetedCashDeskPeopleUnitsPerDay = "Planned Cash Desk People Units per day:";
        private string TargetedCashDeskPeopleUnitsPerHour = "Planned Cash Desk People Units per hour:";

        private string DifferencePerDayTotalPercent = "Difference per day (total) percent:";
        private string AbsoluteDifferencePerDayPercent = "Absolute difference per day (percent):";

        private string __MinimumPresence = "Minimum presence:";
        private string __MaximumPresence = "Maximum presence:";
        private string __AvailableWorldBufferHours = "Available world-buffer hours:";

        private List<CashDeskInfoItem> _cashdeskItems = new List<CashDeskInfoItem>();
        private ICountryColorManager _colormanager = null;
        private CashDeskPlanningInfo _CashDeskInfo = null;
        private CashDeskDailyPlanningCalculator2 _calculator = new CashDeskDailyPlanningCalculator2();

        #endregion


       

        public UCActualCashDeskDailyInfo()
        {
            InitializeComponent();
            BuildColumns();
        }

        public ICountryColorManager ColorManager
        {
            get { return _colormanager; }
            set { _colormanager = value; }
        }

        public CashDeskPlanningInfo CashDeskInfo
        {
            get { return _CashDeskInfo; }
            set
            {
                if (_CashDeskInfo != value)
                {
                    _CashDeskInfo = value;
                    UpdateStoreWorldInfo();
                }
            }
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {
                BuildRows();

                PlannedCashDeskPeopleUnitsPerDay = GetLocalized("ATRActualCashDeskPeopleUnitsPerDay");
                PlannedCashDeskPeopleUnitsPerHour = GetLocalized("ATRActualCashDeskPeopleUnitsPerHour");

                TargetedCashDeskPeopleUnitsPerDay = GetLocalized("ATRAcPlannedCashDeskPeopleUnitsPerDay");
                TargetedCashDeskPeopleUnitsPerHour = GetLocalized("ATRAcPlannedCashDeskPeopleUnitsPerHour");

                DifferencePerDayTotalPercent = GetLocalized("DifferencePerDayTotalPercent");
                AbsoluteDifferencePerDayPercent = GetLocalized("AbsoluteDifferencePerDayPercent");

                __MinimumPresence = GetLocalized("MinimumPresence");
                __MaximumPresence = GetLocalized("MaximumPresence");

                __AvailableWorldBufferHours = GetLocalized("AvailableWorldBufferHours");

                UpdateStoreWorldInfo();
            }
        }


        public void AssignPlannedInfo(int[] unitsPerHour)
        {
            _calculator.AssignPlannedInfo(unitsPerHour);
            gridView.RefreshData();
            UpdateStoreWorldInfo();


        }
        public void AssignTargetedInfo(int[] unitsPerHour)
        {
            _calculator.AssignTargetedInfo(unitsPerHour);
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

        #region events and internal methods

        private void BuildRows()
        {
            gridControl.DataSource = null;

            _cashdeskItems.Clear();

            _cashdeskItems.Add(new CashDeskInfoItem(GetLocalized("ATRActualCashDeskUnits"), CashDeskItemType.PlannedCashDeskUnits));
            _cashdeskItems.Add(new CashDeskInfoItem(GetLocalized("ATRPlannedCashDeskUnits"), CashDeskItemType.TargetedCashDeskUnits));
            _cashdeskItems.Add(new CashDeskInfoItem(GetLocalized("DifferenceTargetedPlannedPercent"), CashDeskItemType.DifferenceTargetedPlannedPercent));

            gridControl.DataSource = _cashdeskItems;
        }

        private void BuildColumns()
        {
            int countColumn = 24;

            GridColumn column_8 = null;
            GridColumn column_18 = null;
            GridColumn column_24 = null;
            GridColumn column = null;
            int columnTime = 0;
            for (int i = 0; i < countColumn; i++, columnTime += 60)
            {
                column = gridView.Columns.Add();

                if (i == 7)
                    column_8 = column;
                if (i == 17)
                    column_18 = column;
                if (i == 23)
                    column_24 = column;

                column.Tag = i;

                column.Caption = TextParser.TimeToString(columnTime);
                column.OptionsColumn.ReadOnly = true;
                column.OptionsColumn.AllowEdit = false;
                column.OptionsColumn.ShowInCustomizationForm = false;
                column.OptionsColumn.AllowMove = false;
                column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                column.UnboundType = DevExpress.Data.UnboundColumnType.String;
                column.ColumnEdit = repositoryItemMemoEdit1;
                column.FieldName = "i" + i;
                column.MinWidth = 50;
                column.Width = 50;
                column.Visible = true;
                column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                column.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                column.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            }
            //if (column_24 != null)
            //    gridView.MakeColumnVisible(column_24);


            if (column_8 != null)
                gridView.MakeColumnVisible(column_8);
            if (column_18 != null)
                gridView.MakeColumnVisible(column_18);

        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.Tag != null)
            {
                // hours cells
                int columnHour = (int)e.Column.Tag;
                CashDeskInfoItem item = (CashDeskInfoItem)gridView.GetRow(e.RowHandle);
                if (item.Type == CashDeskItemType.PlannedCashDeskUnits)
                {
                    double value = _calculator.PlannedCashDeskUnits.Elements[columnHour];
                    e.Value = String.Format("{0:F2}", value);
                }
                else if (item.Type == CashDeskItemType.TargetedCashDeskUnits)
                {
                    double value = _calculator.TargetedCashDeskUnits.Elements[columnHour];

                    e.Value = String.Format("{0:F2}", value);
                }
                else if (item.Type == CashDeskItemType.DifferenceTargetedPlannedPercent)
                {
                    double value = _calculator.DifferenceTargetedPlannedPercent.Elements[columnHour];
                    e.Value = String.Format("{0}%", Math.Round (value));

                }
            }
            else
            {
                if (gcResult == e.Column)
                {
                    CashDeskInfoItem item = (CashDeskInfoItem)gridView.GetRow(e.RowHandle);
                    if (item.Type == CashDeskItemType.PlannedCashDeskUnits)
                    {
                        e.Value = String.Format("{1:F2} - {0}", PlannedCashDeskPeopleUnitsPerDay, _calculator.PlannedCashDeskUnits.Sum);
                    }
                    else if (item.Type == CashDeskItemType.TargetedCashDeskUnits)
                    {
                        e.Value = String.Format("{1:F2} - {0}", TargetedCashDeskPeopleUnitsPerDay, _calculator.TargetedCashDeskUnits.Sum);
                    }
                    else if (item.Type == CashDeskItemType.DifferenceTargetedPlannedPercent)
                    {
                        e.Value = String.Format("{1}% - {0}", AbsoluteDifferencePerDayPercent, 
                            Math.Round (_calculator.DifferenceTargetedPlannedPercent.AbsAverage));
                    }
                }
            }

        }

        private void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.Tag != null)
            {
                // hours cells
                int columnHour = (int)e.Column.Tag;

                CashDeskInfoItem item = (CashDeskInfoItem)gridView.GetRow(e.RowHandle);
                
                Debug.Assert(item != null);

                if (item.Type == CashDeskItemType.DifferenceTargetedPlannedPercent)
                {
                    double value = _calculator.DifferenceTargetedPlannedPercent.Elements[columnHour];
                    if (ColorManager != null)
                    {
                        Color color = ColorManager.GetColorByDifferenceInPercentPlannedAndEstimatedHours(value);
                        e.Appearance.ForeColor = color;
                    }
                }
            }
        }


        class CashDeskInfoItem
        {
            private string _ItemName;

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
