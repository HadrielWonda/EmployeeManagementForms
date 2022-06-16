using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IAuthorizationService : IService
    {
        LoginResult Login(string login, string password, out User resultUser);
        void Logout();
        User GetCurrentUser();
        bool CanExecute(RuntimeMethodHandle rmh, Guid svcId);
        AccessType GetAccess(IService svc);
        AccessType GetAccess(IService svc, UserRole role);
        LoginResult ChangePassword(string oldPassword, string newPassword);
        bool IsUserHasPassword(string loginName);
        LoginResult LoginVersionCheck(string login, string password, out User resultUser, Version clientVersion);
    }
}
