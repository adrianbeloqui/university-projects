using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.People
{
    public class Client : Person
    {
        private DateTime initClasses;
        private Int32 quantityClassesTaken;
        private DateTime endingOfClasses;

        #region Properties
        public DateTime InitClasses
        {
            get { return initClasses; }
            set { initClasses = value; }
        }

        public Int32 QuantityClassesTaken
        {
            get { return quantityClassesTaken; }
            set { quantityClassesTaken = value; }
        }

        public DateTime EndingOfClasses
        {
            get { return endingOfClasses; }
            set { endingOfClasses = value; }
        }
        #endregion


        public Client(String xNom, String xAp, Int32 xCed, String xNac, String xSe,DateTime xFe)
            : base(xNom, xAp, xCed, xNac, xSe, xFe)
        {
            InitClasses = DateTime.Today;
            EndingOfClasses = DateTime.Today;
        }

        public Client()
        { }
    }
}
