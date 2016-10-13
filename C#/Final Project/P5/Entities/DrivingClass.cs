using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DrivingClass
    {
        private People.Person client;
        private People.Employee driver;
        private Vehicles.Vehicle vehi;
        private DateTime date;

        #region Properties
        public People.Person Client
        {
            get { return client; }
            set { client = value; }
        }
        
        public People.Employee Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        public Vehicles.Vehicle Vehi
        {
            get { return vehi; }
            set { vehi = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        #endregion

        public DrivingClass(People.Person xCli, People.Employee xChof, Vehicles.Vehicle xVe, DateTime xFe)
        {
            Client = xCli;
            Driver = xChof;
            Vehi = xVe;
            Date = xFe;
        }

        public DrivingClass(People.Person xCli, DateTime xFe)
        {
            Client = xCli;
            Date = xFe;
        }

        public DrivingClass()
        { }
    }
}
