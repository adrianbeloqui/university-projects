using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.People
{
    public class Employee: Person
    {
        private String position;
        public String Position
        {
            get { return position; }
            set { position = value; }
        }

        //Metodos para Choferes van abstractos (el administrador no puede acceder)
        //public abstract void ClaseDictada(DateTime fechaClase);

        public Employee(String xNom, String xAp, Int32 xCed, String xNa, String xSe, DateTime xFe, String xCar)
            : base(xNom, xAp, xCed, xNa, xSe, xFe)
        {
            Position = xCar;
        }

        public Employee()
        { }
    }
}
