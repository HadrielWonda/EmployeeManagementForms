using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Contract.TimePlanning;

namespace Baumax.ClientUI.FormEntities.Controls
{
    public partial class StoreWorldPanleInfo : UCBaseEntity
    {
        private string __MinimumPresence = "Minimum presence:";
        private string __MaximumPresence = "Maximum presence:";
        private string __AvailableWorldBufferHours = "Available world-buffer hours:";
        private string __TargetedNetPerformancePerHour = "Targeted Net-performance per hour:";
        private string __Benchmark = "Benchmark: ";
        private string __DifferenceToBenchmark = "Difference to benchmark:";

        public StoreWorldPanleInfo()
        {
            InitializeComponent();
        }

        private StoreWorldPlanningInfo _worldinfo = null;


        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {

                __MinimumPresence = GetLocalized("MinimumPresence");
                __MaximumPresence = GetLocalized("MaximumPresence");

                __AvailableWorldBufferHours = GetLocalized("AvailableWorldBufferHours");


                __TargetedNetPerformancePerHour = GetLocalized("TargetedNetPerformancePerHour");

                __Benchmark = GetLocalized("Benchmark");

                __DifferenceToBenchmark = GetLocalized("DifferenceToBenchmark");


                UpdateStoreWorldInfo();

                LocalizerControl.ComponentsLocalize(this.components);
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

        public void UpdateInfo()
        {
            UpdateStoreWorldInfo();
        }

        private ICountryColorManager _colormanager = null;
        public ICountryColorManager ColorManager
        {
            get { return _colormanager; }
            set { _colormanager = value; }
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
