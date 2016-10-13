using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Administrador
    {
        string nombre;
        string contraseña;

        int id;
        public int Id
        {
            get { return id; }

        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }
        

        /// <summary>
        /// Constructor Vacio
        /// </summary>
        public Administrador()
        {
        }

        /// <summary>
        /// Constructor que setea los datos del administrador
        /// </summary>
        /// <param name="pNombre">Usuario</param>
        /// <param name="pContraseña">Contraseña</param>
        public Administrador(string pNombre, string pContraseña)
        {
            this.nombre = pNombre;
            this.contraseña = pContraseña;
        }

        public Administrador(int pId, string pNombre, string pContraseña)
        {
            this.id = pId;
            this.nombre = pNombre;
            this.contraseña = pContraseña;
        }
    }
}
