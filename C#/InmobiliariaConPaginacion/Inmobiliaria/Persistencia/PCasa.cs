using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Data;
namespace Persistencia
{
    public class PCasa : PPersistencia
    {
        public bool Guardar(Casa zCa)
        {
            bool rest = false;
            SqlConnection xCon = Conexion();
            SqlCommand zCmd = new SqlCommand();
            zCmd.CommandType = CommandType.StoredProcedure;
            zCmd.CommandText = "GuardarInmuebleCasa";
            zCmd = AgregarAInmueble(zCa, zCmd);
            try
            {
                xCon.Open();
                zCmd.Connection = xCon;
                List<Foto> zList = zCa.List;
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

        private SqlCommand AgregarAInmueble(Casa zCa, SqlCommand zCmd)
        {
            zCmd.Parameters.AddWithValue("@Descripcion", zCa.Descripcion);
            zCmd.Parameters.AddWithValue("@Titulo", zCa.Titulo);
            zCmd.Parameters.AddWithValue("@Direccion", zCa.Direccion);
            zCmd.Parameters.AddWithValue("@Barrio", zCa.Barrio);
            zCmd.Parameters.AddWithValue("@Dormitorios", zCa.Comodidades.Dormitorios);
            zCmd.Parameters.AddWithValue("@Amueblado", zCa.Comodidades.Amueblado);
            zCmd.Parameters.AddWithValue("@Internet", zCa.Comodidades.Internet);
            zCmd.Parameters.AddWithValue("@EquipamientoCocina", zCa.Comodidades.EquipamientoCocina);
            zCmd.Parameters.AddWithValue("@Microondas", zCa.Comodidades.Microondas);
            zCmd.Parameters.AddWithValue("@TvCable", zCa.Comodidades.TvCable);
            zCmd.Parameters.AddWithValue("@Parrillero", zCa.Comodidades.Parrillero);
            zCmd.Parameters.AddWithValue("@EstufaALena", zCa.Comodidades.EstufaALeña);
            zCmd.Parameters.AddWithValue("@Estacionamiento", zCa.Comodidades.Estacionamiento);
            zCmd.Parameters.AddWithValue("@Piscina", zCa.Comodidades.Piscina);
            zCmd.Parameters.AddWithValue("@Heladera", zCa.Comodidades.Heladera);
            zCmd.Parameters.AddWithValue("@Bano", zCa.Comodidades.Baños);

            if (zCa.Vende == null)
            {
                zCmd.Parameters.AddWithValue("@PrecioVenta", null);
            }
            else
            {
                zCmd.Parameters.AddWithValue("@PrecioVenta", zCa.Vende.Precio);
            }
            if (zCa.Alquila == null)
            {
                zCmd.Parameters.AddWithValue("@PrecioAlquiler", null);
            }
            else
            {
                zCmd.Parameters.AddWithValue("@PrecioAlquiler", zCa.Alquila.Precio);
            }

            return zCmd;
        }

        public bool Modificar(Casa zCa)
        {
            bool rest = false;
            SqlConnection xCon = Conexion();
            SqlCommand zCmd = new SqlCommand();
            zCmd.CommandType = CommandType.StoredProcedure;
            zCmd.CommandText = "ModificarInmuebleCasa";
            zCmd = AgregarAInmueble(zCa, zCmd);
            zCmd.Parameters.AddWithValue("@id", zCa.Id);
            try
            {
                xCon.Open();
                zCmd.Connection = xCon;
                List<Foto> aux = zCa.List;
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

        public bool Eliminar(Casa zCa)
        {
            bool rest = false;
            SqlConnection xCon = Conexion();
            SqlCommand zCmd = new SqlCommand();
            zCmd.CommandType = CommandType.StoredProcedure;
            zCmd.CommandText = "EliminarInmuebleCasa";
            zCmd.Parameters.AddWithValue("@idInmueble", zCa.Id);
            try
            {
                xCon.Open();
                zCmd.Connection = xCon;
                List<Foto> aux = zCa.List;
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

        public List<Casa> BuscarCasa(BusquedaCasa zBusqueda)
        {
            List<Casa> zList = null;
            SqlConnection xCon = Conexion();
            string zComando;
            try
            {
                xCon.Open();
                if (zBusqueda.aTipoNegocio == "Venta") { zComando = "BuscarCasaVenta"; }
                else
                {
                    zComando = "BuscarCasaAlquiler";
                }
                SqlCommand zCmd = new SqlCommand(zComando, xCon);
                zCmd = buscarCasa(zBusqueda, zCmd);
                zCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader zDR = zCmd.ExecuteReader();
                if (zDR != null)
                {
                    zList = new List<Casa>();
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

        public List<Casa> BuscarCasaPorId(int id)
        {
            List<Casa> zList = new List<Casa>(); ;
            SqlConnection xCon = Conexion();
            string zComando;
            try
            {
                xCon.Open();
                zComando = "BuscarCasaPorId";
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

        private void transformRowToAp(SqlDataReader zDR, List<Casa> zList)
        {
            while (zDR.Read())
            {
                Casa zCasa = new Casa();
                zCasa.Id = Convert.ToInt32(zDR["id"]);
                zCasa.Titulo = zDR["Titulo"].ToString();
                zCasa.Descripcion = zDR["Descripcion"].ToString();
                zCasa.Direccion = zDR["Direccion"].ToString();
                zCasa.Barrio = zDR["Barrio"].ToString();
                if (zDR["PrecioAlquiler"] != null)
                {
                    zCasa.Alquila = new Negocio();
                    string aux = zDR["PrecioAlquiler"].ToString();
                    if (aux == "")
                    {
                        zCasa.Alquila.Precio = 0;
                    }
                    else
                    {
                        zCasa.Alquila.Precio = Convert.ToInt32(zDR["PrecioAlquiler"]);
                    }
                }
                if (zDR["PrecioVenta"] != null)
                {
                    zCasa.Vende = new Negocio();
                    string aux = zDR["PrecioVenta"].ToString();
                    if (aux == "")
                    {
                        zCasa.Vende.Precio = 0;
                    }
                    else
                    {
                        zCasa.Vende.Precio = Convert.ToInt32(zDR["PrecioVenta"]);
                    }
                }
                zCasa.Comodidades = new Comodidad();

                zCasa.Comodidades.Amueblado = Convert.ToBoolean(zDR["Amueblado"]);
                zCasa.Comodidades.Dormitorios = Convert.ToInt32(zDR["Dormitorios"]);
                zCasa.Comodidades.EquipamientoCocina = Convert.ToBoolean(zDR["EquipamientoCocina"]);
                zCasa.Comodidades.Estacionamiento = Convert.ToBoolean(zDR["Estacionamiento"]);
                zCasa.Comodidades.EstufaALeña = Convert.ToBoolean(zDR["EstufaALena"]);
                zCasa.Comodidades.Heladera = Convert.ToBoolean(zDR["Heladera"]);
                zCasa.Comodidades.Internet = Convert.ToBoolean(zDR["Internet"]);
                zCasa.Comodidades.Microondas = Convert.ToBoolean(zDR["Microondas"]);
                zCasa.Comodidades.Parrillero = Convert.ToBoolean(zDR["Parrillero"]);
                zCasa.Comodidades.Piscina = Convert.ToBoolean(zDR["Piscina"]);
                zCasa.Comodidades.TvCable = Convert.ToBoolean(zDR["TvCable"]);
                zCasa.Comodidades.Baños = Convert.ToInt32(zDR["Bano"]);

                LevantarFotos(zCasa);

                zList.Add(zCasa);

            }
        }

        private void LevantarFotos(Casa zCasa)
        {

            SqlConnection xCon = this.Conexion();
            SqlCommand zCmd = new SqlCommand();
            zCmd.CommandType = CommandType.StoredProcedure;
            zCmd.CommandText = "BuscarFoto";
            zCmd.Parameters.AddWithValue("@idInmueble", zCasa.Id);
            try
            {
                xCon.Open();
                zCmd.Connection = xCon;
                SqlDataReader zDR = zCmd.ExecuteReader();
                while (zDR.Read())
                {
                    zCasa.AgregarFoto(zDR["Locacion"].ToString());
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

        private SqlCommand buscarCasa(BusquedaCasa zBusqueda, SqlCommand zCmd)
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
