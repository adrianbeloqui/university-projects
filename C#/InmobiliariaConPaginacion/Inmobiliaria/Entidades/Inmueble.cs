using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entidades
{
    abstract public class Inmueble
    {
        Negocio xAlquila;
        Negocio xVende;
        string xTitulo;
        string xDescripcion;
        string xDireccion;
        string xBarrio;
        Comodidad xComodidades;
        int xId;
        List<Foto> xList;

        public void AgregarFoto(string zPath)
        {
            AgregarFoto(new Foto(zPath));
        }

        private void AgregarFoto(Foto zF)
        {
            xList.Add(zF);
        }
        public List<Foto> List
        {
            get { return xList; }
        }
        public Negocio Alquila
        {
            get { return xAlquila; }
            set { xAlquila = value; }
        }
        public Negocio Vende
        {
            get { return xVende; }
            set { xVende = value; }
        }
        public string Titulo
        {
            get { return xTitulo; }
            set { xTitulo = value; }
        }
        public string Descripcion
        {
            get { return xDescripcion; }
            set { xDescripcion = value; }
        }
        public string Direccion
        {
            get { return xDireccion; }
            set { xDireccion = value; }
        }
        public string Barrio
        {
            get { return xBarrio; }
            set { xBarrio = value; }
        }

        public Comodidad Comodidades
        {
            get { return xComodidades; }
            set { xComodidades = value; }
        }


        public int Id
        {
            get;
            set;
        }



        /// <summary>
        /// Constructor Vacio
        /// </summary>
        public Inmueble()
        {
            this.xList = new List<Foto>();
        }


        /// <summary>
        /// Constructor que setea los datos del inmueble
        /// </summary>
        /// <param name="zVenta">Venta</param>
        /// <param name="zAlquiler">Alquiler</param>
        /// <param name="zListComodidades">Lista de comodidades</param>
        /// <param name="zBarrio">Barrio</param>
        public Inmueble(Negocio zAlquila, Negocio zVende, Comodidad zComodidades, string zTitulo, string zDescripcion, string zDireccion, string zBarrio)
        {
            this.xList = new List<Foto>();
            this.xVende = zVende;
            this.xAlquila = zAlquila;
            this.xComodidades = zComodidades;
            this.xTitulo = zTitulo;
            this.xDescripcion = zDescripcion;
            this.xDireccion = zDireccion;
            this.xBarrio = zBarrio;
        }
    }
}