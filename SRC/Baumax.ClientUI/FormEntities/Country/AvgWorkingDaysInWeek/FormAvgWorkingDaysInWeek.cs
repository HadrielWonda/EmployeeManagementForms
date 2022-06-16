using System.Windows.Forms;
using Baumax.Domain;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class AvgWorkingDaysInWeekForm : FormBaseEntity
    {
        public AvgWorkingDaysInWeekForm()
        {
            InitializeComponent();
            EntityControl = ecAvgWorkingDaysInWeek1;
            button_Cancel.Left = panelBottom.Width - button_Cancel.Width - 16;
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            if (Amount.IsNew) 
                lb_AverageWorkingDayInWeek.Text = GetLocalized("NewAverageDaysInWeek");
            else 
                lb_AverageWorkingDayInWeek.Text = GetLocalized("EditAverageDaysInWeek");
        }

        public AvgWorkingDaysInWeek Amount
        {
            get { return (AvgWorkingDaysInWeek)Entity; }
            set { Entity = value; }
        }
      
        private void AvgWDInWeekForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape: 
                    if (DoBeforeCancel())
                        DialogResult = DialogResult.Cancel;
                    break;
            }
        }
    }
}