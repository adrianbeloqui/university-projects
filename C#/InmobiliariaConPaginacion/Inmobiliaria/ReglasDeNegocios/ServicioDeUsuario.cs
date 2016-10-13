using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia;
namespace ReglasDeNegocios
{
    public class ServicioDeUsuario
    {

        internal bool AgregarMensaje(Mensaje zMen)
        {
            PMensaje zME = new PMensaje();
            return zME.Guardar(zMen);
        }

        internal void EliminarMensaje(Mensaje zMen)
        {
            PMensaje zME = new PMensaje();
            zME.Eliminar(zMen);
        }

        internal Administrador Login(Administrador zAdm)
        {
            PLogin zLog = new PLogin();
            return zLog.LoginAdmin(zAdm);

        }

    }
}
