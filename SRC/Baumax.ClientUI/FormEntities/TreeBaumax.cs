using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities
{
    using Baumax.Environment;
    using Baumax.Domain;
    using Baumax.ClientUI.FormEntities.Country;
    using Baumax.Contract;

    public partial class TreeBaumax : UCBaseEntity
    {
        BaumaxTreeNodeList _nodesList = null;
        public TreeBaumax()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ClientEnvironment.IsRuntimeMode)
            {
                _nodesList = new BaumaxTreeNodeList();
                List<Domain.Country> lst = ClientEnvironment.CountryService.FindAll();
                _nodesList.AddCountries(lst);
                List<Domain.Region> lstRegion = ClientEnvironment.RegionService.FindAll();
                _nodesList.AddRegions(lstRegion);

                List<Domain.Store> lstStore = ClientEnvironment.StoreService.FindAll();
                _nodesList.AddStores(lstStore);


                treeList1.DataSource = _nodesList;

            }
        }

        private void menuStriptree_Opening(object sender, CancelEventArgs e)
        {
            BaumaxTreeNode node = (BaumaxTreeNode)treeList1.GetDataRecordByNode(treeList1.FocusedNode);

            e.Cancel = !ShowOrHideMenu(node);
        }

        private bool ShowOrHideMenu(BaumaxTreeNode node)
        {
            if (node == null) return false;

            bool bShowCountry = node.NodeType == BaumaxNodeType.Country;
            bool bShowCountries = bShowCountry || (node.NodeType == BaumaxNodeType.Countries);
            bool bShowRegion = node.NodeType == BaumaxNodeType.Region;
            bool bShowRegions = bShowRegion || (node.NodeType == BaumaxNodeType.Regions);
            bool bShowStore = node.NodeType == BaumaxNodeType.Store;
            bool bShowStores = bShowStore || (node.NodeType == BaumaxNodeType.Stores);


            toolStripMenuItem_newCountry.Visible = bShowCountries;
            toolStripMenuItem_editCountry.Visible = toolStripMenuItem_deleteCountry.Visible  = bShowCountry;

            CountryRegionSeparator.Visible = false;

            toolStripMenuItem_newRegion.Visible = bShowRegions;
            toolStripMenuItem_editRegion.Visible = toolStripMenuItem_deleteRegion.Visible = bShowRegion;

            RegionStoreSeparator.Visible = false;

            toolStripMenuItem_newStore.Visible = bShowStores;
            toolStripMenuItem_editStore.Visible = toolStripMenuItem_deleteStore.Visible = bShowStore;

            return (bShowCountries | bShowRegions | bShowStores);

            /*bool bExistVisible = false;
            for (int i = 0; i < menuStriptree.Items.Count ; i++)
            {
                if (menuStriptree.Items[i].Visible) return true;
                
            }*/
            //menuStriptree.V
            
            //return true;
        }

        private void toolStripMenuItem_newCountry_Click(object sender, EventArgs e)
        {
            FireNewEntity();
        }

        private void FireNewEntity()
        {
            BaumaxTreeNode node = (BaumaxTreeNode)treeList1.GetDataRecordByNode(treeList1.FocusedNode);

            switch (node.NodeType)
            {
                case BaumaxNodeType.Countries :
                case BaumaxNodeType.Country :
                    NewCountry(); break ;
                case BaumaxNodeType.Regions :
                case BaumaxNodeType.Region :
                    NewRegion(); break;
                case BaumaxNodeType.Stores :
                case BaumaxNodeType.Store :
                    NewStore(); break;
            }
        }

        private void NewStore()
        {
            
        }

        private void NewRegion()
        {
            Domain.Region r = ClientEnvironment.RegionService.CreateEntity();
            if (ClientEnvironment.LogonUser.LanguageID.HasValue)
                r.LanguageID = ClientEnvironment.LogonUser.LanguageID.Value;
            else
                r.LanguageID = SharedConsts.NeutralLangId;

            using (Baumax.ClientUI.FormEntities.Region.RegionFrm frm = new Baumax.ClientUI.FormEntities.Region.RegionFrm())
            {
                frm.Entity = r;
                if (frm.ShowDialog(this) == DialogResult.OK && frm.Modified)
                {
                    Domain.Region region = ClientEnvironment.RegionService.Save(r);
                    List<Domain.Region> l = new List<Baumax.Domain.Region>();
                    l.Add(region);

                    _nodesList.AddRegions(l);
                }
            }
        }

        private void NewCountry()
        {

            Domain.Country entity = ClientEnvironment.CountryService.CreateEntity();
            FormCountry2 countryform = new FormCountry2();
            countryform.Country = entity;
            if (countryform.ShowDialog() == DialogResult.OK)
            {
                List<Domain.Country> l = new List<Baumax.Domain.Country>();
                l.Add(countryform.Country);

                _nodesList.AddCountries(l);
            }
        }

        private void toolStripMenuItem_newRegion_Click(object sender, EventArgs e)
        {
            FireNewEntity();
        }
    }
}
