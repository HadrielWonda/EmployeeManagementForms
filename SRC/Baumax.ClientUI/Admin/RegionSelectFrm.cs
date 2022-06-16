using System;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.Admin
{
    public partial class RegionSelectFrm : XtraForm
    {
        public RegionSelectFrm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                ctrlRegionGrid.RegionList = ClientEnvironment.RegionService.FindAll();
            }
        }

        public Region SelectedRegion
        {
            get
            {
                return ctrlRegionGrid.FocusedEntity;
            }
        }
    }
}