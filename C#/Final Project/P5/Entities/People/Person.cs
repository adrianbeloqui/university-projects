using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.People
{
    public class Person
    {
        private String name;
        private String lastName;
        private Int32 ssn;
        private String nationality;
        private String sex;
        private DateTime birthDate;

        #region Properties
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        
        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        
        public Int32 Ssn
        {
            get { return ssn; }
            set { ssn = value; }
        }

        
        public String Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        
        public String Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        #endregion


        public Person(String xName, String xLastName, Int32 xSSN, String xNatio, String xSex, DateTime xBirth)
        {
            Name = xName;
            LastName = xLastName;
            Ssn = xSSN;
            Nationality = xNatio;
            Sex = xSex;
            BirthDate = xBirth;
        }

        public Person()
        { }
    }
}
