using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class FeastEntityControl : UCBaseEntity
    {
        CountryFeastList _bindingFeasts = null;
        Dictionary<int, string> m_weekDays = new Dictionary<int, string>();
        private bool _listIsEmpty = true;


        public FeastEntityControl()
        {
            InitializeComponent();
            dateNavigator1.DateTime = DateTime.Today;
        }

        private Domain.Country  _country;

        public Domain.Country  Country
        {
            get { return _country; }
            set 
            { 
                _country = value;
                Bind();
            }
        }
        protected override void OnLoad(object sender, EventArgs e)
        {
            base.OnLoad(sender, e);
            if (Country != null)
                UpdateEnableButtonAdd();
        }
        public override void AssignLanguage()
        {
            if (ClientEnvironment.IsRuntimeMode)
            {
                base.AssignLanguage();
                LocalizerControl.ComponentsLocalize(components);
            }
        }
      
        public override bool Commit()
        {
            bool bResult = base.Commit();
           List<Feast> lst = DeleteExistingFeast(_bindingFeasts.GetNewItemList());
            if (lst.Count > 0)
            {
                try
                {
                   ClientEnvironment.CountryService.FeastService.SaveList(lst);
                    Modified = true;
                }
                catch (EntityException)
                {
                    // can't obtain more details while saving list
                    ErrorMessage(GetLocalized("SomeFeastsNotDeleted"));
                    bResult = false;
                }
            }
            return bResult;
        }

        List<Feast> DeleteExistingFeast(List<Feast> lst)
        {
            List<Feast> lstAll = ClientEnvironment.CountryService.FeastService.GetFeastsFiltered(Country.ID, null, null);
            CountryFeastList  lstFeast = new  CountryFeastList(Country.ID);
            lstFeast.CopyList(lstAll);

            for (int i = lst.Count - 1; i >= 0; i--)
            {
                if (lstFeast.IsExistsFeast(lst[i].FeastDate.ToString().Remove(10)))
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
                m_weekDays[(int)DayOfWeek.Sunday] = GetLocalized(DayOfWeek.Sunday.ToString ());
            }
            if (Country == null) return;

            _bindingFeasts = new CountryFeastList(Country.ID); 
            _bindingFeasts.Clear();
            gridControl1.DataSource = _bindingFeasts;
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == gc_DayOfWeek)
            {
                if (e.IsGetData)
                {
                    int idx = e.ListSourceRowIndex;
                    if (idx >= 0 && idx < _bindingFeasts.Count )
                    {
                        Feast feast = _bindingFeasts[e.ListSourceRowIndex];
                        e.Value = m_weekDays[(int)feast.FeastDate.DayOfWeek];
                    }
                }
            }
        }

        Feast GetEntityByRowHandle(int rowHandle)
        {
            Feast feast = null;
            if (gridView1.IsDataRow(rowHandle))
                feast = (Feast)gridView1.GetRow(rowHandle);
            return feast;

        }

        public Feast FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridView1.FocusedRowHandle);
            }
        }

        void UpdateEnableButtonDelete()
        {
            if (_bindingFeasts != null)
            {
                if (_bindingFeasts.Count != 0)
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
        
        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && FocusedEntity != null)
            {
                DeleteEntity();
            }
                
        }
        
        private bool DeleteEntityBySelectedRows()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i) && _bindingFeasts != null)
                {
                    _bindingFeasts.Remove(GetEntityByRowHandle(i));
                    return true;
                }
            }
            return false;
        }

        private void DeleteEntity()
        {
            if (FocusedEntity == null || _bindingFeasts == null) return;

            if (gridView1.SelectedRowsCount > 1)
            {
                if (QuestionMessageYes(GetLocalized("questiondeletefeast") + " (" + gridView1.SelectedRowsCount.ToString() + ")"))
                {
                    while (DeleteEntityBySelectedRows()) ;
                    UpdateEnableButtonDelete();
                }
            }
            else
            {
                if (QuestionMessageYes(GetLocalized("questiondeletefeast") + String.Format(" ({0})", FocusedEntity.FeastDate.ToString("d"))))
                {
                    _bindingFeasts.Remove(FocusedEntity);
                    UpdateEnableButtonDelete();
                }
            }
        }

        private void deleteFeastContextMenuStrip_Click(object sender, EventArgs e)
        {
            if (FocusedEntity != null) DeleteEntity();
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStripAddEntity.Enabled = FocusedEntity != null;
        }

        private void btAdd_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_bindingFeasts == null) return;

            for (int i = 0; i < dateNavigator1.Selection.Count; i++)
            {
               _bindingFeasts.AddWithChecking(dateNavigator1.Selection[i].Date);
            }
            UpdateEnableButtonDelete();
        }

        private void btn_DeleteFeast_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FocusedEntity != null) DeleteEntity();
        }
        
        private void UpdateEnableButtonAdd()
        {
            for (int i = 0; i < dateNavigator1.Selection.Count; i++)
            {
                if (dateNavigator1.Selection[i].Date < DateTime.Now.Date )//|| UCCountryEdit.IsEstimationExist(dateNavigator1.Selection[i], Country.ID)
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
                UpdateEnableButtonAdd();
        }

        public bool IsListEmpty
        {
            get { return _listIsEmpty; }
            set { _listIsEmpty = value; }
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

