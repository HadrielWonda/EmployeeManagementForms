using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.WGR
{
    public partial class UCRegisterList : UCBaseEntity
    {
        private UCWgrGrid _wgrGrid;
        private UCHwgrGrid _hwgrGrid;
        private UCWorldGrid _worldGrid; 

        public UCRegisterList()
        {
            InitializeComponent();
            UnVisibleAll();
        }

        private void UnVisibleAll()
        {
            nb_HWGR.Visible = false;
            nb_Store.Visible = false;
            nb_WGR.Visible = false;
            nb_World.Visible = false;

            if (_wgrGrid != null)
                _wgrGrid.Visible = false;
            if (_hwgrGrid != null)
                _hwgrGrid.Visible = false;
            if (_worldGrid != null)
                _worldGrid.Visible = false;
        }

        private void EnableStore(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void EnableWorld(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UnVisibleAll();
            if (_worldGrid == null)
            {
                _worldGrid = new UCWorldGrid();
                splitContainerControl1.Panel2.Controls.Add(_worldGrid);
                _worldGrid.Dock = DockStyle.Fill;
            }
            _worldGrid.Visible = true;
            nb_World.Visible = true;    
        }

        private void EnableHWGR(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UnVisibleAll();
            if (_hwgrGrid == null)
            {
                _hwgrGrid = new UCHwgrGrid();
                splitContainerControl1.Panel2.Controls.Add(_hwgrGrid);
                _hwgrGrid.Dock = DockStyle.Fill;
            }
            _hwgrGrid.Visible = true;
            nb_HWGR.Visible = true;           
        }

        private void EnableWGR(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UnVisibleAll();
            if (_wgrGrid == null)
            {
                _wgrGrid = new UCWgrGrid();
                splitContainerControl1.Panel2.Controls.Add(_wgrGrid);
                _wgrGrid.Dock = DockStyle.Fill;
            }
            _wgrGrid.Visible = true;
            nb_WGR.Visible = true;     
        }

        private void NewStore(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void EditStore(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void DeleteStore(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void EditWorld(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _worldGrid.Edit();
        }

        private void DeleteWorld(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _worldGrid.Delete();
        }

        private void NewWorld(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _worldGrid.Add();
        }

        private void DeleteHWGR(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _hwgrGrid.Delete();
        }

        private void EditHWGR(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _hwgrGrid.Edit();
        }

        private void NewHWGR(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _hwgrGrid.Add();
        }

        private void DeleteWGR(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _wgrGrid.Delete();
        }

        private void EditWgr(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _wgrGrid.Edit();
        }

        private void NewWGR(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _wgrGrid.Add();
        }
    }
}
