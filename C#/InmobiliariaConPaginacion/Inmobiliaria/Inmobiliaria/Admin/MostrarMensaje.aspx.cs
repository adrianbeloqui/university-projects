using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inmobiliaria.Admin
{
    public partial class MostrarMensaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] == null)
            {
                string script = "alert('Solo el Administrador tiene acceso a esta página.');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "login", script, true);
                Response.Redirect("~/Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                Entidades.Mensaje zMen = new Entidades.Mensaje();
                zMen = (Entidades.Mensaje)Session["Mensaje"];
                txtNombre.Text = zMen.Contacto;
                txtTelefono.Text = zMen.Telefono;
                txtMail.Text = zMen.Mail;
                txtMensaje.Text = zMen.Message;         
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaDeMensajes.aspx");
        }
    }
}