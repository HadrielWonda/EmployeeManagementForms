using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace ControlTest
{
    public partial class PlanningWeek : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        public PlanningWeek()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            InitColumns();
            // TODO: Add any initialization after the InitForm call
        }
        void InitColumns()
        {
            _columns.Add(colMonday, null);
            _columns.Add(colTuesday, null);
            _columns.Add(colWednesday, null);
            _columns.Add(colThusday, null);
            _columns.Add(colFriday, null);
            _columns.Add(colSaturday, null);
            _columns.Add(colSunday, null);
            colEmployyeName.FieldName = "EmployeeName";
            colEmployyeNumber.FieldName = "EmployeeID";

        }
        Hashtable _columns = new Hashtable(7);
        private IList _list;

        public IList List
        {
            get { return _list; }
            set { _list = value; gridPlanningWeek.DataSource = _list; }
        }

        private void PlanningWeek_Load(object sender, EventArgs e)
        {
           // bandedGridColumn7.Caption = "1111\n 22222";
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (!_columns.ContainsKey(e.Column)) return;
            TimeRange[] range = new TimeRange[2];
            range[0] = new TimeRange(660, 1080, Color.Red, Color.Purple); 
            range[1] = new TimeRange(660, 1080, Color.Red, Color.Purple);

            DrawTimeRange dr = new DrawTimeRange();
            dr.Draw(e.Graphics, e.Bounds, range);
            e.Handled = true;
        }

        private void bandedGridView1_CalcRowHeight(object sender, DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs e)
        {
            TimeRange[] range = new TimeRange[2];
            range[0] = new TimeRange(660, 1080, Color.Red, Color.Purple); 
            range[1] = new TimeRange(660, 1080, Color.Red, Color.Purple);

            DrawTimeRange dr = new DrawTimeRange();
            
            e.RowHeight = 40;

        }

        private void bandedGridView1_CustomUnboundColumnData_1(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            e.Value = "00:00-00:00";
        }

        private void bandedGridView1_ShownEditor(object sender, EventArgs e)
        {
            bandedGridView1.EditingValue = "09:30-12:30";
        }

        private void bandedGridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (bandedGridView1.FocusedColumn == colMonday) e.Cancel = true;
        }

        private void bandedGridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //if (bandedGridView1.FocusedColumn == colWednesday) e.Valid = false;
            Regex ret = new Regex(@"^\d{3,4}-\d{3,4}$");
            if (!ret.IsMatch(e.Value.ToString()))
            {
                e.Valid = false;
                e.ErrorText = "Присутствуют недопустимые символы !!!";
            }

        }

    }
}
