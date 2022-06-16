using Baumax.Contract;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.User
{
    public partial class FormUser : FormBaseEntity
    {
        public FormUser()
        {
            InitializeComponent();
            EntityControl = ctrlUser;
            bool canWrite = (ClientEnvironment.AuthorizationService.GetAccess(ClientEnvironment.UserService) &
                           AccessType.Write) != 0;

            ctrlUser.Enabled = canWrite;
            button_OK.Enabled = canWrite;
        }
    }
}