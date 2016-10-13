using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inmobiliaria
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ListaFotos"] = null;

            string var = Request.QueryString["var"];

            if (var != null)
            {
                if (var.ToString() == "ingTrue" || var.ToString() == "ingFalse")
                {
                    #region Ingresar
                    string script;
                    if (var.ToString() == "ingTrue")
                    {
                        script = "alert('El inmueble fue ingresado con exito');";
                    }
                    else
                    {
                        script = "alert('El inmueble  no pudo ser ingresado');";
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "ing", script, true);
                    #endregion
                }

                else if (var.ToString() == "modTrue" || var.ToString() == "modFalse")
                {
                    #region Modificar
                    string script;
                    if (var.ToString() == "modTrue")
                    {
                        script = "alert('El inmueble fue modificado con exito');";
                    }
                    else
                    {
                        script = "alert('El inmueble no pudo ser modificado');";
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mod", script, true);
                    #endregion
                }
                else if (var.ToString() == "delTrue" || var.ToString() == "delFalse")
                {
                    #region Eliminar
                    string script;
                    if (var.ToString() == "delTrue")
                    {
                        script = "alert('El inmueble fue eliminado con exito');";
                    }
                    else
                    {
                        script = "alert('El inmueble no pudo ser eliminado');";
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "del", script, true);
                    #endregion
                }
            }
        }
    }
}
