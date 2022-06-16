using System;
using System.Diagnostics;
using System.Drawing;
using Baumax.Localization;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class FormCountryEdit : FormBaseEntity 
    {
        public FormCountryEdit()
        {
            InitializeComponent();
            EntityControl = ucCountryEdit1;
            textEdit1.ForeColor = Color.Black;
        
        }


        public FormCountryEdit(Domain.Country country):this()
        {
            Debug.Assert(country != null);
            Entity = country;
            
        }

        public override object Entity
        {
            get
            {
                return base.Entity;
            }
            set
            {
                base.Entity = value;

                if (Entity != null)
                {
                    Domain.Country c = (Domain.Country)Entity;
                    textEdit1.Text = c.Name;
                    lblCaption.Text = GetLocalized("EditCountry");
                }
                else textEdit1.Text = String.Empty ;
            }
        }


        public override void AssignLanguage()
        {
            base.AssignLanguage();

            button_Cancel.Text = GetLocalized("Close");
        }
    }
}