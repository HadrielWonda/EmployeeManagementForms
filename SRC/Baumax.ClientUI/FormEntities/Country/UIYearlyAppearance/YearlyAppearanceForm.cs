using Baumax.Domain;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class YearlyAppearanceForm : FormBaseEntity
    {
        public YearlyAppearanceForm()
        {
            InitializeComponent();
            EntityControl = yearAppearanceEntityControl1;

            button_Cancel.Left = panelBottom.Width - button_Cancel.Width - 16;
        }

        public AvgAmount Amount
        {
            get { return (AvgAmount)Entity; }
            set { Entity = value; }
        }
    }
}

