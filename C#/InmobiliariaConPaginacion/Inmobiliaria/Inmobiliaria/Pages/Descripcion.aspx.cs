using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Entidades;
using ReglasDeNegocios;



namespace Inmobiliaria
{
    public partial class Descripcion : System.Web.UI.Page
    {
        private Inmueble xInm;

        protected void Page_Load(object sender, EventArgs e)
        {
            int zId = Convert.ToInt32(Request.QueryString["id"]);

            #region JavaScript
            string script = "";
            if (Request.QueryString["var"] == "True")
            {
                script = "alert('El Mensaje fue enviado');";
            }
            else if (Request.QueryString["var"] == "False")
            {
                script = "alert('El mensaje no pudo ser enviado');";
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ing", script, true);
            #endregion

            if ((Request.QueryString["inmueble"] == "Apartamento"))
            {
                #region Apartamento
                List<Apartamento> zlist = (List<Apartamento>)Session["ResultadoBusquedaApto"];
                foreach (Apartamento zNodo in zlist)
                {
                    if (zNodo.Id == zId)
                    {
                        xInm = zNodo;
                        lblTitulo.Text = zNodo.Titulo;

                        if (zNodo.Vende.Precio == 0)
                        {
                            lblSiNoVen.Text = "NO";
                        }
                        else
                        {
                            lblSiNoVen.Text = "SI";
                            lblPrecioVen.Text = "Precio: $ " + zNodo.Vende.Precio;
                        }

                        if (zNodo.Alquila.Precio == 0)
                        {
                            lblSiNoAlq.Text = "NO";
                        }
                        else
                        {
                            lblSiNoAlq.Text = "SI";
                            lblPrecioAlq.Text = "Precio: $ " + zNodo.Alquila.Precio;
                        }

                        #region Comodidades
                        lblComodidades.Text += "Baños: " + zNodo.Comodidades.Baños.ToString() + "</br>";
                        lblComodidades.Text += "Dormitorios: " + zNodo.Comodidades.Dormitorios.ToString() + "</br>";
                        if (zNodo.Comodidades.Amueblado)
                        {
                            lblComodidades.Text += "Amueblado incluido " + "</br>";
                        }
                        if (zNodo.Comodidades.EquipamientoCocina)
                        {
                            lblComodidades.Text += "Equipamiento para Cocina incluido " + "</br>";
                        }
                        if (zNodo.Comodidades.Estacionamiento)
                        {
                            lblComodidades.Text += "Estacionamiento incluido " + "</br>";
                        }
                        if (zNodo.Comodidades.EstufaALeña)
                        {
                            lblComodidades.Text += "Estufa a Leña incluida " + "</br>";
                        }
                        if (zNodo.Comodidades.Heladera)
                        {
                            lblComodidades.Text += "Heladera incluida " + "</br>";
                        }
                        if (zNodo.Comodidades.Internet)
                        {
                            lblComodidades.Text += "Internet incluido " + "</br>";
                        }
                        if (zNodo.Comodidades.Microondas)
                        {
                            lblComodidades.Text += "Microondas incluido " + "</br>";
                        }
                        if (zNodo.Comodidades.Parrillero)
                        {
                            lblComodidades.Text += "Parrillero incluido " + "</br>";
                        }
                        if (zNodo.Comodidades.Piscina)
                        {
                            lblComodidades.Text += "Piscina incluida " + "</br>";
                        }
                        if (zNodo.Comodidades.TvCable)
                        {
                            lblComodidades.Text += "TvCable incluido " + "</br>";
                        }
                        #endregion

                        lblDescripcion.Text = zNodo.Descripcion;
                        lblInfoAdi.Text = "<b>Barrio: </b>" + zNodo.Barrio.ToString() + "</br>" + "</br>" + "<b>Direccion: </b>" +
                            zNodo.Direccion.ToString() + "</br>" + "</br>" + "<b>Piso: </b>" + "</br>" + zNodo.Piso.ToString();

                        int numFotos = zNodo.List.Count;
                        for (int i = 0; i < numFotos; i++)
                        {
                            gallery.InnerHtml += "<li><img src='.." + zNodo.List[i].Direccion.Substring(1) + "' alt='' /></li>";
                        }
                    }

                }
                #endregion
            }
            else
            {
                #region Casa
                if ((Request.QueryString["inmueble"] == "Casa"))
                {
                    List<Casa> zlist = (List<Casa>)Session["ResultadoBusquedaCasa"];
                    foreach (Casa zNodo in zlist)
                    {
                        xInm = zNodo;
                        if (zNodo.Id == zId)
                        {
                            lblTitulo.Text = zNodo.Titulo;

                            if (zNodo.Vende.Precio == 0)
                            {
                                lblSiNoVen.Text = "NO";
                            }
                            else
                            {
                                lblSiNoVen.Text = "SI";
                                lblPrecioVen.Text = "Precio: $ " + zNodo.Vende.Precio;
                            }

                            if (zNodo.Alquila.Precio == 0)
                            {
                                lblSiNoAlq.Text = "NO";
                            }
                            else
                            {
                                lblSiNoAlq.Text = "SI";
                                lblPrecioAlq.Text = "Precio: $ " + zNodo.Alquila.Precio;
                            }

                            #region Comodidades
                            lblComodidades.Text += "Baños: " + zNodo.Comodidades.Baños.ToString() + "</br>";
                            lblComodidades.Text += "Dormitorios: " + zNodo.Comodidades.Dormitorios.ToString() + "</br>";
                            if (zNodo.Comodidades.Amueblado)
                            {
                                lblComodidades.Text += "Amueblado incluido " + "</br>";
                            }
                            if (zNodo.Comodidades.EquipamientoCocina)
                            {
                                lblComodidades.Text += "Equipamiento para Cocina incluido " + "</br>";
                            }
                            if (zNodo.Comodidades.Estacionamiento)
                            {
                                lblComodidades.Text += "Estacionamiento incluido " + "</br>";
                            }
                            if (zNodo.Comodidades.EstufaALeña)
                            {
                                lblComodidades.Text += "Estufa a Leña incluida " + "</br>";
                            }
                            if (zNodo.Comodidades.Heladera)
                            {
                                lblComodidades.Text += "Heladera incluida " + "</br>";
                            }
                            if (zNodo.Comodidades.Internet)
                            {
                                lblComodidades.Text += "Internet incluido " + "</br>";
                            }
                            if (zNodo.Comodidades.Microondas)
                            {
                                lblComodidades.Text += "Microondas incluido " + "</br>";
                            }
                            if (zNodo.Comodidades.Parrillero)
                            {
                                lblComodidades.Text += "Parrillero incluido " + "</br>";
                            }
                            if (zNodo.Comodidades.Piscina)
                            {
                                lblComodidades.Text += "Piscina incluida " + "</br>";
                            }
                            if (zNodo.Comodidades.TvCable)
                            {
                                lblComodidades.Text += "TvCable incluido " + "</br>";
                            }
                            #endregion

                            lblDescripcion.Text = zNodo.Descripcion;
                            lblInfoAdi.Text = "<b>Barrio: </b>" + zNodo.Barrio.ToString() + "</br>" + "</br>" +
                                "<b>Direccion: </b>" + zNodo.Direccion.ToString();

                            int numFotos = zNodo.List.Count;
                            for (int i = 0; i < numFotos; i++)
                            {
                                gallery.InnerHtml += "<li><img src='.." + zNodo.List[i].Direccion.Substring(1) + "' alt='' /></li>";
                            }
                        }
                    }
                }
                #endregion
            }



        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ModificarInmueble.aspx?id=" + xInm.Id);
        }

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            if (Session["ResultadoBusquedaCasa"] != null)
            {
                Casa zCasa = (Casa)xInm;
                Fachada fachada = new Fachada();
                fachada.EliminarCasa(zCasa);
            }
            else if (Session["ResultadoBusquedaApto"] != null)
            {
                Apartamento zApto = (Apartamento)xInm;
                Fachada fachada = new Fachada();
                fachada.EliminarApto(zApto);
            }

            Session["ResultadoBusquedaApto"] = null;
            Session["ResultadoBusquedaCasa"] = null;
            Session["Busqueda"] = null;
            Response.Redirect("~/Pages/Default.aspx");

        }
    }
}