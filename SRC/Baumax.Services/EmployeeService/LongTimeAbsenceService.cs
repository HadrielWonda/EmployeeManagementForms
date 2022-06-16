using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;
using Baumax.Contract.Exceptions;

namespace Baumax.Services
{
    [ServiceID("F6903242-8334-4aeb-B5BB-6CBDFCB64664")]
    public class LongTimeAbsenceService : BaseService<LongTimeAbsence>, ILongTimeAbsenceService
    {
        private IAbsenceService _absenceService;

        private static bool _IsRunningLongTimeAbsenceImport = false;
        private static Object _SyncIsRunningLongTimeAbsenceImport = new Object();

        private static bool IsRunningLongTimeAbsenceImport
        {
            get { return _IsRunningLongTimeAbsenceImport; }
            set
            {
                lock (_SyncIsRunningLongTimeAbsenceImport)
                {
                    if (_IsRunningLongTimeAbsenceImport != value)
                        _IsRunningLongTimeAbsenceImport = value;
                }
            }
        }

        [AccessType(AccessType.Import)]
        public SaveDataResult ImportLongTimeAbsence(List<ImportLongTimeAbsenceData> list)
        {
            if (IsRunningLongTimeAbsenceImport)
                throw new AnotherImportRunning();
            IsRunningLongTimeAbsenceImport = true;
            try
            {
                return ((ILongTimeAbsenceDao)Dao).ImportLongTimeAbsence(list);
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
            finally
            {
                IsRunningLongTimeAbsenceImport = false;
            }
        }

        [AccessType(AccessType.Read)]
        public List<LongTimeAbsence> FindAllByCountry(long countryid)
        {
            try
            {
                return ((ILongTimeAbsenceDao) Dao).FindAllByCountry(countryid);
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
        }

        public bool IsExistCodeNameOrAbbreviation(long? countryID, string codeName, string charID, long id)
        {
            StringBuilder hql = new StringBuilder("entity.CountryID= :country_id and entity.ID<>:abs_id and (");
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();
            pNames.Add("country_id");
            pValues.Add(countryID);
            pNames.Add("abs_id");
            pValues.Add(id);
            if (codeName != null)
            {
                hql.Append("entity.CodeName=:absencename or ");
                pNames.Add("absencename");
                pValues.Add(codeName);
            }
            hql.Append("entity.CharID=:abrev)");
            pNames.Add("abrev");
            pValues.Add(charID);
            IList lst = FindByNamedParam(hql.ToString(), pNames.ToArray(), pValues.ToArray());
            return (lst != null && lst.Count > 0);
        }

        protected override bool Validate(LongTimeAbsence entity)
        {
            if (IsExistCodeNameOrAbbreviation(entity.CountryID, entity.CodeName, entity.CharID, entity.ID) ||
                _absenceService.IsExistAbsenceNameOrAbbreviation(entity.CountryID, null, entity.CharID, 0))
            {
                return false;
            }
            return base.Validate(entity);
        }
    }
}