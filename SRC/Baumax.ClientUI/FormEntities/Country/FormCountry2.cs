namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class FormCountry2 : FormBaseEntity
    {
        public FormCountry2()
        {
            InitializeComponent();
            EntityControl = countryEntityControl1;
        }
        public Domain.Country Country
        {
            get { return countryEntityControl1.Country; }
            set 
            { 
                countryEntityControl1.Country = value;
                if (value != null)
                {
                    lblCaption.Text = (value.IsNew) ? GetLocalized("newcountry") : GetLocalized("editcountry");
                }
            }
        }
    }
}

