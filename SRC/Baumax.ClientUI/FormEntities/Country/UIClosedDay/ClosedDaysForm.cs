using System.Windows.Forms;
using Baumax.Domain;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class ClosedDaysForm : FormBaseEntity
    {
        public ClosedDaysForm()
        {
            InitializeComponent();
            EntityControl = closedDayEntityControl1;
            button_Cancel.Left = panelBottom.Width - button_Cancel.Width - 16;
        }

        public YearlyWorkingDay Amount
        {
            get { return (YearlyWorkingDay)Entity; }
            set { Entity = value; }
        }

        private Domain.Country _country;

        public Domain.Country Country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                    closedDayEntityControl1.Country = _country;
                }
            }
        }

        private void ClosedDaysForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Escape: if (DoBeforeCancel()) 
                        DialogResult = DialogResult.Cancel; 
                    break;
            }
        }
    }
}