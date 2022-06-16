using System;
using System.Collections;
using System.Collections.Generic ;

namespace Baumax.Domain
{
	#region StoreToWorld

	/// <summary>
	/// StoreToWorld object for NHibernate mapped table 'StoreToWorld'.
	/// </summary>
	[Serializable]
	public class StoreToWorld : BaseEntity
		{
		#region Member Variables
		
		protected long _worldID;
		protected long _storeID;
        [NonSerialized ]
        protected string _worldname;
        [NonSerialized]
        protected WorldType _worldTypeID;

		#endregion

		#region Constructors

		public StoreToWorld() { }

		public StoreToWorld( long world, long store )
		{
			this._worldID = world;
			this._storeID = store;
		}

		#endregion

		#region Public Properties

		public virtual long WorldID
		{
			get { return _worldID; }
			set { _worldID = value; }
		}

		public virtual long StoreID
		{
			get { return _storeID; }
			set { _storeID = value; }
		}
        
        public virtual string WorldName
        {
            get { return _worldname; }
            set { _worldname = value; }
        }
        public virtual WorldType WorldTypeID
        {
            get { return _worldTypeID; }
            set { _worldTypeID = value; }
        }


		#endregion


        public virtual bool IsAdministration
        {
            get { return WorldTypeID == WorldType.Administration; }
        }
        public virtual bool IsCashDesk
        {
            get { return WorldTypeID == WorldType.CashDesk ; }
        }
        public virtual bool IsWorld
        {
            get { return WorldTypeID == WorldType.World ; }
        }

	}

	#endregion


    public class StoreToWorldSorter : IComparer<StoreToWorld>
    {
        public int Compare(StoreToWorld x, StoreToWorld y)
        {

            String a = String.Format("{0} {1} {2}",x.StoreID,(int)x.WorldTypeID,x.WorldName);
            String b = String.Format("{0} {1} {2}", y.StoreID, (int)y.WorldTypeID, y.WorldName);

            return a.CompareTo(b);
        }
    }
}
