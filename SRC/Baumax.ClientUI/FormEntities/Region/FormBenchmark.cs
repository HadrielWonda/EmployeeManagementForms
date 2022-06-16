using System;
using System.Collections.Generic;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Region
{
    public partial class FormBenchmark : FormBaseEntity 
    {
        Store _store = null;
        bool _modified = false;
        private Benchmark _entity;


        public FormBenchmark()
        {
            InitializeComponent();
             seYear.Value = DateTime.Today.Year;
             button_Cancel.Left = panelBottom.Width - 20 - button_Cancel.Width;
        }

        public Store EntityStore
        {
            set
            {
                _store = value;

                if (_store != null)
                {
                    teStore.Text = _store.Name;
                }
            }
        }

        public Benchmark EntityBenchmark
        {
            get { return _entity; }
            set 
            {
                if (_entity != value)
                {
                    _entity = value;
                    ChangedEntity();
                }
            }
        }

        private void ChangedEntity()
        {
            if (EntityBenchmark != null)
            {
                StoreWorldId = EntityBenchmark.StoreWorldID;
                Year = EntityBenchmark.Year;
                Value = EntityBenchmark.Value;
            }
        }

        public void SetStoreWorlds(List<StoreToWorld> lst)
        {
            lookUpWorlds.Properties.DataSource = lst;

            if (lst != null && lst.Count > 0)
            {
                lookUpWorlds.EditValue = lst[0].ID;
            }
        }


        public long StoreWorldId
        {
            get 
            {
                if (lookUpWorlds.EditValue == null) return -1;
                return Convert.ToInt64(lookUpWorlds.EditValue);
            }
            set 
            {
                lookUpWorlds.EditValue = value; 
            }
        }
        public short Year
        {
            get 
            {
                return Convert.ToInt16(seYear.Value);
            }
            set 
            {
                seYear.Value = value; 
            }
        }
        public double Value
        {
            get 
            {
                return Convert.ToDouble(seBenchmark.Value); 
            }
            set 
            {
                seBenchmark.Value = Convert.ToDecimal(value); 
            }
        }

        public void SetReadOnly()
        {
            lookUpWorlds.Properties.ReadOnly = true;
            seYear.Properties.ReadOnly = true;
            lookUpWorlds.Enabled = false;
            seYear.Enabled = false;
        }

        bool IsModified()
        {
            return (EntityBenchmark == null) || (EntityBenchmark.Year != Year) || (EntityBenchmark.StoreWorldID != StoreWorldId) ||
                (EntityBenchmark.Value != Value);
        }

        protected override bool SaveEntity()
        {
            _modified = false;

            if (EntityBenchmark == null || EntityBenchmark.IsNew)
            {
                if (!InsertEntity()) return false;
            }
            else if (!UpdateEntity()) return false;

            return base.SaveEntity();
        }

        private bool CheckExistStoreWorldID(long _StoreWorldID, List<Benchmark> _cols)
        {
            if (_cols == null) return false;
            foreach (Benchmark _col in _cols)
                if (_col.StoreWorldID == _StoreWorldID) return true;
            return false;
        }

        bool InsertEntity()
        {
            if (EntityBenchmark == null || EntityBenchmark.IsNew)
            {
                Benchmark bench = ClientEnvironment.StoreService.BenchmarkService.CreateEntity();

                bench.StoreWorldID = StoreWorldId;
                bench.Year = Year;
                bench.Value = Value;

                try
                {
                    List<Benchmark> cols = ClientEnvironment.StoreService.BenchmarkService.GetBenchmarkFiltered(_store.ID, Year, Year);
                    if (cols == null || cols.Count == 0 || !CheckExistStoreWorldID(bench.StoreWorldID, cols))
                    {
                        bench = ClientEnvironment.StoreService.BenchmarkService.Save(bench);

                        StoreToWorld sw = (StoreToWorld)lookUpWorlds.Properties.GetDataSourceRowByKeyValue(StoreWorldId);

                        if (sw != null)
                            bench.WorldName = sw.WorldName;
                        _entity = bench;

                        _modified = true;
                        return true;
                    }
                    else throw new DBDuplicateKeyException();
                }
                catch(DBDuplicateKeyException)
                {
                    ErrorMessage(GetLocalized ("WorldYearBenchmarkExist"), GetLocalized ("Attention"));
                    return false;
                }
            }
            return true;
        }
        bool UpdateEntity()
        {
            if (EntityBenchmark != null && IsModified ())
            {
                Benchmark bench = ClientEnvironment.StoreService.BenchmarkService.CreateEntity();
                bench.ID = EntityBenchmark.ID;
                bench.StoreWorldID = StoreWorldId;
                bench.Year = Year;
                bench.Value = Value;
                try
                {
                    bench = ClientEnvironment.StoreService.BenchmarkService.SaveOrUpdate(bench);

                    EntityBenchmark.Year = bench.Year;
                    EntityBenchmark.StoreWorldID = bench.StoreWorldID;
                    EntityBenchmark.Value = bench.Value;

                    _modified = true;
                    return true;
                }
                catch (ValidationException)
                {
                    ErrorMessage(GetLocalized("ErrorBenchmarkDontExists"));
                    return false;
                }
            }
            return true;
        }

        protected override bool ValidateEntity()
        {
            if (StoreWorldId == -1)
            {
                ErrorMessage(GetLocalized("ErrorSelectWorld"));
                lookUpWorlds.Focus();
                return false;
            }
            return base.ValidateEntity();
        }
        public override bool Modified
        {
            get
            {
                return _modified;
            }
        }

        
    }
}