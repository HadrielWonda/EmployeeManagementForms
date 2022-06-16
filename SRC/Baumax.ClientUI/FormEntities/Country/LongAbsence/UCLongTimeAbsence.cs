using System;
using System.Diagnostics;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities
{
	public partial class UCLongTimeAbsence : UCBaseEntity
	{
        const int lightWhite = 1, darkWhite = -5, lightBlack = -16777215, darkBlack = -16777218, red = -65536;
	    bool isChecked = false;
		public UCLongTimeAbsence()
		{
			InitializeComponent();
		}

		internal string AbsenceName
		{
			get { return teAbsenceName.Text.Trim(); }
			set { teAbsenceName.Text = value; }
		}

		internal string AbsenceAbbreviation
		{
			get { return teAbsenceAbbreviation.Text.Trim(); }
			set { teAbsenceAbbreviation.Text = value; }
		}

        internal int AbsenceColor
        {
            get
            {
                return Convert.ToInt32(cbLongTimeColor.EditValue);
            }
            set
            {
                cbLongTimeColor.EditValue = value;
            }
        }
	    
		public LongTimeAbsence EntityAbsence
		{
			get { return (LongTimeAbsence)Entity; }
		}

		protected override void EntityChanged()
		{
			base.EntityChanged();
			if(EntityAbsence != null)
			{
				AbsenceName = EntityAbsence.CodeName;
				AbsenceAbbreviation = EntityAbsence.CharID;
                AbsenceColor = EntityAbsence.Color;
			}
		}

		public override bool IsValid()
		{
			bool isValid = true;
		   // Validate: Absence Name should be filled
			if(String.IsNullOrEmpty(AbsenceName))
			{
				teAbsenceName.ErrorText = GetLocalized("InvalidValue");
				isValid = false;
			} else
			{
				teAbsenceName.ErrorText = String.Empty;
			}
			// Validate: Absence abbreviation should be filled
			if(String.IsNullOrEmpty(AbsenceAbbreviation))
			{
				teAbsenceAbbreviation.ErrorText = GetLocalized("InvalidValue");
				isValid = false;
			} else
			{
				teAbsenceAbbreviation.ErrorText = String.Empty;
			}
			return isValid;
		}

	/*	private static void CopyAbsence(LongTimeAbsence source, LongTimeAbsence dest)
		{
			Debug.Assert(source != null);
			Debug.Assert(dest != null);
			Debug.Assert(!source.Equals(dest));

			dest.ID = source.ID;
			dest.Code = source.Code;
			dest.CodeName = source.CodeName;
			dest.CharID = source.CharID;
			dest.CountryID = source.CountryID;
			dest.Import = source.Import;
		}
*/
		public bool IsModified()
		{
			if(EntityAbsence == null)
			{
				return false;
			} 
			else
			{
				return (AbsenceName != EntityAbsence.CodeName || AbsenceAbbreviation != EntityAbsence.CharID || AbsenceColor != EntityAbsence.Color);
			}
		}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (EntityAbsence.IsNew) 
                AbsenceColor = red;
        }

		public override bool Commit()
		{
		    if (!IsModified())
                return base.Commit();
		    else
		        if(IsValid())
			    {
                    if (!isChecked && ((AbsenceColor < lightWhite && AbsenceColor > darkWhite) || (AbsenceColor < lightBlack && AbsenceColor > darkBlack)))
                    {
                        InfoMessage(GetLocalized("err_enter_absence_colour"));
                        cbLongTimeColor.Focus();
                        isChecked = true;
                        return false;
                    }
			        LongTimeAbsence copyAbsence = new LongTimeAbsence();
                    LongTimeAbsence.CopyTo(EntityAbsence, copyAbsence); //CopyAbsence();

				    copyAbsence.CodeName = AbsenceName;
				    copyAbsence.CharID = AbsenceAbbreviation;
                    copyAbsence.Color = AbsenceColor;
			        try
				    {
					    Debug.Assert(copyAbsence.CountryID > 0);

					    copyAbsence = ClientEnvironment.LongTimeAbsenceService.SaveOrUpdate(copyAbsence);

                        LongTimeAbsence.CopyTo(copyAbsence, EntityAbsence);
					    Modified = true;
					    return base.Commit();
				    } 
			        catch(DBDuplicateKeyException)
				    {
					    ErrorMessage(GetLocalized("ErrorLongTimeAbsenceNameExists"));
					    teAbsenceName.Focus();
					    return false;
				    }
			    } 
			    else
				    return false;
			
		}
	}
}