using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Baumax.Contract;
using DevExpress.XtraEditors;
using Baumax.Environment;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using System.Collections;
using Baumax.Contract.Exceptions.EntityExceptions;
using DevExpress.XtraEditors.Repository;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCWorldDetail : UCBaseEntity
    {
        private StoreStructureContext context = null;
        private bool isUserStoreAdministrator = false;
        
        #region focused row
        private int FocusedRowHandle 
        { 
            get
            {
                if (vGrid.Visible)
                    return vGrid.FocusedRecord;
                else
                {
                    WorldDetailElement entity = gridControl.MainView.GetRow((gridControl.MainView as DevExpress.XtraGrid.Views.Base.ColumnView).FocusedRowHandle) as WorldDetailElement;
                    if (entity != null)
                        return (gridControl.DataSource as WorldDetailList).IndexOf(entity);
                    else 
                        return 0;
                }
            }
            set 
            {
                if (vGrid.Visible)
                {
                    vGrid.FocusedRecord = value;
                    vGrid.Focus();
                }
                else
                    (gridControl.MainView as DevExpress.XtraGrid.Views.Base.ColumnView).FocusedRowHandle =
                        (gridControl.MainView as DevExpress.XtraGrid.Views.Base.ColumnView).GetRowHandle(value);            
            }
        }

        private WorldDetailElement FocusedEntity 
        {
            get 
            {
                if (vGrid.Visible)
                    return (vGrid.DataSource != null)
                        ? (vGrid.DataSource as WorldDetailList)[vGrid.FocusedRecord]
                        : null;
                else
                    return gridControl.MainView.GetRow((gridControl.MainView
                        as DevExpress.XtraGrid.Views.Base.ColumnView).FocusedRowHandle) as WorldDetailElement;
            }
        }

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            FlyFoucusedChanged();
        }

        private void View_RowCountChanged(object sender, EventArgs e)
        {
            FlyFoucusedChanged();
        }
        private void vGrid_FocusedRecordChanged(object sender, DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            FlyFoucusedChanged();
        }

        private void FlyFoucusedChanged()
        {
            if (FocusedEntity != null)
                context.StoreToWorldID = FocusedEntity.StoreWorldId;
        }
        #endregion

        public UCWorldDetail()
        {
            InitializeComponent();
            if (!IsDesignMode)
            {

                vGrid.Dock = DockStyle.Fill;
                if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value == (long)UserRoleId.StoreAdmin))
                    isUserStoreAdministrator = true;
            }
        }

        protected override void EntityChanged()
        {
            base.EntityChanged();
            ts_ViewMinMax.Text = GetLocalized("ViewMinMax") ?? "View all min / max";
            ts_Refresh.Text = GetLocalized("Refresh") ?? "Refresh";
            context = Entity as StoreStructureContext;
            if (context != null)
            {
                context.StoreChanged += new EventHandler(Context_StoreChanged);
                context.TakeWorldDetail.YearChanged += new EventHandler(context_WorldChanged);
                context_WorldChanged(this, null);
            }
        }

        public override void RefreshData()
        {
            base.RefreshData();
            context_WorldChanged(this, null);
            if (vGrid.Visible)
                vGrid.Focus();
            else
                gridControl.MainView.Focus();

        }

        protected void Context_StoreChanged(object s, EventArgs e)
        {
            context.TakeWorldDetail.YearChanged += new EventHandler(context_WorldChanged);
            context_WorldChanged(this, null);
        }

        protected void context_WorldChanged(object sender, EventArgs e)
        {
            if (context != null)
            {
                context.TakePersonMinMax.Year = context.TakeWorldDetail.Year;
                WorldDetailList list = new WorldDetailList(context.TakeWorldDetail.GetDetailList(), context);
                if (list != null)
                {
                    repWorld.Items.Clear();
                    foreach (WorldDetailElement var in list)
                	{
                        int imageindex = 2;
                        StoreToWorld item = context.TakeStoreWorld.GetWorld(var.StoreWorldId);
                        switch (item.WorldTypeID)
                        {
                            case WorldType.Administration : imageindex = 0; break;
                            case WorldType.CashDesk : imageindex = 1; break;
                            default: imageindex = 2; break;
                        }
                        repWorld.Items.Add(new DevExpress.XtraEditors.Controls.
                             ImageComboBoxItem(var.WorldName, var.WorldName, imageindex));
                    }
                    int buffer = FocusedRowHandle;
                    context.TakeWorldDetail.CurrentDetailList = list;
                    gridControl.DataSource = list;
                    vGrid.DataSource = list;
                    FocusedRowHandle = buffer;
                }
            }
        }
            
        private void ts_ViewAllMinMax_Click(object sender, EventArgs e)
        {
            ViewAllMinMax();
        }



        private void cms_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = context == null || context.StoreToWorldID == 0;
            ts_ViewMinMax.Visible = !isUserStoreAdministrator; 
        }

        public void ViewAllMinMax()
        {
            if (FocusedEntity != null)
                using (FormWorldMinMax form = new FormWorldMinMax())
                {
                    form.Entity = this.Entity;
                    form.ShowDialog();
                    context.TakeWorldDetail.CurrentDetailList.ResetBindings();
                }
        }

        private void UCWorldDetail_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (FocusedEntity != null)
                ts_ViewAllMinMax_Click (this, null);
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {
                LocalizerControl.ComponentsLocalize(this.components);

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in cardView.Columns)
                    col.Caption = GetLocalized(col.Name.Replace("cc_", ""));

                foreach (DevExpress.XtraVerticalGrid.Rows.BaseRow col in vGrid.Rows)
                    col.Properties.Caption = GetLocalized(col.Name.Replace("vc_", ""));
            }
        }

        public void ExchangeView (string viewType)
        {
            int handle = FocusedRowHandle;
            switch (viewType)
            {
                case "card":
                    gridControl.MainView = cardView;
                    vGrid.Visible = false;
                    break;
                case "grid":
                    gridControl.MainView = gridView;
                    vGrid.Visible = false;
                    break;
                case "vgrid":
                    vGrid.Visible = true;
                    break;
            }
            FocusedRowHandle = handle;
        }

        private void cardView_CustomDrawCardCaption(object sender, DevExpress.XtraGrid.Views.Card.CardCaptionCustomDrawEventArgs e)
        {
            WorldDetailElement row = cardView.GetRow(e.RowHandle) as WorldDetailElement;
            e.CardCaption = (row != null) ? row.WorldName : string.Empty;
        }

        private void cardView_CustomCardCaptionImage(object sender, DevExpress.XtraGrid.Views.Card.CardCaptionImageEventArgs e)
        {
            WorldDetailElement row = cardView.GetRow(e.RowHandle) as WorldDetailElement;
            if (row != null)
            {
                if (context != null && context.TakeStoreWorld != null)
                {
                    StoreToWorld s_t_w = context.TakeStoreWorld.GetWorld(row.StoreWorldId);
                    if (s_t_w != null)
                    {
                        switch (s_t_w.WorldTypeID)
                        {
                            case WorldType.Administration:
                                e.ImageIndex = 0;
                                break;
                            case WorldType.CashDesk:
                                e.ImageIndex = 1;
                                break;
                            case WorldType.World:
                                e.ImageIndex = 2;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
