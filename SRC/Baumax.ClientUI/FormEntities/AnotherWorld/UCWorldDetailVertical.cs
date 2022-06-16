using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using Baumax.Dao.QueryResult;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCWorldDetailVertical : UCBaseEntity
    {
        public UCWorldDetailVertical()
        {
            InitializeComponent();
        }


        private StoreStructureContext context = null;
        private Dictionary<long, Domain.World> m_forReposit = new Dictionary<long, Baumax.Domain.World>();


        protected override void EntityChanged()
        {
            base.EntityChanged();
            ts_ViewMinMax.Text = GetLocalized("ViewMinMax") ?? "View all min / max";
            ts_Refresh.Text = GetLocalized("Refresh") ?? "Refresh";
            context = Entity as StoreStructureContext;
            if (context != null)
            {
                context.TakeWorldDetail.YearChanged += new EventHandler(context_ParameterChanged);
                context.StoreChanged += new EventHandler(context_ParameterChanged);
                context_ParameterChanged (this, null);
            }
        }

        public override void RefreshData()
        {
            base.RefreshData();
            int buffer = vGrid.FocusedRecord;
            context_ParameterChanged(this, null);
            vGrid.FocusedRecord = buffer;
        }

        protected void context_ParameterChanged(object sender, EventArgs e)
        {
            if (context != null)
            { 
                List <StoreWorldDetail> list = context.TakeWorldDetail.GetDetailList();
                if (list != null)
                {
                    repWorld.Items.Clear();
                    m_forReposit.Clear();
                    foreach (StoreWorldDetail var in list)
                	{
                        int imageindex = 2;
                        Domain.World item = context.TakeStoreWorld.GetWorld(var.StoreWorldId);
                        switch (item.WorldTypeID)
                        {
                            case WorldType.Administration : imageindex = 0; break;
                            case WorldType.CashDesk : imageindex = 1; break;
                            default: imageindex = 2; break;
                        }
                        repWorld.Items.Add(new DevExpress.XtraEditors.Controls.
                             ImageComboBoxItem(item.Name, item, imageindex));
                        m_forReposit.Add(var.StoreWorldId, item);
                    }
                    BaseRow row = vGrid.FocusedRow;
                    vGrid.DataSource = list;
                    vGrid.FocusedRow = row;
                }
            }
        }

            
        private void ts_ViewAllMinMax_Click(object sender, EventArgs e)
        {
            ViewAllMinMax();
        }



        

        private void cms_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = context == null || context.StoreToWorldID == 0;
        }

        public void ViewAllMinMax()
        {
            //StoreWorldDetail swd = gridView.GetRow(gridView.FocusedRowHandle) as StoreWorldDetail;
            using (FormWorldMinMax form = new FormWorldMinMax())
            {
                form.Entity = this.Entity;
                form.ShowDialog();
                RefreshData();
            }
        }

        private void UC_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ts_ViewAllMinMax_Click (this, null);
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                LocalizerControl.ComponentsLocalize(this.components);

                foreach (BaseRow col in vGrid.Rows)
                    col.Properties.Caption = GetLocalized(col.Name.Replace("vc_", ""));
            }
        }

        private void vGrid_FocusedRecordChanged(object sender, DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            //MessageBox.Show(vGrid.GetCellValue(vGrid.FocusedRow , e.NewIndex).ToString());
        }

    }
}
