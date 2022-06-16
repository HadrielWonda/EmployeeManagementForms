using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.Region
{
    using Baumax.Environment;
    using Baumax.Templates;

    public partial class FormRegionEdit : FormBaseEntity 
    {
        Domain.Region _region = null;
        Domain.Store _store = null;
        
        BindingTemplate<Domain.Store> _listStores = new BindingTemplate<Baumax.Domain.Store>();
        StoreWorldController _StoreWorldList = new StoreWorldController();

        public FormRegionEdit()
        {
            InitializeComponent();
            lookUpStores.Properties.PopupFormWidth = lookUpStores.Width;
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                button_Cancel.Text = GetLocalized("Close");
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
        }

        private void LoadStores()
        {
            lookUpStores.Properties.BeginUpdate();
            try
            {
                _listStores.Clear();
                
                if (Entity != null)
                {
                    StoreViewList lst = new StoreViewList();
                    lst.LoadByRegion(EntityRegion.ID);

                    for (int i = 0; i < lst.Count; i++)
                    {
                        _listStores.Add(lst[i].Entity);
                    }

                    //List<Domain.Store> lst = ClientEnvironment.StoreService.FindAll();
//                    if (lst != null)
//                    {
//                        foreach (Domain.Store store in lst)
//                            if (store.RegionID == EntityRegion.ID) _listStores.Add(store);
//                    }
                }

                if (lookUpStores.Properties.DataSource == null)
                    lookUpStores.Properties.DataSource = _listStores;

            }
            finally
            {
                lookUpStores.Properties.EndUpdate();
            }
            
            if (_listStores.Count > 0)
            {
                lookUpStores.EditValue = _listStores[0].ID;
            }
        }

        public Domain.Region  EntityRegion
        {
            get { return (Domain.Region)Entity; }
            set { Entity = value; }
        }

        public override object Entity
        {
            get
            {
                return _region;
            }
            set
            {
                if (value != _region)
                {
                    _region = (Domain.Region )value;
                    UpdateCaption();
                    EntityChanged();
                }

            }
        
        }

        private void UpdateCaption()
        {
            String regName = GetLocalized ("Region");
            if (EntityRegion != null)
            {
                lblRegion.Text = String.Format("{0}: {1}", regName, EntityRegion.Name);
            }
            else lblRegion.Text = String.Format("{0}:", regName);
        }
        private void EntityChanged()
        {
            if (EntityRegion != null)
            {
                _StoreWorldList.LoadByRegionId(EntityRegion.ID);
                ucBufferHoursView1.SWController = _StoreWorldList;
                ucBenchmarksView1.SWController = _StoreWorldList;
                ucTrendCorrectionsView1.SWController = _StoreWorldList;
            }
            else
            {
                ucBufferHoursView1.SWController = null;
            }
            LoadStores();
        }

        public Domain.Store SelectedStore
        {
            get { return _store; }
            set 
            {
                if (_store != value)
                {
                    _store = value;
                    ChangedStore();
                }
            }
        }

        private void ChangedStore()
        {
            ucBufferHoursView1.Entity = SelectedStore;
            ucBenchmarksView1.Entity = SelectedStore;
            ucTrendCorrectionsView1.Entity = SelectedStore;
        }

        private void lookUpStores_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpStores.EditValue != null)
            {
                long id = Convert.ToInt64(lookUpStores.EditValue);
                Domain.Store store = _listStores.GetItemByID(id);

                if (store != null)
                {
                    SelectedStore = store;
                }
            }
        }

        private void FormRegionEdit_Resize(object sender, EventArgs e)
        {
            lookUpStores.Properties.PopupFormWidth = lookUpStores.Width;
        }

    }
}