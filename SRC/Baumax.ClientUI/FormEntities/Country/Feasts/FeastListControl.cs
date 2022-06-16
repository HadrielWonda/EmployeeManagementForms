using System;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Import;
using Baumax.Import.UI;
using Baumax.Templates;
using System.Collections.Generic;
using DevExpress.Utils;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class FeastListControl : UCBaseEntity
    {
        Dictionary<int, string> m_weekDays = new Dictionary<int, string>();
        BindingTemplate<Feast> m_bindingFeasts = new BindingTemplate<Feast>();
        bool isImortableRight = false;
        bool isWriteRigth = false;

        public FeastListControl()
        {
            InitializeComponent();
            BeginDate = new DateTime(DateTime.Today.Year, 1, 1, 0, 0, 0);
            EndDate = new DateTime(DateTime.Today.Year, 12, 31, 23, 59, 59);
        }

        public DateTime BeginDate
        {

            get { return Convert.ToDateTime(deBegin.EditValue); }
            set { deBegin.EditValue = value; }
        }
        
        public DateTime EndDate
        {
            get { return Convert.ToDateTime(deEnd.EditValue); }
            set { deEnd.EditValue = value; }
        }
        
        public override void AssignLanguage()
        {
            if (ClientEnvironment.IsRuntimeMode)
            {
                base.AssignLanguage();
                LocalizerControl.ComponentsLocalize(components);
            }
        }

        public BindingTemplate<Feast> ListOfFeasts
        {
            get
            {
                return m_bindingFeasts;
            }
        }

        public Domain.Country Country
        {
            get { return (Domain.Country)Entity; }
            set 
            {
                Entity = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            IAuthorizationService auth = ClientEnvironment.AuthorizationService;
            AccessType country_service = auth.GetAccess(ClientEnvironment.CountryService);
            isImortableRight = (country_service & AccessType.Import) != 0;
            isWriteRigth = (country_service & AccessType.Write) != 0;
            if (!isWriteRigth) gridControlFeast.ContextMenuStrip = null;
            InitToolBar();

            ToolTipController toolTip = new ToolTipController();
            
            // ToolTips *****************
            toolTip.Rounded = true;
            toolTip.ShowBeak = true;
            toolTip.ToolTipType = ToolTipType.Standard;
            gridControlFeast.ToolTipController = toolTip;
            foreach (DevExpress.XtraGrid.Views.Base.ColumnView bview in gridControlFeast.Views)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in
                    bview.Columns)
                {
                    column.ToolTip = GetLocalized(column.Caption); 
                }
            }
            //*********end tooltips
            
            UpdateEnableButton();
        }
        
        void UpdateEnableButton()
        {
            btn_Apply.Enabled = FocusedEntity != null;
            if (FocusedEntity == null)
                bi_DeleteFeast.Enabled = false;
            else
                bi_DeleteFeast.Enabled =
                   FocusedEntity.FeastDate >= DateTime.Now.Date; // && !UCCountryEdit.IsEstimationExist(FocusedEntity.FeastDate, Country.ID)
        }
        
        protected override void EntityChanged()
        {
            ReloadFeasts();
        }

        Feast GetEntityByRowHandle(int rowHandle)
        {
            Feast feast = null;
            if (gridViewFeast.IsDataRow(rowHandle))
                feast = (Feast)gridViewFeast.GetRow(rowHandle);
            return feast;

        }

        public Feast FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewFeast.FocusedRowHandle);
            }
        }
        
        private void InitToolBar()
        {
            bar_tools.ClearLinks();
            // if (isImortableRight) bar_tools.ItemLinks.Add(bi_Import);
            if (isWriteRigth)
            {
                bar_tools.ItemLinks.Add(bi_NewFeast);
                bar_tools.ItemLinks.Add(bi_DeleteFeast);
            }
            if (!isImortableRight && !isWriteRigth)
                bar_tools.Visible = false;
           
            
            barFilter.ClearLinks();
            barFilter.ItemLinks.Add(bs_FilterByDate);
            barFilter.ItemLinks.Add(deBegin);
            barFilter.ItemLinks.Add(li_to);
            barFilter.ItemLinks.Add(deEnd);
            barFilter.ItemLinks.Add(btn_Apply);
            deBegin.Width = 82;
            deEnd.Width = 82;
        }
        
        public void ReloadFeasts()
        {
            if (m_weekDays.Count == 0)
            {
                m_weekDays[(int)DayOfWeek.Monday] = GetLocalized(DayOfWeek.Monday.ToString());
                m_weekDays[(int)DayOfWeek.Tuesday] = GetLocalized(DayOfWeek.Tuesday.ToString());
                m_weekDays[(int)DayOfWeek.Wednesday] = GetLocalized(DayOfWeek.Wednesday.ToString());
                m_weekDays[(int)DayOfWeek.Thursday] = GetLocalized(DayOfWeek.Thursday.ToString());
                m_weekDays[(int)DayOfWeek.Friday] = GetLocalized(DayOfWeek.Friday.ToString());
                m_weekDays[(int)DayOfWeek.Saturday] = GetLocalized(DayOfWeek.Saturday.ToString());
                m_weekDays[(int)DayOfWeek.Sunday] = GetLocalized(DayOfWeek.Sunday.ToString());
            }

            ListOfFeasts.Clear();

            if (Country != null)
            {
                DateTime EndCorrectDate = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, 23, 59, 59);
                ListOfFeasts.CopyList(ClientEnvironment.FeastService.GetFeastsFiltered(Country.ID, BeginDate, EndCorrectDate));
            }

            if (gridControlFeast.DataSource == null)
                gridControlFeast.DataSource = ListOfFeasts;
            
            UpdateEnableButton();
                

        }

        private bool DeleteEntityBySelectedRows()
        {
            for (int i = 0; i < gridViewFeast.RowCount; i++)
            {
                if (gridViewFeast.IsRowSelected(i) && ListOfFeasts != null)
                {
                   if  (DeleteEntity(GetEntityByRowHandle(i)))
                    return true;
                }
            }
            return false;
        }

        private void DeleteEntity()
        {
            if (FocusedEntity == null || ListOfFeasts == null) return;

            if (gridViewFeast.SelectedRowsCount > 1)
            {
                if (
                    QuestionMessageYes(GetLocalized("questiondeletefeast") + " (" +
                                       gridViewFeast.SelectedRowsCount.ToString() + ")"))
                    while (DeleteEntityBySelectedRows()) ;
            }
            else
            {
                if (
                    QuestionMessageYes(GetLocalized("questiondeletefeast") +
                                       String.Format(" ({0})", FocusedEntity.FeastDate.ToString("d"))))
                    DeleteEntity(FocusedEntity);
            }
        }

        public bool DeleteEntity(Feast feast)
        {
            if (ReadOnly) return false;

            Feast f = feast;

            if (f == null || f.FeastDate < DateTime.Now.Date) // || UCCountryEdit.IsEstimationExist(f.FeastDate, Country.ID)
                return false;

            try
            {
                    ClientEnvironment.FeastService.DeleteByID(f.ID);
                    ListOfFeasts.Remove(f);
                    UpdateEnableButton();
                    return true;
            }
            catch(Exception  ex)
            {
                ErrorMessage(ex.Message);
                return false;
            }
        }

        public void NewEntity()
        {
            if (ReadOnly) return;
            FormFeast ffeast = new FormFeast();
            ffeast.Country = Country;
            if (ffeast.ShowDialog() == DialogResult.OK)
            {
                ReloadFeasts();
            }
        }

        private void defineNewFeastsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ReadOnly) return;

            NewEntity();
        }

        private void deleteFeastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ReadOnly) return;

            DeleteEntity();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (ReadOnly) e.Cancel = true;

            if (FocusedEntity == null)
                toolStripMenuItem_DeleteFeast.Enabled = false;
            else toolStripMenuItem_DeleteFeast.Enabled = FocusedEntity.FeastDate >= DateTime.Now.Date ;//&& !UCCountryEdit.IsEstimationExist(FocusedEntity.FeastDate, Country.ID)
        }

        private void gridViewFeast_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == gc_DayOfWeek)
            {
                if (e.IsGetData)
                {
                    int idx = e.ListSourceRowIndex;
                    if (idx >= 0 && idx < ListOfFeasts.Count)
                    {
                        Feast feast = ListOfFeasts[e.ListSourceRowIndex];
                        e.Value = m_weekDays[(int)feast.FeastDate.DayOfWeek];
                    }
                }
            }
        }

        private void gridControlFeast_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isWriteRigth) return;
            
            switch(e.KeyCode)
            {
                case Keys.Insert: NewEntity(); 
                    break;
                case Keys.Delete: if (FocusedEntity != null && FocusedEntity.FeastDate >= DateTime.Now.Date )  //&& !UCCountryEdit.IsEstimationExist(FocusedEntity.FeastDate, Country.ID)
                                        DeleteEntity();
                    break;
                    
            }
        }

        private void bi_Import_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmImport frmImport = new FrmImport(ClientEnvironment.ImportParam, ImportType.Feast))
            {
                frmImport.ShowDialog();
                if (frmImport.BeenRunSuccessfully)
                {
                    ReloadFeasts();
                }
            }
        }

        private void bi_NewFeast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewEntity();
        }

        private void bi_DeleteFeast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FocusedEntity != null) DeleteEntity();
        }

        private void btnApply_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           if (BeginDate <= EndDate)
            {

             ReloadFeasts();
            }
            else
            {
                ErrorMessage(GetLocalized("ErrorDateRange"));
                return;
            }
        }

        private void deBegin_EditValueChanged(object sender, EventArgs e)
        {
            if (!btn_Apply.Enabled) btn_Apply.Enabled = true;
        }

        private void deEnd_EditValueChanged(object sender, EventArgs e)
        {
            if (!btn_Apply.Enabled) btn_Apply.Enabled = true;
            if (BeginDate <= EndDate)
            {

                ReloadFeasts();
            }
            else
            {
                ErrorMessage(GetLocalized("ErrorDateRange"));
                return;
            }
        }

        private void GridViewfeast_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedEntity != null) bi_DeleteFeast.Enabled = FocusedEntity.FeastDate >= DateTime.Now.Date ;//&& !UCCountryEdit.IsEstimationExist(FocusedEntity.FeastDate, Country.ID)
        }

    }
}

