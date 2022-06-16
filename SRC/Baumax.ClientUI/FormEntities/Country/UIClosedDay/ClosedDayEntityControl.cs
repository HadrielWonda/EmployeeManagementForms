using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class ClosedDayEntityControl : UCBaseEntity
    {
        ClosedDayList _bindingClosedDay = null;
        Dictionary<int, string> m_weekDays = new Dictionary<int, string>();

        public ClosedDayEntityControl()
        {
            InitializeComponent();
            dateNavigatorClosedDay.DateTime = DateTime.Today;
        }
        
        private Domain.Country  _country;
        private bool _listIsEmpty = true;

        public Domain.Country  Country
        {
            get { return _country; }
            set 
            { 
                _country = value;
                Bind(); 
            }
        }
        
        public override void AssignLanguage()
        {
            if (ClientEnvironment.IsRuntimeMode)
            {
                base.AssignLanguage();
                LocalizerControl.ComponentsLocalize(components);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Country != null)
                updateEnableButtonNew();
        }
        public override bool Commit()
        {
            bool bResult = base.Commit();
            List<YearlyWorkingDay> lst = DeleteExistingWorkingDay(_bindingClosedDay.GetNewItemList());
            if (lst.Count > 0)
            {
                try
                {
                    ClientEnvironment.CountryService.YearlyWorkingDayService.SaveList(lst);
                    Modified = true;
                }
                catch (EntityException)
                {
                    ErrorMessage(GetLocalized("ErrorSaveYearlyClosedDay"));
                    bResult = false;
                }
            }
            return bResult;
        }

        List<YearlyWorkingDay> DeleteExistingWorkingDay(List<YearlyWorkingDay> lst)
        {
            List<YearlyWorkingDay> lstAll =
                ClientEnvironment.CountryService.YearlyWorkingDayService.GetYearlyWorkingDaysFiltered(Country.ID, null, null);
            ClosedDayList lstWorkingDayAll = new ClosedDayList(Country.ID);
            lstWorkingDayAll.CopyList(lstAll);

            for (int i = lst.Count - 1; i >= 0; i--)
            {
                if ( lstWorkingDayAll.IsExistsYearlyWorkingDay(lst[i].WorkingDay.ToString().Remove(10)) )
                {
                    lst.RemoveAt(i);
                }

            }
            return lst;
        }

        public override void Bind()
        {
            base.Bind();
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
           if (Country == null) return;
           _bindingClosedDay = new ClosedDayList(Country.ID);
           _bindingClosedDay.Clear();
           gridControl1.DataSource = _bindingClosedDay;
        }
       
        private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == gc_DayOfWeek)
            {
                if (e.IsGetData)
                {
                    int idx = e.ListSourceRowIndex;
                    if (idx >= 0 && idx < _bindingClosedDay.Count)
                    {
                        YearlyWorkingDay wday = _bindingClosedDay[e.ListSourceRowIndex];
                        e.Value = m_weekDays[(int)wday.WorkingDay.DayOfWeek];
                    }
                }
            }
        }

        public YearlyWorkingDay FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridView1.FocusedRowHandle);
            }
        }

        public bool IsListEmpty
        {
            get { return _listIsEmpty; }
            set { _listIsEmpty = value; }
        }

        YearlyWorkingDay GetEntityByRowHandle(int rowHandle)
        {
            YearlyWorkingDay WorkingDay = null;
            if (gridView1.IsDataRow(rowHandle))
                WorkingDay = (YearlyWorkingDay) gridView1.GetRow(rowHandle);
            return WorkingDay;

        }
        
        void UpdateEnableButtonDelete()
        {
            if (_bindingClosedDay != null)
            {
                if (_bindingClosedDay.Count != 0)
                {
                    btn_Delete.Enabled = true;
                    IsListEmpty = false;
                }
                else
                {
                    btn_Delete.Enabled = false;
                    IsListEmpty = true;
                }
            }
        }
       
        private bool DeleteEntityBySelectedRows()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i) && _bindingClosedDay != null)
                {
                    _bindingClosedDay.Remove(GetEntityByRowHandle(i));
                    return true;
                }
            }
            return false;
        }
        
        private void DeleteEntity()
        {
            if (FocusedEntity == null || _bindingClosedDay == null) return;
            
            if (gridView1.SelectedRowsCount > 1)
            {
                if (QuestionMessageYes(GetLocalized("SureToRemoveClosedDay") + " (" + gridView1.SelectedRowsCount.ToString() + ")"))
                {
                   while (DeleteEntityBySelectedRows()) ;
                    UpdateEnableButtonDelete();
                }
            }
            else
            {
                if (QuestionMessageYes(GetLocalized("SureToRemoveClosedDay") + String.Format(" ({0})", FocusedEntity.WorkingDay.ToString("d"))))
                {
                    _bindingClosedDay.Remove(FocusedEntity);   
                     UpdateEnableButtonDelete(); 
                }
            }
        }

        private void MenuStripItem_DeleteClosedDays_Click(object sender, EventArgs e)
        {
           DeleteEntity();
        }

        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStrip_AddEntity.Enabled = FocusedEntity != null;
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteEntity();
        }

        private void btnAddClosedDays_Click(object sender, ItemClickEventArgs e)
        {
             if (_bindingClosedDay == null) return;
            
            for (int i = 0; i < dateNavigatorClosedDay.Selection.Count; i++)
            {
                _bindingClosedDay.AddWithChecking(dateNavigatorClosedDay.Selection[i].Date);
            }
            UpdateEnableButtonDelete();
        }

       private void btnDelete_Click(object sender, ItemClickEventArgs e)
        {
           DeleteEntity();
        }

        private void updateEnableButtonNew()
        {
            for (int i = 0; i < dateNavigatorClosedDay.Selection.Count; i++)
            {
                if (dateNavigatorClosedDay.Selection[i].Date < DateTime.Now.Date || UCCountryEdit.IsEstimationExist(dateNavigatorClosedDay.Selection[i], Country.ID))
                {
                    btn_Add.Enabled = false;
                    return;
                }
            }
            btn_Add.Enabled = true;
        }
        
        private void dateNavigator_EditDateModified(object sender, EventArgs e)
        {
            if (Country != null)
                updateEnableButtonNew();
        }

        public override bool IsValid()
        {
            if (IsListEmpty)
                return false;
            else 
                return base.IsValid();
        }
    }
}