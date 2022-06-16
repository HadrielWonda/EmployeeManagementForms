using System;
using System.Collections.Generic;
using System.ComponentModel;
using Baumax.Domain;
using Baumax.Localization;
using DevExpress.XtraEditors;
using Baumax.Environment;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCWorldMinMaxEntity : UCBaseEntity
    {
        private PersonMinMax PersonMinMax 
        {
            set { (Entity as StoreStructureContext).TakePersonMinMax.PersonMinMax = value; }
            get { return (Entity as StoreStructureContext).TakePersonMinMax.PersonMinMax; }
        }

        
        private StoreStructureContext Context
        {
            get { return Entity as StoreStructureContext; }
        }
	

        public UCWorldMinMaxEntity()
        {
            InitializeComponent();
        }


        private short PersonMin
        {
            get
            {
                return Convert.ToInt16(edMinimum.Value);
            }
            set
            {
                edMinimum.EditValue = value;
            }
        }

        private short PersonMax
        {
            get
            {
                return Convert.ToInt16(edMaximum.Value);
            }
            set
            {
                edMaximum.EditValue = value;
            }
        }
        private short Year
        {
            get
            {
                return Convert.ToInt16(edYear.Value);
            }
            set
            {
                edYear.EditValue = value;
            }
        }

        public override bool Commit()
        {
            if (IsModified())
            {
                try
                {

                    PersonMinMax newentity = new PersonMinMax();
                    PersonMinMax.CopyTo(PersonMinMax, newentity);
                    newentity.Year = Year;
                    newentity.Max = PersonMax;
                    newentity.Min = PersonMin;
                    newentity = ClientEnvironment.PersonMinMaxService.SaveOrUpdate(newentity);
                    PersonMinMax.CopyTo(newentity, PersonMinMax);
                    Modified = true;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    return false;
                }
            }
            return true;
        }

        public override void  Bind()
        {
 	        base.Bind();
            if (PersonMinMax != null)
            {
                Year = PersonMinMax.Year;
                PersonMin = PersonMinMax.Min;
                PersonMax = PersonMinMax.Max;

                lbWorldName.Text = Context.TakeStoreWorld.GetWorldName (PersonMinMax.Store_WorldID);
            }
        }

        public bool IsModified()
        {
            return PersonMinMax.IsNew || (Year != PersonMinMax.Year ||
                PersonMin != PersonMinMax.Min ||
                PersonMax != PersonMinMax.Max);
        }

        public override bool IsValid()
        {
            bool isvalid = true;
            if (edMinimum.Value > edMaximum.Value)
            {
                edMaximum.ErrorText = GetLocalized("MinMaxLarge") ?? "Maximum value must be greater minimun value.";
                isvalid = false;
            }
            else
                edMaximum.ErrorText = String.Empty;


            if (Context != null )
            {
                if (!Context.TakePersonMinMax.ValidateEditMinMaxPerson(PersonMinMax.ID, Year, PersonMinMax.Store_WorldID))
                {
                    edYear.ErrorText = GetLocalized("YearExist") ?? "This year is already exist.";
                    isvalid = false;
                }
                else
                    edYear.ErrorText = String.Empty;

            }

            if (!isvalid) return false;

            return base.IsValid();
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
                LocalizerControl.ComponentsLocalize(this.components);
        }
    }
}
