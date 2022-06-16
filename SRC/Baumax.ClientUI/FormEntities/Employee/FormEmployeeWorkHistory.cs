using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class FormEmployeeWorkHistory : FormBaseEntity 
    {
        public FormEmployeeWorkHistory()
        {
            InitializeComponent();
            EntityControl = ucEmployeeWorkingHistory1;
        }
    }
}