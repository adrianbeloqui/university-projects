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
    public partial class NodoListado : System.Web.UI.UserControl
    {
        private Inmueble xInm;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] == null)
            {
                btnActualizar.Visible = false;
                btnEliminar.Visible = false;
            }
            else
            {
                btnActualizar.Visible = true;
                btnEliminar.Visible = true;
            }
        }

        public void NodoListadoApto(Apartamento zAp)
        {
            xInm = zAp;
            lblInmueble.Text = "Apartamento";

            if (zAp.List.Count != 0)
            {
                imgButton.ImageUrl = zAp.List[0].Direccion;
            }

            lblTextoTitulo.Text = zAp.Titulo;

            if (zAp.Vende.Precio == 0)
            {
                lblSiNoVen.Text = "NO";
            }
            else
            {
                lblSiNoVen.Text = "SI";
                lblPrecioVen.Text = "Precio: $ " + zAp.Vende.Precio;
            }

            if (zAp.Alquila.Precio == 0)
            {
                lblSiNoAlq.Text = "NO";
            }
            else
            {
                lblSiNoAlq.Text = "SI";
                lblPrecioAlq.Text = "Precio: $ " + zAp.Alquila.Precio;
            }

            lblBarrio.Text = zAp.Barrio;

            lblId.Text = zAp.Id.ToString();

        }

        public void NodoListadoCasa(Casa zCa)
        {
            xInm = zCa;
            lblInmueble.Text = "Casa";

            if (zCa.List.Count != 0)
            {
                imgButton.ImageUrl = zCa.List[0].Direccion;
            }

            lblTextoTitulo.Text = zCa.Titulo;

            if (zCa.Vende.Precio == 0)
            {
                lblSiNoVen.Text = "NO";
            }
            else
            {
                lblSiNoVen.Text = "SI";
                lblPrecioVen.Text = "Precio: $ " + zCa.Vende.Precio;
            }

            if (zCa.Alquila.Precio == 0)
            {
                lblSiNoAlq.Text = "NO";
            }
            else
            {
                lblSiNoAlq.Text = "SI";
                lblPrecioAlq.Text = "Precio: $ " + zCa.Alquila.Precio;
            }

            lblBarrio.Text = zCa.Barrio;

            lblId.Text = zCa.Id.ToString();

        }

        protected void imgButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/Descripcion.aspx?id=" + lblId.Text + "&inmueble=" + lblInmueble.Text);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ModificarInmueble.aspx?id=" + lblId.Text + "&inmueble=" + lblInmueble.Text);
        }

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            if (lblInmueble.Text == "Casa")
            {
                #region Casa
                Casa zCasa = (Casa)xInm;
                Fachada fachada = new Fachada();
                bool rest;

                int zId = Convert.ToInt32(lblId.Text);

                List<Casa> auxCasas = (List<Casa>)Session["ResultadoBusquedaCasa"];
                List<Foto> aux = new List<Foto>();

                foreach (Casa zNodo in auxCasas)
                {
                    if (zNodo.Id == zId)
                    {
                        aux = zNodo.List;
                    }
                }

                rest = fachada.EliminarCasa(zCasa);

                if (rest)
                {
                    #region Eliminado de fotos
                    foreach (Foto img in aux)
                    {
                        img.eliminarFoto(path());
                    }
                    #endregion
                    auxCasas.Remove(zCasa);
                    Session["ResultadoBusquedaCasa"] = auxCasas;
                }
                Session["ListaFotos"] = null;

                Response.Redirect("~/Pages/Default.aspx?var=del" + rest.ToString());
                #endregion Casa
            }
            else if (lblInmueble.Text == "Apartamento")
            {
                #region Apartamento
                Apartamento zApto = (Apartamento)xInm;
                Fachada fachada = new Fachada();
                bool rest;

                int zId = Convert.ToInt32(lblId.Text);

                List<Apartamento> auxApto = (List<Apartamento>)Session["ResultadoBusquedaApto"];
                List<Foto> aux = new List<Foto>();

                foreach (Apartamento zNodo in auxApto)
                {
                    if (zNodo.Id == zId)
                    {
                        aux = zNodo.List;
                    }
                }

                rest = fachada.EliminarApto(zApto);

                if (rest)
                {
                    #region Eliminado de fotos
                    foreach (Foto img in aux)
                    {
                        img.eliminarFoto(path());
                    }
                    #endregion
                    auxApto.Remove(zApto);
                    Session["ResultadoBusquedaApto"] = auxApto;
                }
                Session["ListaFotos"] = null;

                Response.Redirect("~/Pages/Default.aspx?var=del" + rest.ToString());
                #endregion
            }
        }

        private string path()
        {
            string appPath = HttpContext.Current.Request.ApplicationPath;
            string physicalPath = HttpContext.Current.Request.MapPath(appPath);
            return physicalPath;
        }
    }
}