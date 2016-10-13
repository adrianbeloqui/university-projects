using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inmobiliaria.SiteMasters
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] == null)
            {
                string soloAdmin = "alert('Solo el Administrador tiene acceso a esta página.');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "login", soloAdmin, true);
                Response.Redirect("~/Account/Ingresar.aspx");
            }
        }

        protected void imgBtnIngInmuebles_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/IngresarInmueble.aspx");
        }

        protected void imgBtnListInmuebles_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/ListadoDeInmuebles.aspx");
        }

        protected void imgBtnListMensajes_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/ListaDeMensajes.aspx");
        }
    }
}