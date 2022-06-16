using System;
using System.Collections;

namespace Baumax.Domain
{
	#region Language

	/// <summary>
	/// Language object for NHibernate mapped table 'Language'.
	/// </summary>
	[Serializable]
    public class Language : BaseEntity
		{
		#region Member Variables
		
		protected string _name;
		protected string _languageCode;
		protected IList _countries;

		#endregion

		#region Constructors

		public Language() { }

		public Language( string name, string languageCode )
		{
			this._name = name;
			this._languageCode = languageCode;
		}

		#endregion

		#region Public Properties

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

		public virtual string LanguageCode
		{
			get { return _languageCode; }
			set
			{
				if ( value != null && value.Length > 5)
					throw new ArgumentOutOfRangeException("Invalid value for LanguageCode", value, value.ToString());
				_languageCode = value;
			}
		}

		public virtual IList Countries
		{
			get
			{
				if (_countries==null)
				{
					_countries = new ArrayList();
				}
				return _countries;
			}
			set { _countries = value; }
		}
		#endregion
	}

	#endregion
}
