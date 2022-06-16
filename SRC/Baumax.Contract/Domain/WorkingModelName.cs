using System;
using System.Collections;

namespace Baumax.Domain
{
	#region WorkingModelName

	/// <summary>
	/// WorkingModelName object for NHibernate mapped table 'WorkingModelName'.
	/// </summary>
	[Serializable]
    public class WorkingModelName : BaseEntity
		{
		#region Member Variables
		
		protected long _languageID;
		protected string _name;
		protected WorkingModel _workingModel;

		#endregion

		#region Constructors

		public WorkingModelName() { }

		public WorkingModelName( long languageID, string name, WorkingModel workingModel )
		{
			this._languageID = languageID;
			this._name = name;
			this._workingModel = workingModel;
		}

		#endregion

		#region Public Properties

		public virtual long LanguageID
		{
			get { return _languageID; }
			set { _languageID = value; }
		}

		public virtual string Name
		{
			get { return _name; }
			set
			{
				if ( value != null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_name = value;
			}
		}

		public virtual WorkingModel WorkingModel
		{
			get { return _workingModel; }
			set { _workingModel = value; }
		}
		#endregion
	}

	#endregion
}
