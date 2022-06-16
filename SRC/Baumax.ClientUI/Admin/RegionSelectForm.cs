using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baumax.Localization;
using DevExpress.XtraEditors;
using Baumax.ClientUI.FormEntities;
using Baumax.Domain;

namespace Baumax.ClientUI.Admin
{
    public partial class RegionSelectForm : FormBaseEntity
    {
        private UCRegionList _regionGridCtrl = null;

        public RegionSelectForm()
        {
            InitializeComponent();
            _regionGridCtrl = new UCRegionList();
            _regionGridCtrl.Parent = panelClient;
            _regionGridCtrl.Dock = DockStyle.Fill;
            _regionGridCtrl.ReadOnly = true;
            _regionGridCtrl.MultiSelect = true;
            _regionGridCtrl.EntityDblClick += new EntityDblClickDelegate(_regionGridCtrl_EntityDblClick);
            _regionGridCtrl.Init();

            Modified = true;
        }

        public void ExcludeIds(long[] ids)
        {
            _regionGridCtrl.ExcludeIds(ids);
        }

        public Domain.Region FocusedRegion
        {
            get { return _regionGridCtrl.FocusedRegion; }
        }

        public List<Domain.Region> SelectedRegions
        {
            get { return _regionGridCtrl.SelectedRegions; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                button_OK.Text = Localizer.GetLocalized("ButtonSelect");
            }
        }
        
        private void _regionGridCtrl_EntityDblClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}