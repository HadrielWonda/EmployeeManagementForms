using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baumax.Localization;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.EntityStore
{
    using Baumax.Domain ;
    using Baumax.Environment;

    public partial class FormStore : DevExpress.XtraEditors.XtraForm
    {
        Domain.Store _entity = null;
        StoreView _entityview = null;
        private bool _readonly;
        private bool _modified = false;
        private RegionViewBindingList _regionsList = new RegionViewBindingList();

        public FormStore()
        {
            InitializeComponent();
        }
        public FormStore(Domain.Store entity)
        {
            InitializeComponent();
            LoadRegions();
            Entity = entity;

            lookUpRegions.Properties.PopupFormWidth = lookUpRegions.Width;
        }
        public Domain.Store Entity
        {
            get
            {
                return _entity;
            }
            protected set
            {
                if (_entity != value)
                {
                    _entity = value;
                    _entityview = new StoreView(_entity);
                    _entityview.Edit();
                    Bind();
                }
            }
        }

        protected void Bind()
        {
            _modified = false;
            if (Entity.IsNew)
            {
                if (_regionsList.Count > 0)
                    lookUpRegions.EditValue = _regionsList[0].ID;
            }
            else 
                lookUpRegions.EditValue = _entityview.RegionID;
            
            teStoreName.Text = _entityview.StoreName;
            teCity.Text = _entityview.City;
            teAddress.Text = _entityview.Address;
            tePostCode.Text = _entityview.PostCode;
            teArea.Text = _entityview.Area.ToString();

            teInternalId.Text = _entityview.InternalID.ToString();

            if (Entity.Import) 
                ReadOnly = true;
            
            checkImport.Checked = Entity.Import;
        }

        protected bool IsValid()
        {
            bool isvalid = true;
            long regionid = 0;
            if (lookUpRegions.EditValue != null) 
                regionid = Convert.ToInt64 (lookUpRegions.EditValue);

            if (regionid == 0)
            {
                lookUpRegions.ErrorText = UILocalizer.Current["SelectRegion"];
                isvalid = false;
            }
            else 
                lookUpRegions.ErrorText = String.Empty ;


            if (teStoreName.Text.Trim().Length == 0)
            {
                teStoreName.ErrorText = UILocalizer.Current["EnterStoreName"];
                isvalid = false;
            }
            else 
                teStoreName.ErrorText = String.Empty;


            if (teCity.Text.Trim().Length == 0)
            {
                teCity.ErrorText = UILocalizer.Current["EnterCity"];
                isvalid = false;
            }
            else 
                teCity.ErrorText = String.Empty;

            if (teAddress.Text.Trim().Length == 0)
            {
                teAddress.ErrorText = UILocalizer.Current["EnterAddress"];
                isvalid = false;
            }
            else 
                teAddress.ErrorText = String.Empty;

            long number = 0;
            if (tePostCode.Text.Trim().Length > 0) 
                number = Convert.ToInt64(tePostCode.Text);

            if (number == 0)
            {
                tePostCode.ErrorText = UILocalizer.Current["EnterPostCode"];
                isvalid = false;
            }
            else 
                tePostCode.ErrorText = String.Empty;

            if (teArea.Text.Trim().Length > 0) 
                number = Convert.ToInt64(teArea.Text);
            if (number == 0)
            {
                teArea.ErrorText = UILocalizer.Current["EnterArea"];
                isvalid = false;
            }
            else 
                teArea.ErrorText = String.Empty;


            _entityview.RegionID = (lookUpRegions.EditValue != null) ? Convert.ToInt64(lookUpRegions.EditValue) : 0;
            _entityview.StoreName = teStoreName.Text.Trim();
            _entityview.City = teCity.Text.Trim();
            _entityview.Address = teAddress.Text.Trim();
            _entityview.PostCode = tePostCode.Text;
            _entityview.Area = Convert.ToInt32(teArea.Text);

            return isvalid;
        }


        public bool Commit()
        {
            if (IsValid())
            {
                if (_entityview.IsModified())
                {
                    _entityview.Commit();

                    if (Entity.IsNew)
                    {
                        Domain.Store st = ClientEnvironment.StoreService.Save(Entity);
                        Entity.ID = st.ID;

                    }
                    else
                        ClientEnvironment.StoreService.SaveOrUpdate(Entity);
                    _modified = true;
                    return true;
                }
            }
            return false;
        }

        public bool Modified
        {
            get 
            {
                return _modified; 
            }
        }

        public bool ReadOnly
        {
            get { return _readonly; }
            set 
            {
                if (_readonly != value)
                {
                    _readonly = value;
                    ChangeReadOnly();
                }
            }
        }

        protected void ChangeReadOnly()
        {
            lookUpRegions.Properties.ReadOnly = ReadOnly;
            teStoreName.Properties.ReadOnly = ReadOnly;
            teAddress.Properties.ReadOnly = ReadOnly;
            teCity.Properties.ReadOnly = ReadOnly;
            tePostCode.Properties.ReadOnly = ReadOnly;
            teArea.Properties.ReadOnly = ReadOnly;
            teInternalId.Properties.ReadOnly = ReadOnly; 
        }


        private void LoadRegions()
        {
            List<Domain.Region> lst = ClientEnvironment.RegionService.FindAll();
            _regionsList.AssignList(lst);

            lookUpRegions.Properties.DataSource = _regionsList;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (Commit())
            {
                if (Modified) DialogResult = DialogResult.OK;
                else DialogResult = DialogResult.Cancel;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}