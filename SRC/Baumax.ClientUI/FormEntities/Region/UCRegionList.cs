using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.ClientUI.FormEntities.Region;
using Baumax.ClientUI.Import;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities
{
    public delegate void NotifyFocusedEntityChanged(BaseEntity entity);
    public delegate void EntityDblClickDelegate(object sender, EventArgs e);
    
    public partial class UCRegionList : UCBaseEntity
    {
        private RegionViewBindingList _entityList = new RegionViewBindingList();
        private RegionViewMode _mode = RegionViewMode.ShowAll;
        private bool _groupByCountry = true;
        private bool isUserGlobaAdministrator = (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value ==
                 (long)UserRoleId.GlobalAdmin); 

        public event NotifyFocusedEntityChanged OnNotifyFocusedChanged = null;
        public event EntityDblClickDelegate EntityDblClick = null;

        public UCRegionList()
        {
            InitializeComponent();
            gridControl.DataSource = _entityList;
        }

        #region Public Methotds
        public void ExcludeIds(long[] ids)
        {
            if (ids != null)
            {
                foreach (long id in ids)
                {
                    int iCount = _entityList.Count;
                    for (int i = 0; i < iCount; i++)
                    {
                        if (_entityList[i].ID == id)
                        {
                            _entityList.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        public void Init()
        {
            LoadRegions();
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                LocalizerControl.ComponentsLocalize(components);
            }
        }

        public override void Add()
        {
            if (ReadOnly) return;

            if (ImportUI.ImportRegions())
            {
                LoadRegions();
            }
            /*Baumax.Import.UI.FrmImport frmImport = new Baumax.Import.UI.FrmImport(ClientEnvironment.CountryService, ClientEnvironment.RegionService, ClientEnvironment.StoreService, ClientEnvironment.EmployeeService, Baumax.Import.ImportType.Region);
            frmImport.ShowDialog();
            if (frmImport.BeenRunSuccessfully)
            {
                LoadRegions();
            }*/


            /*
            Domain.Region r = ClientEnvironment.RegionService.CreateEntity();
            r.LanguageID = Baumax.Contract.SharedConsts.NeutralLangId;
            using (RegionFrm frm = new RegionFrm())
            {
                frm.Entity = r;
                if (frm.ShowDialog(this) == DialogResult.OK && frm.Modified)
                {
                    if (r.IsNew)
                        r = ClientEnvironment.RegionService.Save(r);
                    else
                        ClientEnvironment.RegionService.SaveOrUpdate(r);
                    _entityList.Add(new RegionView(r));
                }
            }
             */
        }

        public void ShowRegionStores()
        {
            if (ReadOnly) return;

            Domain.Region region = FocusedRegion;
            if (region != null)
            {
                using (FormRegionStores form = new FormRegionStores())
                {
                    form.Entity = region;
                    form.ShowDialog();
                }
            }
        }

        public void EditRegion()
        {
            if (ReadOnly) return;

            Domain.Region region = FocusedRegion;

            if (region != null)
            {
                using (FormRegionEdit editForm = new FormRegionEdit())
                {
                    editForm.EntityRegion = region;

                    editForm.ShowDialog();
                }
            }
        }

        #endregion

        protected override void EntityChanged()
        {
            if (Entity != null)
            {
                gridColumn_CountryName.Visible = false;
                _entityList.Clear();
                List<Domain.Region> lst = ClientEnvironment.RegionService.FindAll();
                if (lst != null)
                {
                    long countryid = EntityCountry.ID;
                    foreach (Domain.Region reg in lst)
                    {
                        if (reg.CountryID == countryid)
                        {
                            _entityList.Add(new RegionView(reg));
                        }
                    }
                }
            }
            else _entityList.Clear();
        }

        protected void FireNotifyFocusedEntityChanged()
        {
            if (OnNotifyFocusedChanged != null)
            {
                OnNotifyFocusedChanged(FocusedRegion);
            }
        }
        
        protected void OnEntityDblClick()
        {
            if (EntityDblClick != null)
            {
                EntityDblClick(this, new EventArgs());
            }
        }
        
        private void LoadRegions()
        {
            gridViewRegions.BeginDataUpdate();
            try
            {
                _entityList.Clear();

                List<Domain.Region> list = ClientEnvironment.RegionService.FindAll();

                _entityList.AssignList(list);
                if (GroupByCountry)
                    gridColumn_CountryName.GroupIndex = 0;
                else gridColumn_CountryName.GroupIndex = -1;
            }
            finally
            {
                gridViewRegions.EndDataUpdate();
                if (GroupByCountry) gridViewRegions.ExpandAllGroups();
            }
        }

        private RegionView GetEntityByRowHandle(int rowHandle)
        {
            RegionView entity = null;
            if (gridViewRegions.IsDataRow(rowHandle))
            {
                entity = (RegionView)gridViewRegions.GetRow(rowHandle);
            }
            return entity;
        }

        #region Properties
        public RegionViewMode ViewMode
        {
            get { return _mode; }
            set
            {
                if (_mode != value)
                {
                    _mode = value;
                }
            }
        }

        [DefaultValue(false)]
        public bool MultiSelect
        {
            get { return gridViewRegions.OptionsSelection.MultiSelect; }
            set { gridViewRegions.OptionsSelection.MultiSelect = value; }
        }
    
        [DefaultValue(true)]
        public bool GroupByCountry
        {
            get { return _groupByCountry; }
            set
            {
                if (value != _groupByCountry)
                {
                    _groupByCountry = value;
                    if (GroupByCountry)
                    {
                        gridColumn_CountryName.GroupIndex = 0;
                    }
                    else
                    {
                        gridColumn_CountryName.GroupIndex = -1;
                    }
                }
            }
        }

        [Browsable(false)]
        public Domain.Country EntityCountry
        {
            get { return (Domain.Country) Entity; }
            set
            {
                if (value != null)
                {
                    if (value is Domain.Country)
                    {
                        Entity = value;
                    }
                    else throw new InvalidCastException();
                }
            }
        }

        [Browsable(false)]
        public Domain.Region FocusedRegion
        {
            get
            {
                RegionView view = GetEntityByRowHandle(gridViewRegions.FocusedRowHandle);
                return (view == null) ? null : view.Entity;
            }
        }

        protected RegionView FocusedEntity
        {
            get { return GetEntityByRowHandle(gridViewRegions.FocusedRowHandle); }
        }

        public List<Domain.Region> SelectedRegions
        {
            get
            {
                int[] selection = gridViewRegions.GetSelectedRows();
                List<Domain.Region> res = new List<Domain.Region>(selection.Length);
                foreach (int i in selection)
                {
                    RegionView rv = GetEntityByRowHandle(i);
                    if (rv != null)
                        res.Add(rv.Entity);
                }
                return res;
            }
        }
        #endregion

        private void menuItem_NewRegion_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void menuItem_EditRegion_Click(object sender, EventArgs e)
        {
            ShowRegionStores();
        }

        private void menuItem_DeleteRegion_Click(object sender, EventArgs e)
        {
            EditRegion();
        }

        private void menuItem_ExpandedAll_Click(object sender, EventArgs e)
        {
            gridViewRegions.ExpandAllGroups();
        }

        private void menuItem_CollapseAll_Click(object sender, EventArgs e)
        {
            gridViewRegions.CollapseAllGroups();
        }

        private void menuItem_GroupByCountry_Click(object sender, EventArgs e)
        {
            GroupByCountry = !GroupByCountry;
        }

        private void menuRegion_Opening(object sender, CancelEventArgs e)
        {
            if (ReadOnly)
            {
                e.Cancel = true;
                return;
            }
            RegionView region = FocusedEntity;

            menuItem_EditRegion.Enabled = region != null;
            menuItem_RegionDetails.Enabled = region != null;

            menuItem_GroupByCountry.Checked = GroupByCountry;

            menuItem_EditRegion.Visible = !ReadOnly;
            menuItem_RegionDetails.Visible = !ReadOnly;
            menuItem_ImportRegion.Visible = isUserGlobaAdministrator;
            separatorMenuItem.Visible = !ReadOnly;
        }

        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (ReadOnly) return;
            if (e.KeyCode == Keys.Enter) ShowRegionStores();
            else if (e.KeyCode == Keys.Insert) Add();
            else if (e.KeyCode == Keys.Delete) EditRegion();
        }

        private void gridViewRegions_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            FireNotifyFocusedEntityChanged();
        }

        private void gridControlCountries_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridViewRegions.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewRegions.IsDataRow(info.RowHandle))
            {
                RegionView entity = GetEntityByRowHandle(info.RowHandle);
                if (entity != null)
                {
                    OnEntityDblClick();
                    if (!ReadOnly)
                        EditRegion();
                }
            }
        }
    }
}