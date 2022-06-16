using System.ComponentModel;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class CountryDetailControl : UCBaseEntity
    {
        public CountryDetailControl()
        {
            InitializeComponent();
        }

        private Domain.Country _country = null;

        [DefaultValue (null)]
        public Domain.Country Country
        {
            get { return _country; }
            set 
            {
                if (_country != value)
                {
                    _country = value;
                    ChangeCountry();
                }
            }
        }

        void ChangeCountry()
        {
            if (Country != null)
            {
                yearlyAppearanceListControl1.EntityCountry = Country;
            }
            else yearlyAppearanceListControl1.EntityCountry = null;
            feastListControl1.Country = Country;
            coloringListControl1.Country = Country;
            absenceListControl1.Country = Country;
            wModelList1.Country = Country;
            

        }
    }
}

