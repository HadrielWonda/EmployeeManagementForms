using System;
using System.Diagnostics;
using System.Reflection;

namespace Baumax.Domain
{
	/// <summary>
	/// Absence object for NHibernate mapped table 'Absence'.
	/// </summary>
	[Serializable]
	public class BaseEntity
	{
        protected long _ID;

        public virtual long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
	    
	    public virtual bool IsNew
	    {
            get { return _ID <= 0; }
	    }

        static public void CopyTo(object Source, object Destination)
        {
            Debug.Assert(Source != null);
            Debug.Assert(Destination != null);
            Debug.Assert(!Destination.Equals(Source));

            if (Source == null || Destination == null || Destination.Equals(Source)) return;

            FieldInfo[] sourceFieldInfo, destinationFieldInfo;

            Type sourceType = Source.GetType();
            Type destinationType = Destination.GetType();

            if (sourceType != destinationType) throw new Exception("Source and Destination have different class");
            try
            {
                sourceFieldInfo = sourceType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                destinationFieldInfo = destinationType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

                if (sourceFieldInfo.Length != destinationFieldInfo.Length) throw new Exception("Different quantity of fileld Source and Destination");

                for (int i = 0; i < sourceFieldInfo.Length; i++)
                {
                    if (sourceFieldInfo[i].Name == destinationFieldInfo[i].Name && sourceFieldInfo[i].FieldType == destinationFieldInfo[i].FieldType)
                    {
                        destinationFieldInfo[i].SetValue(Destination, sourceFieldInfo[i].GetValue(Source));
                    }
                }
            }

            catch (Exception e)
            {
                throw new Exception("Error of 'copyTo' method 'BaseEntity':" + e.Message);
            }
        }

    }

}
