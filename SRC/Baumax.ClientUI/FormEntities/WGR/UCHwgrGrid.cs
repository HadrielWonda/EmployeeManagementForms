using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Environment;
using Baumax.Templates;
using Baumax.Domain;

namespace Baumax.ClientUI.FormEntities.WGR
{
    public delegate void ChangeFocusedEntity(BaseEntity entity);

    public partial class UCHwgrGrid : UCBaseEntity
    {
        public UCHwgrGrid()
        {
            InitializeComponent();
            _hwgrList = ClientEnvironment.HWGRService.FindAll();
            InitBindingList();
        }

        private List<Domain.HWGR> _hwgrList = null;
        private BindingTemplate<Domain.HWGR> _bindingEntities = null;

        public event ChangeFocusedEntity OnChangeFocusedEntity = null;

        private BaseEntity _focusedEntity = null;
        private void CheckFocusedEntityAndRaiseEvent()
        {
            BaseEntity entity = FocusedEntity;
            if (entity != _focusedEntity)
            {
                _focusedEntity = entity;
                FireChangeFocusedEntity(entity);
            }
        }
        private void FireChangeFocusedEntity(BaseEntity entity)
        {
            if (OnChangeFocusedEntity != null)
                OnChangeFocusedEntity(entity);
        }

        private Domain.HWGR GetEntityByRowHandle(int rowHandle)
        {
            Domain.HWGR entity = null;
            entity = (Domain.HWGR)gridViewHWGR.GetRow(rowHandle);
            return entity;
        }

        public Domain.HWGR FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewHWGR.FocusedRowHandle);
            }
        }

        public List<Domain.HWGR> HWGRList
        {
            get { return _hwgrList; }
            set
            {
                _hwgrList = value;
                InitBindingList();
            }
        }

        private void InitBindingList()
        {
            if (_bindingEntities == null) _bindingEntities =
                new BindingTemplate<Domain.HWGR>();
            if (_bindingEntities.Count > 0) _bindingEntities.Clear();

            if (_hwgrList != null)
            {
                _bindingEntities.CopyList(_hwgrList);
            }

            if (gridControl1.DataSource == null)
                gridControl1.DataSource = _bindingEntities;

        }

        private void cmsOpening(object sender, CancelEventArgs e)
        {
            /* decomment tomorrow
            Domain.HWGR hwgr = FocusedEntity;
            ts_DeleteHWGR.Enabled = hwgr != null;
            ts_EditHWGR.Enabled = hwgr != null;
             */
        }

        private void gvFocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CheckFocusedEntityAndRaiseEvent();
        }

        public void FireEditEntity(Domain.HWGR hwgr)
        {
            if (ReadOnly) return;
            Domain.HWGR entity = hwgr;
            if (entity == null) entity = FocusedEntity;
            if (entity != null)
            {
                FormHwgrAdd form = new FormHwgrAdd();
                form.HWGR = entity;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _bindingEntities.SetEntity(form.HWGR);
                }
            }
        }

        public void FireNewEntity()
        {
            if (ReadOnly) return;

            Domain.HWGR entity = new Domain.HWGR();
            FormHwgrAdd form = new FormHwgrAdd();
            form.HWGR = entity;
            if (form.ShowDialog() == DialogResult.OK)
            {
                _bindingEntities.Add(form.HWGR);
            }

        }

        public void FireDeleteEntity(Domain.HWGR hwgr)
        {
            if (ReadOnly) return;
            Domain.HWGR entity = hwgr;
            if (entity == null) entity = FocusedEntity;
            if (entity != null)
            {
                if (QuestionMessageYes(GetLocalized("Are you sure?")))
                {
                    try
                    {
                        ClientEnvironment.HWGRService.DeleteByID(entity.ID);
                        _bindingEntities.Remove(entity);
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage(ex.Message);
                    }

                }
            }
        }

        private void tsNewHWGRClick(object sender, EventArgs e)
        {
            FireNewEntity();
        }

        private void tsEditHWGRClick(object sender, EventArgs e)
        {
            Domain.HWGR entity = FocusedEntity;
            if (entity != null)
                FireEditEntity(entity);
        }

        private void tsDeleteHWGRClick(object sender, EventArgs e)
        {
            Domain.HWGR entity = FocusedEntity;
            if (entity != null)
                FireDeleteEntity(entity);
        }

        private void gvRowCountChanged(object sender, EventArgs e)
        {
            CheckFocusedEntityAndRaiseEvent();
        }

        private void gcKeyDown(object sender, KeyEventArgs e)
        {
            /* decomment tomorrow 
            if (e.KeyCode == Keys.Enter)
            {
                FireEditEntity(null);
            }
            else if (e.KeyCode == Keys.Insert)
            {
                FireNewEntity();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                FireDeleteEntity(null);
            }
             */
        }

        public override void Add()
        {
            FireNewEntity();
        }
        public override void Edit()
        {
            Domain.HWGR entity = FocusedEntity;
            if (entity != null)
                FireEditEntity(entity);
        }
        public override void Delete()
        {
            Domain.HWGR entity = FocusedEntity;
            if (entity != null)
                FireDeleteEntity(entity);
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
                LocalizerControl.ComponentsLocalize(this.components);
        }

        private void DoubleClick(object sender, MouseEventArgs e)
        {
            /* decomment tomorrow
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = gridViewHWGR.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewHWGR.IsDataRow(info.RowHandle))
            {
                Domain.HWGR entity = GetEntityByRowHandle(info.RowHandle);
                if (entity != null) FireEditEntity(entity);
            }
            */
        }
    }
 }
