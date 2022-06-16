using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.ClientUI.FormEntities;

namespace Baumax.ClientUI.Admin
{
    public partial class ChangePasswordForm :  FormBaseEntity
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
            EntityControl = ctrlChangePassword;
        }
        
        public void SetCaption(string caption)
        {
            lblCaption.Text = caption;
            panelTop.Visible = true;
        }
    }
}