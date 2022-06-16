using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Environment;
using Baumax.Domain;
using Baumax.Templates;

namespace Baumax.ClientUI.FormEntities.WGR
{
    public partial class UCWorldGrid : UCBaseEntity
    {
        public UCWorldGrid()
        {
            InitializeComponent();
            _worldList = ClientEnvironment.WorldService.FindAll();
            InitBindingList();
        }

        private List<Domain.World> _worldList = null;
        private BindingTemplate<Domain.World> _bindingEntities = null;


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

        private Domain.World GetEntityByRowHandle(int rowHandle)
        {
            Domain.World entity = null;
            entity = (Domain.World)gridViewWorld.GetRow(rowHandle);
            return entity;
        }

        public Domain.World FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewWorld.FocusedRowHandle);
            }
        }

        public List<Domain.World> WorldList
        {
            get { return _worldList; }
            set
            {
                _worldList = value;
                InitBindingList();
            }
        }

        private void InitBindingList()
        {
            if (_bindingEntities == null) _bindingEntities = 
                new BindingTemplate<Domain.World>();
            if (_bindingEntities.Count > 0) _bindingEntities.Clear();

            if (_worldList != null)
            {
                _bindingEntities.CopyList(_worldList);
            }

            if (gridControl1.DataSource == null)
                gridControl1.DataSource = _bindingEntities;

        }

        private void cmsOpening(object sender, CancelEventArgs e)
        {
            Domain.World world = FocusedEntity;
            ts_DeleteWorld.Enabled = world != null;
            ts_EditWorld.Enabled = world != null;
        }

        private void gvFocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CheckFocusedEntityAndRaiseEvent();
        }

        public void FireEditEntity(Domain.World world)
        {
            if (ReadOnly) return;
            Domain.World entity = world;
            if (entity == null) entity = FocusedEntity;
            if (entity != null)
            {
                FormWorldAdd form = new FormWorldAdd();
                form.World = entity;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _bindingEntities.SetEntity (form.World);
                }
            }
        }

        public void FireNewEntity()
        {
            if (ReadOnly) return;

            Domain.World entity = new Domain.World();
            FormWorldAdd form = new FormWorldAdd();
            form.World = entity;
            if (form.ShowDialog() == DialogResult.OK)
            {
                _bindingEntities.Add (form.World);
            }

        }

        public void FireDeleteEntity(Domain.World world)
        {
            if (ReadOnly) return;
            Domain.World entity = world;
            if (entity == null) entity = FocusedEntity;
            if (entity != null)
            {
                if (QuestionMessageYes(GetLocalized("Are you sure?")))
                {
                    try
                    {
                        ClientEnvironment.WorldService.DeleteByID(entity.ID);
                        _bindingEntities.Remove(entity);
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage(ex.Message);
                    }

                }
            }
        }

        private void tsNewWorldClick(object sender, EventArgs e)
        {
            FireNewEntity();
        }

        private void tsEditWorldClick(object sender, EventArgs e)
        {
            Domain.World entity = FocusedEntity;
            if (entity != null)
                FireEditEntity(entity);
        }

        private void tsDeleteWorldClick(object sender, EventArgs e)
        {
            Domain.World entity = FocusedEntity;
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
            Domain.World entity = FocusedEntity;
            if (entity != null)
                FireEditEntity(entity);
        }
        public override void Delete()
        {
            Domain.World entity = FocusedEntity;
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
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = 
                gridViewWorld.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewWorld.IsDataRow(info.RowHandle))
            {
                Domain.World entity = GetEntityByRowHandle(info.RowHandle);
                if (entity != null) FireEditEntity(entity);
            }
        }
    }
}
