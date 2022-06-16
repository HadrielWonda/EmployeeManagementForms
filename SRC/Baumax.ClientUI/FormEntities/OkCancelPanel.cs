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
    public partial class OkCancelPanel : DevExpress.XtraEditors.XtraUserControl
    {
        public OkCancelPanel()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            if (OnButtonCancel != null) OnButtonCancel(sender, e);
        }


        public event EventHandler OnButtonCancel = null;
        public event EventHandler OnButtonOk = null;

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (OnButtonOk != null) OnButtonOk(sender, e);
        }
    }
}
