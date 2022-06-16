using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;

namespace Baumax.ClientUI.FormEntities.TimePlanning.Daily
{
    public partial class UCWorlDailyView : UCBaseEntity 
    {
        public UCWorlDailyView()
        {
            InitializeComponent();
            BuildHalfHoursColumns();
        }


        private void BuildHalfHoursColumns()
        {
            GridColumn column = null;
            int countColumn = 48;
            int iStep = 30;
            int icurrentTime = 0;

            gridViewHalfHour.Columns.Clear();

            for (int i = 0; i < countColumn; i++)
            {
                column = gridViewHalfHour.Columns.Add();
                column.Caption = String.Format ("{0}:{1}", (int)(icurrentTime / 60), (icurrentTime % 60));
                column.Tag = icurrentTime;
                icurrentTime += iStep;
            }
        }

    }
}
