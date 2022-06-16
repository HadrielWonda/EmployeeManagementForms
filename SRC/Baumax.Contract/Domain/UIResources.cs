using System;
using System.Collections;

namespace Baumax.Domain
{
	#region UIResource

	/// <summary>
	/// UIResource object for NHibernate mapped table 'UIResources'.
	/// </summary>
	[Serializable]
	public class UIResource : BaseEntity
	{
		#region Member Variables

		protected long _languageID;
		protected int _resourceID;
		protected string _resource;

		#endregion

		#region Constructors

		public UIResource() { }

		public UIResource(int resourceID, long languageID, string resource)
		{
			this._resourceID = resourceID;
			this._languageID = languageID;
			this._resource = resource;
		}

		#endregion

		#region Public Properties


		public virtual int ResourceID
		{
			get { return _resourceID; }
			set { _resourceID = value; }
		}

		public virtual long LanguageID
		{
			get { return _languageID; }
			set { _languageID = value; }
		}

		public virtual string Resource
		{
			get { return _resource; }
			set
			{
				if (value != null && value.Length > 500)
					throw new ArgumentOutOfRangeException("Invalid value for Resource", value, value.ToString());
				_resource = value;
			}
		}
		#endregion
	}

	#endregion
}
