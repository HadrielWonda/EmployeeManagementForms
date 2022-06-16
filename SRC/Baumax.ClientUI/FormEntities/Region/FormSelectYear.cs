using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Localization;
using DevExpress.XtraEditors;
using Baumax.Contract;

namespace Baumax.ClientUI.FormEntities.Region
{
    public partial class FormSelectYear : FormBaseEntity
    {
        Store _store = null;
        private BufferHours _entity;


        public FormSelectYear()
        {
            InitializeComponent();
            seYear.Value = DateTime.Today.Year;
        }

        public Store EntityStore
        {
            set
            {
                _store = value;

                if (_store != null)
                {
                    teStore.Text = _store.Name;
                }
            }
        }


        public BufferHours  Entity
        {
            get { return _entity; }
            set 
            {
                if (_entity != value)
                {
                    _entity = value;
                    ChangedEntity();
                }
            }
        }

        private void ChangedEntity()
        {
            if (Entity != null)
            {
                StoreWorldId = Entity.StoreWorldID;
                Year = Entity.Year;
                Value = Entity.Value;
            }
        }

        public void SetStoreWorlds(List<StoreToWorld> lst)
        {
            lookUpWorlds.Properties.DataSource = lst;

            if (lst != null && lst.Count > 0)
            {
                lookUpWorlds.EditValue = lst[0].ID;
            }
        }

        #region BufferHour Properties

        public long StoreWorldId
        {
            get 
            {
                if (lookUpWorlds.EditValue == null) return -1;
                return Convert.ToInt64(lookUpWorlds.EditValue);
            }
            set 
            {
                lookUpWorlds.EditValue = value; 
            }
        }
        public short Year
        {
            get 
            {
                return Convert.ToInt16(seYear.Value);
            }
            set 
            {
                seYear.Value = value; 
            }
        }
        public double Value
        {
            get 
            {
                return Convert.ToDouble(seBufferHours.Value); 
            }
            set 
            { 
                seBufferHours.Value = Convert.ToDecimal (value); 
            }
        }

        #endregion

        public void SetReadOnly()
        {
            lookUpWorlds.Properties.ReadOnly = true;
            seYear.Properties.ReadOnly = true;
            lookUpWorlds.Enabled = false;
            seYear.Enabled = false;
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool CheckExistStoreWorldID(long _StoreWorldID, List<BufferHours> _cols)
        {
           if (_cols == null) return false;
            foreach (BufferHours _col in _cols)
                if (_col.StoreWorldID == _StoreWorldID) return true;
            return false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (StoreWorldId != -1)
            {
                if (Entity == null)
                {
                    BufferHours bh = new BufferHours();
                    bh.StoreWorldID = StoreWorldId;
                    bh.Year = Year;
                    bh.Value = Value;
                    bh.ValueWeek = BufferHours.GetWeekStepValue(bh);// Value / DateTimeHelper.GetCountWeekInYear(Year);
                    try
                    {
                       List<BufferHours> cols = ClientEnvironment.StoreService.BufferHoursService.GetBufferHoursFiltered(_store.ID, Year, Year);
                        if (cols == null || cols.Count == 0 || !CheckExistStoreWorldID(bh.StoreWorldID, cols))
                        {
                            bh = ClientEnvironment.StoreService.BufferHoursService.ValidateAndUpdate(bh);

                            if (bh != null)
                            {
                                StoreToWorld sw = (StoreToWorld)lookUpWorlds.Properties.GetDataSourceRowByKeyValue(StoreWorldId);

                                if (sw != null) bh.WorldName = sw.WorldName;
                                _entity = bh;

                                DialogResult = DialogResult.OK;
                            }
                            else
                                throw new DBDuplicateKeyException();
                        }
                        else throw new DBDuplicateKeyException();
                        
                    }
                    catch (DBDuplicateKeyException)
                    {
                        XtraMessageBox.Show(UILocalizer.Current["WorldYearBufferHoursExist"], 
                            UILocalizer.Current["Attention"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                        seYear.Focus();
                        return;
                    }
                }
                else
                {
                    BufferHours bh = new BufferHours();
                    bh.ID = Entity.ID;
                    bh.StoreWorldID = StoreWorldId;
                    bh.Year = Year;
                    bh.Value = Value;
                    bh.ValueWeek = BufferHours.GetWeekStepValue(bh);// Value / DateTimeHelper.GetCountWeekInYear(Year);
                    try
                    {
                        bh = ClientEnvironment.StoreService.BufferHoursService.ValidateAndUpdate(bh);

                        Entity.ID = bh.ID;
                        Entity.StoreWorldID = StoreWorldId;
                        Entity.Year = Year;
                        Entity.Value = Value;
                        Entity.ValueWeek = BufferHours.GetWeekStepValue (bh);
                        DialogResult = DialogResult.OK;
                    }
                    catch (ValidationException)
                    {
                        XtraMessageBox.Show(UILocalizer.Current["WorldYearBufferHoursExist"],
                                                    UILocalizer.Current["Attention"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    catch (EntityException)
                    {

                        XtraMessageBox.Show(UILocalizer.Current["BufferHoursNotExist"],
                            UILocalizer.Current["Attention"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(UILocalizer.Current["ErrorSelectWorld"]);
            }
        }
    }
}