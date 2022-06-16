using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCWgrList : UCHwgrList
    {
        public UCWgrList()
        {
            InitializeComponent();
            MutableToWgrList();
        }
    }
}
