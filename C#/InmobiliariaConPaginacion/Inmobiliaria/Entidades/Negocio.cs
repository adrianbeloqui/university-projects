using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entidades
{
    public class Negocio
    {
        
     
        int precio;
        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        int id;
        public int Id
        {
            get { return id; }

        }

        /// <summary>
        /// Constructor Vacio
        /// </summary>
        public Negocio () 
        {
        }

        /// <summary>
        /// Constructor que ya setea el precio
        /// </summary>
        /// <param name="nPrecio">¿Cual es el precio?</param>
        public Negocio( int nPrecio)
        {
            this.Precio = nPrecio;
           
        }    
    }
}