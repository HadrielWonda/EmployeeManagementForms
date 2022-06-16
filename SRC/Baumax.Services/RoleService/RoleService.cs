using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.Services
{
    [ServiceID("5F61F016-3E30-45e4-ACC5-BA9D80437540")]
    public class RoleService: BaseService<UserRole>, IRoleService
    {
    }
}
