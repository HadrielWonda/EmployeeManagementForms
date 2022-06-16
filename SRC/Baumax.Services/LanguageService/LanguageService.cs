using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Util;

namespace Baumax.Services
{
    [ServiceID("5F58A713-C043-4c94-8613-AE9789A872AE")]
    public class LanguageService : BaseService<Language>, ILanguageService
    {
        #region Private fields

        private IUIResourceDao _resDao;

        #endregion

        #region Properties

        public IUIResourceDao ResDao
        {
            get { return _resDao; }
            set { _resDao = value; }
        }

        #endregion

        #region ILanguageService Members

        [AccessType(AccessType.Read)]
        public List<UIResource> GetResources(long langID)
        {
            try
            {
                return TypedListConverter<UIResource>.ToTypedList(_resDao.FindForLanguage(langID));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        private void MergeResourceListWithSavedResources(ICollection<UIResource> list)
        {
            if ((list == null) || (list.Count == 0))
            {
                return;
            }

            // prepare dictionary for selecting from DB
            Dictionary<long, List<int>> curResDictionary = new Dictionary<long, List<int>>(2);
            foreach (UIResource entity in list)
            {
                if (curResDictionary.ContainsKey(entity.LanguageID))
                {
                    long langId = entity.LanguageID;
                    if (curResDictionary[langId] == null)
                    {
                        curResDictionary[langId] = new List<int>();
                    }
                    curResDictionary[langId].Add(entity.ResourceID);
                }
                else
                {
                    curResDictionary.Add(entity.LanguageID, new List<int>(new int[] {entity.ResourceID}));
                }
            }

            // select current resources for merge
            // 2think: should we implement reading in the one "SELECT" with big condition string and many parameters?
            StringBuilder condition = new StringBuilder();
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();
            List<UIResource> savedResources = new List<UIResource>();
            foreach (long langId in curResDictionary.Keys)
            {
                condition.Length = 0;
                pNames.Clear();
                pValues.Clear();
                pNames.Add("langid");
                pValues.Add(langId);
                condition.AppendFormat("entity.LanguageID = :langid AND entity.ResourceID IN ({0})",
                                       QueryUtils.GenIDList(
                                           curResDictionary[langId].ConvertAll<long>(
                                               delegate(int value) { return value; }), pNames, pValues));
                List<UIResource> curLanguageResources =
                    TypedListConverter<UIResource>.ToTypedList(
                        _resDao.FindByNamedParam(condition.ToString(), pNames.ToArray(), pValues.ToArray()));
                if ((curLanguageResources != null) && (curLanguageResources.Count > 0))
                {
                    savedResources.AddRange(curLanguageResources);
                }
            }

            // merge IDs
            if (savedResources.Count > 0)
            {
                foreach (UIResource entity in list)
                {
                    if (entity.ID <= 0)
                    {
                        if (curResDictionary.ContainsKey(entity.LanguageID))
                        {
                            long langId = entity.LanguageID;
                            UIResource savedResource =
                                savedResources.Find(
                                    delegate(UIResource res)
                                    {
                                        return ((res.LanguageID == langId) &&
                                                (res.ResourceID == entity.ResourceID));
                                    });
                            if (savedResource != null)
                            {
                                entity.ID = savedResource.ID;
                            }
                        }
                    }
                }
            }
        }

        private void DeleteDupesFromResourceList(List<UIResource> list)
        {
            if ((list == null) || (list.Count == 0))
            {
                return;
            }

            int i = 0;
            while (i < list.Count - 1)
            {
                if (list[i] != null)
                {
                    int lastIndex =
                        list.FindIndex(i + 1,
                                       delegate(UIResource entity)
                                       {
                                           return
                                               ((entity.LanguageID == list[i].LanguageID) &&
                                                (entity.ResourceID == list[i].ResourceID));
                                       });
                    if(lastIndex > 0)
                    {
                        list.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }


        [AccessType(AccessType.Write)]
        public void UpdateResources(List<UIResource> list)
        {
            if ((list == null) || (list.Count == 0))
            {
                return;
            }

            DeleteDupesFromResourceList(list);

            List<long> failedIDs = list.ConvertAll<long>(delegate(UIResource entity) { return entity.ID; });

            Exception error = null;
            try
            {
                MergeResourceListWithSavedResources(list);

                List<long> idList = new List<long>();
                foreach (UIResource entity in list)
                {
                    long oldID = entity.ID;
                    if (entity.ID < 0)
                    {
                        entity.ID = 0;
                    }
                    UIResource savedEntity;
                    try
                    {
                        savedEntity = _resDao.SaveOrUpdate(entity);
                    }
                    catch (Exception ex)
                    {
                        // remember last error to show something comprehensible
                        error = ex;
                        continue;
                    }
                    idList.Add(savedEntity.ID);
                    failedIDs.Remove(oldID);
                }
                _resDao.OnDaoEntitiesChanged(idList);
            }
            catch (Exception ex)
            {
                error = ex;
                throw new SaveOrUpdateException(failedIDs.Count > 0 ? failedIDs.ToArray() : null, ex);
            }
            finally
            {
                if (failedIDs.Count > 0)
                {
                    throw new SaveOrUpdateException(failedIDs.ToArray(), error);
                }
            }
        }

        public override void Delete(Language entity)
        {
            if (entity.ID == SharedConsts.NeutralLangId)
            {
                throw new ValidationException(new long[] {entity.ID}, null);
            }
            base.Delete(entity);
        }

        public override void DeleteByID(long id)
        {
            if (id == SharedConsts.NeutralLangId)
            {
                throw new ValidationException(new long[] {id}, null);
            }
            base.DeleteByID(id);
        }

        public override void DeleteList(List<Language> entities)
        {
            foreach (Language entity in entities)
            {
                if (entity.ID == SharedConsts.NeutralLangId)
                {
                    throw new ValidationException(new long[] {entity.ID}, null);
                }
            }
            base.DeleteList(entities);
        }

        public override void DeleteListByID(List<long> ids)
        {
            foreach (long id in ids)
            {
                if (id == SharedConsts.NeutralLangId)
                {
                    throw new ValidationException(new long[] {id}, null);
                }
            }
            base.DeleteListByID(ids);
        }

        //2think: whether it should be implemented in C#? this is DB-constraints level logic.
        //!this checks are not even required by current specification (25.07.2007)
        //TODO: Give more informative name to method
        [AccessType(AccessType.Read)]
        public LanguageCheckError CheckLanguage(string languageName, string languageCode, long id)
        {
            try
            {
                List<string> pNames = new List<string>();
                List<object> pValues = new List<object>();
                StringBuilder sb = new StringBuilder("entity.Name = :lname");
                pNames.Add("lname");
                pValues.Add(languageName);
                if (id > 0)
                {
                    sb.Append(" AND entity.ID <> :id");
                    pNames.Add("id");
                    pValues.Add(id);
                }
                IList list = FindByNamedParam(sb.ToString(), pNames.ToArray(), pValues.ToArray());
                if ((list != null) && (list.Count > 0))
                {
                    return LanguageCheckError.LanguageNameExists;
                }

                // language code now is not editable in UI
                /*
                sb.Length = 0;
                pNames.Clear();
                pValues.Clear();
                sb.Append("SELECT entity FROM Language entity WHERE entity.LanguageCode = :lcode ");
                pNames.Add("lcode");
                pValues.Add(languageCode);
                if (id > 0)
                {
                    sb.Append(" AND entity.ID <> :id");
                    pNames.Add("id");
                    pValues.Add(id);
                }
                list = FindByNamedParam(sb.ToString(), pNames.ToArray(), pValues.ToArray());
                if ((list != null) && (list.Count > 0))
                {
                    return LanguageCheckError.LanguageNameExists;
                }
                */
                return LanguageCheckError.OK;
            }
            catch (Exception ex)
            {
                throw new ValidationException(ex);
            }
        }

        #endregion
    }
}