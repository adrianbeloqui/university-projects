using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BusquedaApto
    {
        string xTipoNegocio;
        int xPrecioMin;
        int xPrecioMax;
        Comodidad xComodidad;
        string xTipoInmueble;
        string xBarrio;

        public BusquedaApto(string zTipoNegocio, int zPrecioMin, int zPrecioMax, Comodidad zComodidad, string zTipoInmueble, string zBarrio)
        {
            xTipoNegocio = zTipoNegocio;
            xPrecioMin = zPrecioMin;
            xPrecioMax = zPrecioMax;
            xComodidad = zComodidad;
            xTipoInmueble = zTipoInmueble;
            xBarrio = zBarrio;
            
        }

        public string aTipoNegocio
        {
            get { return xTipoNegocio; }
        }
        public int aPrecioMin
        {
            get { return xPrecioMin; }
        }
        public int aPrecioMax
        {
            get { return xPrecioMax; }
        }
        public Comodidad aComodidad
        {
            get { return xComodidad; }
        }
        public string aBarrio {
            get { return xBarrio; }
        }

    }
}
