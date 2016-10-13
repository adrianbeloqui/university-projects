using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using ReglasDeNegocios;

namespace Inmobiliaria.Admin
{
    public partial class ListaDeMensajes : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] == null)
            {
                string script = "alert('Solo el Administrador tiene acceso a esta página.');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "login", script, true);
                Response.Redirect("~/Account/Login.aspx");
            }
            
                if (GridViewMensajes.Rows.Count<=0)
                {
                    advertencia.Visible = false;
                    btnEliminar.Visible = false;
                }
                else
                {
                    advertencia.Visible = true;
                    btnEliminar.Visible = true;
                }
            
        }        
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Entidades.Mensaje zMens = new Entidades.Mensaje();
            for (int i = 0; i < GridViewMensajes.Rows.Count; i++) 
            {                           
                    CheckBox chkSel = (CheckBox)GridViewMensajes.Rows[i].FindControl("chkSeleccionar");

                    if (chkSel.Checked == true)
                    {
                        HiddenField hdId = new HiddenField();
                        hdId = (HiddenField)GridViewMensajes.Rows[i].FindControl("hdf");
                        zMens.Id = Convert.ToInt32(hdId.Value);
                       Fachada fachada = new Fachada();
                        fachada.EliminarMensaje(zMens);
                    }
                }
                Response.Redirect("~/Admin/ListaDeMensajes.aspx");    
            
        }

        protected void GridViewMensajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entidades.Mensaje zMen = new Entidades.Mensaje();         
            int row = GridViewMensajes.SelectedIndex;                               
            HiddenField hdId = new HiddenField();
            hdId = (HiddenField)GridViewMensajes.Rows[row].FindControl("hdf");           
            zMen.Id = Convert.ToInt32(hdId.Value);
            hdId = (HiddenField)GridViewMensajes.Rows[row].FindControl("hdfInmueble");
            zMen.Inmueble = Convert.ToInt32(hdId.Value);
            hdId = (HiddenField)GridViewMensajes.Rows[row].FindControl("hdfContacto");
            zMen.Contacto = hdId.Value;
            hdId = (HiddenField)GridViewMensajes.Rows[row].FindControl("hdfMail");
            zMen.Mail = hdId.Value;
            hdId = (HiddenField)GridViewMensajes.Rows[row].FindControl("hdfTelefono");
            zMen.Telefono = hdId.Value;
            hdId = (HiddenField)GridViewMensajes.Rows[row].FindControl("hdfMensaje");
            zMen.Message = hdId.Value;
            Session.Add("Mensaje", zMen);             
            Response.Redirect("~/Admin/MostrarMensaje.aspx"); 
        }              
    }
}
