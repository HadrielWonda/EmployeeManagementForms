using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract;
using System.Diagnostics;
using Baumax.AppServer.Environment;

namespace Baumax.Services._HelperObjects
{
    public class TrendCorrectionHelper
    {
        private TrendCorrectionService _service = null;
        private List<TrendCorrection> _listEntities = new List<TrendCorrection>();
        private TrendCorrection _cache_entity = null;

        public TrendCorrectionHelper(ITrendCorrectionService service)
        {
            if (service == null)
                throw new ArgumentNullException();

            _service = (service as TrendCorrectionService);
        }

        public TrendCorrectionHelper()
        {
            _service = ServerEnvironment.TrendCorrectionService as TrendCorrectionService;

            if (_service == null)
                throw new ArgumentNullException();
        }

        public bool IsExistsForWorld(long storeworldid)
        {
            return _listEntities.Exists (
                                    delegate(TrendCorrection trend)
                                    {
                                        return (trend.StoreWorldID == storeworldid);
                                            
                                    }
                                 );

            
        }

        public bool IsExistsForWorldByDateRange(long storeworldid, DateTime begin, DateTime end)
        {
            Debug.Assert(begin < end);

            return _listEntities.Exists(
                                    delegate(TrendCorrection trend)
                                    {
                                        return (trend.StoreWorldID == storeworldid)
                                            && DateTimeHelper.IsIntersectExc(begin, end, trend.BeginTime, trend.EndTime);

                                    }
                                 );


        }
        

        public void LoadByStoreAndDateRange(long storeid, DateTime aBegin, DateTime aEnd)
        {
            _listEntities.Clear();

            List<TrendCorrection> lst = 
                _service.GetTrendCorrectionFiltered(storeid, aBegin, aEnd);

            if (lst != null)
                _listEntities.AddRange(lst);
        }


        public double GetTrendCorrection(long storeworldid, DateTime date)
        {
            if (_listEntities == null || _listEntities.Count == 0) 
                return 1;


            if (_cache_entity != null)
            {
                if (_cache_entity.StoreWorldID == storeworldid &&
                    DateTimeHelper.Between(date, _cache_entity.BeginTime, _cache_entity.EndTime))
                    return _cache_entity.Value;

                _cache_entity = null;
            }

            TrendCorrection trend = _listEntities.Find(delegate(TrendCorrection trend1)
                                                        {
                                                            if (trend1.StoreWorldID == storeworldid)
                                                                return DateTimeHelper.Between(date, trend1.BeginTime, trend1.EndTime);
                                                            else return false;
                                                        }
                                                       );
            _cache_entity = trend;
            //foreach (TrendCorrection trend in _listEntities)
            //{
            //    if (DateTimeHelper.IsHitInInterval(date, trend.BeginTime, trend.EndTime))
            //        return trend.Value;
            //}

            return (trend != null) ? trend.Value : 1;
        }
    }
}
