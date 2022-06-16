using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Dao
{
    public interface IUserDao: IDao<User>
    {
        User GetByLogin(string login);
    }
}
