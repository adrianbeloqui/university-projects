using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entidades
{
    public class Apartamento : Inmueble
    {
        int piso;
        //Boolean esPenthouse;

        public int Piso
        {
            get { return piso; }
            set { piso = value; }
        }


        
        /// <summary>
        /// Constructor Vacio
        /// </summary>
        public Apartamento()
        {
        }

        /// <summary>
        /// Constructor que setea los datos del inmueble
        /// </summary>
        /// <param name="zVenta">Venta</param>
        /// <param name="zAlquiler">Alquiler</param>
        /// <param name="zListComodidades">Lista de comodidades</param>
        /// <param name="zBarrio">Barrio</param>
        /// <param name="zPiso">En que piso es</param>
        public Apartamento(Negocio zVenta, Negocio zAlquiler, Comodidad zComodidades, string zTitulo, string zDescripcion, 
                           int zPiso, string zDireccion, string zBarrio) : base(zVenta, zAlquiler, zComodidades, zTitulo, zDescripcion, zDireccion,zBarrio)
        {
            this.Piso = zPiso;
        }

    }
}