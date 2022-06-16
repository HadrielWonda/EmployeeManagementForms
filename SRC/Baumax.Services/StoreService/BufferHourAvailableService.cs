using System;
using System.Collections.Generic;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Contract.Interfaces;

namespace Baumax.Services
{
    [ServiceID("B5F3DCDD-0F1B-4010-B610-D97282A0922B")]
    public class BufferHourAvailableService : BaseService<BufferHourAvailable>, IBufferHourAvailableService
    {
        private IEmployeeService _employeeService;

        private IBufferHourAvailableDao BufferHourAvailableDao
        {
            get { return (IBufferHourAvailableDao)Dao; }
        }

        #region IBufferHourAvailableService Members


        public List<BufferHourAvailable> GetAvailableBufferHoursForYear(long storeworldid, int year)
        {
            return BufferHourAvailableDao.GetAvailableBufferHoursForYear(storeworldid, year);
        }

        public List<BufferHourAvailable> GetAvailableBufferHours(long storeworldid, DateTime aBegin,DateTime aEnd)
        {
            return BufferHourAvailableDao.GetAvailableBufferHours(storeworldid, aBegin, aEnd);
        }

        public List<BufferHourAvailable> GetAvailableBufferHoursForStore(long storeid, DateTime aBegin, DateTime aEnd)
        {
            return BufferHourAvailableDao.GetAvailableBufferHoursForStore (storeid, aBegin, aEnd);
        }

        public List<BufferHourAvailable> GetAvailableBufferHoursForStore(long storeid, int year)
        {
            return BufferHourAvailableDao.GetAvailableBufferHoursForStore(storeid, year);
        }
        
        public BufferHourAvailable GetBufferHoursAvailable(long storeworldid, DateTime date)
        {
            return BufferHourAvailableDao.GetBufferHoursAvailable(storeworldid, date);
        }
        // from date to ,,,,
        public List<BufferHourAvailable> GetBufferHoursAvailableFrom(long storeworldid, DateTime date)
        {
            return BufferHourAvailableDao.GetBufferHoursAvailableFrom(storeworldid, date);
        }

        public void SaveOrUpdate2(BufferHourAvailable entity)
        {
            BufferHourAvailableDao.SaveOrUpdate2(entity);
        }
        #endregion
    }
}