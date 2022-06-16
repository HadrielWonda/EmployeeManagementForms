using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalRoleService : LocalBaseCachingService<UserRole>, IRoleService
    {
    }
}
