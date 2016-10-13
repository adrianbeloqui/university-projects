using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inmobiliaria.SiteMasters
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] != null)
            {
                Session["Administrador"] = null;

                string alerta = "alert('Hasta luego!')";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "logout", alerta, true);
            }

            Response.Redirect("~/Pages/Default.aspx");
        }
    }
}