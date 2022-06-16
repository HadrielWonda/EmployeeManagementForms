using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Domain
{
    
    [Serializable ]
    public class EmployeeShortView
    {
        private long m_EmployeeID;
        private string m_FirstName;
        private string m_LastName;

        public virtual long EmployeeID
        {
            get { return m_EmployeeID; }
            set { m_EmployeeID = value; }
        }

        

        public virtual string FirstName
        {
            get { return m_FirstName; }
            set { m_FirstName = value; }
        }
        

        public virtual string LastName
        {
            get { return m_LastName; }
            set { m_LastName = value; }
        }
        public virtual string FullName
        {
            get { return String.Format ("{0} {1}", LastName, FirstName); }
        }

        public EmployeeShortView(long id, string fname,string lname)
        {
            EmployeeID = id;
            FirstName = fname;
            LastName = lname;
        }
	
    }
}
