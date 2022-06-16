using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using Baumax.Domain ;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities
{
    public partial class UCStoreList : UCBaseEntity 
    {
        StoreManagerContext _context = null;
        private bool _isfirstload = true;
        private bool _groupbyregion = false;
        private bool _groupbycountry = false;
        public delegate void NotifyEntityChanged(BaseEntity entity);
        public event NotifyEntityChanged OnNotifyChangeCountry = null;

        public event EntityDblClickDelegate EntityDblClick = null;
        
        public UCStoreList()
        {
            InitializeComponent();
            GroupByCounrty = true;
            GroupByRegion = true;
            gridViewEntities.ExpandAllGroups();
        }
        
        public void SetCaption(string text)
        {
            lbl_Stores.Text = text;
        }
        
        public void InitContext()
        {
            gridControl.BeginUpdate();
            try
            {
                if (Context == null)
                {
                    _context = new StoreManagerContext();
                    _context.Init();


                    SetStoreContext(_context);


                }

            }
            finally
            {
                gridControl.EndUpdate();
            }

        }
        
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                LocalizerControl.ComponentsLocalize(this.components);
            }
        }

        public void SetStoreContext(StoreManagerContext context)
        {
            _context = context;
            gridControl.DataSource = ListOfStoresView;

            if (_isfirstload)
            {
                _isfirstload = true;
                gridViewEntities.ExpandAllGroups();
            }

            if (Context.CurrentView != null)
            {
                SetFocusOnStoreById(Context.CurrentView.ID);
            }
        }

        public void ReloadData()
        {
            gridViewEntities.BeginDataUpdate();
            try
            {
                ListOfStoresView.LoadAll();
            }
            finally
            {
                gridViewEntities.EndDataUpdate();
            }
        }

        public void New()
        {
            if (Baumax.ClientUI.Import.ImportUI.ImportStores())
            {
                ReloadData();
            }

            /*Domain.Store store = ClientEnvironment.StoreService.CreateEntity();
            EntityStore.FormStore form = new Baumax.ClientUI.FormEntities.EntityStore.FormStore(store);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ListOfStoresView.AddStoreView(new StoreView(store));
            }*/

        }

        protected void OnEntityDblClick()
        {
            if (EntityDblClick != null)
            {
                EntityDblClick(this, new EventArgs());
            }
        }
        
        private Domain.Store GetEntityByRowHandle(int rowHandle)
        {
            StoreView entity = null;
            if (gridViewEntities.IsDataRow(rowHandle))
            {
                entity = (StoreView)gridViewEntities.GetRow(rowHandle);

            }
            return (entity == null) ? null : entity.Entity;

        }
        
        private StoreView GetEntityViewByRowHandle(int rowHandle)
        {
            StoreView entity = null;
            if (gridViewEntities.IsDataRow(rowHandle))
            {
                entity = (StoreView)gridViewEntities.GetRow(rowHandle);

            }
            return entity;

        }

        private void SetFocusOnStoreById(long p)
        {
            StoreView view = ListOfStoresView.GetById(p);
            if (view != null)
            {
                int h = gridViewEntities.GetRowHandle(ListOfStoresView.LastSearchIndex);
                if (h != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    gridViewEntities.FocusedRowHandle = h;
                    gridViewEntities.MakeRowVisible(h, true);
                }
                else Context.CurrentView = FocusedEntityView;
            }
        }

        private Domain.Store GetEntityByIndex(int index)
        {
            if (index >= 0 && index < ListOfStoresView.Count)
                return ListOfStoresView[index].Entity;
            return null;
        }

        [DefaultValue(false)]
        public bool MultiSelect
        {
            get { return gridViewEntities.OptionsSelection.MultiSelect; }
            set { gridViewEntities.OptionsSelection.MultiSelect = value; }
        }
        
        public StoreManagerContext Context
        {
            get
            {
                return _context;
            }
        }

        public StoreViewList ListOfStoresView
        {
            get
            {
                return Context.ListOfStoresView;
            }
        }

        public Domain.Region RegionEntity
        {
            get { return (Domain.Region) Entity; }
            set 
            {
                if (Entity != value)
                {
                    Entity = value;
                }
            }
        }
        
        public bool GroupByRegion
        {
            get { return _groupbyregion; }
            set
            {
                if (value != _groupbyregion)
                {
                    _groupbyregion = value;
                    if (_groupbyregion)
                    {
                        if (gridColumn_Region.GroupIndex == -1)
                        {
                            gridColumn_Region.GroupIndex = gridViewEntities.GroupedColumns.Count;
                            gridViewEntities.ExpandAllGroups();
                        }

                    }
                    else
                    {
                        gridColumn_Region.GroupIndex = -1;
                    }
                }
            }
        }

        public bool GroupByCounrty
        {
            get { return _groupbycountry; }
            set 
            {
                if (value != _groupbycountry)
                {
                    _groupbycountry = value;
                    if (_groupbycountry)
                    {
                        if (gridColumn_Country.GroupIndex == -1)
                        {
                            gridColumn_Country.GroupIndex = gridViewEntities.GroupedColumns.Count;
                            gridViewEntities.ExpandAllGroups();
                        }

                    }
                    else
                    {
                        gridColumn_Country.GroupIndex = -1;
                    }
                }
            }
        }
        
        public Domain.Store FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewEntities.FocusedRowHandle);
            }
        }
        
        protected  StoreView FocusedEntityView
        {
            get
            {
                return GetEntityViewByRowHandle(gridViewEntities.FocusedRowHandle);
            }
        }

        public List<Domain.Store> SelectedStores
        {
            get
            {
                int[] selection = gridViewEntities.GetSelectedRows();
                List<Domain.Store> res = new List<Domain.Store>(selection.Length);
                foreach (int i in selection)
                {
                    StoreView rv = GetEntityViewByRowHandle(i);
                    if (rv != null)
                        res.Add(rv.Entity);
                }
                return res;
            }
        }

        private void mi_GroupByCountry_Click(object sender, EventArgs e)
        {
            GroupByCounrty = !GroupByCounrty;
        }

        private void mi_GroupByRegion_Click(object sender, EventArgs e)
        {
            GroupByRegion = !GroupByRegion;
        }

        private void menuStore_Opening(object sender, CancelEventArgs e)
        {
            mi_GroupByCountry.Checked = GroupByCounrty;
            mi_GroupByRegion.Checked = GroupByRegion;

            mi_ExpandedAll.Enabled = gridViewEntities.GroupCount > 0;
            mi_CollapseAll.Enabled = gridViewEntities.GroupCount > 0;
        }

        private void mi_ExpandedAll_Click(object sender, EventArgs e)
        {
            if (gridViewEntities.GroupCount > 0)
                gridViewEntities.ExpandAllGroups();
        }

        private void mi_CollapseAll_Click(object sender, EventArgs e)
        {
            if (gridViewEntities.GroupCount > 0)
                gridViewEntities.CollapseAllGroups();
        }

        private void gridViewEntities_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Context.CurrentView = FocusedEntityView;
            if (OnNotifyChangeCountry != null)
            {
                if (FocusedEntity != null)
                    OnNotifyChangeCountry(FocusedEntity);
                else OnNotifyChangeCountry(null);
            }
        }

        private void gridViewEntities_RowCountChanged(object sender, EventArgs e)
        {
            Context.CurrentView = FocusedEntityView;
        }

        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridViewEntities.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewEntities.IsDataRow(info.RowHandle))
            {
                OnEntityDblClick();
            }
        }

        /*
        public void Edit()
        {
            Domain.Store store = FocusedEntity;
            if (store != null)
            {
                EntityStore.FormStore form = new Baumax.ClientUI.FormEntities.EntityStore.FormStore(store);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _listviewStores.UpdateStoreView(store);
                }
            }

        }*/
    }
}
