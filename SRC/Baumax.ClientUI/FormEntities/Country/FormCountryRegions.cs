using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.Country
{
    using Baumax.Environment;
    public partial class FormCountryRegions : FormBaseEntity 
    {
        public FormCountryRegions()
        {
            InitializeComponent();
            EntityControl = ucRegionList1;
            ucRegionList1.ReadOnly = true;
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                lblCaption.Text = GetLocalized("CountryDetails");
            }
        }
    }
}