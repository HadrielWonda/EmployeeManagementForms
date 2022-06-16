using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;

namespace Baumax.Services
{
    [ServiceID("D01247A6-DED0-49ed-B5C9-181BAB48F3A8")]
    public class PersonMinMaxService : BaseService<PersonMinMax>, IPersonMinMaxService
    {

        public IPersonMinMaxDao ServiceDao { get { return (IPersonMinMaxDao)Dao; } }
        protected override bool Validate(PersonMinMax entity)
        {
            IList list =
                Dao.FindByNamedParam(
                    @" entity.Store_WorldID = :storeworldid AND entity.Year = :year ",
                    new string[] {"storeworldid", "year"},
                    new object[] {entity.Store_WorldID, entity.Year});
            if ((list != null) && (list.Count > 0))
            {
                if (entity.IsNew)
                {
                    return false;
                }
                else
                {
                    foreach (PersonMinMax e in list)
                    {
                        if (e.ID != entity.ID)
                        {
                            return false;
                        }
                    }
                }
            }
            return base.Validate(entity);
        }

        #region IPersonMinMaxService Members

        [AccessType(AccessType.Read)]
        public List<PersonMinMax> GetPersonMinMaxFiltered(long storeID)
        {
            try
            {
                return GetTypedListFromIList(ServiceDao.GetPersonMinMaxFiltered(storeID));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        [AccessType(AccessType.Read)]
        public List<PersonMinMax> GetPersonMinMaxFiltered(long storeID, int year)
        {
            try
            {
                return GetTypedListFromIList(ServiceDao.GetPersonMinMaxFiltered(storeID, year));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public PersonMinMax GetPersonMinMaxByStoreWorld(long storeworldID, int year)
        {
            try
            {
                return ServiceDao.GetPersonMinMaxByStoreWorld(storeworldID, year);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        public List<PersonMinMax> GetPersonMinMaxByStoreWorld(long storeworldID)
        {
            return ServiceDao.GetPersonMinMaxByStoreWorld(storeworldID);
        }
        #endregion
    }
}