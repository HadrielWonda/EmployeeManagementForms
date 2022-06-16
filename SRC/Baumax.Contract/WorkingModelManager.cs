using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using System.Diagnostics;
using Baumax.Contract.QueryResult;
using Baumax.Contract.WorkingModelConditions;
using Baumax.Contract.Interfaces;
using Baumax.Contract.TimePlanning;


namespace Baumax.Contract
{
    public class WorkingModelManager : IWorkingModelManager
    {
        private IWorkingModelService _modelService = null;
        private long _countryId = 0;

        LunchBrakeModelManager _lunchManager = null;

        private List<WorkingModel> _listmodels = new List<WorkingModel>();
        private Dictionary<long, WorkingModelWrapper> _diction = new Dictionary<long, WorkingModelWrapper>();

        private List<WorkingModelWrapper> _dailyModels = new List<WorkingModelWrapper>();
        private List<WorkingModelWrapper> _weeklyModels = new List<WorkingModelWrapper>();
        private List<WorkingModelWrapper> _weeklyMessagesModels = new List<WorkingModelWrapper>();

        public WorkingModelManager(IWorkingModelService service)
        {
            _modelService = service;

            _lunchManager = new LunchBrakeModelManager(service);

        }

        public WorkingModelManager(IWorkingModelService service, long countryid)
            : this(service)
        {
            CountryId = countryid;
            
        }
        public long CountryId
        {
            get { return _countryId; }
            set
            {
                if (_countryId != value)
                {
                    _countryId = value;
                    LoadWorkingModels();
                    if (_lunchManager != null)
                        _lunchManager.CountryId = value;
                }
            }
        }
        public List<WorkingModel> List
        {
            get { return _listmodels; }
        }

        public WorkingModelWrapper this[long wmid]
        {
            get
            {
                if (_diction.ContainsKey(wmid))
                    return _diction[wmid];
                else
                    return null;
            }
        }


        private void LoadWorkingModels()
        {


            _listmodels.Clear();
            _diction.Clear();
            _dailyModels.Clear();
            _weeklyMessagesModels.Clear();
            _weeklyModels.Clear();

            if (CountryId > 0)
            {
                List<WorkingModel> l = _modelService.GetCountryWorkingModel(CountryId, null, null);

                if (l != null) _listmodels.AddRange(l);

                foreach (WorkingModel wm in _listmodels)
                {
                    WorkingModelWrapper item = new WorkingModelWrapper(wm);
                    _diction[wm.ID] = item;

                    if (item.IsWeekModel)
                    {
                        if (item.IsWeekMessageModel)
                            _weeklyMessagesModels.Add(item);
                        else
                            _weeklyModels.Add(item);
                    }
                    else _dailyModels.Add(item);
                }
            }


        }

        public void Calculate(EmployeePlanningWeek planningweek)
        {

            if (_lunchManager != null)
                _lunchManager.Process(planningweek);

            planningweek.CalculateWithoutWorkingModels();

            CalculateDailyWorkingModels(planningweek);
            CalculateWeeklyWorkingModels(planningweek);
            planningweek.CalculateAfterWorkingModels();
            CalculateWeeklyMessageOrSaldoWorkingModels(planningweek);
        }

        public void CalculateNew(EmployeeWeek planningweek, bool bPlanned)
        {
            //planningweek.CalculateBeforeWorkingModels ();
            //CalculateDailyWorkingModels(daysInfo, planningweek);
            //CalculateWeeklyWorkingModels(daysInfo, planningweek);
            //planningweek.CalculateAfterWorkingModels();
            //CalculateWeeklyMessageOrSaldoWorkingModels(daysInfo, planningweek);
        }

        
        

        #region old methods - need remove later

        private void CalculateDailyWorkingModels(EmployeePlanningWeek planningweek)
        {
            #region daily calculation
            if (planningweek.IsValidWeek)
            {
                EmployeePlanningWorkingModel entity = null;
                foreach (EmployeePlanningDay epd in planningweek.Days.Values)
                {
                    epd.CountDailyAdditionalCharges = 0;
                    epd.WorkingModels = null;
                    // if day don't have - contractr, relation or it under long absence
                    if (epd.IsBlockedDay) continue;

                    foreach (WorkingModelWrapper wrap in _dailyModels)
                    {
                        if (!DateTimeHelper.Between(epd.Date, wrap.Model.BeginTime, wrap.Model.EndTime)) continue;

                        if (wrap.Validate(planningweek, epd.Date))
                        {
                            entity = new EmployeePlanningWorkingModel();
                            entity.EmployeeID = epd.EmployeeId;
                            entity.Date = epd.Date;
                            entity.WorkingModelID = wrap.Model.ID;

                            if (!wrap.IsMessageModel)
                            {
                                entity.Hours = wrap.GetModelValue;
                                entity.AdditionalCharge = wrap.Model.AddCharges;

                                if (wrap.Model.AddCharges)
                                {
                                    epd.CountDailyAdditionalCharges += entity.Hours;
                                }
                                else
                                {
                                    epd.CountDailyPlannedWorkingHours += entity.Hours;
                                }
                            }
                            
                            if (epd.WorkingModels == null)
                                epd.WorkingModels = new List<EmployeePlanningWorkingModel>();
                            epd.WorkingModels.Add(entity);
                        }
                    }

                }
            }
            #endregion
        }

        private void CalculateWeeklyWorkingModels(EmployeePlanningWeek planningweek)
        {
            if (planningweek.IsValidWeek)
            {
                EmployeePlanningDay epday = planningweek.Days[planningweek.EndDate];
                EmployeePlanningWorkingModel entity = null;
                foreach (WorkingModelWrapper wrap in _weeklyModels)
                {
                    if (!DateTimeHelper.IsIntersectInc(wrap.Model.BeginTime, wrap.Model.EndTime,
                        planningweek.BeginDate, planningweek.EndDate)) continue;

                    if (wrap.Validate(/*daysInfo, */planningweek, planningweek.BeginDate))
                    {
                        entity = new EmployeePlanningWorkingModel();
                        entity.EmployeeID = epday.EmployeeId;
                        entity.Date = epday.Date;
                        entity.WorkingModelID = wrap.Model.ID;

                        if (!wrap.IsMessageModel)
                        {
                            entity.AdditionalCharge = wrap.Model.AddCharges ;
                            entity.Hours += wrap.GetModelValue; ;

                            if (wrap.Model.AddCharges)
                            {
                                epday.CountDailyAdditionalCharges += entity.Hours;// result += DateTimeHelper.RoundToQuoter((short)(60 * wrap.Model.AddValue));
                            }
                            else
                            {
                                epday.CountDailyPlannedWorkingHours  += entity.Hours; //result += DateTimeHelper.RoundToQuoter((short)(wrap.Hours * wrap.Model.MultiplyValue - wrap.Hours));
                            }
                        }
                        if (epday.WorkingModels == null)
                            epday.WorkingModels = new List<EmployeePlanningWorkingModel>();
                        epday.WorkingModels.Add(entity);
                    }
                }
            }
        }

        private void CalculateWeeklyMessageOrSaldoWorkingModels(EmployeePlanningWeek planningweek)
        {
            if (planningweek.IsValidWeek)
            {
                EmployeePlanningDay epday = planningweek.Days[planningweek.EndDate];
                EmployeePlanningWorkingModel entity = null;
                foreach (WorkingModelWrapper wrap in _weeklyMessagesModels)
                {
                    if (!DateTimeHelper.IsIntersectInc(wrap.Model.BeginTime, wrap.Model.EndTime,
                        planningweek.BeginDate, planningweek.EndDate)) continue;

                    if (wrap.Validate(planningweek, planningweek.BeginDate))
                    {
                        entity = new EmployeePlanningWorkingModel();
                        entity.EmployeeID = epday.EmployeeId;
                        entity.Date = epday.Date;
                        entity.WorkingModelID = wrap.Model.ID;
                        
                        if (epday.WorkingModels == null)
                            epday.WorkingModels = new List<EmployeePlanningWorkingModel>();

                        epday.WorkingModels.Add(entity);
                    }
                }
            }
        }

        

        #endregion

    }






    public class WorkingModelManagerNew : IWorkingModelManager
    {
        private IWorkingModelService _modelService = null;
        private long _countryId = 0;

        LunchBrakeModelManager _lunchManager = null;
        private List<WorkingModel> _listmodels = new List<WorkingModel>();
        private Dictionary<long, WorkingModelWrapperNew> _diction = new Dictionary<long, WorkingModelWrapperNew>();

        private List<WorkingModelWrapperNew> _dailyModels = new List<WorkingModelWrapperNew>();
        private List<WorkingModelWrapperNew> _weeklyModels = new List<WorkingModelWrapperNew>();
        private List<WorkingModelWrapperNew> _weeklyMessagesModels = new List<WorkingModelWrapperNew>();

        public WorkingModelManagerNew(IWorkingModelService service)
        {
            _modelService = service;
            _lunchManager = new LunchBrakeModelManager(service);
        }

        public WorkingModelManagerNew(IWorkingModelService service, long countryid)
            : this(service)
        {
            CountryId = countryid;
            
        }
        public long CountryId
        {
            get { return _countryId; }
            set
            {
                if (_countryId != value)
                {
                    _countryId = value;
                    LoadWorkingModels();
                    if (_lunchManager != null)
                        _lunchManager.CountryId = value;
                }
            }
        }
        public List<WorkingModel> List
        {
            get { return _listmodels; }
        }

        public WorkingModelWrapperNew this[long wmid]
        {
            get
            {
                if (_diction.ContainsKey(wmid))
                    return _diction[wmid];
                else
                    return null;
            }
        }


        private void LoadWorkingModels()
        {


            _listmodels.Clear();
            _diction.Clear();
            _dailyModels.Clear();
            _weeklyMessagesModels.Clear();
            _weeklyModels.Clear();

            if (CountryId > 0)
            {
                List<WorkingModel> l = _modelService.GetCountryWorkingModel(CountryId, null, null);

                if (l != null) _listmodels.AddRange(l);

                foreach (WorkingModel wm in _listmodels)
                {
                    WorkingModelWrapperNew item = new WorkingModelWrapperNew(wm);
                    _diction[wm.ID] = item;

                    if (item.IsWeekModel)
                    {
                        if (item.IsWeekMessageModel)
                            _weeklyMessagesModels.Add(item);
                        else
                            _weeklyModels.Add(item);
                    }
                    else _dailyModels.Add(item);
                }
            }


        }
        public void Calculate(EmployeePlanningWeek planningweek)
        {
        }

        public void CalculateNew(EmployeeWeek planningweek, bool bPlanned)
        {
            if (_lunchManager != null)
                _lunchManager.Process(planningweek);

            planningweek.CalculateBeforeWorkingModels();
            CalculateDailyWorkingModels(planningweek);
            CalculateWeeklyWorkingModels(planningweek);
            planningweek.CalculateAfterWorkingModels();
            CalculateWeeklyMessageOrSaldoWorkingModels(planningweek);
        }

        private void CalculateDailyWorkingModels(EmployeeWeek planningweek)
        {
            #region daily calculation

            Debug.Assert(planningweek != null);

            if (planningweek.IsValidWeek)
            {
                EmployeeWorkingModel entity = null;
                foreach (EmployeeDay epd in planningweek.DaysList)
                {
                    epd.CountDailyAdditionalCharges = 0;
                    epd.WorkingModels = null;

                    if (!epd.IsValidDay) continue;

                    foreach (WorkingModelWrapperNew wrap in _dailyModels)
                    {
                        if (!planningweek.PlannedWeek)
                        {
                            if (!wrap.Model.UseInRecording) continue;

                        }

                        if (!DateTimeHelper.Between(epd.Date, wrap.Model.BeginTime, wrap.Model.EndTime)) continue;

                        if (wrap.Validate(planningweek, epd.Date))
                        {
                            entity = new EmployeeWorkingModel();
                            entity.EmployeeID = epd.EmployeeId;
                            entity.Date = epd.Date;
                            entity.WorkingModelID = wrap.Model.ID;
                            // modify 20.12.2007 
                            if (!wrap.IsMessageModel)
                            {
                                entity.Hours = wrap.GetModelValue ;
                                entity.AdditionalCharge = wrap.Model.AddCharges;

                                if (wrap.Model.AddCharges)
                                {
                                    epd.CountDailyAdditionalCharges += entity.Hours;
                                }
                                else
                                {
                                    epd.CountDailyPlannedWorkingHours += entity.Hours;
                                }
                                //if (wrap.Model.AddCharges)
                                //{
                                //    entity.AdditionalCharge = true;
                                //    if (wrap.Model.AddValue != 0)
                                //    {
                                //        entity.Hours += DateTimeHelper.RoundToQuoter((short)(60 * wrap.Model.AddValue));
                                //        epd.CountDailyAdditionalCharges += DateTimeHelper.RoundToQuoter((short)(60 * wrap.Model.AddValue));
                                //    }
                                //    if (wrap.Model.MultiplyValue != 0)
                                //    {
                                //        entity.Hours = DateTimeHelper.RoundToQuoter((short)(wrap.Hours * wrap.Model.MultiplyValue - wrap.Hours));
                                //        epd.CountDailyAdditionalCharges += DateTimeHelper.RoundToQuoter((short)(wrap.Hours * wrap.Model.MultiplyValue - wrap.Hours));
                                //    }
                                //}
                                //else
                                //{
                                //    entity.AdditionalCharge = false;
                                //    if (wrap.Model.AddValue != 0)
                                //    {
                                //        entity.Hours += DateTimeHelper.RoundToQuoter((short)(60 * wrap.Model.AddValue));
                                //        epd.CountDailyPlannedWorkingHours += DateTimeHelper.RoundToQuoter((short)(60 * wrap.Model.AddValue));
                                //    }
                                //    if (wrap.Model.MultiplyValue != 0)
                                //    {
                                //        entity.Hours += DateTimeHelper.RoundToQuoter((short)(wrap.Hours * wrap.Model.MultiplyValue - wrap.Hours));
                                //        epd.CountDailyPlannedWorkingHours += DateTimeHelper.RoundToQuoter((short)(wrap.Hours * wrap.Model.MultiplyValue - wrap.Hours));
                                //    }

                                //}
                            }

                            if (epd.WorkingModels == null)
                                epd.WorkingModels = new List<EmployeeWorkingModel>();
                            epd.WorkingModels.Add(entity);
                        }
                    }

                }
            }
            #endregion
        }


        private void CalculateWeeklyWorkingModels(EmployeeWeek planningweek)
        {
            Debug.Assert(planningweek != null);

            if (planningweek.IsValidWeek)
            {
                EmployeeDay epday = planningweek.GetDay(planningweek.EndDate);
                EmployeeWorkingModel entity = null;

                foreach (WorkingModelWrapperNew wrap in _weeklyModels)
                {
                    if (!planningweek.PlannedWeek)
                    {
                        if (!wrap.Model.UseInRecording) continue;

                    }

                    if (!DateTimeHelper.IsIntersectInc(wrap.Model.BeginTime, wrap.Model.EndTime,
                        planningweek.BeginDate, planningweek.EndDate)) continue;

                    if (wrap.Validate(planningweek, planningweek.BeginDate))
                    {
                        entity = new EmployeeWorkingModel();
                        entity.EmployeeID = epday.EmployeeId;
                        entity.Date = epday.Date;
                        entity.WorkingModelID = wrap.Model.ID;
                        if (!wrap.IsMessageModel)
                        {
                            entity.Hours = wrap.GetModelValue;
                            entity.AdditionalCharge = wrap.Model.AddCharges;

                            if (wrap.Model.AddCharges)
                            {
                                epday.CountDailyAdditionalCharges += entity.Hours;
                            }
                            else
                            {
                                epday.CountDailyPlannedWorkingHours += entity.Hours;
                            }
                        }
                        //if (!wrap.IsMessageModel)
                        //{
                        //    int result = 0;
                        //    if (wrap.Model.AddValue != 0)
                        //    {
                        //        result += DateTimeHelper.RoundToQuoter((short)(60 * wrap.Model.AddValue));
                        //    }
                        //    if (wrap.Model.MultiplyValue != 0)
                        //    {
                        //        result += DateTimeHelper.RoundToQuoter((short)(wrap.Hours * wrap.Model.MultiplyValue - wrap.Hours));
                        //    }

                        //    if (wrap.Model.AddCharges)
                        //    {
                        //        entity.AdditionalCharge = true;
                        //        entity.Hours = result;
                        //        epday.CountDailyAdditionalCharges += result;

                        //    }
                        //    else
                        //    {
                        //        entity.AdditionalCharge = false;
                        //        entity.Hours = result;
                        //        epday.CountDailyPlannedWorkingHours += result;
                        //    }
                        //}
                        if (epday.WorkingModels == null)
                            epday.WorkingModels = new List<EmployeeWorkingModel>();
                        epday.WorkingModels.Add(entity);
                    }
                }
            }
        }

        private void CalculateWeeklyMessageOrSaldoWorkingModels(EmployeeWeek planningweek)
        {
            if (planningweek.IsValidWeek)
            {
                EmployeeDay epday = planningweek.GetDay(planningweek.EndDate);
                EmployeeWorkingModel entity = null;
                foreach (WorkingModelWrapperNew wrap in _weeklyMessagesModels)
                {
                    if (!planningweek.PlannedWeek)
                    {
                        if (!wrap.Model.UseInRecording) continue;

                    }
                    if (!DateTimeHelper.IsIntersectInc(wrap.Model.BeginTime, wrap.Model.EndTime,
                        planningweek.BeginDate, planningweek.EndDate)) continue;

                    if (wrap.Validate(planningweek, planningweek.BeginDate))
                    {
                        if (wrap.IsMessageModel)
                        {
                            entity = new EmployeeWorkingModel();
                            entity.EmployeeID = epday.EmployeeId;
                            entity.Date = epday.Date;
                            entity.WorkingModelID = wrap.Model.ID;


                            if (epday.WorkingModels == null)
                                epday.WorkingModels = new List<EmployeeWorkingModel>();
                            epday.WorkingModels.Add(entity);
                        }
                    }
                }
            }
        }

    }
}
