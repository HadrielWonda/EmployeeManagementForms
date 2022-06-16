using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Templates;
using Baumax.Domain;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.WGR
{
    public partial class UCWgrGrid : UCBaseEntity
    {
        public UCWgrGrid()
        {
            InitializeComponent();
            _wgrList = ClientEnvironment.WGRService.FindAll();
            InitBindingList();
        }

        private List<Domain.WGR> _wgrList = null;
        private BindingTemplate<Domain.WGR> _bindingEntities = null;


        public delegate void ChangeFocusedEntity(BaseEntity entity);

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

        private Domain.WGR GetEntityByRowHandle(int rowHandle)
        {
            Domain.WGR entity = null;
            entity = (Domain.WGR)gridViewWGR.GetRow(rowHandle);
            return entity;
        }

        public Domain.WGR FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewWGR.FocusedRowHandle);
            }
        }

        public List<Domain.WGR> WGRList
        {
            get { return _wgrList; }
            set
            {
                _wgrList = value;
                InitBindingList();
            }
        }

        private void InitBindingList()
        {
            if (_bindingEntities == null) _bindingEntities = 
                new BindingTemplate<Domain.WGR>();
            if (_bindingEntities.Count > 0) _bindingEntities.Clear();
            
            if (_wgrList != null)
            {
                _bindingEntities.CopyList(_wgrList);
            }

            if (gridControlWGR.DataSource == null)
                gridControlWGR.DataSource = _bindingEntities;

        }

        private void cmsOpening(object sender, CancelEventArgs e)
        {
            Domain.WGR wgr = FocusedEntity;
            ts_DeleteWGR.Enabled = wgr != null;
            ts_EditWGR.Enabled = wgr != null;
        }

        private void gvFocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CheckFocusedEntityAndRaiseEvent();
        }

        public void FireEditEntity(Domain.WGR wgr)
        {
            if (ReadOnly) return;
            Domain.WGR entity = wgr;
            if (entity == null) entity = FocusedEntity;
            if (entity != null)
            {
                FormWgrAdd formWGR = new FormWgrAdd();
                formWGR.WGR = entity;
                if (formWGR.ShowDialog() == DialogResult.OK)
                {
                    _bindingEntities.SetEntity (formWGR.WGR);
                }
            }
        }

        public void FireNewEntity()
        {
            if (ReadOnly) return;

            Domain.WGR entity = new Domain.WGR();
            FormWgrAdd formWGR = new FormWgrAdd();
            formWGR.WGR = entity;
            if (formWGR.ShowDialog() == DialogResult.OK)
            {
                _bindingEntities.Add (formWGR.WGR);
            }

        }

        public void FireDeleteEntity(Domain.WGR wgr)
        {
            if (ReadOnly) return;
            Domain.WGR entity = wgr;
            if (entity == null) entity = FocusedEntity;
            if (entity != null)
            {
                if (QuestionMessageYes(GetLocalized("Are you sure?")))
                {
                    try
                    {
                        ClientEnvironment.WGRService.DeleteByID(entity.ID);
                        _bindingEntities.Remove(entity);
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage(ex.Message);
                    }

                }
            }
        }

        private void tsNewWGRClick(object sender, EventArgs e)
        {
            FireNewEntity();
        }

        private void tsEditWGRClick(object sender, EventArgs e)
        {
            Domain.WGR entity = FocusedEntity;
            if (entity != null)
                FireEditEntity(entity);
        }

        private void tsDeleteWGRClick(object sender, EventArgs e)
        {
            Domain.WGR entity = FocusedEntity;
            if (entity != null)
                FireDeleteEntity(entity);
        }

        private void gvRowCountChanged(object sender, EventArgs e)
        {
            CheckFocusedEntityAndRaiseEvent();
        }

        private void gcKeyDown(object sender, KeyEventArgs e)
        {
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
        }

        public override void Add()
        {
            FireNewEntity();
        }
        public override void Edit()
        {
            Domain.WGR entity = FocusedEntity;
            if (entity != null)
                FireEditEntity(entity);
        }
        public override void Delete()
        {
            Domain.WGR entity = FocusedEntity;
            if (entity != null)
                FireDeleteEntity(entity);
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
                LocalizerControl.ComponentsLocalize(this.components);
        }

        private void DoubliClick(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridViewWGR.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewWGR.IsDataRow(info.RowHandle))
            {
                Domain.WGR entity = GetEntityByRowHandle(info.RowHandle);
                if (entity != null) FireEditEntity(entity);
            }
        }

    }
}
