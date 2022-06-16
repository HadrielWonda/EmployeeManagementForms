using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class UCAvgWorkingDaysInWeek : UCBaseEntity
    {
        BindingTemplate<AvgWorkingDaysInWeek> ListOfAvgWDInWeek = new BindingTemplate<AvgWorkingDaysInWeek>();
        List<AvgWorkingDaysInWeek> _listAmounts = null;
        bool isUserWriteRight = UCCountryEdit.isUserWriteRight();
        
        public UCAvgWorkingDaysInWeek()
        {
            InitializeComponent();
            if (!isUserWriteRight) gridControlAvgWDiWeek.ContextMenuStrip = null;
        }

        public override void AssignLanguage()
        {
            if (ClientEnvironment.IsRuntimeMode)
            {
                base.AssignLanguage();
                LocalizerControl.ComponentsLocalize(components);
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

        private void InitTollBar()
        {
            barTools.ClearLinks();
            if (isUserWriteRight)
            {
                barTools.ItemLinks.Add(bi_NewAverageDaysInWeek);
                barTools.ItemLinks.Add(bi_EditAverageDaysInWeek);
                barTools.ItemLinks.Add(bi_DeleteAverageDaysInWeek);    
            }
            else
            {
                barTools.Visible = false; 
                contextMenuStripAvgWDInWeek.Enabled = false;
            }
               
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitTollBar();
            UpdateBarButtons();
        }
        
        protected override void EntityChanged()
        {
           InitControl(null);
           UpdateBarButtons();
        }
        
        protected void UpdateBarButtons()
        {
            if (bi_DeleteAverageDaysInWeek != null)
            {
                if (FocusedEntity == null)
                {
                    bi_EditAverageDaysInWeek.Enabled = false;
                    bi_DeleteAverageDaysInWeek.Enabled = false;
                }
                else
                {
                    bi_DeleteAverageDaysInWeek.Enabled = (FocusedEntity.Year > DateTime.Now.Year || (!isAliquoteAbsence() && FocusedEntity.Year == DateTime.Now.Year));
                    bi_EditAverageDaysInWeek.Enabled = bi_DeleteAverageDaysInWeek.Enabled;   
                }
                
            }
            
            //set focuse by row with now dateTime
            if (FocusedEntity != null)
            {
                if(FocusedEntity.Year != DateTime.Today.Year)
                {
                    for (int i = 0; i < gridViewAvgWDiWeek.RowCount; i++)
                    {
                        if (GetEntityByRowHandle(i).Year == DateTime.Now.Year)
                        {
                            gridViewAvgWDiWeek.FocusedRowHandle = i;
                            return;
                        }
                    }
                }
            }
        }
        
         void Clear()
        {
            if (ListOfAvgWDInWeek == null) ListOfAvgWDInWeek = new BindingTemplate<AvgWorkingDaysInWeek>();
            ListOfAvgWDInWeek.Clear();
            if (_listAmounts != null)
                _listAmounts.Clear();

             gridControlAvgWDiWeek.DataSource = null;
        }
        
        public void InitControl(List<AvgWorkingDaysInWeek> lst)
        {
            Clear();
            if (EntityCountry != null)
            {
                _listAmounts = lst;
                if (_listAmounts == null)
                    _listAmounts = ClientEnvironment.CountryService.AvgWorkingDaysInWeekService.GetAvgWorkingDaysInWeekFiltered(Country.ID, null, null);
                
                if (_listAmounts != null)
                {
                    foreach (AvgWorkingDaysInWeek amount in _listAmounts)
                    {
                        ListOfAvgWDInWeek.Add(amount);
                    }
                }

                gridControlAvgWDiWeek.DataSource = ListOfAvgWDInWeek;
                
                gc_AverageWorkingDayInWeek.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gc_AverageWorkingDayInWeek.DisplayFormat.FormatString = "n1";
                
                UpdateBarButtons();
            }

        }

        public Domain.Country EntityCountry
        {
            get { return (Domain.Country)Entity; }
            set
            {
                Entity = value;
            }
        }

        public AvgWorkingDaysInWeek FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewAvgWDiWeek.FocusedRowHandle);
            }
        }

        AvgWorkingDaysInWeek GetEntityByRowHandle(int rowHandle)
        {
            AvgWorkingDaysInWeek AvgWDinweek = null;
            if (gridViewAvgWDiWeek.IsDataRow(rowHandle))
                AvgWDinweek = (AvgWorkingDaysInWeek)gridViewAvgWDiWeek.GetRow(rowHandle);
            return AvgWDinweek;
        }

         void NewEntity()
        {
            AvgWorkingDaysInWeek amount = ClientEnvironment.AvgWorkingDaysInWeekService.CreateEntity();

            amount.CountryID = EntityCountry.ID;
            using (AvgWorkingDaysInWeekForm form = new AvgWorkingDaysInWeekForm())
            {
                form.Amount = amount;

                if (form.ShowDialog() == DialogResult.OK)
                {
                        ListOfAvgWDInWeek.Add(form.Amount);
                        UpdateBarButtons();   
                }
            }
        }

         void DeleteEntity()
        {
            DeleteEntity(null);
        }

         void DeleteEntity(AvgWorkingDaysInWeek entity)
        {
            AvgWorkingDaysInWeek am = entity;
            if (am == null && FocusedEntity == null) return;
            am = FocusedEntity;

            if (QuestionMessageYes(GetLocalized("QuestionRemoveEverageDaysInweek") + String.Format(" ({0})", am.Year)))
            {
                try
                {
                    ClientEnvironment.AvgWorkingDaysInWeekService.DeleteByID(am.ID);
                    AvgWorkingDaysInWeek removing = ListOfAvgWDInWeek.GetItemByID(am.ID);
                    if (removing != null)
                    {
                        ListOfAvgWDInWeek.Remove(removing);
                        UpdateBarButtons();
                    }
                }
                catch (ValidationException)
                {
                    ErrorMessage("CannotDeleteAverageDaysInWeek");
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
        
        public void EditEntity(AvgWorkingDaysInWeek amount)
        {
            AvgWorkingDaysInWeek am = amount;
            if (amount == null && FocusedEntity == null) return;

            if (am == null) am = FocusedEntity;
            if (am == null) return;// paranoik check

            using (AvgWorkingDaysInWeekForm form = new AvgWorkingDaysInWeekForm())
            {
                form.Amount = am;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    ListOfAvgWDInWeek.ResetItemById(am.ID);
                }
            }
        }

        private void bi_NewAvgWorkingDaysInWeek_ItemClick(object sender, ItemClickEventArgs e)
        {
            NewEntity();
        }

        private void bi_EditAvgWorkingDaysInWeek_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FocusedEntity != null) EditEntity(null);
        }

        private void bi_DeleteAvgWorkingDaysInWeek_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FocusedEntity != null)
                DeleteEntity();
        }

        private void contextMenuStripAvgWDInWeek_Opening(object sender, CancelEventArgs e)
        {
            if (ReadOnly) e.Cancel = true;
            if (!isUserWriteRight) return;
            if (FocusedEntity == null)
            {
                toolStripMenuItem_EditAverageDaysInWeek.Enabled = false;
                toolStripMenuItem_DeleteAverageDaysInWeek.Enabled = false;
            }
            else
            {
                toolStripMenuItem_EditAverageDaysInWeek.Enabled = (FocusedEntity.Year > DateTime.Now.Year || (!isAliquoteAbsence() && FocusedEntity.Year == DateTime.Now.Year));
                toolStripMenuItem_DeleteAverageDaysInWeek.Enabled = toolStripMenuItem_EditAverageDaysInWeek.Enabled;    
            }
            
            
            if (EntityCountry == null)
            {
                e.Cancel = true;
            }
        }

        private void NewAvgWDInWeekTollMenuStrip_Click(object sender, EventArgs e)
        {
            NewEntity();
        }

        private void EditAvgWDInWeekTollMenuStrip_Click(object sender, EventArgs e)
        {
            if (FocusedEntity != null) EditEntity(FocusedEntity);
        }

        private void DeleteAvgWDInWeekTollMenuStrip_Click(object sender, EventArgs e)
        {
            if (FocusedEntity != null)
                DeleteEntity();
        }

        private void gridViewAvgWDInWeek_KeyDown(object sender, KeyEventArgs e)
        {
            if(!isUserWriteRight) return;
            
            switch (e.KeyCode)
            {
                case Keys.Insert: NewEntity(); 
                    break;
                case Keys.Delete: if (FocusedEntity != null)
                        if (FocusedEntity.Year > DateTime.Now.Year || (!isAliquoteAbsence() && FocusedEntity.Year == DateTime.Now.Year))  DeleteEntity(); 
                    break;
            }
        }

        private void GridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isUserWriteRight) return;
            
            GridHitInfo info = gridViewAvgWDiWeek.CalcHitInfo(e.X, e.Y); 
            
            if (info.InRowCell && gridViewAvgWDiWeek.IsDataRow(info.RowHandle))
            {
                AvgWorkingDaysInWeek amount = GetEntityByRowHandle(info.RowHandle);
                if (amount != null)
                    if (FocusedEntity.Year > DateTime.Now.Year || (!isAliquoteAbsence() && FocusedEntity.Year == DateTime.Now.Year))
                        EditEntity(amount);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedEntity != null)
            {
                bi_DeleteAverageDaysInWeek.Enabled = (FocusedEntity.Year > DateTime.Now.Year ||
                                                      (!isAliquoteAbsence() && FocusedEntity.Year == DateTime.Now.Year));
                bi_EditAverageDaysInWeek.Enabled = bi_DeleteAverageDaysInWeek.Enabled;
            }
        }
        
        bool isAliquoteAbsence()
        {
           List <Absence> _absence = ClientEnvironment.AbsenceService.GetCountryAbsences(Country.ID);
            if (_absence == null || _absence.Count == 0) return false;
            else
            {
                foreach (Absence abs in _absence)
                {
                    if (abs.IsFixed) return true;
                }
            }
                return false;
        }
    }
}
