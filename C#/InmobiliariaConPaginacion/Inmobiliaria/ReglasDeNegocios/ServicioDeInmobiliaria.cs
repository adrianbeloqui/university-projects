using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia;

namespace ReglasDeNegocios
{
    class ServicioDeInmobiliaria
    {
        internal bool AgregarApto(Apartamento zApto)
        {
            PApto zPA = new PApto();
            return zPA.Guardar(zApto);

        }

        internal bool ModificarApto(Apartamento zApto)
        {
            PApto zPA = new PApto();
            return zPA.Modificar(zApto);
        }

        internal bool EliminarApto(Apartamento zApto)
        {
            PApto zPA = new PApto();
            return zPA.Eliminar(zApto);
        }

        internal bool AgregarCasa(Casa zCasa)
        {
            PCasa zCA = new PCasa();
            return zCA.Guardar(zCasa);
        }

        internal bool ModificarCasa(Casa zCasa)
        {
            PCasa zCA = new PCasa();
            return zCA.Modificar(zCasa);
        }

        internal bool EliminarCasa(Casa zCasa)
        {
            PCasa zCA = new PCasa();
            return zCA.Eliminar(zCasa);

        }

        internal List<Apartamento> BuscarApto(BusquedaApto zBusqueda)
        {
            PApto zPA = new PApto();
            return zPA.BuscarApto(zBusqueda);
        }

        internal List<Casa> BuscarCasa(BusquedaCasa zBusqueda)
        {
            PCasa zPA = new PCasa();
            return zPA.BuscarCasa(zBusqueda);
        }

        internal List<Casa> BuscarCasaPorId(int id)
        {
            PCasa zPA = new PCasa();
            return zPA.BuscarCasaPorId(id);
        }

        internal List<Apartamento> BuscarAptoPorId(int id)
        {
            PApto zPA = new PApto();
            return zPA.BuscarAptoPorId(id);
        }
    }
}
