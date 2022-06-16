using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.AppServer.Environment;

namespace Baumax.Services._HelperObjects.ExEntity
{
    public partial class ExStoreToWorld
    {
        private StoreToWorld entity = null;

        protected BufferHoursService BFService
        {
            get
            {
                return ServerEnvironment.BufferHoursService as BufferHoursService;
            }
        }
        public StoreToWorld Entity
        {
            get { return entity; }
        }
        public ExStoreToWorld(StoreToWorld sw)
        {
            entity = sw;
        }

        public ExStoreToWorld(long storeworldid)
        {
            entity = Service.FindById (storeworldid);
        }


        #region buffer-hours

        List<BufferHours> _bufferhours = null;
        private void LoadBufferHours()
        {
            if (_bufferhours == null)
            {
                List<BufferHours> l = (ServerEnvironment.BufferHoursService as BufferHoursService).GetBufferHours(entity.ID);

                if (l != null)
                    _bufferhours = l;
                else
                    _bufferhours = new List<BufferHours>(1);
            }
        }

        public BufferHours BufferHours(int year)
        {
            LoadBufferHours();
            if (_bufferhours != null)
            {
                foreach (BufferHours bh in _bufferhours)
                    if (bh.Year == year) return bh;
            }
            return null;
        }
        #endregion

        #region min/max
        List<PersonMinMax > _personminmax = null;
        private void LoadMinMax()
        {
            if (_personminmax == null)
            {
                List<PersonMinMax> l = (ServerEnvironment.PersonMinMaxService as PersonMinMaxService).GetPersonMinMaxByStoreWorld(entity.ID);

                if (l != null)
                    _personminmax = l;
                else
                    _personminmax = new List<PersonMinMax>(1);
            }
        }

        public PersonMinMax PersonMinMax(int year)
        {
            LoadMinMax();

            if (_personminmax != null)
            {
                foreach (PersonMinMax mm in _personminmax)
                    if (mm.Year == year) return mm;
            }
            return null;
        }

        #endregion

        #region benchmark
        List<Benchmark> _benchmark = null;
        private void LoadBenchmark()
        {
            if (_benchmark == null)
            {
                List<Benchmark> l = (ServerEnvironment.BenchmarkService as BenchmarkService).GetBenchmarkByStoreWorld(entity.ID);

                if (l != null)
                    _benchmark = l;
                else
                    _benchmark = new List<Benchmark>(1);
            }
        }

        public Benchmark Benchmark(int year)
        {
            LoadBenchmark();
            if (_benchmark != null)
            {
                foreach (Benchmark b in _benchmark)
                    if (b.Year == year) return b;
            }
            return null;
        }
        #endregion
    }

    public partial class ExStoreToWorld
    {
        public static StoreToWorldService Service
        {
            get
            {
                return ServerEnvironment.StoreToWorldService as StoreToWorldService;
            }
        }
        public static BufferHours GetBufferHours(StoreToWorld sw, int year)
        {
            return (new ExStoreToWorld(sw)).BufferHours(year); 
        }
        public static PersonMinMax GetPersonMinMax(StoreToWorld sw, int year)
        {
            return (new ExStoreToWorld(sw)).PersonMinMax(year);
        }
        public static Benchmark GetBenchmark(StoreToWorld sw, int year)
        {
            return (new ExStoreToWorld(sw)).Benchmark(year);
        }
        public static List<StoreToWorld> List(long storeid)
        {
            return ServerEnvironment.StoreToWorldService.FindAllForStore(storeid);
        }

        public static StoreToWorld Get(long storeid, long worldid)
        {
            List<StoreToWorld> lst = List(storeid);
            if (lst != null)
            {
                foreach (StoreToWorld sw in lst)
                    if (sw.WorldID == worldid) return sw;
            }
            throw new ArgumentException(String.Format ("Not found StoreToWorld -StoreId = {0} and WorldId = {1}",storeid, worldid));
        }


        public static Dictionary<long, int?> GetPlannedWorkingSumByStore(long storeid, DateTime monday)
        {
            return Service.GetWorkingHoursByWorlds(storeid, monday, true);
        }
        public static Dictionary<long, int?> GetActialWorkingSumByStore(long storeid, DateTime monday)
        {
            return Service.GetWorkingHoursByWorlds(storeid, monday, false);
        }

    }


}
