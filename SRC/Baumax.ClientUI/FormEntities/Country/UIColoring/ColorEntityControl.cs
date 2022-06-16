using System;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Country.UIColoring
{
    public partial class ColorEntityControl : UCBaseEntity
    {
        public ColorEntityControl()
        {
            InitializeComponent();
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();

        }
        public Domain.Colouring CountryColor
        {
            get { return (Domain.Colouring)Entity; }
            set 
            {
                if (Entity != value)
                {
                    Entity = value;
                }
            }
        }
        
        public int LowValue
        {
            get { return Convert.ToInt32(seLowValue.EditValue); }
            set { seLowValue.EditValue = value; }
        }
        public int YValue
        {
            get { return Convert.ToInt32(seYValue.EditValue); }
            set { seYValue.EditValue = value; }
        }
        public int XValue
        {
            get { return Convert.ToInt32(seXValue.EditValue); }
            set { seXValue.EditValue = value; }
        }
        public int HighValue
        {
            get { return Convert.ToInt32(seHighValue.EditValue); }
            set { seHighValue.EditValue = value; }
        }

        
        public int NormalColor
        {
            get { return Convert.ToInt32(ceNormalColor.EditValue); }
            set { ceNormalColor.EditValue = value; }
        }
        public int HigherCautionColor
        {
            get { return Convert.ToInt32(ceHigherCautionColor.EditValue); }
            set { ceHigherCautionColor.EditValue = value; }
        }
        public int HigherCriticalColor
        {
            get { return Convert.ToInt32(clHigherCriticalColor.EditValue); }
            set { clHigherCriticalColor.EditValue = value; }
        }
        public int LowCautionColor
        {
            get { return Convert.ToInt32(ceLowCautionColor.EditValue); }
            set { ceLowCautionColor.EditValue = value; }
        }
        public int LowerCriticalColor
        {
            get { return Convert.ToInt32(ceLowerCriticalColor.EditValue); }
            set { ceLowerCriticalColor.EditValue = value; }
        }


        public override void Bind()
        {
            
            base.Bind();

            if (CountryColor == null) return;
            HighValue = CountryColor.H;
            XValue = CountryColor.X;
            YValue = CountryColor.Y;
            LowValue = CountryColor.L;

            HigherCriticalColor = CountryColor.HCColour;
            HigherCautionColor = CountryColor.HColour;
            NormalColor = CountryColor.NColour;
            LowCautionColor = CountryColor.LColour;
            LowerCriticalColor = CountryColor.LCColour;

            lblColorName.Text = CountryColourList.GetColorName ((Domain.CountryColorValueType)CountryColor.ColourType); 
            
        }

        public override bool IsValid()
        {
            bool valid = true;
            if (LowValue >= YValue)
            {
                seLowValue.Focus();
                seLowValue.ErrorText = GetLocalized("InvalidValue") + " ("+ GetLocalized("LowValue") + " < " + GetLocalized("NormalYValue") + ")";
                valid = false;
            }
            else seLowValue.ErrorText = String.Empty;
 
            if (YValue >= XValue)
            {
                seYValue.Focus();
                seYValue.ErrorText = GetLocalized("InvalidValue") + " (" + GetLocalized("NormalYValue") + " < " + GetLocalized("NormalXValue") + ")"; 
                valid = false;
            }
            else seYValue.ErrorText = String.Empty;

            if (XValue >= HighValue)
            {
                seXValue.Focus();
                seXValue.ErrorText = GetLocalized("InvalidValue") + " (" + GetLocalized("NormalYValue") + " < " + GetLocalized("HighValue") + ")"; 
                valid = false;
            }
            else seXValue.ErrorText = String.Empty;

            if (!valid) return false;

            return true;

        }
        public bool IsModified()
        {
            if (LowValue != CountryColor.L || 
                XValue != CountryColor.X || 
                YValue != CountryColor.Y || 
                HighValue != CountryColor.H)
            {
                return true;
            }
            if (LowerCriticalColor != CountryColor.LCColour ||
                HigherCautionColor != CountryColor.HColour ||
                NormalColor != CountryColor.NColour ||
                LowCautionColor != CountryColor.LColour ||
                HigherCriticalColor != CountryColor.HCColour) return true;

            return false;

        }
        public override bool Commit()
        {
            if (CountryColor == null) return true;


            if (CountryColor.IsNew || IsModified())
            {
                
                CountryColor.L = LowValue ;
                CountryColor.Y = YValue ;
                CountryColor.X = XValue ;
                CountryColor.H = HighValue ;

                CountryColor.LCColour = LowerCriticalColor ;
                CountryColor.NColour = NormalColor ;
                CountryColor.HColour = HigherCautionColor ;
                CountryColor.LColour = LowCautionColor ;
                CountryColor.HCColour = HigherCriticalColor ;
                try
                {
                    ClientEnvironment.ColouringService.SaveOrUpdate(CountryColor);
                }
                catch (EntityException ex)
                {
                    // 2think: what details should we show?
                    // 2think: how to localize?
                    using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                    {
                        form.Text = GetLocalized("CannotSaveColouring");
                        form.ShowDialog(this);
                        return false;
                    }
                }
                Modified = true;
            }
            
            return true;
        }

    }
}

