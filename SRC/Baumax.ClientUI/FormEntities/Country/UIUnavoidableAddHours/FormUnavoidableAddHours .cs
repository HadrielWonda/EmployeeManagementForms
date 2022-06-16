using System;
using System.Windows.Forms;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class FormUnavoidableAddHours : FormBaseEntity
    {
        public FormUnavoidableAddHours()
        {
            InitializeComponent();
            EntityControl = eCadditionHours1;
            button_Cancel.Left = panelBottom.Width - button_Cancel.Width - 16;
        }

        public CountryAdditionalHour Amount
        {
            get { return (CountryAdditionalHour)Entity; }
            set { Entity = value; }
        }

       protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Amount == null) return;
            if (ClientEnvironment.IsRuntimeMode && Amount.IsNew)
            {
                eCadditionHours1.Year = (short)DateTime.Now.Year;
                eCadditionHours1.FactorBegin = eCadditionHours1.FactorEnd = 1;
                lb_NewUAAH.Text = GetLocalized("NewUAAH");
            }
            else
            {
                lb_NewUAAH.Text = GetLocalized("EditUAAH");
                eCadditionHours1.Year = Amount.Year;
                if (Amount.BeginTime != 0 && Amount.EndTime != 0)
                {
                    eCadditionHours1.FactorBegin = Amount.FactorEarly;
                    eCadditionHours1.FactorEnd = Amount.FactorLate;
                }
                    
                else
                    if(Amount.BeginTime == 0 && Amount.EndTime != 0)
                    {
                        eCadditionHours1.FactorBegin = 1;
                        eCadditionHours1.FactorEnd = Amount.FactorLate;
                    }
                    else
                    {
                        eCadditionHours1.FactorBegin = Amount.FactorEarly;
                        eCadditionHours1.FactorEnd = 1;
                    }
            }
           
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape: if (DoBeforeCancel())
                        DialogResult = DialogResult.Cancel;
                    break;
            }
        }
    }
}