using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        bool UserExist(string login);
        IList<User> GetUserList();
        IList<Country> GetUserCountries(long userId);
        Employee GetUserEmployee(long employeeId);
        User GetByLogin(string login);
        IList<Region> GetUserRegions(long userId);
        IList<Store> GetUserStores(long userId);
        IList<UserRole> GetRoles();
    }
}
