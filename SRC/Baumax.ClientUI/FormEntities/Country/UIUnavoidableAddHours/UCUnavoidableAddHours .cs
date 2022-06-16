using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class UCUnavoidableAddHours : UCBaseEntity
    {
        BindingTemplate<CountryAdditionalHour> ListOfUnavAddHours = new BindingTemplate<CountryAdditionalHour>();
        bool isUserWriteRight = UCCountryEdit.isUserWriteRight();
        
        
        public UCUnavoidableAddHours()
        {
            InitializeComponent();
            if (!isUserWriteRight) gridControl_UnAdHours.ContextMenuStrip = null;
            BeginDate = (short) DateTime.Today.Year;
            EndDate = (short) DateTime.Today.Year;
        }

        public Domain.Country Country
        {
            get { return (Domain.Country)Entity; }
            set
            {
                Entity = value;
            }
        }

        #region fields
        
        string[] daysOfWeek = null;
        private DateTime ConvertShortToDateTime(short date)
        {
            int hour, min;
                hour = date / 60;
                min = date - hour * 60;
                return new DateTime(DateTime.Today.Year, 1, 1, hour, min, 0);
        }
        
        public Domain.Country EntityCountry
        {
            get { return (Domain.Country)Entity; }
            set
            {
                Entity = value;
            }
        }

        public short BeginDate
        {
            get { return Convert.ToInt16(de_Begin.EditValue); }
            set {de_Begin.EditValue = value;}
        }

        public short EndDate
        {
            get
            {
                if (de_End.EditValue == null) return 2079;
                return Convert.ToInt16(de_End.EditValue);
            }
            set
            {
                if (value == -1) 
                    de_End.EditValue = null;
                else
                     de_End.EditValue = value;
            }
        }
        
        #endregion
        
        public override void AssignLanguage()
        {
            if (ClientEnvironment.IsRuntimeMode)
            {
                base.AssignLanguage();
                LocalizerControl.ComponentsLocalize(components);
            }
        }
        
        protected override void EntityChanged()
        {
            InitControl();
            UpdateBarButtons();
        }
        
        private void InitTollBar()
        {
            barTool.ClearLinks();
            if (isUserWriteRight)
            {
                barTool.ItemLinks.Add(bi_NewUAAH);
                barTool.ItemLinks.Add(bi_EditUAAH);
                barTool.ItemLinks.Add(bi_DeleteUAAH);
                //barTool.ItemLinks.Add(Calculate); // remove **
            }
            else
            {
                barTool.Visible = false; 
                contextMenuStrip_UnAdHours.Enabled = false;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitTollBar();
            UpdateBarButtons();
        }
        
        protected void UpdateBarButtons()
        {
                if (FocusedEntity == null)
                {
                    bi_EditUAAH.Enabled = false;
                    bi_DeleteUAAH.Enabled = false;
                }
                else
                {
                    bi_DeleteUAAH.Enabled = FocusedEntity.Year >= DateTime.Now.Year && !UCCountryEdit.IsEstimationExist(FocusedEntity.Year, Country.ID);
                    bi_EditUAAH.Enabled = bi_DeleteUAAH.Enabled;   
                }
               
        }
        
         void Clear()
        {
            if (ListOfUnavAddHours == null) ListOfUnavAddHours = new BindingTemplate<CountryAdditionalHour>();
            ListOfUnavAddHours.Clear();
            gridControl_UnAdHours.DataSource = null;
        }
        
        public void InitControl()
        {
            Clear();
             
            if (daysOfWeek == null)
            {
                daysOfWeek = new string[8];
                daysOfWeek[(int)BaumaxDayOfWeek.Monday] = GetLocalized(BaumaxDayOfWeek.Monday.ToString());
                daysOfWeek[(int)BaumaxDayOfWeek.Tuesday] = GetLocalized(BaumaxDayOfWeek.Tuesday.ToString());
                daysOfWeek[(int)BaumaxDayOfWeek.Wednesday] = GetLocalized(BaumaxDayOfWeek.Wednesday.ToString());
                daysOfWeek[(int)BaumaxDayOfWeek.Thursday] = GetLocalized(BaumaxDayOfWeek.Thursday.ToString());
                daysOfWeek[(int)BaumaxDayOfWeek.Friday] = GetLocalized(BaumaxDayOfWeek.Friday.ToString());
                daysOfWeek[(int)BaumaxDayOfWeek.Saturday] = GetLocalized(BaumaxDayOfWeek.Saturday.ToString());
                daysOfWeek[(int)BaumaxDayOfWeek.Sunday] = GetLocalized(BaumaxDayOfWeek.Sunday.ToString());
            }
            if (EntityCountry != null)
            {
                List<CountryAdditionalHour> lst;
                for (short year = BeginDate; year <= EndDate; year ++)
                {
                    lst = ClientEnvironment.CountryService.CountryAdditionalHourService.GetCountryAdditionalHourFiltered(Country.ID, year);
                    if (lst != null && lst.Count != 0)
                        foreach (CountryAdditionalHour amount in lst)
                            ListOfUnavAddHours.Add(amount);
                }
                gridControl_UnAdHours.DataSource = ListOfUnavAddHours;
                UpdateBarButtons();
            }
        }

       public CountryAdditionalHour FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridView_UnAdHours.FocusedRowHandle);
            }
        }

        CountryAdditionalHour GetEntityByRowHandle(int rowHandle)
        {
            CountryAdditionalHour AvgWDinweek = null;
            if (gridView_UnAdHours.IsDataRow(rowHandle))
                AvgWDinweek = (CountryAdditionalHour)gridView_UnAdHours.GetRow(rowHandle);
            return AvgWDinweek;
        }

        private void NewEntity()
        {
            CountryAdditionalHour amount = ClientEnvironment.CountryAdditionalHourService.CreateEntity();
            amount.CountryID = EntityCountry.ID;
            using (FormUnavoidableAddHours form = new FormUnavoidableAddHours())
            {
                form.Amount = amount;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    gridControl_UnAdHours.DataSource = null;
                    InitControl();
                }
            }
        }

        private void DeleteEntity()
        {
            DeleteEntity(null);
        }

        private void DeleteEntity(CountryAdditionalHour entity)
        {
            CountryAdditionalHour am = entity;
            if (am == null && FocusedEntity == null) return;
            am = FocusedEntity;
            if (QuestionMessageYes(GetLocalized("QuestionRemoveCountryAdditionalHour")))
            {
                try
                {
                    ClientEnvironment.CountryAdditionalHourService.DeleteByID(am.ID);
                    ClientEnvironment.StoreService.DeleteCalculatedCountryAdditionalHours(am.Year, am.CountryID,
                                                                                          am.WeekDay);
                    CountryAdditionalHour removing = ListOfUnavAddHours.GetItemByID(am.ID);
                    if (removing != null)
                    {
                        ListOfUnavAddHours.Remove(removing);
                        UpdateBarButtons();
                    }
                }
                catch (ValidationException)
                {
                    ErrorMessage("CannotDeleteCountryAdditionalHour"); 
                    return;
                }
                catch (EntityException ex)
                {
                    ProcessEntityException(ex);
                    return;
                }
            }
        }

        public void EditEntity()
        {
            EditEntity(null);
        }
        
        public void EditEntity(CountryAdditionalHour amount)
        {
            CountryAdditionalHour am = amount;
            if (amount == null && FocusedEntity == null) return;

            if (am == null) am = FocusedEntity;
            if (am == null) return;

            using (FormUnavoidableAddHours form = new FormUnavoidableAddHours())
            {
                form.Amount = am;

                if (form.ShowDialog() == DialogResult.OK)
                    ListOfUnavAddHours.ResetItemById(am.ID);
                
            }
        }

       private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (ReadOnly) e.Cancel = true;
            if (!isUserWriteRight) return;
            if (FocusedEntity == null)
            {
                sm_EditUAAH.Enabled = false;
                sm_DeleteUAAH.Enabled = false;
            }
            else
            {
                sm_EditUAAH.Enabled = FocusedEntity.Year >= DateTime.Now.Year && !UCCountryEdit.IsEstimationExist(FocusedEntity.Year, Country.ID); 
                sm_DeleteUAAH.Enabled = sm_EditUAAH.Enabled;    
            }
            
            
            if (EntityCountry == null)
            {
                e.Cancel = true;
            }
        }
                
        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if(!isUserWriteRight) return;
            
            switch (e.KeyCode)
            {
                case Keys.Insert: NewEntity(); 
                    break;
                case Keys.Delete: if (FocusedEntity != null)
                        if (FocusedEntity.Year >= DateTime.Now.Year && !UCCountryEdit.IsEstimationExist(FocusedEntity.Year, Country.ID)) DeleteEntity(); 
                    break;
            }
        }

        private void GridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isUserWriteRight) return;
            
            GridHitInfo info = gridView_UnAdHours.CalcHitInfo(e.X, e.Y); 
            
            if (info.InRowCell && gridView_UnAdHours.IsDataRow(info.RowHandle))
            {
                CountryAdditionalHour amount = GetEntityByRowHandle(info.RowHandle);
                if (amount != null)
                    if (FocusedEntity.Year >= DateTime.Now.Year && !UCCountryEdit.IsEstimationExist(FocusedEntity.Year, Country.ID))
                        EditEntity(amount);
            }
        }

        private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            UpdateBarButtons();
        }

        private void contextmenuItemNew_Click(object sender, EventArgs e)
        {
            NewEntity();
        }

        private void contextmenuItemEdit_Click(object sender, EventArgs e)
        {
            if (FocusedEntity != null) EditEntity(null);
        }

        private void contextmenuItemDelete_Click(object sender, EventArgs e)
        {
            if (FocusedEntity != null)
                DeleteEntity();
        }

        private void bi_NewUAAH_Click(object sender, ItemClickEventArgs e)
        {
            NewEntity();
        }

        private void bi_EditUAAH_Click(object sender, ItemClickEventArgs e)
        {
            if (FocusedEntity != null) EditEntity(null);
        }

        private void bi_DeleteUAAH_Click(object sender, ItemClickEventArgs e)
        {
            if (FocusedEntity != null)
                DeleteEntity();
        }


        private void gridViewUnAdHours_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
          if (e.Column == gc_DayOfWeek)
            {
                if (e.IsGetData)
                {
                    int idx = e.ListSourceRowIndex;
                    if (idx >= 0 && idx < ListOfUnavAddHours.Count)
                    {
                        CountryAdditionalHour AdHours = ListOfUnavAddHours[e.ListSourceRowIndex];
                        e.Value = daysOfWeek[AdHours.WeekDay];
                    }
                } 
            }           
            
            if (e.Column == gc_StartTime)
            {
                if (e.IsGetData)
                {
                    int idx = e.ListSourceRowIndex;
                    if (idx >= 0 && idx < ListOfUnavAddHours.Count)
                    {
                        CountryAdditionalHour AdHours = ListOfUnavAddHours[e.ListSourceRowIndex];
                        e.Value = ConvertShortToDateTime(AdHours.BeginTime).ToShortTimeString();
                    }
                }
            }

            if (e.Column == gc_FinishTime)
            {
                if (e.IsGetData)
                {
                    int idx = e.ListSourceRowIndex;
                    if (idx >= 0 && idx < ListOfUnavAddHours.Count)
                    {
                        CountryAdditionalHour AdHours = ListOfUnavAddHours[e.ListSourceRowIndex];
                        e.Value = ConvertShortToDateTime(AdHours.EndTime).ToShortTimeString();
                    }
                }
            }
        }

        private void bi_calculate_click(object sender, ItemClickEventArgs e)
        {
            ClientEnvironment.StoreService.CalculateAdditionalHoursForAllTime();
        }
        
        private void filterApply()
        {
            if (BeginDate > EndDate)
                ErrorMessage(GetLocalized("ErrorDateRange"));
            else
            {
                gridControl_UnAdHours.DataSource = null;
                InitControl();    
            }
        }

        private void bt_Apply_Click(object sender, ItemClickEventArgs e)
        {
           filterApply(); 
        }

        private void seEnd_buttonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                EndDate = -1;
                filterApply();
            }
        }

        private void de_End_EditValueChanged(object sender, EventArgs e)
        {
            if (EndDate < BeginDate)
                EndDate = BeginDate;
        }
    }
}
