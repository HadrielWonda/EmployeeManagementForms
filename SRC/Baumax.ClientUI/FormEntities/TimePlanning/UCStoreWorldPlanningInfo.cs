using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Baumax.Environment;
using Baumax.Contract.TimePlanning;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public partial class UCStoreWorldPlanningInfo : UCBaseEntity
    {

        #region  string fields for translation

        private string __SummTargetedHours = "Summ targeted hours:";
        private string __SummDifference = "Summ difference:";
        private string __AbsoluteSummDifference = "Absolute summ difference:";
        private string __SummDifferenceInPercent = "Summ difference (percent):";
        private string __AbsoluteSummDifferenceInPercent = "Absolute summ difference (percent):";


        private string __MinimumPresence = "Minimum presence:";
        private string __MaximumPresence = "Maximum presence:";
        private string __AvailableWorldBufferHours = "Available world-buffer hours:";
        private string __TargetedNetPerformancePerHour = "Targeted Net-performance per hour:";
        private string __Benchmark = "Benchmark: ";
        private string __DifferenceToBenchmark = "Difference to benchmark:";

        #endregion

        private WorldPlanningStatisticItem[] _statisticItems = new WorldPlanningStatisticItem[3];

        private StoreWorldPlanningInfo _worldinfo = null;
        private ICountryColorManager _colormanager = null;
        private bool _IsPlanned = true;

        public bool IsPlanned
        {
            get { return _IsPlanned; }
            set 
            {
                if (_IsPlanned != value)
                {
                    _IsPlanned = value;
                    AssignLanguage();
                }
            }
        }

        public StoreWorldPlanningInfo WorldInfo
        {
            get { return _worldinfo; }
            set
            {
                _worldinfo = value;
                UpdateInfo();
            }
        }
        public ICountryColorManager ColorManager
        {
            get { return _colormanager; }
            set { _colormanager = value; }
        }

        public UCStoreWorldPlanningInfo()
        {
            InitializeComponent();
            if (!IsDesignMode)
            {
                _statisticItems[0] = new WorldPlanningStatisticItem(
                    GetLocalized(WorldStaticticItemType.SummPlannedWorkingHours.ToString()),
                    WorldStaticticItemType.SummPlannedWorkingHours);
                _statisticItems[1] = new WorldPlanningStatisticItem(
                    GetLocalized(WorldStaticticItemType.TargetedHours.ToString()),
                    WorldStaticticItemType.TargetedHours);
                /*_statisticItems[2] = new WorldPlanningStatisticItem(
                    GetLocalized(WorldStaticticItemType.Difference.ToString()),
                    WorldStaticticItemType.Difference);*/
                _statisticItems[2] = new WorldPlanningStatisticItem(
                    GetLocalized(WorldStaticticItemType.DifferenceInPercent.ToString()),
                    WorldStaticticItemType.DifferenceInPercent);

                gridControlInfo.DataSource = _statisticItems;
                gridViewInfo.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(gridViewInfo_CustomUnboundColumnData);
            }
        }

        private void gridViewInfo_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (WorldInfo == null)
            {
                e.Value = "0";
                return;
            }
            if (e.IsGetData)
            {
                if (e.Column == gcInfoSummAndDifferences)
                {
                    WorldPlanningStatisticItem item = (WorldPlanningStatisticItem)gridViewInfo.GetRow(e.RowHandle);

                    if (item.ItemType == WorldStaticticItemType.DifferenceInPercent)
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.AppendLine(String.Format("{0}%", Math.Round (WorldInfo.SumDifferencePercent)) + " " + __SummDifferenceInPercent);
                        sb.AppendLine(TextParser.BuildDifferenceAbsoluteSumInPercent
                                        (
                                        WorldInfo.AbsSumDifferencePercent,
                                        WorldInfo.AbsSumDifferencePosPercent,
                                        WorldInfo.AbsSumDifferenceNegPercent
                                        ) + " " + __AbsoluteSummDifferenceInPercent);
                        e.Value = sb.ToString();
                    }
                    if (item.ItemType == WorldStaticticItemType.SummPlannedWorkingHours)
                    {
                        e.Value = TextParser.TimeToString(WorldInfo.SumPlannedHours);
                    }
                    if (item.ItemType == WorldStaticticItemType.TargetedHours)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(TextParser.TimeToString(WorldInfo.SumTargetedHours) + " " + __SummTargetedHours);

                        e.Value = sb.ToString();

                    }
                    return;
                }

                if (e.Column.Tag != null)
                {
                    DayOfWeek dw = (DayOfWeek )e.Column.Tag;

                    WorldPlanningStatisticItem item = (WorldPlanningStatisticItem)gridViewInfo.GetRow(e.RowHandle);
                    if (item != null)
                    {
                        if (item.ItemType == WorldStaticticItemType.DifferenceInPercent)
                        {

                            e.Value = TextParser.ToRoundSignPercent(WorldInfo.GetDayPercent(dw));

                        }
                        if (item.ItemType == WorldStaticticItemType.SummPlannedWorkingHours)
                        {
                            e.Value = TextParser.TimeToString(WorldInfo.GetPlannedValue(dw));
                        }
                        if (item.ItemType == WorldStaticticItemType.TargetedHours)
                        {
                            e.Value = TextParser.TimeToString(WorldInfo.GetTargetValue(dw));
                        }
                    }
                }


            }
        }
        private void gridViewInfo_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (WorldInfo == null) return;

            if ((e.Column.Tag != null) && (ColorManager != null))
            {
                DayOfWeek dw = (DayOfWeek)e.Column.Tag;

                WorldPlanningStatisticItem item = (WorldPlanningStatisticItem)gridViewInfo.GetRow(e.RowHandle);

                if ((item != null) && (item.ItemType == WorldStaticticItemType.DifferenceInPercent))
                {
                    double value = WorldInfo.GetDayPercent(dw);

                    Color color = ColorManager.GetColorByDifferenceInPercentPlannedAndEstimatedHours(value);
                    e.Appearance.ForeColor = color;
                }
            }
        }

        private void gridViewInfo_CalcRowHeight(object sender, DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs e)
        {
            WorldPlanningStatisticItem item = (WorldPlanningStatisticItem)gridViewInfo.GetRow(e.RowHandle);

            if (item == null) return;

            Graphics graphics = gridControlInfo.CreateGraphics();
            try
            {
                Size sf = graphics.MeasureString("222", gridViewInfo.Appearance.Row.Font).ToSize();
                int stringHeight = sf.Height;


                if (item.ItemType == WorldStaticticItemType.TargetedHours)
                    e.RowHeight = stringHeight;
                else if (item.ItemType == WorldStaticticItemType.SummPlannedWorkingHours)
                    e.RowHeight = stringHeight;
                else if (item.ItemType == WorldStaticticItemType.DifferenceInPercent)
                    e.RowHeight = stringHeight * 2;
            }
            finally
            {
                graphics.Dispose();
            }
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {

                if (IsPlanned)
                {
                    _statisticItems[0].ItemName = GetLocalized(_statisticItems[0].ItemType.ToString());
                    _statisticItems[1].ItemName = GetLocalized(_statisticItems[1].ItemType.ToString());
                    //_statisticItems[2].ItemName = GetLocalized(_statisticItems[2].ItemType.ToString());
                    _statisticItems[2].ItemName = GetLocalized(_statisticItems[2].ItemType.ToString());
                }
                else
                {
                    _statisticItems[0].ItemName = GetLocalized("ATRSummActualWorkingHours");
                    _statisticItems[1].ItemName = GetLocalized("ATRPlannedHours");
                    _statisticItems[2].ItemName = GetLocalized(_statisticItems[2].ItemType.ToString());

                }
                __SummTargetedHours = (IsPlanned) ? GetLocalized("SummTargetedHours") : GetLocalized("ATRSummActualHours");
                __SummDifference = GetLocalized("SummDifference");
                __AbsoluteSummDifference = GetLocalized("AbsoluteSummDifference");
                __SummDifferenceInPercent = GetLocalized("SummDifferenceInPercent");
                __AbsoluteSummDifferenceInPercent = GetLocalized("AbsoluteSummDifferenceInPercent");

                __MinimumPresence = GetLocalized("MinimumPresence");
                __MaximumPresence = GetLocalized("MaximumPresence");

                __AvailableWorldBufferHours = GetLocalized("AvailableWorldBufferHours");


                if (IsPlanned )
                    __TargetedNetPerformancePerHour = GetLocalized("TargetedNetPerformancePerHour");
                else
                    __TargetedNetPerformancePerHour = GetLocalized("ATRActualNetPerformancePerHour");
                    

                __Benchmark = GetLocalized("Benchmark");

                __DifferenceToBenchmark = GetLocalized("DifferenceToBenchmark");

                
                UpdateStoreWorldInfo();

                LocalizerControl.ComponentsLocalize(this.components);
            }
        }

        public void UpdateInfo()
        {
            gridViewInfo.RefreshData();
            UpdateStoreWorldInfo();
        }

        private void UpdateStoreWorldInfo()
        {
            short min = 0;
            short max = 0;
            int available = 0;
            decimal netperformance = 0;
            decimal benchmark = 0;
            decimal difference = 0;

            if (WorldInfo != null)
            {
                min = WorldInfo.MinimumPresence;
                max = WorldInfo.MaximumPresence;

                available = WorldInfo.CurrentBufferHours;

                netperformance = WorldInfo.TargetedNetPerformancePerHour;


                if (WorldInfo.SumHoursForNetPerformance != 0)
                    netperformance = (netperformance / WorldInfo.SumHoursForNetPerformance) * 60;

                benchmark = (decimal)WorldInfo.Benchmark;
                if (benchmark != 0)
                {
                    difference = (100 / benchmark) * (netperformance - benchmark);
                }
                else difference = 100;

                lblAvailableWorldBufferHours.Visible = WorldInfo.ExistBufferHours;
            }

            lblMinimumPresence.Text = String.Format("{0} {1}", __MinimumPresence, min);
            lblMaximumPresence.Text = String.Format("{0} {1}", __MaximumPresence, max);

            lblAvailableWorldBufferHours.Text = String.Format("{0}  {1}", __AvailableWorldBufferHours, TextParser.TimeToString(available));

            lblTargetedNetPerformancePerHour.Text = String.Format("{0} {1:F2}", __TargetedNetPerformancePerHour, netperformance);

            lblBenchmark.Text = String.Format("{0} {1:F2}", __Benchmark, benchmark);

            lblDifferenceToBenchmark.Text = String.Format("{0} {1:F2}%", __DifferenceToBenchmark, difference);
            if (ColorManager != null)
            {
                Color color = ColorManager.GetByTypeAndValue(Baumax.Domain.CountryColorValueType.BenchmarkDifference, (int)(difference));
                lblDifferenceToBenchmark.Appearance.ForeColor = color;
            }
        }
    }
}
