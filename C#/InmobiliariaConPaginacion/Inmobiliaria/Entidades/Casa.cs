using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entidades
{
    public class Casa : Inmueble
    {        
        /// <summary>
        /// Constructor Vacio
        /// </summary>
        public Casa()
        {
        }

        /// <summary>
        /// Constructor que setea los datos del inmueble
        /// </summary>
        /// <param name="zVenta">Venta</param>
        /// <param name="zAlquiler">Alquiler</param>
        /// <param name="zListComodidades">Lista de comodidades</param>
        /// <param name="zBarrio">Barrio</param>
        public Casa(Negocio zVenta, Negocio zAlquiler, Comodidad zComodidades, string zTitulo, string zDescripcion, string zDireccion, string zBarrio)
                     : base(zVenta, zAlquiler, zComodidades, zTitulo, zDescripcion, zDireccion, zBarrio)
        {           
        }
    }
}