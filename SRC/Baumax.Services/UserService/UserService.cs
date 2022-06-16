using System;
using System.Collections;
using System.Collections.Generic;

using Spring.Transaction.Interceptor;

using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Util;

namespace Baumax.Services
{
    [ServiceID("8D8053A1-AFA8-4086-8530-B8CCFECC25EA")]
    public class UserService : BaseService<User>, IUserService
    {
        private IRoleService _RoleSvc;
        private IEmployeeService _EmployeeSvc;
        private ICountryService _CountrySvc;
        private IRegionService _RegionSvc;
        private IStoreService _StoreSvc;

        public override IDao<User> Dao
        {
            get
            {
                return _dao;
            }
            set { _dao = value; }
        }
        
        #region IUserService Members

        [AccessType(AccessType.None)]
        public User GetByLogin(string login)
        {
            try
            {
                return UserDao.GetByLogin(login);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public bool UserExist(string login)
        {
            try
            {
                return UserDao.GetByLogin(login) != null;
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public IList<User> GetUserList()
        {
            return FindAll();
        }

        [AccessType(AccessType.Read)]
        public IList<Country> GetUserCountries(long userId)
        {
            return _CountrySvc.GetUserCountries(userId);
        }

        [AccessType(AccessType.Read)]
        public IList<Region> GetUserRegions(long userId)
        {
            return _RegionSvc.GetUserRegions(userId);
        }

       [AccessType(AccessType.Read)]
        public IList<UserRole> GetRoles()
        {
            return _RoleSvc.FindAll();
        }

        [AccessType(AccessType.Read)]
        public Employee GetUserEmployee(long employeeId)
        {
            return _EmployeeSvc.FindById(employeeId);
        }

        [AccessType(AccessType.Read)]
        public IList<Store> GetUserStores(long userId)
        {
            return _StoreSvc.GetUserStores(userId);
        }

        #endregion

        [AccessType(AccessType.Read)]
        public override User FindById(long id)
        {
            User usr = base.FindById(id);
            return usr;
        }

        [AccessType(AccessType.Read)]
        public override List<User> FindAll()
        {
            IList list = base.FindAll();
            if (list == null)
            {
                return null;
            }
            int count = list.Count;
            List<User> result = new List<User>(count);
            for (int i = 0; i < count; i++)
            {
                User usr = (User) list[i];
                result.Add(usr);
            }
            return result;
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public override User SaveOrUpdate(User entity)
        {
            try
            {
                EncodePasswordIfRequired(entity);
                return base.SaveOrUpdate(entity);
            }
            catch(EntityException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new SaveOrUpdateException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public override void SaveOrUpdateList(List<User> entities)
        {
            try 
            {
                EncodePasswordIfRequired(entities);
                base.SaveOrUpdateList(entities);
            }
            catch (EntityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SaveOrUpdateException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public override User Save(User entity)
        {
            try
            {
                EncodePasswordIfRequired(entity);
                return base.Save(entity);
            }
            catch (EntityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public override void SaveList(List<User> entities)
        {
            try
            {
                EncodePasswordIfRequired(entities);
                base.SaveList(entities);
            }
            catch (EntityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
        }

        private void EncodePasswordIfRequired(List<User> users)
        {
            foreach (User user in users)
            {
                EncodePasswordIfRequired(user);
            }
        }

        private static void EncodePasswordIfRequired(User usr)
        {
            if (!string.IsNullOrEmpty(usr.Password) && usr.Password[0] == '#')
            {
                usr.Salt = SaltHashing.CreateRandomSalt();
                usr.Password = SaltHashing.ComputeSaltedHash(usr.Password.Substring(1), usr.Salt);
            }

            /*
            // encode password
            if (usr.IsNew)
            {
                usr.Salt = SaltHashing.CreateRandomSalt();
                usr.Password = SaltHashing.ComputeSaltedHash(usr.Password, usr.Salt);
            }
            //if not new User then get it from DB
            else
            {
                if (usr.Password == null || usr.Password.Length == 0)
                {
                    // shorj: not really sure if this try/catch has to be exactly here
                    try
                    {
                        User tmp = UserDao.FindById(usr.ID);
                        if (tmp != null)
                        {
                            usr.Password = tmp.Password;
                            usr.Salt = tmp.Salt;
                        }
                        return;
                    }
                    catch (Exception ex)
                    {
                        throw new LoadException(ex);
                    }
                }
                else if (usr.Password[0] == '#')
                {
                    usr.Salt = SaltHashing.CreateRandomSalt();
                    usr.Password = SaltHashing.ComputeSaltedHash(usr.Password.Substring(1), usr.Salt);
                }
            }*/
        }

        protected IUserDao UserDao
        {
            get { return (IUserDao)Dao; }
        }
    }
}
