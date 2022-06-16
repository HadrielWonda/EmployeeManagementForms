using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class FormChangeTime : FormBaseEntity
    {

        public FormChangeTime()
        {
            InitializeComponent();
            EntityControl = timeRange;
        }

        [Browsable(false)]
        public UCChangeTime UC
        {
            get { return timeRange; }
            set { timeRange = value; }
        }
    }
}