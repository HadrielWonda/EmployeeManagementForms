using DevExpress.XtraEditors.DXErrorProvider;

namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class EmployeeCtrl : UCBaseEntity
    {
        public EmployeeCtrl()
        {
            InitializeComponent();
        }

        public override bool IsValid()
        {
            bool firstNameValid = !string.IsNullOrEmpty(teFirstName.Text);
            if (!firstNameValid)
            {
                dxErrorProvider.SetError(teFirstName, GetLocalized("FirstNameShouldBeNotEmpty"));
            }
            else
            {
                dxErrorProvider.SetError(teFirstName, "", ErrorType.None);
            }

            bool secondNameValid = !string.IsNullOrEmpty(teSecondName.Text);
            if (!secondNameValid)
            {
                dxErrorProvider.SetError(teSecondName, GetLocalized("SecondNameShouldBeNotEmpty"));
            }
            else
            {
                dxErrorProvider.SetError(teSecondName, "", ErrorType.None);
            }

            bool pidValid = !string.IsNullOrEmpty(tePersonalID.Text);
            if (!pidValid)
            {
                dxErrorProvider.SetError(tePersonalID, GetLocalized("PersonalIdNameShouldBeNotEmpty"));
            }
            else
            {
                long id;
                if (!long.TryParse(tePersonalID.Text, out id))
                {
                    dxErrorProvider.SetError(tePersonalID, GetLocalized("PersonalIdShouldBeNumber"));
                }
                else
                {
                    dxErrorProvider.SetError(tePersonalID, "", ErrorType.None);
                }
            }
            return firstNameValid && secondNameValid && pidValid;
        }

        public override void Bind()
        {
            Domain.Employee emp = (Domain.Employee) Entity;
            teFirstName.Text = emp.FirstName;
            teSecondName.Text = emp.LastName;
            tePersonalID.Text = emp.PersID;
        }

        public override bool Commit()
        {
            if (!IsValid())
            {
                return false;
            }

            Domain.Employee emp = (Domain.Employee) Entity;

            if (emp.FirstName != teFirstName.Text)
            {
                emp.FirstName = teFirstName.Text;
                Modified = true;
            }

            if (emp.LastName != teSecondName.Text)
            {
                emp.LastName = teSecondName.Text;
                Modified = true;
            }

            if (emp.PersID != tePersonalID.Text)
            {
                emp.PersID = tePersonalID.Text;
                Modified = true;
            }
            return true;
        }

        protected override void EntityChanged()
        {
            base.EntityChanged();
            Bind();
        }
    }
}