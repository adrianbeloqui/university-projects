using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Inmobiliaria.Admin
{
    public partial class AgregarFoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] == null)
            {
                string script = "alert('Solo el Administrador tiene acceso a esta página.');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "login", script, true);
                Response.Redirect("~/Account/Login.aspx");   
            }
      
        }        

        private void MostrarFotos()
        {
            List<FileUpload> zListFotos = (List<FileUpload>)Session["ListaFotos"];
            List<String> zListMostrar = new List<string>();
            foreach (FileUpload zF in zListFotos)
            {
                zListMostrar.Add(zF.PostedFile.FileName);
            }
            this.lstFotos.DataSource = zListMostrar;
            lstFotos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombreFoto = FUFoto.PostedFile.FileName.ToUpper();

            if (nombreFoto.EndsWith(".JPG") || nombreFoto.EndsWith(".PNG"))
            {
                List<FileUpload> zListFotos;
                if (Session["ListaFotos"] != null)
                {
                    zListFotos = (List<FileUpload>)Session["ListaFotos"];
                }
                else
                {
                    zListFotos = new List<FileUpload>();
                }
                zListFotos.Add(FUFoto);
                Session["ListaFotos"] = zListFotos;
                MostrarFotos();
            }
            else 
            {
                lblError.Text = "Se aceptan imagenes .JPG o .PNG solamente";
            }
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstFotos.SelectedIndex != -1)
            {
                List<FileUpload> zListFotos = (List<FileUpload>)Session["ListaFotos"];
                foreach (FileUpload ft in zListFotos)
                {
                    if (ft.PostedFile.FileName == lstFotos.SelectedValue)
                    {
                        zListFotos.Remove(ft);
                        Session["ListaFotos"] = zListFotos;
                        break;
                    }
                }
                lstFotos.Items.Remove(lstFotos.SelectedItem);
            }
            else
            {
                string script = "alert('Seleccione un elemento.');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert" , script, true);
            }
        }
    }
}