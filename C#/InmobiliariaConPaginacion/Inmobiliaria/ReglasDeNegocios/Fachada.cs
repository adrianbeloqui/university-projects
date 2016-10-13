using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia;

namespace ReglasDeNegocios
{
    public class Fachada
    {
        ServicioDeInmobiliaria xServInm;
        ServicioDeUsuario xServUser;

        public Fachada()
        {
            xServInm = new ServicioDeInmobiliaria();
            xServUser = new ServicioDeUsuario();
        }

        public Administrador Login(Administrador zAdm)
        {
            return xServUser.Login(zAdm);
        }

        public bool AgregarCasa(Casa zInm)
        {
            return xServInm.AgregarCasa(zInm);
        }

        public bool AgregarApto(Apartamento zInm)
        {
            return xServInm.AgregarApto(zInm);

        }

        public bool ModificarCasa(Casa zInm)
        {
            return xServInm.ModificarCasa(zInm);
        }

        public bool ModificarApto(Apartamento zInm)
        {
            return xServInm.ModificarApto(zInm);

        }

        public bool EliminarCasa(Casa zInm)
        {
            return xServInm.EliminarCasa(zInm);

        }

        public bool EliminarApto(Apartamento zInm)
        {
            return xServInm.EliminarApto(zInm);

        }

        public void EliminarMensaje(Mensaje zMen)
        {
            xServUser.EliminarMensaje(zMen);
        }

        public bool AgregarMensaje(Mensaje zMen)
        {
            return xServUser.AgregarMensaje(zMen);
        }

        public List<Casa> BuscarCasa(BusquedaCasa zBusqueda)
        {
            return xServInm.BuscarCasa(zBusqueda);
        }

        public List<Apartamento> BuscarApto(BusquedaApto zBusqueda)
        {
            return xServInm.BuscarApto(zBusqueda);
        }

        public List<Casa> BuscarCasaPorId(int id)
        {
            return xServInm.BuscarCasaPorId(id);
        }

        public List<Apartamento> BuscarAptoPorId(int id)
        {
            return xServInm.BuscarAptoPorId(id);
        }
    }
}
