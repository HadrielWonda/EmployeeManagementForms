using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.Interfaces
{
    public interface IServerFacade
    {
        IUserService UserService
        { get; set;}
        IAuthorizationService AuthorizationService
        {get; set;}

        void Test();
    }
}
