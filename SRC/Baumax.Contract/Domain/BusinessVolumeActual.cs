using System;
using System.Collections;

namespace Baumax.Domain
{
    #region BusinessVolumeActual

    /// <summary>
	/// BusinessVolumeActual object for NHibernate mapped table 'BusinessVolumeActual'.
	/// </summary>
	[Serializable]
    public class BusinessVolumeActual : BaseEntity
		{
		#region Member Variables
		
		protected DateTime _date;
		protected string _volume;
		protected WGR _wGR;

		#endregion

		#region Constructors

		public BusinessVolumeActual() { }

		public BusinessVolumeActual( DateTime date, string volume, WGR wGR )
		{
			this._date = date;
			this._volume = volume;
			this._wGR = wGR;
		}

		#endregion

		#region Public Properties

		public virtual DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		public virtual string Volume
		{
			get { return _volume; }
			set
			{
				if ( value != null && value.Length > 10)
					throw new ArgumentOutOfRangeException("Invalid value for Volume", value, value.ToString());
				_volume = value;
			}
		}

		public virtual WGR WGR_
		{
			get { return _wGR; }
			set { _wGR = value; }
		}

		#endregion
	}

	#endregion
}
