using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Mensaje
    {
        string telefono;
        string mail;
        string message;
        int inmueble;
        int id;
        string contacto;
        //ver id inmueble      
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public int Inmueble
        {
            set { inmueble = value; }
            get { return inmueble; }
        }
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Contacto
        {
            set { contacto = value; }
            get { return contacto; }
        }

        /// <summary>
        /// Constructor que setea los datos del mensaje
        /// </summary>
        /// <param name="mNombre">Nombre del usuario</param>
        /// <param name="mApellido">Apellido del usuario</param>
        /// <param name="mTelefono">Telefono del usuario</param>
        /// <param name="mMail">Mail del usuario</param>
        /// <param name="mMensaje">Mensaje que deja el usuario</param>
        public Mensaje(string mTelefono, string mMail, string mMensaje, int xInmueble)
        {
            this.telefono = mTelefono;
            this.mail = mMail;
            this.message = mMensaje;
            inmueble = xInmueble;
        }

        public Mensaje()
        {

        }


    }
}
