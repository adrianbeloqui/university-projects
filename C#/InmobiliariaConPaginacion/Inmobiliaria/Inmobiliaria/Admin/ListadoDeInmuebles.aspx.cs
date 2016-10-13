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
    public partial class ListadoDeInmuebles : System.Web.UI.Page
    {
        public Casa zCasa= new Casa();
        public Apartamento zApto=new Apartamento();
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] == null)
            {
                string script = "alert('Solo el Administrador tiene acceso a esta página.');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "login", script, true);
                Response.Redirect("~/Account/Login.aspx");
            }

            if (RadioInmueble.SelectedIndex != 0 && RadioInmueble.SelectedIndex != 1)
            {
                btnEliminar.Visible = false;
                btnModificar.Visible = false;
            }
            else 
            {
                btnEliminar.Visible = true;
                btnModificar.Visible = true;
            }

        }

     protected void GridViewCasa_SelectedIndexChanged(object sender, EventArgs e)
        {
                                             
        }
        protected void GridViewApto_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }   

        protected void btnEliminar_Click(object sender, EventArgs e)
        {                   
           
                if (RadioInmueble.SelectedIndex == 0)
                {
                    int row = GridViewApto.SelectedIndex;
                    if (row >= 0)
                    {
                        zApto.Id = Convert.ToInt32(GridViewApto.Rows[row].Cells[1].Text);
                        Fachada fachada = new Fachada();
                        fachada.EliminarApto(zApto);
                    }
                }
                else
                {
                    int row = GridViewCasa.SelectedIndex;
                    if (row >= 0)
                    {
                        zCasa.Id = Convert.ToInt32(GridViewCasa.Rows[row].Cells[1].Text);
                        Fachada fachada = new Fachada();
                        fachada.EliminarCasa(zCasa);
                    }
                }
                Response.Redirect("~/Admin/ListadoDeInmuebles.aspx");                
                           
          
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (RadioInmueble.SelectedIndex == 0)
            {
                int row = GridViewApto.SelectedIndex;
                if (row >= 0)
                {
                    zApto.Id = Convert.ToInt32(GridViewApto.Rows[row].Cells[1].Text);
                    Fachada fachada = new Fachada();
                    List<Apartamento> resultadoBusqueda = new List<Apartamento>();
                    resultadoBusqueda = fachada.BuscarAptoPorId(zApto.Id);
                    Session["ResultadoBusquedaApto"] = resultadoBusqueda;
                    foreach (Apartamento zAp in resultadoBusqueda)
                    {
                        #region Busqueda Apartamento
                        if (zAp.Vende != null)
                        {
                            Session["Busqueda"] = "Apartamentos para vender";
                        }
                        else
                        {
                            Session["Busqueda"] = "Apartamentos para alquilar";
                        }
                        #endregion
                    }
                    Response.Redirect("~/Admin/ModificarInmueble.aspx?id=" + zApto.Id + "&inmueble=" + "Apartamento" );
                }

            }
            else
            {
                int row = GridViewCasa.SelectedIndex;
                if (row >= 0)
                {
                    zCasa.Id = Convert.ToInt32(GridViewCasa.Rows[row].Cells[1].Text);
                    Fachada fachada = new Fachada();
                    List<Casa> resultadoBusqueda = new List<Casa>();
                    resultadoBusqueda = fachada.BuscarCasaPorId(zCasa.Id);
                    Session["ResultadoBusquedaCasa"] = resultadoBusqueda;
                    foreach (Casa zCa in resultadoBusqueda)
                    {
                        #region Busqueda Apartamento
                        if (zCa.Vende != null)
                        {
                            Session["Busqueda"] = "Apartamentos para vender";
                        }
                        else
                        {
                            Session["Busqueda"] = "Apartamentos para alquilar";
                        }
                        #endregion
                    }
                    Response.Redirect("~/Admin/ModificarInmueble.aspx?id=" + zCasa.Id + "&inmueble=" + "Casa");
                }
            }            
        }

        protected void RadioInmueble_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioInmueble.SelectedIndex == 0)
            {
                GridViewApto.Visible = true;
                GridViewCasa.Visible = false;
            }
            else
            {
                GridViewCasa.Visible = true;
                GridViewApto.Visible = false;
            }       
        }

      
    }
}