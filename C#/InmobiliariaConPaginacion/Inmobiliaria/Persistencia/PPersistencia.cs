using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Persistencia
{
    abstract public class PPersistencia
    {
        //private SqlConnection xCon;

        protected SqlConnection Conexion() { 
            return new SqlConnection(ConfigurationManager.ConnectionStrings["InmobiliariaConnection"].ConnectionString);
        }                
    }


}
