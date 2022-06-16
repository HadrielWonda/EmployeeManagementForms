using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Environment;
using Spring.Context;
using Spring.Context.Support;

namespace Baumax.LocalServices
{
    public class LocalUserService : LocalBaseCachingService<User>, IUserService
    {
        private IUserService RemoteService
        {
            get { return (IUserService)_remoteService; }
        }
        
        #region IUserService Members

        public bool UserExist(string login)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();

                User res = _cache.Find(delegate(User item)
                                       {
                                           return string.Compare(item.LoginName, login, true) == 0;
                                       }
                    );
                return res != null;
            }
            return RemoteService.UserExist(login);
        }

        public IList<User> GetUserList()
        {
            return base.FindAll();
        }

        public IList<Country> GetUserCountries(long userId)
        {
            return ClientEnvironment.CountryService.GetUserCountries(userId);
        }

        public IList<Store> GetUserStores(long userId)
        {
            return ClientEnvironment.StoreService.GetUserStores(userId);
        }

        public Employee GetUserEmployee(long employeeId)
        {
            return ClientEnvironment.EmployeeService.FindById(employeeId);
        }

        public User GetByLogin(string login)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();

                User res = _cache.Find(delegate(User item)
                                       {
                                           return string.Compare(item.LoginName, login, true) == 0;
                                       }
                    );
                return res;
            }
            return RemoteService.GetByLogin(login);
        }

        public IList<UserRole> GetRoles()
        {
            return ClientEnvironment.RoleService.FindAll();
        }

        public IList<Region> GetUserRegions(long userId)
        {
            return ClientEnvironment.RegionService.GetUserRegions(userId); 
        }

        #endregion
    }
}
