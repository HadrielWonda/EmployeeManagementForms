using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.Client
{
    public partial class UCSkinPupoup : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler SkinChanged;

        public UCSkinPupoup()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            SkinChanged(sender, e);
        }
    }
}
