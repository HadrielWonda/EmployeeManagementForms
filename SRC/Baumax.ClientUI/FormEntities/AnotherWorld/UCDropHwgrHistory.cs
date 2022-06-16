using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCDropHwgrHistory : UCBaseEntity
    {
        public UCDropHwgrHistory()
        {
            InitializeComponent();
        }

        protected override void EntityChanged()
        {
            WorldToHwgr hwgr = Entity as WorldToHwgr;
            HwgrToWgr wgr = Entity as HwgrToWgr;
            if (hwgr != null)
            {
                List<WorldToHwgr> list = ClientEnvironment.WorldToHWGRService
                    .GetWorldToHwgrFiltered(hwgr.StoreID, hwgr.WorldID, hwgr.HWGR_ID);
                gridControl.DataSource = list;

                lbCaption.Text = string.Format("{0} -> {1} -> {2}",
                    ClientEnvironment.StoreService.FindById(hwgr.StoreID).Name,
                    ClientEnvironment.WorldService.FindById(hwgr.WorldID).Name,
                    ClientEnvironment.HWGRService.FindById(hwgr.HWGR_ID).Name);
            }
            else if (wgr != null)
            { 
            
            }
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
                LocalizerControl.ComponentsLocalize(this.components);
        }
    }
}
