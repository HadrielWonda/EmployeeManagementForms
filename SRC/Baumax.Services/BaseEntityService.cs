using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Services;

namespace Baumax.Services
{
    // Service for base abstract entity. Suppose, it should not be used in client directly
    // Implementing only for importing
    public class BaseEntityService : BaseService<BaseEntity>, IBaseEntityService
    {
    }
}