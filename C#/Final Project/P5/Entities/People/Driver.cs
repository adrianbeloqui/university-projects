using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.People
{
    public class Driver:Employee
    {
        private ArrayList listRelationClientToDate;
        private String idDirverLicense;
        private Int32 quantityClassesGiven;

        #region Properties
        public ArrayList ListRelationClientToDate
        {
            get { return listRelationClientToDate; }
            set { listRelationClientToDate = value; }
        }

        public String IdDirverLicense
        {
            get { return idDirverLicense; }
            set { idDirverLicense = value; }
        }
       
        public Int32 QuantityClassesGiven
        {
            get { return quantityClassesGiven; }
            set { quantityClassesGiven = value; }
        }
        #endregion

        public void ClaseDictada(DrivingClass CliFecha)
        {
            ListRelationClientToDate.Add(CliFecha);
            QuantityClassesGiven += 1;
        }

        public Driver(String xNom, String xAp, Int32 xCed, String xNa, String xSe, DateTime xFe, String xCar)
            : base(xNom, xAp, xCed, xNa, xSe, xFe, xCar)
        {
            ListRelationClientToDate = new ArrayList();
        }

        public Driver()
        {
            ListRelationClientToDate = new ArrayList();
        }
    }
}
