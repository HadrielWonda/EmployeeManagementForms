using System;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class UCCountryProperties : UCBaseEntity 
    {
        const byte DEFAULT_WARNING_DAYS = 7;
        const byte DEFAULT_MAX_DAYS = 30;

        public UCCountryProperties()
        {
            InitializeComponent();
            btn_Save.Enabled = UCCountryEdit.isUserWriteRight();
        }

        protected override void ChangedReadOnlyState()
        {
            base.ChangedReadOnlyState();
            seWarningTime.Properties.ReadOnly = ReadOnly;
            seCriticalTime.Properties.ReadOnly = ReadOnly;
        }

        public byte WarningDays
        {
            get { return Convert.ToByte(seWarningTime.EditValue) ; }
            set { seWarningTime.EditValue = value; }
        }

        public byte CriticalDays
        {
            get { return Convert.ToByte(seCriticalTime.EditValue); }
            set { seCriticalTime.EditValue = value; }
        }

        public void Init()
        {
        }

        public Domain.Country EntityCountry
        {
            get
            {
                return (Domain.Country)Entity;
            }
        }

        protected override void EntityChanged()
        {
            Bind();
            base.EntityChanged();
        }

        public override void Bind()
        {
            if (EntityCountry != null)
            {
                WarningDays = EntityCountry.WarningDays;
                CriticalDays = EntityCountry.MaxDays;

                if (EntityCountry.IsNew)
                {
                    if (WarningDays == 0) WarningDays = DEFAULT_WARNING_DAYS;
                    if (CriticalDays == 0) CriticalDays = DEFAULT_MAX_DAYS;
                }
            }
            else
            {
                WarningDays = DEFAULT_WARNING_DAYS;
                CriticalDays = DEFAULT_MAX_DAYS;
            }

            ReadOnly = (ClientEnvironment.CountryService.AustriaCountryID == EntityCountry.ID);

            base.Bind();
        }

        public bool IsModified()
        {
            if (EntityCountry != null)
            {
                return (WarningDays != EntityCountry.WarningDays) ||
                       (CriticalDays != EntityCountry.MaxDays);
            }
            else return false;
        }

        public override bool IsValid()
        {
            if (EntityCountry != null)
            {
                bool valid = true;

                if (WarningDays > CriticalDays)
                {
                    seCriticalTime.ErrorText = GetLocalized ("ErrorWarningCriticalDays");
                    valid = false;
                }
                else seCriticalTime.ErrorText = String.Empty;

                if (!valid) return false;

                return base.IsValid();
            }
            else return false;
            
        }

        public override bool Commit()
        {
            if (IsValid())
            {
                if (IsModified())
                {
                    Modified = false;

                    EntityCountry.WarningDays = WarningDays;
                    EntityCountry.MaxDays = CriticalDays;
                    
                    try
                    {
                        ClientEnvironment.CountryService.SaveOrUpdate(EntityCountry);
                    }
                    catch (EntityException ex)
                    {
                        ProcessEntityException(ex);
                        return false;
                    }

                    Modified = true;

                }
                return base.Commit();
            }
            else return false;
        }

        private void UCCountryProperties_Resize(object sender, EventArgs e)
        {
            int la = layoutControl1.Width;
            int cw = this.Width;

            int half = (int)(cw / 2);
            int halflc = (int)(la/2);
            layoutControl1.Left = half - halflc;


            la = layoutControl1.Height;
            cw = this.Height;

            half = (int)(cw / 2);
            halflc = (int)(la / 2);
            layoutControl1.Top = half - halflc;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Commit();
        }


    }
}
