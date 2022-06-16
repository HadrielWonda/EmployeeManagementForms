using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.Services._HelperObjects
{
    public class EmployeePlanningWorkingModelHelper
    {

        EmployeePlanningWorkingModelService _service = null;

        public EmployeePlanningWorkingModelHelper(IEmployeePlanningWorkingModelService service)
        {
            if (service == null)
                throw new ArgumentNullException();

            _service = (service as EmployeePlanningWorkingModelService);

            if (_service == null)
                throw new ArgumentNullException();
        }

        public void SaveEmployeeWorkingModel(EmployeePlanningWeek week)
        {
            List<EmployeePlanningWorkingModel> lst = PlanningWeekProcessor.GetWorkingModels(week);

            SaveEmployeeWorkingModel(week.EmployeeId, lst, week.BeginDate, week.EndDate);
        }

        public void SaveEmployeeWorkingModel(List<EmployeePlanningWeek> lstWeeks)
        {
            if (lstWeeks == null || lstWeeks.Count == 0) return;
            foreach (EmployeePlanningWeek week in lstWeeks)
                SaveEmployeeWorkingModel(week);

        }

        public void SaveEmployeeWorkingModel2(List<EmployeePlanningWeek> lstWeeks)
        {
            if (lstWeeks == null || lstWeeks.Count == 0) return;
            List<EmployeePlanningWorkingModel> lstEntities = new List<EmployeePlanningWorkingModel>(lstWeeks.Count*10);
            
            long[] ids = new long[lstWeeks.Count];
            int index = 0;
            DateTime begin, end;

            begin = lstWeeks[0].BeginDate;
            end = lstWeeks[0].EndDate;

            foreach (EmployeePlanningWeek week in lstWeeks)
            {
                ids[index++] = week.EmployeeId;

                List<EmployeePlanningWorkingModel> lst = PlanningWeekProcessor.GetWorkingModels(week);
                if (lst != null && lst.Count > 0)
                    lstEntities.AddRange(lst);


                
            }
            //SaveEmployeesWorkingModel(ids, lstEntities, begin,end);

        }


        public void SaveEmployeeWorkingModel(long emplid, List<EmployeePlanningWorkingModel> lst, DateTime aBegin,DateTime aEnd)
        {
            if (lst == null)
                throw new ArgumentNullException();

            List<EmployeePlanningWorkingModel> oldList = LoadEmployeeWorkingModel(emplid, aBegin, aEnd);

            if (oldList == null)
                oldList = new List<EmployeePlanningWorkingModel>();

            int iCount = Math.Max(lst.Count, oldList.Count);

            EmployeePlanningWorkingModel newModel = null;
            EmployeePlanningWorkingModel oldModel = null;
            for (int i = 0; i < iCount; i++)
            {
                newModel = null;
                oldModel = null;

                if (i < lst.Count)
                    newModel = lst[i];

                if (i < oldList.Count)
                    oldModel = oldList[i];

                if (newModel != null && oldModel != null)
                {
                    oldModel.Date = newModel.Date;
                    oldModel.AdditionalCharge = newModel.AdditionalCharge;
                    oldModel.Hours = newModel.Hours;
                    oldModel.WorkingModelID = newModel.WorkingModelID;

                    _service.Update(oldModel);

                    newModel.ID = oldModel.ID;
                    continue;
                }

                if (newModel == null)
                {
                    _service.DeleteByID(oldModel.ID);
                    continue;
                }

                if (oldModel == null)
                {
                    newModel.ID = 0;
                    _service.SaveOrUpdate(newModel);
                    continue;
                }
            }

        }
        public void SaveEmployeesWorkingModel(long[] emplids, List<EmployeePlanningWorkingModel> lst, DateTime aBegin, DateTime aEnd)
        {
            if (lst == null)
                throw new ArgumentNullException();

            List<EmployeePlanningWorkingModel> oldList = LoadEmployeesWorkingModel(emplids, aBegin, aEnd);

            if (oldList == null)
                oldList = new List<EmployeePlanningWorkingModel>();

            int iCount = Math.Max(lst.Count, oldList.Count);

            EmployeePlanningWorkingModel newModel = null;
            EmployeePlanningWorkingModel oldModel = null;
            for (int i = 0; i < iCount; i++)
            {
                newModel = null;
                oldModel = null;

                if (i < lst.Count)
                    newModel = lst[i];

                if (i < oldList.Count)
                    oldModel = oldList[i];

                if (newModel != null && oldModel != null)
                {
                    oldModel.EmployeeID = newModel.EmployeeID;
                    oldModel.Date = newModel.Date;
                    oldModel.AdditionalCharge = newModel.AdditionalCharge;
                    oldModel.Hours = newModel.Hours;
                    oldModel.WorkingModelID = newModel.WorkingModelID;

                    _service.Update(oldModel);

                    newModel.ID = oldModel.ID;
                    continue;
                }

                if (newModel == null)
                {
                    _service.DeleteByID(oldModel.ID);
                    continue;
                }

                if (oldModel == null)
                {
                    newModel.ID = 0;
                    _service.SaveOrUpdate(newModel);
                    continue;
                }
            }

        }
        


        public List<EmployeePlanningWorkingModel> LoadEmployeeWorkingModel(long emplid, DateTime aBegin, DateTime aEnd)
        {
            List<EmployeePlanningWorkingModel> resultList = null;

            resultList = _service.LoadByEmployeeAndDateRange(emplid, aBegin, aEnd);

            return resultList;
        }
        public List<EmployeePlanningWorkingModel> LoadEmployeesWorkingModel(long[] emplids, DateTime aBegin, DateTime aEnd)
        {
            List<EmployeePlanningWorkingModel> resultList = null;

            resultList = _service.LoadByEmployeesAndDateRange (emplids, aBegin, aEnd);

            return resultList;
        }



        public void SaveEmployeeWorkingModel(EmployeeWeek week)
        {
            List<EmployeeWorkingModel> lst = EmployeeWeekProcessor.GetWorkingModels(week);

            List<EmployeePlanningWorkingModel> lstEntities = new List<EmployeePlanningWorkingModel>(lst.Count);
            EmployeePlanningWorkingModel entity = null;
            foreach (EmployeeWorkingModel model in lst)
            {
                entity = new EmployeePlanningWorkingModel();
                model.AssignTo(entity);
                lstEntities.Add(entity);
            }


            SaveEmployeeWorkingModel(week.EmployeeId, lstEntities, week.BeginDate, week.EndDate);
        }


        public void SaveEmployeeWorkingModel_old(List<EmployeeWeek> lstWeeks)
        {
            if (lstWeeks == null || lstWeeks.Count == 0) return;

            foreach (EmployeeWeek week in lstWeeks)
                SaveEmployeeWorkingModel(week);
        }


        public void SaveEmployeeWorkingModel(List<EmployeeWeek> lstWeeks)
        {
            if (lstWeeks == null || lstWeeks.Count == 0) return;

            long[] ids = EmployeeWeekProcessor.GetEmployeeIds(lstWeeks);
            List<EmployeePlanningWorkingModel> lstEntities = new List<EmployeePlanningWorkingModel>(lstWeeks.Count*10);
            DateTime begin, end;

            begin = lstWeeks[0].BeginDate;
            end = lstWeeks[0].EndDate;
            EmployeePlanningWorkingModel entity = null;

            foreach (EmployeeWeek week in lstWeeks)
            {
                foreach (EmployeeDay day in week.DaysList)
                {
                    if (day.WorkingModels != null && day.WorkingModels.Count > 0)
                    {
                        foreach (EmployeeWorkingModel model in day.WorkingModels)
                        {
                            entity = new EmployeePlanningWorkingModel();
                            model.AssignTo(entity);
                            lstEntities.Add(entity);
                        }
                    }
                }
            }


            SaveEmployeesWorkingModel(ids, lstEntities, begin, end);
        }

    }


    public class EmployeeRecordingWorkingModelHelper
    {
        private EmployeeRecordingWorkingModelService _service = null;

        public EmployeeRecordingWorkingModelHelper(IEmployeeRecordingWorkingModelService service)
        {
            if (service == null)
                throw new ArgumentNullException();

            _service = (service as EmployeeRecordingWorkingModelService);

            if (_service == null)
                throw new ArgumentNullException();
        }

        public List<EmployeeRecordingWorkingModel> LoadEmployeeWorkingModel(long emplid, DateTime aBegin, DateTime aEnd)
        {
            List<EmployeeRecordingWorkingModel> resultList = null;

            resultList = _service.LoadByEmployeeAndDateRange(emplid, aBegin, aEnd);

            return resultList;
        }
        public List<EmployeeRecordingWorkingModel> LoadEmployeesWorkingModel(long[] emplids, DateTime aBegin, DateTime aEnd)
        {
            List<EmployeeRecordingWorkingModel> resultList = null;

            resultList = _service.LoadByEmployeesAndDateRange(emplids, aBegin, aEnd);

            return resultList;
        }

        public void SaveEmployeeWorkingModel(EmployeeWeek week)
        {
            List<EmployeeWorkingModel> lst = EmployeeWeekProcessor.GetWorkingModels(week);

            List<EmployeeRecordingWorkingModel> lstEntities = new List<EmployeeRecordingWorkingModel>(lst.Count);
            EmployeeRecordingWorkingModel entity = null;
            foreach (EmployeeWorkingModel model in lst)
            {
                entity = new EmployeeRecordingWorkingModel();
                model.AssignTo(entity);
                lstEntities.Add(entity);
            }


            SaveEmployeeWorkingModel(week.EmployeeId, lstEntities, week.BeginDate, week.EndDate);
        }

        public void SaveEmployeeWorkingModel_old(List<EmployeeWeek> lstWeeks)
        {
            if (lstWeeks == null || lstWeeks.Count == 0) return;

            foreach (EmployeeWeek week in lstWeeks)
                SaveEmployeeWorkingModel(week);
        }

        public void SaveEmployeeWorkingModel(List<EmployeeWeek> lstWeeks)
        {
            if (lstWeeks == null || lstWeeks.Count == 0) return;

            long[] ids = EmployeeWeekProcessor.GetEmployeeIds(lstWeeks);
            List<EmployeeRecordingWorkingModel> lstEntities = new List<EmployeeRecordingWorkingModel>(lstWeeks.Count * 10);
            DateTime begin, end;

            begin = lstWeeks[0].BeginDate;
            end = lstWeeks[0].EndDate;
            EmployeeRecordingWorkingModel entity = null;

            foreach (EmployeeWeek week in lstWeeks)
            {
                foreach (EmployeeDay day in week.DaysList)
                {
                    if (day.WorkingModels != null && day.WorkingModels.Count > 0)
                    {
                        foreach (EmployeeWorkingModel model in day.WorkingModels)
                        {
                            entity = new EmployeeRecordingWorkingModel();
                            model.AssignTo(entity);
                            lstEntities.Add(entity);
                        }
                    }
                }
            }


            SaveEmployeesWorkingModel(ids, lstEntities, begin, end);
        }

        public void SaveEmployeeWorkingModel(long emplid, List<EmployeeRecordingWorkingModel> lst, DateTime aBegin, DateTime aEnd)
        {
            if (lst == null)
                throw new ArgumentNullException();

            List<EmployeeRecordingWorkingModel> oldList = LoadEmployeeWorkingModel(emplid, aBegin, aEnd);

            if (oldList == null)
                oldList = new List<EmployeeRecordingWorkingModel>();

            int iCount = Math.Max(lst.Count, oldList.Count);

            EmployeeRecordingWorkingModel newModel = null;
            EmployeeRecordingWorkingModel oldModel = null;
            for (int i = 0; i < iCount; i++)
            {
                newModel = null;
                oldModel = null;

                if (i < lst.Count)
                    newModel = lst[i];

                if (i < oldList.Count)
                    oldModel = oldList[i];

                if (newModel != null && oldModel != null)
                {
                    oldModel.Date = newModel.Date;
                    oldModel.AdditionalCharge = newModel.AdditionalCharge;
                    oldModel.Hours = newModel.Hours;
                    oldModel.WorkingModelID = newModel.WorkingModelID;

                    _service.Update(oldModel);

                    newModel.ID = oldModel.ID;
                    continue;
                }

                if (newModel == null)
                {
                    _service.DeleteByID(oldModel.ID);
                    continue;
                }

                if (oldModel == null)
                {
                    newModel.ID = 0;
                    _service.SaveOrUpdate(newModel);
                    continue;
                }
            }

        }
        public void SaveEmployeesWorkingModel(long[] emplids, List<EmployeeRecordingWorkingModel> lst, DateTime aBegin, DateTime aEnd)
        {
            if (lst == null)
                throw new ArgumentNullException();

            List<EmployeeRecordingWorkingModel> oldList = LoadEmployeesWorkingModel(emplids, aBegin, aEnd);

            if (oldList == null)
                oldList = new List<EmployeeRecordingWorkingModel>();

            int iCount = Math.Max(lst.Count, oldList.Count);

            EmployeeRecordingWorkingModel newModel = null;
            EmployeeRecordingWorkingModel oldModel = null;
            for (int i = 0; i < iCount; i++)
            {
                newModel = null;
                oldModel = null;

                if (i < lst.Count)
                    newModel = lst[i];

                if (i < oldList.Count)
                    oldModel = oldList[i];

                if (newModel != null && oldModel != null)
                {
                    oldModel.EmployeeID = newModel.EmployeeID;
                    oldModel.Date = newModel.Date;
                    oldModel.AdditionalCharge = newModel.AdditionalCharge;
                    oldModel.Hours = newModel.Hours;
                    oldModel.WorkingModelID = newModel.WorkingModelID;

                    _service.Update(oldModel);

                    newModel.ID = oldModel.ID;
                    continue;
                }

                if (newModel == null)
                {
                    _service.DeleteByID(oldModel.ID);
                    continue;
                }

                if (oldModel == null)
                {
                    newModel.ID = 0;
                    _service.SaveOrUpdate(newModel);
                    continue;
                }
            }

        }
    }
}
