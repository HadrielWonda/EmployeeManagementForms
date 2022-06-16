using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Baumax.Contract.TimePlanning;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public partial class UCCashDeskDailyPlannedInfo : UCBaseEntity 
    {

        private CashDeskPlanningInfo _CashDeskInfo = null;
        private CashDeskDailyPlanningCalculator2 _calculator = new CashDeskDailyPlanningCalculator2();
        private DateTime _ViewDate = DateTime.Today;
        private List<CashDeskInfoItem> _cashdeskItems = new List<CashDeskInfoItem>();

        private string __PlannedHoursPerDay = " Planned hours per Day";
        private string __TargetedHoursPerDay = " Targeted hours per Day";
        private string __DiffInPercentPerDay = " Sum difference in %";

        private string __MinimumPresence = "Minimum presence:";
        private string __MaximumPresence = "Maximum presence:";
        private string __AvailableWorldBufferHours = "Available world-buffer hours:";
        
        private ICountryColorManager _colormanager = null;
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
                _CashDeskInfo = value;
                _calculator.AssignCashDeskInfo(_CashDeskInfo, ViewDate);
                UpdateStoreWorldInfo();
            }
        }

        public DateTime ViewDate
        {
            get { return _ViewDate; }
            set { _ViewDate = value; }
        }

        public void SetCashDeskInfo(CashDeskPlanningInfo cashdeskinfo, DateTime viewdate)
        {
            ViewDate = viewdate;
            CashDeskInfo = cashdeskinfo;
        }

        public UCCashDeskDailyPlannedInfo()
        {
            InitializeComponent();
            BuildColumns();
        }

        private void BuildColumns()
        {
            int countColumn = 24;

            GridColumn column = null;
            int columnTime = 0;
            for (int i = 0; i < countColumn; i++, columnTime += 60)
            {
                column = gridView.Columns.Add();
                column.Tag = i;

                column.Caption = TextParser.TimeToString(columnTime);
                column.OptionsColumn.ReadOnly = true;
                column.OptionsColumn.AllowEdit = false;
                column.OptionsColumn.ShowInCustomizationForm = false;
                column.OptionsColumn.AllowMove = false;
                column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                column.UnboundType = DevExpress.Data.UnboundColumnType.String;
                //column.ColumnEdit = repositoryItemMemoEdit1;
                column.FieldName = "i" + i;
                column.MinWidth = 50;
                column.Width = 50;
                column.Visible = true;
                column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                column.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                //column.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            }

            if ((column = FindColumnByFieldName("i8")) != null)
                gridView.MakeColumnVisible(column);
            if ((column = FindColumnByFieldName("i18")) != null)
                gridView.MakeColumnVisible(column);
        }

        private void BuildRows()
        {
            gridControl.DataSource = null;

            _cashdeskItems.Clear();

            _cashdeskItems.Add(new CashDeskInfoItem(GetLocalized("PlannedHours"), CashDeskItemType.PlannedCashDeskUnits));
            _cashdeskItems.Add(new CashDeskInfoItem(GetLocalized("TargetedHours"), CashDeskItemType.TargetedCashDeskUnits));
            _cashdeskItems.Add(new CashDeskInfoItem(GetLocalized("DiffInPercent"), CashDeskItemType.DifferenceTargetedPlannedPercent));

            gridControl.DataSource = _cashdeskItems;
        }

        private GridColumn FindColumnByFieldName(string field_name)
        {
            foreach (GridColumn column in gridView.Columns)
                if (column.FieldName == field_name) return column;

            return null;
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {
                __PlannedHoursPerDay = GetLocalized("PlannedCashDeskHoursPerDay");
                __TargetedHoursPerDay = GetLocalized("TargetedCashDeskHoursPerDay");
                __DiffInPercentPerDay = GetLocalized("DiffPerDayInPercent");

                BuildRows();

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
                    //e.Value = String.Format("{0:F2}%", value);
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
                        e.Value = String.Format("{1:F2} - {0}",
                            __PlannedHoursPerDay,
                            _calculator.PlannedCashDeskUnits.Sum);

                    }
                    else if (item.Type == CashDeskItemType.TargetedCashDeskUnits)
                    {
                        e.Value = String.Format("{1:F2} - {0}",
                            __TargetedHoursPerDay,
                            _calculator.TargetedCashDeskUnits.Sum);

                    }
                    else if (item.Type == CashDeskItemType.DifferenceTargetedPlannedPercent)
                    {
                        e.Value = String.Format("{1}% - {0}",
                           __DiffInPercentPerDay,
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
                int columnHour = Convert.ToInt32(e.Column.Tag);
                CashDeskInfoItem item = (CashDeskInfoItem)gridView.GetRow(e.RowHandle);
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
            TargetedReceipt,
            DifferenceTargetedPlanned,
            DifferenceTargetedPlannedPercent

        }
    }
}
