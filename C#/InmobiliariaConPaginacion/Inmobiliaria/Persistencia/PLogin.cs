using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PLogin : PPersistencia
    {
        public Administrador LoginAdmin(Administrador zAdm)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr = null;
            try
            {
                SqlConnection zcon = Conexion();
                zcon.Open();
                cmd.Connection = zcon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LoginAdministrador";
                cmd.Parameters.AddWithValue("@Usuario", zAdm.Nombre);
                cmd.Parameters.AddWithValue("@Contrasena", zAdm.Contraseña);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return new Administrador(Convert.ToInt32(dr["id"]), dr["Nick"].ToString(), dr["Contrasena"].ToString());

                }
                return null;
            }
            catch
            {
                return null;
            }
            finally 
            {
                cmd.Connection.Close();
                cmd.Dispose();
                dr.Dispose();
            } 
        
        }
    }
}
