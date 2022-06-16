using System;
using System.Collections.Generic;
using Baumax.ClientUI.FormEntities;
using Baumax.Domain;
using Baumax.Localization;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.Admin
{
    public partial class StoreSelectFrm : FormBaseEntity
    {
        private FormEntities.UCStoreList ctrlStoreList;
        public StoreSelectFrm()
        {
            InitializeComponent();
            
            ctrlStoreList = new UCStoreList();
            ctrlStoreList.Parent = panelClient;
            ctrlStoreList.Dock = System.Windows.Forms.DockStyle.Fill;
            ctrlStoreList.MultiSelect = true;
            ctrlStoreList.EntityDblClick += new EntityDblClickDelegate(ctrlStoreList_EntityDblClick);
            ctrlStoreList.ReadOnly = true;
            
            Modified = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                ctrlStoreList.InitContext();
                ctrlStoreList.SetCaption(Localizer.GetLocalized("SelectStores"));
                button_OK.Text = Localizer.GetLocalized("ButtonSelect");
            }
        }

        public void ExcludeIds(long[] ids)
        {
           // ctrlStoreList.ExcludeIds(ids);
        }

        public Store SelectedStore
        {
            get
            {
                return ctrlStoreList.FocusedEntity;
            }
        }
        
        public List<Domain.Store> SelectedStores
        {
            get { return ctrlStoreList.SelectedStores; }
        }

        private void ctrlStoreList_EntityDblClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}