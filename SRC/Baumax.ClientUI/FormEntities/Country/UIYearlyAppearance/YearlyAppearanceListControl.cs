using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class YearlyAppearanceListControl : UCBaseEntity
    {
        BindingTemplate<AvgAmount> _bindingWeeks = null;
        List<AvgAmount> _listAmounts = null;
        bool isUserWriteRight = UCCountryEdit.isUserWriteRight();

        public YearlyAppearanceListControl()
        {
           InitializeComponent();
            if (!isUserWriteRight) gridControl.ContextMenuStrip = null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitToolBar();
        }
        
        void UpdateButtonEnable()
        {
            if (FocusedEntity == null)
            {
                bi_EditYearlyAppearance.Enabled =
                bi_DeleteYearlyAppearance.Enabled = false;
            }
                
            else
                {
                    bi_EditYearlyAppearance.Enabled = FocusedEntity.Year >= DateTime.Now.Year && !UCCountryEdit.IsEstimationExist(FocusedEntity.Year, EntityCountry.ID);
                    bi_DeleteYearlyAppearance.Enabled = bi_EditYearlyAppearance.Enabled;
                }
            
                //set focuse by row with now dateTime
            if (FocusedEntity != null)
                if (FocusedEntity.Year != DateTime.Today.Year)
                    for (int i = 0; i < gridViewYearly.RowCount; i++)
                    {
                        if (GetEntityByRowHandle(i).Year == DateTime.Now.Year)
                        {
                            gridViewYearly.FocusedRowHandle = i;
                            return;
                        }
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

        public Domain.Country EntityCountry
        {
            get { return (Domain.Country)Entity; }
            set 
            {
                Entity = value;
            }
        }

        protected override void EntityChanged()
        {
            InitControl(null);
            UpdateButtonEnable();
        }

        AvgAmount GetEntityByRowHandle(int rowHandle)
        {
            AvgAmount entity = null;
            if (gridViewYearly.IsDataRow(rowHandle))
                entity = (AvgAmount)gridViewYearly.GetRow(rowHandle);
            return entity;
        }
        
        public AvgAmount FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewYearly.FocusedRowHandle);
            }
        }
         
       void InitToolBar()
       {
           bar_tools.ClearLinks();
           if (isUserWriteRight)
           {
           bar_tools.ItemLinks.Add(bi_NewYearlyAppearance);
           bar_tools.ItemLinks.Add(bi_EditYearlyAppearance);
           bar_tools.ItemLinks.Add(bi_DeleteYearlyAppearance);
           }
           else
           {
               bar_tools.Visible = false;
               contextMenuStripYearly.Enabled = false;
           }
           
           UpdateButtonEnable();
       }

        void Clear()
        {
            if (_bindingWeeks == null) _bindingWeeks = new BindingTemplate<AvgAmount>();
            _bindingWeeks.Clear();
            if (_listAmounts != null)
                _listAmounts.Clear();

            gridControl.DataSource = null;
        }
        
        public void InitControl(List<AvgAmount> lst)
        {
            Clear();

            if (EntityCountry != null)
            {
                _listAmounts = lst;
                if (_listAmounts == null)
                {
                    _listAmounts = ClientEnvironment.AvgAmountService.GetCountryAvgAmounts(EntityCountry.ID);
                }

                if (_listAmounts != null)
                {
                    foreach (AvgAmount amount in _listAmounts)
                    {
                        _bindingWeeks.Add(amount);
                    }
                }

                gridControl.DataSource = _bindingWeeks;
            }

        }

        public void NewEntity()
        {
            AvgAmount amount = ClientEnvironment.AvgAmountService.CreateEntity();

            amount.CountryID = EntityCountry.ID;
                
            using (YearlyAppearanceForm form = new YearlyAppearanceForm())
            {
                form.Amount = amount;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _bindingWeeks.Add(form.Amount);
                    UpdateButtonEnable();
                }
            }
        }
        
        public void EditEntity()
        {
            EditEntity(null);
        }
        
        public void EditEntity(AvgAmount amount)
        {
            AvgAmount am = amount;
            if (amount == null && FocusedEntity == null) return;

            if (am == null) am = FocusedEntity;
            if (am == null) return;// paranoik check

            using (YearlyAppearanceForm form = new YearlyAppearanceForm())
            {
                form.Amount = am;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _bindingWeeks.ResetItemById (am.ID);
                }
            }
        }
        public void DeleteEntity()
        {
            DeleteEntity(null);
        }

        public void DeleteEntity(AvgAmount amount)
        {
            AvgAmount am = amount;
            if (am == null && FocusedEntity == null) return;
            am = FocusedEntity;

            if (QuestionMessageYes(GetLocalized("SureToRemoveYearAppearance") + String.Format(" ({0})", am.Year)))
            {
                try
                {
                    ClientEnvironment.CountryService.AvgAmountService.DeleteByID(am.ID);

                    AvgAmount removing = _bindingWeeks.GetItemByID(am.ID);
                    if (removing != null)
                    {
                        _bindingWeeks.Remove(removing);
                        UpdateButtonEnable();
                    }
                }
                catch(ValidationException)
                {
                    ErrorMessage("CantDeleteYearlyAppearance");
                    return;
                }
                catch (EntityException ex)
                {
                    ProcessEntityException(ex);
                    return;
                }
            }


        }

        private void newYearlyAppearanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewEntity();
        }

        private void editYearlyAppearanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FocusedEntity != null)
                EditEntity(FocusedEntity);
        }

        private void deleteYearlyAppearanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FocusedEntity != null)
                DeleteEntity(FocusedEntity);
        }

        private void contextMenuStripYearly_Opening(object sender, CancelEventArgs e)
        {
            if (ReadOnly) e.Cancel = true;

            toolStripMenuItem_editYearlyAppearance.Enabled =
                toolStripMenuItem_deleteYearlyAppearance.Enabled = bi_EditYearlyAppearance.Enabled;

            if (EntityCountry == null)
            {
                e.Cancel = true;
            }
        }

        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isUserWriteRight) return;
            GridHitInfo info = gridViewYearly.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewYearly.IsDataRow(info.RowHandle))
            {
                AvgAmount amount = GetEntityByRowHandle(info.RowHandle);
                if (amount != null && bi_EditYearlyAppearance.Enabled) EditEntity(amount);
            }
        }

        private void bi_NewYearlyAppearance_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewEntity();
        }

        private void bi_EditYearlyAppearance_click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FocusedEntity != null) EditEntity(FocusedEntity);
        }

        private void bi_DeleteYearlyAppearance_click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FocusedEntity != null) DeleteEntity(FocusedEntity);
        }

        private void gridViewYearly_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isUserWriteRight) return;
            
            switch(e.KeyCode)
            {
                case Keys.Insert: NewEntity(); 
                    break;
                case Keys.Delete:
                    if (FocusedEntity != null && bi_DeleteYearlyAppearance.Enabled) DeleteEntity();
                    break;
            }
             
        }

        private void gridViewYearly_focusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedEntity != null)
            {
                bi_EditYearlyAppearance.Enabled = FocusedEntity.Year >= DateTime.Now.Year && !UCCountryEdit.IsEstimationExist(FocusedEntity.Year, EntityCountry.ID);
                bi_DeleteYearlyAppearance.Enabled = bi_EditYearlyAppearance.Enabled;
            }
            
        }

    }
}

