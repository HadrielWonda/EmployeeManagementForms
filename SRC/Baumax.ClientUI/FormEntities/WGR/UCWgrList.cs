using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.WGR
{
    public partial class UCWgrList : UCBaseEntity
    {
        public UCWgrList()
        {
            InitializeComponent();
        }

        private void nb_NewClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _ucWgrGrid.Add();
        }

        private void nb_EditClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _ucWgrGrid.Edit();
        }

        private void nbDeleteClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _ucWgrGrid.Delete();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            _ucWgrGrid.WGRList = ClientEnvironment.WGRService.FindAll();
        }

    }
}
