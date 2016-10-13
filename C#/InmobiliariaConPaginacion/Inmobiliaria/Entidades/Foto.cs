using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Entidades
{
    public class Foto
    {
        string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public Foto(string fDireccion)
        {
            this.direccion = fDireccion;
        }

        public void eliminarFoto(string path)
        {
            string archivo = Direccion.Substring(1);
            File.Delete(path + "\\" + archivo);
        }        
    }
}
