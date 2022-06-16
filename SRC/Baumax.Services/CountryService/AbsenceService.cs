using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Exceptions;

namespace Baumax.Services
{
    [ServiceID("9A8754BB-760E-493b-A7F1-291824EAED5D")]
    public class AbsenceService : BaseService<Absence>, IAbsenceService
    {
        private static bool _IsRunningAbsenceImport = false;
        private static Object _SyncIsRunningAbsenceImport = new Object();

        private static bool IsRunningAbsenceImport
        {
            get { return _IsRunningAbsenceImport; }
            set
            {
                lock (_SyncIsRunningAbsenceImport)
                {
                    if (_IsRunningAbsenceImport != value)
                        _IsRunningAbsenceImport = value;
                }
            }
        }

        private ILongTimeAbsenceService _longTimeAbsenceService;

        #region IAbsenceService Members

        [AccessType(AccessType.Read)]
        public List<Absence> GetCountryAbsences(long countryID)
        {
            try
            {
                return GetTypedListFromIList(((IAbsenceDao) Dao).GetCountryAbsences(countryID));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        public bool IsExistAbsenceNameOrAbbreviation(long? countryID, string name, string charID, long id)
        {
            StringBuilder hql = new StringBuilder("entity.CountryID= :country_id and entity.ID<>:abs_id and (");
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();
            pNames.Add("country_id");
            pValues.Add(countryID);
            pNames.Add("abs_id");
            pValues.Add(id);
            if (name != null)
            {
                hql.Append("entity.Name=:absencename or ");
                pNames.Add("absencename");
                pValues.Add(name);
            }
            hql.Append("entity.CharID=:abrev)");
            pNames.Add("abrev");
            pValues.Add(charID);
            IList lst = FindByNamedParam(hql.ToString(), pNames.ToArray(), pValues.ToArray());
            return (lst != null && lst.Count > 0);
        }

        protected override bool Validate(Absence entity)
        {
            if (IsExistAbsenceNameOrAbbreviation(entity.CountryID, entity.Name, entity.CharID, entity.ID) ||
                _longTimeAbsenceService.IsExistCodeNameOrAbbreviation(entity.CountryID, null, entity.CharID, 0))
            {
                return false;
            }
            return base.Validate(entity);
        }

        [AccessType(AccessType.Import)]
        public SaveDataResult ImportAbsence(List<ImportAbsenceData> list)
        {
            if (IsRunningAbsenceImport)
                throw new AnotherImportRunning();
            IsRunningAbsenceImport = true;
            try
            {
                return ((IAbsenceDao)Dao).ImportAbsence(list);
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
            finally
            {
                IsRunningAbsenceImport = false;
            }
        }

        #endregion
    }
}