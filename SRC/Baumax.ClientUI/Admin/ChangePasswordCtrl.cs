using Baumax.ClientUI.FormEntities;
using Baumax.Contract;
using Baumax.Environment;
using Baumax.Localization;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Baumax.ClientUI.Admin
{
    public partial class ChangePasswordCtrl : UCBaseEntity
    {
        public ChangePasswordCtrl()
        {
            InitializeComponent();
        }

        public override bool Commit()
        {
            if (IsValid())
            {
                LoginResult res =
                    ClientEnvironment.AuthorizationService.ChangePassword(txtOldPassword.Text, txtNewPassword.Text);
                switch (res)
                {
                    case LoginResult.Successful:
                        return true;

                    case LoginResult.WrongLogin:
                    case LoginResult.WrongPassword:
                        dxErrorProvider.SetError(txtOldPassword, GetLocalized("WrongLoginOrPassword"));
                        return false;
                    case LoginResult.UserIsInactive:
                        dxErrorProvider.SetError(txtOldPassword, GetLocalized("UserIsInactive"));
                        return false;
                }
            }

            return false;
        }

        public override bool IsValid()
        {
            bool passwordValid = true;//!string.IsNullOrEmpty(txtNewPassword.Text) && txtNewPassword.Text.Length > 4;
            /*if (!passwordValid)
                dxErrorProvider.SetError(txtNewPassword, GetLocalized("InvalidPassword"));
            else
                dxErrorProvider.SetError(txtNewPassword, "", ErrorType.None);
            */
            if (txtNewPassword.Text == txtOldPassword.Text)
            {
                dxErrorProvider.SetError(txtNewPassword, Localizer.GetLocalized("OldNewPasswordShouldDiffer"));
                dxErrorProvider.SetError(txtOldPassword, Localizer.GetLocalized("OldNewPasswordShouldDiffer"));
                passwordValid = false;
            }
            else if (txtNewPassword.Text != txtRetypeNewPassword.Text)
            {
                dxErrorProvider.SetError(txtNewPassword, Localizer.GetLocalized("PasswordShouldIdentical"));
                dxErrorProvider.SetError(txtRetypeNewPassword, Localizer.GetLocalized("PasswordShouldIdentical"));
                passwordValid = false;
            }
            else
            {
                dxErrorProvider.SetError(txtNewPassword, "", ErrorType.None);
                dxErrorProvider.SetError(txtRetypeNewPassword, "", ErrorType.None);
            }

            return passwordValid;
        }
    }
}