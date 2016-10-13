using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Vehicles
{
    public class Vehicle
    {
        private String brand;
        private String model;
        private String plateNumber;
        private Boolean state;
        private String type;

        #region Properties
        public String Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        
        public String Model
        {
            get { return model; }
            set { model = value; }
        }

        public String PlateNumber
        {
            get { return plateNumber; }
            set { plateNumber = value; }
        }

        public Boolean State
        {
            get { return state; }
            set { state = value; }
        }

        public String Type
        {
            get { return type; }
            set { type = value; }
        }
#endregion


        public Vehicle(String xMarca, String xModelo, String xMatricula, String xTipo)
        {
            Brand = xMarca;
            Model = xModelo;
            PlateNumber = xMatricula;
            Type = xTipo;
            State = false;
        }

        public Vehicle()
        {
            State = false;
        }
    }
}
