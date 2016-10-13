using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Data;
namespace Persistencia
{
    public class PMensaje : PPersistencia
    {

        public bool Guardar(Mensaje zMen)
        {
            bool rest = false;
            SqlConnection xCon = Conexion();
            SqlCommand zCmd = new SqlCommand();
            zCmd.CommandType = CommandType.StoredProcedure;
            zCmd.CommandText = "GuardarMensaje";
            zCmd = AgregarAMensaje(zMen, zCmd);
            try
            {
                xCon.Open();
                zCmd.Connection = xCon;
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
            return rest;
        }

        public bool Eliminar(Mensaje zMen)
        {
            bool rest = false;
            SqlConnection xCon = Conexion();
            SqlCommand zCmd = new SqlCommand();
            zCmd.CommandType = CommandType.StoredProcedure;
            zCmd.CommandText = "EliminarMensaje";
            zCmd.Parameters.AddWithValue("@idMensaje", zMen.Id);
            try
            {
                xCon.Open();
                zCmd.Connection = xCon;
                zCmd.ExecuteNonQuery();
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

        private SqlCommand AgregarAMensaje(Mensaje zMen, SqlCommand zCmd)
        {
            zCmd.Parameters.AddWithValue("@idInmueble", zMen.Inmueble);
            zCmd.Parameters.AddWithValue("@Contacto", zMen.Contacto);
            zCmd.Parameters.AddWithValue("@Telefono", zMen.Telefono);
            zCmd.Parameters.AddWithValue("@Mail", zMen.Mail);
            zCmd.Parameters.AddWithValue("@Mensaje", zMen.Message);
            return zCmd;
        }

    }
}
