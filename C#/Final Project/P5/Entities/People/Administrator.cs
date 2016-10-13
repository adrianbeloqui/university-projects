using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.People
{
    public class Administrator: Employee
    {
        private String username;
        private String password;

        #region Properties
        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public String Username
        {
            get { return username; }
            set { username = value; }
        }
        #endregion

        public Administrator(String xNom, String xAp, Int32 xCed, String xNa, String xSe, DateTime xFe, String xCar)
            : base(xNom, xAp, xCed, xNa, xSe, xFe, xCar)
        { }

        //public override void ClaseDictada(DateTime fechaClase)
        //{ }

        public Administrator()
        { }
    }
}
