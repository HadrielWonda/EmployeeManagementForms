using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Contract;

namespace Baumax.ClientUI.FormEntities.EntityStore
{
    using Baumax.Domain;
    using Baumax.Contract.QueryResult ;
    using Baumax.Environment;
    using Baumax.Templates;
    using System.ComponentModel ;

    public partial class UCStoreStructure : UCBaseEntity 
    {
        BindingList<StoreStructure> _listEntities = null;
        BindingList<StoreStructure> _fullEntities = null;
        DateTime _filterDate = DateTime.Today;
        StoreManagerContext _context = null;
        public UCStoreStructure()
        {
            InitializeComponent();

            dateEdit1.DateTime = _filterDate;

            gridLookUpEdit1.Properties.PopupFormWidth = gridLookUpEdit1.Width;
            gridColumn_Country.GroupIndex = 0;
            gridColumn_Region.GroupIndex = 1;
        }


        [Browsable (false)]
        public DateTime FilterDate
        {
            get { return _filterDate; }
            set 
            {
                if (value != _filterDate)
                {
                    _filterDate = value;
                    LoadStructures();
                }
            }
        }
        
        public Domain.Store EntityStore
        {
            get
            {
                return (Domain.Store)Entity;
            }
        }

        protected override void EntityChanged()
        {
            if (Entity != null)
            {
                _fullEntities = null;
                LoadStructures();
            }
            else
            {
                _fullEntities = null;
                _listEntities.Clear();
            }
        }

        public StoreManagerContext Context
        {
            get
            {
                return _context;
            }
        }

        public StoreViewList ListOfStoresView
        {
            get
            {
                return Context.ListOfStoresView;
            }
        }

        public void SetStoreContext(StoreManagerContext context)
        {
            _context = context;
            gridLookUpEdit1.Properties.DataSource = ListOfStoresView;

            if (Context.CurrentView != null)
            {
                gridLookUpEdit1.EditValue = Context.CurrentView.ID;
            }
            gridLookUpEdit1.Properties.View.ExpandAllGroups();
            if ((ListOfStoresView != null) && (ListOfStoresView.Count == 1))
            {
                gridLookUpEdit1.EditValue = ListOfStoresView[0].ID;
            }
        }

        public void InitContext()
        {
            _context = new StoreManagerContext();
            _context.Init();
            SetStoreContext(_context);
        }

        void LoadStructures()
        {
            
            _listEntities = new BindingList<StoreStructure>();
            if (_fullEntities == null)
            {
                IList lst = ClientEnvironment.StoreService.GetStoreStructure(EntityStore.ID);
                _fullEntities = new BindingList<StoreStructure>();
                if (lst != null)
                {
                    foreach (StoreStructure str in lst)
                    {
                        _fullEntities.Add(str);
                    }
                }
                PrepareList();
            }

            foreach (StoreStructure str in _fullEntities)
            {
                if (str.HWGR_BeginTime.HasValue)
                {
                    if (ExtractDate(str.HWGR_BeginTime.Value) <= ExtractDate(FilterDate) && ExtractDate(FilterDate) <= ExtractDate(str.HWGR_EndTime.Value ))

                    {
                        if (str.WGR_BeginTime.HasValue)
                        {
                            if (ExtractDate(str.WGR_BeginTime.Value) <= ExtractDate(FilterDate) && ExtractDate(FilterDate) <= ExtractDate(str.WGR_EndTime.Value))
                                _listEntities.Add(str);
                        }
                    }
                }
            }

            gridControl.DataSource = _listEntities;
        }

        private DateTime ExtractDate(DateTime dt)
        {
            return DateTimeHelper.ResetTime(dt);
        }

        private void PrepareList()
        {
            if (_fullEntities != null && _fullEntities.Count > 0)
            {
                List<Domain.HWGR> _lstHwgr = ClientEnvironment.HWGRService.FindAll();
                List<Domain.WGR> _lstWgr = ClientEnvironment.WGRService.FindAll();
                List<Domain.Store> _lstStore = ClientEnvironment.StoreService.FindAll();
                List<Domain.World> _lstWorld = ClientEnvironment.WorldService.FindAll();
                WorldDictionary wdDiction = new WorldDictionary();
                wdDiction.Refresh();

                Dictionary<long, BaseEntity> _diction = new Dictionary<long, BaseEntity>();

                if (_lstStore != null)
                {
                    foreach (Domain.Store store in _lstStore)
                        _diction[store.ID] = store;
                }

                if (_lstHwgr != null)
                {
                    foreach (Domain.HWGR hwgr in _lstHwgr)
                        _diction[hwgr.ID] = hwgr;
                }
                if (_lstWgr != null)
                {
                    foreach (Domain.WGR wgr in _lstWgr)
                        _diction[wgr.ID] = wgr;
                }

                /*if (_lstWorld != null)
                {
                    foreach (Domain.World world in _lstWorld)
                        _diction[world.ID] = world;
                }*/


                BaseEntity item = null;

                foreach (StoreStructure entity in _fullEntities)
                {
                    if (_diction.TryGetValue(entity.StoreID, out item))
                        entity.StoreName = (item as Domain.Store).Name;
                    if (entity.HWGR_ID.HasValue)
                    {
                        if (_diction.TryGetValue(entity.HWGR_ID.Value, out item))
                        {
                            entity.HWGR_Name = (item as Domain.HWGR).Name;
                            entity.HWGR_Name = String.Format("{0} ({1}-{2})", entity.HWGR_Name, entity.HWGR_BeginTime.Value.ToShortDateString(), entity.HWGR_EndTime.Value.ToShortDateString());
                        }
                    }
                    if (entity.WGR_ID.HasValue)
                    {
                        if (_diction.TryGetValue(entity.WGR_ID.Value , out item))
                        {
                            entity.WGR_Name = (item as Domain.WGR).Name;
                            entity.WGR_Name = String.Format("{0} ({1}-{2})", entity.WGR_Name, entity.WGR_BeginTime.Value.ToShortDateString(), entity.WGR_EndTime.Value.ToShortDateString());
                        }
                    }

                    //if (_diction.TryGetValue(entity.WorldID, out item))
//                        entity.WorldName = (item as Domain.World).Name;
                    entity.WorldName = wdDiction.GetNameById(entity.WorldID);


                }
            }

        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            FilterDate = dateEdit1.DateTime;
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit1.EditValue != null)
            {
                object o = gridLookUpEdit1.Properties.View.GetRow(gridLookUpEdit1.Properties.View.FocusedRowHandle);

                if (o != null)
                {
                    StoreView view = (o as StoreView);// _listStoreViews.GetById(Convert.ToInt64(gridLookUpEdit1.EditValue));
                    Context.CurrentView = view;
                    Entity = view.Entity;
                }
            }
            else Entity = null;
        }

        private void UCStoreStructure_Resize(object sender, EventArgs e)
        {
            gridLookUpEdit1.Properties.PopupFormWidth = gridLookUpEdit1.Width;
        }
    }
}
