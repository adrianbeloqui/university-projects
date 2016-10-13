using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Vehicles
{
    public class Car: Vehicle
    {
        public Car(String xMarca, String xModelo, String xMatricula,String xTipo)
            : base(xMarca, xModelo, xMatricula,xTipo)
        {
 
        }

        public Car(): base()
        { }
    }
}
