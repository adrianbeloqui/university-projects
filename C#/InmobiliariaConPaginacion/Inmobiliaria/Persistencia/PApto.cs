using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Data;
namespace Persistencia
{
    public class PApto : PPersistencia
    {
        public bool Guardar(Apartamento zAp)
        {
            bool rest = false;
            SqlConnection xCon = Conexion();
            SqlCommand zCmd = new SqlCommand();
            zCmd.CommandType = CommandType.StoredProcedure;
            zCmd.CommandText = "GuardarInmuebleApto";
            zCmd = AgregarAInmueble(zAp, zCmd);
            try
            {
                xCon.Open();
                zCmd.Connection = xCon;
                List<Foto> zList = zAp.List;
                zCmd.ExecuteNonQuery();
                AgregarFoto(zList, zCmd);
                rest = true;
            }
            catch
            {
            }
            finally
            {
                if (xCon != null && xCon.State == ConnectionState.Open)
                {
                    xCon.Dispose();
                    xCon.Close();
                }
                zCmd.Dispose();

            }
            return rest;
        }

        private void AgregarFoto(List<Foto> zList, SqlCommand zCmd)
        {
            zCmd.CommandText = "GuardarFoto";
            foreach (Foto zF in zList)
            {
                zCmd.Parameters.Clear();
                zCmd.Parameters.AddWithValue("@Direccion", zF.Direccion);
                zCmd.ExecuteNonQuery();
            }
        }

        private SqlCommand AgregarAInmueble(Apartamento zAp, SqlCommand zCmd)
        {
            zCmd.Parameters.AddWithValue("@Descripcion", zAp.Descripcion);
            zCmd.Parameters.AddWithValue("@Titulo", zAp.Titulo);
            zCmd.Parameters.AddWithValue("@Direccion", zAp.Direccion);
            zCmd.Parameters.AddWithValue("@Barrio", zAp.Barrio);
            zCmd.Parameters.AddWithValue("@Dormitorios", zAp.Comodidades.Dormitorios);
            zCmd.Parameters.AddWithValue("@Amueblado", zAp.Comodidades.Amueblado);
            zCmd.Parameters.AddWithValue("@Internet", zAp.Comodidades.Internet);
            zCmd.Parameters.AddWithValue("@EquipamientoCocina", zAp.Comodidades.EquipamientoCocina);
            zCmd.Parameters.AddWithValue("@Microondas", zAp.Comodidades.Microondas);
            zCmd.Parameters.AddWithValue("@TvCable", zAp.Comodidades.TvCable);
            zCmd.Parameters.AddWithValue("@Parrillero", zAp.Comodidades.Parrillero);
            zCmd.Parameters.AddWithValue("@EstufaALena", zAp.Comodidades.EstufaALeña);
            zCmd.Parameters.AddWithValue("@Estacionamiento", zAp.Comodidades.Estacionamiento);
            zCmd.Parameters.AddWithValue("@Piscina", zAp.Comodidades.Piscina);
            zCmd.Parameters.AddWithValue("@Heladera", zAp.Comodidades.Heladera);
            zCmd.Parameters.AddWithValue("@Bano", zAp.Comodidades.Baños);
            zCmd.Parameters.AddWithValue("@Piso", zAp.Piso);
            if (zAp.Vende == null)
            {
                zCmd.Parameters.AddWithValue("@PrecioVenta", null);
            }
            else
            {
                zCmd.Parameters.AddWithValue("@PrecioVenta", zAp.Vende.Precio);
            }
            if (zAp.Alquila == null)
            {
                zCmd.Parameters.AddWithValue("@PrecioAlquiler", null);
            }
            else
            {
                zCmd.Parameters.AddWithValue("@PrecioAlquiler", zAp.Alquila.Precio);
            }

            return zCmd;
        }

        public bool Modificar(Apartamento zAp)
        {
            bool rest = false;
            SqlConnection xCon = Conexion();
            SqlCommand zCmd = new SqlCommand();
            zCmd.CommandType = CommandType.StoredProcedure;
            zCmd.CommandText = "ModificarInmuebleApto";
            zCmd.Parameters.AddWithValue("@id", zAp.Id);
            zCmd = AgregarAInmueble(zAp, zCmd);
            try
            {
                xCon.Open();
                zCmd.Connection = xCon;
                List<Foto> aux = zAp.List;
                zCmd.ExecuteNonQuery();
                AgregarFoto(aux, zCmd);
                rest = true;
            }
            catch
            {
            }
            finally
            {
                if (xCon != null && xCon.State == ConnectionState.Open)
                {
                    xCon.Dispose();
                    xCon.Close();
                }
                zCmd.Dispose();

            }
            return rest;
        }

        public bool Eliminar(Apartamento zAp)
        {
            bool rest = false;
            SqlConnection xCon = Conexion();
            SqlCommand zCmd = new SqlCommand();
            zCmd.CommandType = CommandType.StoredProcedure;
            zCmd.CommandText = "EliminarInmuebleApto";
            zCmd.Parameters.AddWithValue("@idInmueble", zAp.Id);
            try
            {
                xCon.Open();
                zCmd.Connection = xCon;
                List<Foto> aux = zAp.List;
                zCmd.ExecuteNonQuery();
                rest = true;
            }
            catch
            {
            }
            finally
            {
                if (xCon != null && xCon.State == ConnectionState.Open)
                {
                    xCon.Dispose();
                    xCon.Close();
                }
                zCmd.Dispose();

            }

            if (rest)
            {
                //con la lista auxiliar eliminarlas de la carpeta
            }

            return rest;
        }

        public List<Apartamento> BuscarApto(BusquedaApto zBusqueda)
        {
            List<Apartamento> zList = null;
            SqlConnection xCon = Conexion();
            string zComando;
            try
            {
                xCon.Open();
                if (zBusqueda.aTipoNegocio == "Venta") { zComando = "BuscarAptoVenta"; }
                else
                {
                    zComando = "BuscarAptoAlquiler";
                }
                SqlCommand zCmd = new SqlCommand(zComando, xCon);
                zCmd = buscarApto(zBusqueda, zCmd);
                zCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader zDR = zCmd.ExecuteReader();
                if (zDR != null)
                {
                    zList = new List<Apartamento>();
                    transformRowToAp(zDR, zList);
                }
            }
            catch
            {

            }
            finally
            {
                if (xCon != null && xCon.State == ConnectionState.Open)
                {
                    xCon.Dispose();
                    xCon.Close();
                }


            }
            return zList;
        }

        public List<Apartamento> BuscarAptoPorId(int id)
        {            
            List<Apartamento> zList = new List<Apartamento>(); ;
            SqlConnection xCon = Conexion();
            string zComando;
            try
            {
                xCon.Open();
                zComando = "BuscarAptoPorId";
                SqlCommand zCmd = new SqlCommand(zComando, xCon);
                zCmd.CommandType = CommandType.StoredProcedure;
                zCmd.Parameters.AddWithValue("@idInmueble", id);
                SqlDataReader zDR = zCmd.ExecuteReader();
                if (zDR != null)
                {
                    transformRowToAp(zDR, zList);
                }
            }
            catch
            {

            }
            finally
            {
                if (xCon != null && xCon.State == ConnectionState.Open)
                {
                    xCon.Dispose();
                    xCon.Close();
                }


            }
            return zList;
        }

        private void transformRowToAp(SqlDataReader zDR, List<Apartamento> zLista)
        {
            while (zDR.Read())
            {

                Apartamento zApto = new Apartamento();
                zApto.Id = Convert.ToInt32(zDR["id"]);
                zApto.Titulo = zDR["Titulo"].ToString();
                zApto.Descripcion = zDR["Descripcion"].ToString();
                zApto.Direccion = zDR["Direccion"].ToString();
                zApto.Barrio = zDR["Barrio"].ToString();
                zApto.Piso = Convert.ToInt32(zDR["Piso"]);
                if (zDR["PrecioAlquiler"] != null)
                {
                    zApto.Alquila = new Negocio();
                    string aux = zDR["PrecioAlquiler"].ToString();
                    if (aux == "")
                    {
                        zApto.Alquila.Precio = 0;
                    }
                    else
                    {
                        zApto.Alquila.Precio = Convert.ToInt32(zDR["PrecioAlquiler"]);
                    }
                }
                if (zDR["PrecioVenta"] != null)
                {
                    zApto.Vende = new Negocio();
                    string aux = zDR["PrecioVenta"].ToString();
                    if (aux == "")
                    {
                        zApto.Vende.Precio = 0;
                    }
                    else
                    {
                        zApto.Vende.Precio = Convert.ToInt32(zDR["PrecioVenta"]);
                    }
                }
                zApto.Comodidades = new Comodidad();

                zApto.Comodidades.Amueblado = Convert.ToBoolean(zDR["Amueblado"]);
                zApto.Comodidades.Dormitorios = Convert.ToInt32(zDR["Dormitorios"]);
                zApto.Comodidades.EquipamientoCocina = Convert.ToBoolean(zDR["EquipamientoCocina"]);
                zApto.Comodidades.Estacionamiento = Convert.ToBoolean(zDR["Estacionamiento"]);
                zApto.Comodidades.EstufaALeña = Convert.ToBoolean(zDR["EstufaALena"]);
                zApto.Comodidades.Heladera = Convert.ToBoolean(zDR["Heladera"]);
                zApto.Comodidades.Internet = Convert.ToBoolean(zDR["Internet"]);
                zApto.Comodidades.Microondas = Convert.ToBoolean(zDR["Microondas"]);
                zApto.Comodidades.Parrillero = Convert.ToBoolean(zDR["Parrillero"]);
                zApto.Comodidades.Piscina = Convert.ToBoolean(zDR["Piscina"]);
                zApto.Comodidades.TvCable = Convert.ToBoolean(zDR["TvCable"]);
                zApto.Comodidades.Baños = Convert.ToInt32(zDR["Bano"]);
                LevantarFotos(zApto);

                zLista.Add(zApto);

            }
        }

        private void LevantarFotos(Apartamento zApto)
        {

            SqlConnection xCon = this.Conexion();
            SqlCommand zCmd = new SqlCommand();
            zCmd.CommandType = CommandType.StoredProcedure;
            zCmd.CommandText = "BuscarFoto";
            zCmd.Parameters.AddWithValue("@idInmueble", zApto.Id);
            try
            {
                xCon.Open();
                zCmd.Connection = xCon;
                SqlDataReader zDR = zCmd.ExecuteReader();
                while (zDR.Read())
                {
                    zApto.AgregarFoto(zDR["Locacion"].ToString());
                }

            }
            catch
            {

            }
            finally
            {
                if (xCon != null && xCon.State == ConnectionState.Open)
                {
                    xCon.Dispose();
                    xCon.Close();
                }

            }
        }

        private SqlCommand buscarApto(BusquedaApto zBusqueda, SqlCommand zCmd)
        {
            if (zBusqueda.aPrecioMin == 0)
            {
                zCmd.Parameters.AddWithValue("@PrecioMin", null);
            }
            else
            {
                zCmd.Parameters.AddWithValue("@PrecioMin", zBusqueda.aPrecioMin);
            }
            if (zBusqueda.aPrecioMax == 0)
            {
                zCmd.Parameters.AddWithValue("@PrecioMax", null);
            }
            else
            {
                zCmd.Parameters.AddWithValue("@PrecioMax", zBusqueda.aPrecioMax);
            }

            zCmd.Parameters.AddWithValue("@Barrio", zBusqueda.aBarrio);
            zCmd.Parameters.AddWithValue("@Amueblado", zBusqueda.aComodidad.Amueblado);
            if (zBusqueda.aComodidad.Dormitorios == 0)
            {
                zCmd.Parameters.AddWithValue("@Dormitorios", null);
            }
            else
            {
                zCmd.Parameters.AddWithValue("@Dormitorios", zBusqueda.aComodidad.Dormitorios);
            }

            if (zBusqueda.aComodidad.Baños == 0)
            {
                zCmd.Parameters.AddWithValue("@Bano", null);
            }
            else
            {
                zCmd.Parameters.AddWithValue("@Bano", zBusqueda.aComodidad.Baños);
            }

            zCmd.Parameters.AddWithValue("@Equipamiento", zBusqueda.aComodidad.EquipamientoCocina);
            zCmd.Parameters.AddWithValue("@Estacionamiento", zBusqueda.aComodidad.Estacionamiento);
            zCmd.Parameters.AddWithValue("@Estufa", zBusqueda.aComodidad.EstufaALeña);
            zCmd.Parameters.AddWithValue("@Heladera", zBusqueda.aComodidad.Heladera);
            zCmd.Parameters.AddWithValue("@Internet", zBusqueda.aComodidad.Internet);
            zCmd.Parameters.AddWithValue("@Microondas", zBusqueda.aComodidad.Microondas);
            zCmd.Parameters.AddWithValue("@Parrillero", zBusqueda.aComodidad.Parrillero);
            zCmd.Parameters.AddWithValue("@Piscina", zBusqueda.aComodidad.Piscina);
            zCmd.Parameters.AddWithValue("@TvCable", zBusqueda.aComodidad.TvCable);
            return zCmd;
        }
    }
}