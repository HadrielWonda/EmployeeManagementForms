using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities
{
    public partial class FormLongTimeAbsenceList : FormBaseEntity 
    {
        public FormLongTimeAbsenceList()
        {
            InitializeComponent();
            EntityControl = ucLongTimeAbsenceList1;
        }

         public void InitAbsenceList()
        {
            ucLongTimeAbsenceList1.InitLongTimeAbsence();
        }
    }
}