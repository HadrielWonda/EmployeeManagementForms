using System.Collections.Generic;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Region
{
    public partial class RegionCtrl : UCBaseEntity
    {
        public RegionCtrl()
        {
            InitializeComponent();
        }
        
        public override void Bind()
        {
            teName.Text = RegionEntity.Name;
            ceImported.Checked = RegionEntity.Import;
            teName.Enabled = !RegionEntity.Import;
            lookUpCountry.Enabled = !RegionEntity.Import;
            
            List<Domain.Country> countries = ClientEnvironment.CountryService.FindAll();
            lookUpCountry.Properties.DataSource = countries;
            lookUpCountry.EditValue = RegionEntity.CountryID;
            lookUpCountry.Enabled = !RegionEntity.Import;
        }
        
        public override bool Commit()
        {
            if (!IsValid())
                return false;

            if (!RegionEntity.Import)
            {
                if (RegionEntity.Name != teName.Text)
                {
                    RegionEntity.Name = teName.Text;
                    Modified = true;
                }
            }
            if (RegionEntity.CountryID != (long)lookUpCountry.EditValue)
            {
                RegionEntity.CountryID = (long) lookUpCountry.EditValue;
                Modified = true;
            }
            
            return true;
        }
        
        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(teName.Text);
        }

        protected override void EntityChanged()
        {
            base.EntityChanged();
            Bind();
        }

        private Domain.Region RegionEntity
        {
            get { return (Domain.Region)Entity; }
        }
    }
}
