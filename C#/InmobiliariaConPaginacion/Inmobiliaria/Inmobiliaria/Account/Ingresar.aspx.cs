using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using ReglasDeNegocios;

namespace Inmobiliaria.SiteMasters
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Fachada fachada;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] != null)
            {
                string script = "alert('Usted ya ha iniciado sesión.')";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alreadyLoggedIn", script, true);

                Response.Redirect("~/Pages/Default.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Administrador admin = new Administrador();
            fachada = new Fachada();
            admin.Nombre = txtUserName.Text;
            admin.Contraseña = txtPassword.Text;
            admin = fachada.Login(admin);
            if (admin != null)
            {
                Session["Administrador"] = admin;
                Response.Redirect(@"~\Pages\Default.aspx");
            }
            else
            {
                lblWarning.Text = "El usuario no existe!";
            }
            /*No distingue entre mayusculas y minusculas */
        }
    }
}