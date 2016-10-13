using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using ReglasDeNegocios;
namespace Inmobiliaria
{
    public partial class Mensaje : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Entidades.Mensaje zMen = new Entidades.Mensaje();
            zMen.Mail = txtMail.Text;
            zMen.Message = txtMensaje.Text;
            zMen.Telefono = txtTelefono.Text;
            zMen.Contacto = txtNombre.Text;
            zMen.Inmueble = Convert.ToInt32(Request.QueryString["id"]);
            Fachada fachada = new Fachada();
            bool rest = fachada.AgregarMensaje(zMen);
            txtMail.Text = "";
            txtMensaje.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            Response.Redirect(Request.RawUrl + "&var=" + rest.ToString());

        }
    }
}