using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tidwell_5_
{
    public class Vehicle
    {
        private int id;
        private String brand;
        private String model;
        private String plateNumber;
        private String type;

        #region Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
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
        }

        public Vehicle()
        {
        }
    }
}
