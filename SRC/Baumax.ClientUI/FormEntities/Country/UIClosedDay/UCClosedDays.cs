using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Import;
using Baumax.Import.UI;
using Baumax.Templates;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class UCClosedDays : UCBaseEntity 
    {

        BindingTemplate<YearlyWorkingDay> ListOfClosedDays = new BindingTemplate<YearlyWorkingDay>();
        Dictionary<int, string> m_weekDays = new Dictionary<int, string>();
        bool isImortableRight = false;
        bool isWriteRigth = false;
        
        public UCClosedDays()
        {
            InitializeComponent();

            BeginDate = new DateTime(DateTime.Today.Year, 1, 1, 0,0,0);
            EndDate = new DateTime(DateTime.Today.Year, 12, 31, 23,59,59);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
           IAuthorizationService auth = ClientEnvironment.AuthorizationService;
           AccessType country_service = auth.GetAccess(ClientEnvironment.CountryService);
           isImortableRight = (country_service & AccessType.Import) != 0;
           isWriteRigth = (country_service & AccessType.Write) != 0;
           if (!isWriteRigth) gridControlCloseDay.ContextMenuStrip = null;
           InitTollBar();
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
                LocalizerControl.ComponentsLocalize(components);
        }
        public DateTime BeginDate
        {
            get { return Convert.ToDateTime(de_Begin.EditValue); }
            set { de_Begin.EditValue = value; }
        }
        public DateTime EndDate
        {
            get { return Convert.ToDateTime(de_End.EditValue); }
            set { de_End.EditValue = value; }
        }


        public Domain.Country Country
        {
            get { return (Domain.Country)Entity; }
            set
            {
                Entity = value;
            }
        }

        private void InitTollBar()
        {
           bar_tools.ClearLinks();
           barFilter.ClearLinks();
           
           // if(isImortableRight)  bar_tools.ItemLinks.Add(bi_Import);
           if (isWriteRigth)
           {
               bar_tools.ItemLinks.Add(bi_NewClosedDays);
               bar_tools.ItemLinks.Add(bi_DeleteClosedDays);    
           }
           if (!isImortableRight && !isWriteRigth)
               bar_tools.Visible = false;
           
           barFilter.ItemLinks.Add(lb_FilterByDate);
           barFilter.ItemLinks.Add(de_Begin);
           barFilter.ItemLinks.Add(lb_to);
           barFilter.ItemLinks.Add(de_End);
           barFilter.ItemLinks.Add(bt_Apply);
            
           de_Begin.Width = 82;
           de_End.Width = 82;
       }

        protected override void EntityChanged()
        {
            LoadDays();
            UpdateEnableButton();
        }

        public void LoadDays()
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
            gridControlCloseDay.DataSource = null;
            ListOfClosedDays.Clear();

            if (Country != null)
            {
                 DateTime EndCorrectDate = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, 23, 59, 59);
                 ListOfClosedDays.CopyList(ClientEnvironment.CountryService.YearlyWorkingDayService.GetYearlyWorkingDaysFiltered(Country.ID, BeginDate, EndCorrectDate));
            }
                
            
            if (gridControlCloseDay.DataSource == null)
                gridControlCloseDay.DataSource = ListOfClosedDays;
                         
             bt_Apply.Enabled = FocusedEntity != null;
             UpdateEnableButton();
        }
       
      public Domain.Country EntityCountry
        {
            get { return (Domain.Country)Entity; }
            set
            {
                Entity = value;
            }
        }

        public YearlyWorkingDay FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewCloseDay.FocusedRowHandle);
            }
        }

        YearlyWorkingDay GetEntityByRowHandle(int rowHandle)
        {
            YearlyWorkingDay WorkingDay = null;
            if (gridViewCloseDay.IsDataRow(rowHandle))
                WorkingDay = (YearlyWorkingDay)gridViewCloseDay.GetRow(rowHandle);
            return WorkingDay;

        }
        
        public void NewEntity()
        {
            if (ReadOnly) return;
            ClosedDaysForm fwday = new ClosedDaysForm();
            fwday.Country = Country;
            if (fwday.ShowDialog() == DialogResult.OK)
            {
                LoadDays();
                clearSelectedItems();
            }
        }

        private bool DeleteEntityBySelectedRows()
        {
            for (int i = 0; i < gridViewCloseDay.RowCount; i++)
            {
                if (gridViewCloseDay.IsRowSelected(i) && ListOfClosedDays != null)
                {
                   if  (DeleteEntity(GetEntityByRowHandle(i)))
                    return true;
                }
            }
            return false;
        }

        private void DeleteEntity()
        {
            if (FocusedEntity == null || ListOfClosedDays == null) return;

            if (gridViewCloseDay.SelectedRowsCount > 1)
            {
                if (
                    QuestionMessageYes(GetLocalized("SureToRemoveClosedDay") + " (" +
                                       gridViewCloseDay.SelectedRowsCount.ToString() + ")"))
                {
                    while (DeleteEntityBySelectedRows()) ;
                    clearSelectedItems();
                }
                    
            }
            else if (
                QuestionMessageYes(GetLocalized("SureToRemoveClosedDay") +
                                   String.Format(" ({0})", FocusedEntity.WorkingDay.ToString("d"))))
            {
                DeleteEntity(FocusedEntity);
                clearSelectedItems();
            }
                
        }

        public bool DeleteEntity(YearlyWorkingDay amount)
        {
            YearlyWorkingDay am = amount;
            if (am == null) return false;
            if (am.WorkingDay < DateTime.Now.Date || UCCountryEdit.IsEstimationExist(am.WorkingDay, Country.ID)) return false;
            
                try
                {
                    ClientEnvironment.YearlyWorkingDayService.DeleteByID(am.ID);
                    YearlyWorkingDay removing = ListOfClosedDays.GetItemByID(am.ID);
                    if (removing != null) 
                    {
                        ListOfClosedDays.Remove(removing);
                        UpdateEnableButton();
                        return true;
                    }
                }
                catch (ValidationException)
                {
                    ErrorMessage("CantDeleteYearlyAppearance");
                    return false;
                }
                catch (EntityException ex)
                {
                    ProcessEntityException(ex);
                    return false;
                }
            return false;
        }
        
        void UpdateEnableButton()
        {
            if (FocusedEntity == null)
                bi_DeleteClosedDays.Enabled = false;
            else
                bi_DeleteClosedDays.Enabled =
                    FocusedEntity.WorkingDay >= DateTime.Now.Date && !UCCountryEdit.IsEstimationExist(FocusedEntity.WorkingDay, Country.ID); 
            
            bt_Apply.Enabled = FocusedEntity != null;
        }
       
        private void gridViewWorkingDay_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == gc_DayOfWeek)
            {
                if (e.IsGetData)
                {
                    int idx = e.ListSourceRowIndex;
                    if (idx >= 0 && idx < ListOfClosedDays.Count)
                    {
                        YearlyWorkingDay wday = ListOfClosedDays[e.ListSourceRowIndex];
                        e.Value = m_weekDays[(int)wday.WorkingDay.DayOfWeek];
                    }
               }
            }
        }

        private void bi_Import_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmImport frmImport = new FrmImport(ClientEnvironment.ImportParam, ImportType.WorkingDays))
                        {
                            frmImport.ShowDialog();
                            if (frmImport.BeenRunSuccessfully) 
                                    LoadDays();
                            
                        }
        }
        
        private void clearSelectedItems()
        {
            if (ListOfClosedDays != null && gridViewCloseDay.SelectedRowsCount != 0)
            {
                gridViewCloseDay.ClearSelection();
                /*
                for (int i = 0; i < gridViewCloseDay.RowCount; i++)
                {
                    if (gridViewCloseDay.IsRowSelected(i))
                    {
                        
                    }
                }
                 * */
            }
        }

        private void bi_DeleteCloseDay_ItemClick(object sender, ItemClickEventArgs e)
        { 
            if (FocusedEntity != null)
                DeleteEntity();
        }

        private void bi_NewCloseDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            NewEntity();
        }
       
        private void contextMenuStripCloseDay_Opening(object sender, CancelEventArgs e)
        {
            if (ReadOnly) e.Cancel = true;
            if (FocusedEntity == null)
                toolStripMenuItem_DeleteClosedDays.Enabled = false;
            else
                toolStripMenuItem_DeleteClosedDays.Enabled = FocusedEntity.WorkingDay >= DateTime.Now.Date && !UCCountryEdit.IsEstimationExist(FocusedEntity.WorkingDay, Country.ID);
            if (EntityCountry == null)
            {
                e.Cancel = true;
            }
        }

        private void newClosedDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
             NewEntity();
        }

        private void deleteClosedDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (FocusedEntity != null)
                DeleteEntity();
        }

        private void gridViewCloseDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isWriteRigth) return;
            switch(e.KeyCode)
            {
                case Keys.Insert : NewEntity(); break;
                case Keys.Delete: if (FocusedEntity != null && FocusedEntity.WorkingDay >= DateTime.Now.Date && !UCCountryEdit.IsEstimationExist(FocusedEntity.WorkingDay, Country.ID)) DeleteEntity(); break;
            }
        }
        
        private void btn_Apply_Click(object sender, ItemClickEventArgs e)
        {
            if (BeginDate <= EndDate)
            {

                LoadDays();
            }
            else
            {
                ErrorMessage(GetLocalized("ErrorDateRange"));
                return;
            }
        }

        private void edBegin_EditValueChanged(object sender, EventArgs e)
        {
            if (!bt_Apply.Enabled) bt_Apply.Enabled = true;
        }

        private void edEnd_EditValueChanged(object sender, EventArgs e)
        {
           if (!bt_Apply.Enabled) bt_Apply.Enabled = true;
            if (BeginDate <= EndDate)
                LoadDays();
            else
            {
                ErrorMessage(GetLocalized("ErrorDateRange"));
                return;
            }
        }

        private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (FocusedEntity != null) bi_DeleteClosedDays.Enabled = FocusedEntity.WorkingDay >= DateTime.Now.Date && !UCCountryEdit.IsEstimationExist(FocusedEntity.WorkingDay, Country.ID); 
        }
    }
}
