using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.ComponentModel;

namespace Baumax.ClientUI.FormEntities
{
    using Baumax.Domain;
    using Baumax.Environment;


    public enum RegionViewMode
    {
        ShowAll,
        ShowByCountry
    }

    public class RegionView
    {
        private Domain.Region _entity;
        private string _countryname;

        public RegionView(Domain.Region entity)
        {
            if (entity == null) throw new NullReferenceException();
            _entity = entity;

            UpdateProperties();

        }

        public long ID
        {
            get { return Entity.ID; }
        }
        public string RegionName
        {
            get { return Entity.Name; }
        }
        

        public string CountryName
        {
            get { return _countryname; }
        }


        public Domain.Region Entity
        {
            get { return _entity; }
            set 
            {
                if (_entity != value)
                {
                    _entity = value;
                    UpdateProperties();
                }

            }
        }



        public void UpdateProperties()
        {
            _countryname = String.Empty;
            Domain.Country country = null;
            if (Entity != null && Entity.CountryID > 0)
            {
                country = ClientEnvironment.CountryService.FindById(Entity.CountryID);
                if (country != null) _countryname = country.Name;
            }
        }
    }





    public class RegionViewBindingList : BindingList<RegionView>
    {
        public void AssignList(ICollection lst)
        {
            if (lst != null)
            {
                foreach (Domain.Region reg in lst)
                    this.Add(new RegionView(reg));
            }
        }


        public RegionView FindById(long id)
        {
            foreach (RegionView reg in this)
                if (reg.ID == id) return reg;

            return null;
        }

        public Domain.Region FindRegionById(long id)
        {
            RegionView reg = FindById(id);

            return (reg == null) ? null : reg.Entity;
        }

    }


    public class WorldDictionary : Dictionary<long, Domain.World>
    {
        public void Refresh()
        {
            this.Clear();

            List<Domain.World> lst = ClientEnvironment.WorldService.FindAll();

            AssignWorlds(lst);
        }

        public void AssignWorlds(IList lst)
        {
            if (lst != null)
            {
                foreach (Domain.World w in lst)
                {
                    if (!ContainsKey(w.ID))
                    {
                        this[w.ID] = w;
                    }
                }
            }
        }

        public string GetNameById(long id)
        {
            if (this.ContainsKey(id))
                return this[id].Name;
            else return String.Empty;
        }

        public void FillEmployeeRelation(IList lstRelations)
        {
            if (lstRelations != null)
            {
                foreach (EmployeeRelation relation in lstRelations)
                {
                    if (relation.WorldID.HasValue )
                        relation.WorldName = GetNameById(relation.WorldID.Value); 
                }
            }
        }

        public long GetAdministarionWorld()
        {
            foreach (Domain.World w in this.Values)
                if (w.WorldTypeID == WorldType.Administration) return w.ID;

            return 0;
        }

        public WorldType GetWorldType(long id)
        {
            return this[id].WorldTypeID;
        }
    }


    public class StoreWorldController
    {
        Dictionary <long, Domain.StoreToWorld> _list = new Dictionary <long, StoreToWorld>();
        WorldDictionary _worldDiction = new WorldDictionary();

        public StoreWorldController()
        {
            _worldDiction.Refresh();
        }

        public WorldDictionary Worlds
        {
            get
            {
                return _worldDiction;
            }
        }
        public void AddList(List<StoreToWorld> lst)
        {
            if (lst != null)
            {
                StoreToWorld sw = null;
                for (int i = 0; i < lst.Count; i++)
			    {
                    sw = lst[i];
                    if (!_list.ContainsKey(sw.ID))
                    {
                        _list[sw.ID] = sw;
                        sw.WorldName = _worldDiction.GetNameById(sw.WorldID); 
                    }
			    }
                
            }
        }


        public List<StoreToWorld> GetListByStoreId(long id)
        {
            List<StoreToWorld> result = new List<StoreToWorld>();

            foreach (StoreToWorld sw in _list.Values)
            {
                if (sw.StoreID == id) result.Add(sw);
            }

            return result;
        }
        public bool IsExistsStoreWorld(long storeid)
        {
            foreach (StoreToWorld sw in _list.Values)
            {
                if (sw.StoreID == storeid) return true;
            }
            return false;
        }
        public void LoadByRegionId(long id)
        {
            List<StoreToWorld> lst = ClientEnvironment.StoreService.StoreToWorldService.FindAllForRegion (id);
            AddList(lst);
        }

        public void LoadByStoreId(long id)
        {
            List<StoreToWorld> lst = ClientEnvironment.StoreService.StoreToWorldService.FindAllForStore(id);

            AddList(lst);
        }

        public StoreToWorld GetById(long id)
        {
            StoreToWorld sw = null;

            _list.TryGetValue(id, out sw);

            return sw;
        }

        public string GetWorldNameById(long id)
        {
            StoreToWorld sw = GetById(id);
            if (sw == null) return String.Empty;
            else return _worldDiction.GetNameById(sw.WorldID);
        }

        public WorldType GetWorldType(long storeworldid)
        {
            StoreToWorld sw = GetById(storeworldid);
            if (sw != null) 
            {
                return Worlds.GetWorldType(sw.WorldID);
            }

            throw new NullReferenceException();
        }

        public void FillBechmarks(List<Domain.Benchmark> lst)
        {
            if (lst != null && lst.Count > 0)
            {
                foreach (Domain.Benchmark b in lst)
                    b.WorldName = GetWorldNameById(b.StoreWorldID);
            }
        }
        public void FillBufferHours(List<Domain.BufferHours> lst)
        {
            if (lst != null && lst.Count > 0)
            {
                foreach (Domain.BufferHours b in lst)
                    b.WorldName = GetWorldNameById(b.StoreWorldID);
            }
        }

        
    }

}
