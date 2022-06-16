using System;
using Baumax.ClientUI.FormEntities;
using Baumax.ClientUI.Import;
using Baumax.Contract;
using Baumax.Environment;
using DevExpress.XtraNavBar;

namespace Baumax.ClientUI.ManageEntityControls
{
    // old class - need delete
    public partial class WorldManagerControl : UCBaseEntity 
    {
        StoreManagerContext m_Context = null;
        public WorldManagerControl()
        {
            InitializeComponent();
        }
        
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                InitStoreContext();
            }
        }

        public StoreManagerContext StoreContext
        {
            get
            {
                return m_Context;
            }
        }

        public StoreViewList ListOfStoresView
        {
            get
            {
                return StoreContext.ListOfStoresView;
            }
        }

        private void InitStoreContext()
        {
            if (StoreContext == null)
            {
                m_Context = new StoreManagerContext();
                m_Context.Init();
                lookUpEditStores.Properties.DataSource = ListOfStoresView;
            }
        }

        private void lookUpEditStores_EditValueChanged(object sender, EventArgs e)
        {
            OnChangeStore();
        }

        private void OnChangeStore()
        {
            if (lookUpEditStores.EditValue != null)
            {
                long p = Convert.ToInt64(lookUpEditStores.EditValue);

                StoreContext.CurrentView = StoreContext.ListOfStoresView.GetById(p);

                /*if (StoreContext.CurrentView != null)
                {
                    EntityStore = Context.CurrentStore;
                }*/
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        private void nbi_ImportWorlds_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ImportUI.ImportWorlds();
        }

        private void nbi_ImportHwgrs_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ImportUI.ImportHwgrs();
        }

        private void nbi_ImportWgrs_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ImportUI.ImportWgrs();
        }

      
    }
}
