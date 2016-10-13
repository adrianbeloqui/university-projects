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
    public partial class FormularioInmueble : System.Web.UI.UserControl
    {
        private Fachada fachada;

        protected void Page_Load(object sender, EventArgs e)
        {
            string var = Request.QueryString["var"];

            if (var != null)
            {

            }

            if (!Page.IsPostBack)
            {

                listCasaOApto.Items.Add("---Seleccionar---");
                listCasaOApto.Items.Add("Apartamento");
                listCasaOApto.Items.Add("Casa");

                chkAmueblado.Text = "Amueblado";
                chkInternet.Text = "Internet";
                chkCocinaEquipada.Text = "Cocina Equipada";
                chkMicroondas.Text = "Microondas";
                chkTvCable.Text = "Tv Cable";
                chkParrillero.Text = "Parrillero";
                chkEstufaALeña.Text = "Estufa a Leña";
                chkEstacionamiento.Text = "Estacionamiento";
                chkPiscina.Text = "Piscina";
                chkHeladera.Text = "Heladera";

                // Add Atributes:
                listCasaOApto.Attributes.Add("onChange", "myFunction()");
                chkVenta.Attributes.Add("onClick", "myFunction()");
                chkAlquiler.Attributes.Add("onClick", "myFunction()");
                txtdormitorios.Attributes.Add("onChange", "myFunction()");
                txtPiso.Attributes.Add("onChange", "myFunction()");
                txtPrecioAlquiler.Attributes.Add("onChange", "myFunction()");
                txtPrecioVenta.Attributes.Add("onChange", "myFunction()");
                txtBaños.Attributes.Add("onChange", "myFunction()");
                listBarrios.Attributes.Add("onChange", "myFunction()");

                int zId = Convert.ToInt32(Request.QueryString["id"]);

                #region Cargado de Datos
                if (zId != 0)
                {
                    if (Request.QueryString["inmueble"] == "Apartamento")
                    {
                        listCasaOApto.SelectedIndex = 1;
                        listCasaOApto.Enabled = false;
                        List<Apartamento> zlist = (List<Apartamento>)Session["ResultadoBusquedaApto"];
                        foreach (Apartamento zNodo in zlist)
                        {
                            if (zNodo.Id == zId)
                            {
                                txtTitulo.Text = zNodo.Titulo;
                                txtDescripcion.Text = zNodo.Descripcion;
                                txtDireccion.Text = zNodo.Direccion;
                                listBarrios.SelectedValue = zNodo.Barrio;
                                listCasaOApto.SelectedValue = "Apartamento";
                                txtPiso.Text = zNodo.Piso.ToString();
                                if (zNodo.Alquila.Precio == 0)
                                {
                                    txtPrecioVenta.Text = zNodo.Vende.Precio.ToString();
                                }
                                else if (zNodo.Vende.Precio == 0)
                                {
                                    txtPrecioAlquiler.Text = zNodo.Alquila.Precio.ToString();
                                }
                                else
                                {
                                    txtPrecioVenta.Text = zNodo.Vende.Precio.ToString();
                                    txtPrecioAlquiler.Text = zNodo.Alquila.Precio.ToString();
                                }
                                txtBaños.Text = zNodo.Comodidades.Baños.ToString();
                                txtdormitorios.Text = zNodo.Comodidades.Dormitorios.ToString();

                                if (zNodo.Vende.Precio == 0)
                                {
                                    chkAlquiler.Checked = true;
                                }
                                else if (zNodo.Alquila.Precio == 0)
                                {
                                    chkVenta.Checked = true;
                                }
                                else
                                {
                                    chkVenta.Checked = true;
                                    chkAlquiler.Checked = true;
                                }

                                chkAmueblado.Checked = zNodo.Comodidades.Amueblado;
                                chkInternet.Checked = zNodo.Comodidades.Internet;
                                chkCocinaEquipada.Checked = zNodo.Comodidades.EquipamientoCocina;
                                chkMicroondas.Checked = zNodo.Comodidades.Microondas;
                                chkTvCable.Checked = zNodo.Comodidades.TvCable;
                                chkHeladera.Checked = zNodo.Comodidades.Heladera;
                                chkParrillero.Checked = zNodo.Comodidades.Parrillero;
                                chkEstufaALeña.Checked = zNodo.Comodidades.EstufaALeña;
                                chkEstacionamiento.Checked = zNodo.Comodidades.Estacionamiento;
                                chkPiscina.Checked = zNodo.Comodidades.Piscina;

                                foreach (Foto ft in zNodo.List)
                                {
                                    divFotos.InnerHtml += "<img src='.." + ft.Direccion.Substring(1) + "' alt='' height='80' width='80'> ";
                                }
                            }

                        }
                    }
                    else
                    {
                        if (Request.QueryString["inmueble"] == "Casa")
                        {
                            listCasaOApto.SelectedIndex = 2;
                            listCasaOApto.Enabled = false;
                            List<Casa> zlist = (List<Casa>)Session["ResultadoBusquedaCasa"];
                            foreach (Casa zNodo in zlist)
                            {
                                if (zNodo.Id == zId)
                                {
                                    txtTitulo.Text = zNodo.Titulo;
                                    txtDescripcion.Text = zNodo.Descripcion;
                                    txtDireccion.Text = zNodo.Direccion;
                                    listBarrios.SelectedValue = zNodo.Barrio;
                                    listCasaOApto.SelectedValue = "Casa";
                                    if (zNodo.Alquila.Precio == 0)
                                    {
                                        txtPrecioVenta.Text = zNodo.Vende.Precio.ToString();
                                    }
                                    else if (zNodo.Vende.Precio == 0)
                                    {
                                        txtPrecioAlquiler.Text = zNodo.Alquila.Precio.ToString();
                                    }
                                    else
                                    {
                                        txtPrecioVenta.Text = zNodo.Vende.Precio.ToString();
                                        txtPrecioAlquiler.Text = zNodo.Alquila.Precio.ToString();
                                    }
                                    txtBaños.Text = zNodo.Comodidades.Baños.ToString();
                                    txtdormitorios.Text = zNodo.Comodidades.Dormitorios.ToString();

                                    if (zNodo.Vende.Precio == 0)
                                    {
                                        chkAlquiler.Checked = true;
                                    }
                                    else if (zNodo.Alquila.Precio == 0)
                                    {
                                        chkVenta.Checked = true;
                                    }
                                    else
                                    {
                                        chkVenta.Checked = true;
                                        chkAlquiler.Checked = true;
                                    }

                                    chkAmueblado.Checked = zNodo.Comodidades.Amueblado;
                                    chkInternet.Checked = zNodo.Comodidades.Internet;
                                    chkCocinaEquipada.Checked = zNodo.Comodidades.EquipamientoCocina;
                                    chkMicroondas.Checked = zNodo.Comodidades.Microondas;
                                    chkTvCable.Checked = zNodo.Comodidades.TvCable;
                                    chkHeladera.Checked = zNodo.Comodidades.Heladera;
                                    chkParrillero.Checked = zNodo.Comodidades.Parrillero;
                                    chkEstufaALeña.Checked = zNodo.Comodidades.EstufaALeña;
                                    chkEstacionamiento.Checked = zNodo.Comodidades.Estacionamiento;
                                    chkPiscina.Checked = zNodo.Comodidades.Piscina;

                                    foreach (Foto ft in zNodo.List)
                                    {
                                        divFotos.InnerHtml += "<img src='.." + ft.Direccion.Substring(1) + "' alt='' height='80' width='80'> ";
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                string script = "myFunction();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "myFunction", script, true);

            }
        }

        public void boton(string nombre)
        {
            if (nombre == "ingresar")
            {
                btnModificar.Style.Add("display", "none");
                //btnModificar.Visible = false;
            }
            else
            {
                btnIngresar.Style.Add("display", "none");
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (listCasaOApto.SelectedIndex == 2)
            {
                Casa zInm = new Casa();
                zInm.Comodidades = new Comodidad();
                string tit = txtTitulo.Text;
                string desc = txtDescripcion.Text;
                string dir = txtDireccion.Text;
                string barrio = (listBarrios.SelectedItem.Text);

                #region Venta y/o alquiler

                if (chkAlquiler.Checked)
                {
                    zInm.Alquila = new Negocio(Convert.ToInt32(txtPrecioAlquiler.Text));
                }
                else
                {
                    zInm.Alquila = null;
                }

                if (chkVenta.Checked)
                {
                    zInm.Vende = new Negocio(Convert.ToInt32(txtPrecioVenta.Text));
                }
                else
                {
                    zInm.Vende = null;
                }
                #endregion

                #region Comodidades Casa

                if (chkAmueblado.Checked)
                {
                    zInm.Comodidades.Amueblado = true;
                }
                else
                {
                    zInm.Comodidades.Amueblado = false;
                }

                if (chkInternet.Checked)
                {
                    zInm.Comodidades.Internet = true;
                }
                else
                {
                    zInm.Comodidades.Internet = false;
                }

                if (chkCocinaEquipada.Checked)
                {
                    zInm.Comodidades.EquipamientoCocina = true;
                }
                else
                {
                    zInm.Comodidades.EquipamientoCocina = false;
                }

                if (chkMicroondas.Checked)
                {
                    zInm.Comodidades.Microondas = true;
                }
                else
                {
                    zInm.Comodidades.Microondas = false;
                }

                if (chkTvCable.Checked)
                {
                    zInm.Comodidades.TvCable = true;
                }
                else
                {
                    zInm.Comodidades.TvCable = false;
                }

                if (chkParrillero.Checked)
                {
                    zInm.Comodidades.Parrillero = true;
                }
                else
                {
                    zInm.Comodidades.Parrillero = false;
                }

                if (chkEstufaALeña.Checked)
                {
                    zInm.Comodidades.EstufaALeña = true;
                }
                else
                {
                    zInm.Comodidades.EstufaALeña = false;
                }

                if (chkEstacionamiento.Checked)
                {
                    zInm.Comodidades.Estacionamiento = true;
                }
                else
                {
                    zInm.Comodidades.Estacionamiento = false;
                }

                if (chkPiscina.Checked)
                {
                    zInm.Comodidades.Piscina = true;
                }
                else
                {
                    zInm.Comodidades.Piscina = false;
                }
                if (chkHeladera.Checked)
                {
                    zInm.Comodidades.Heladera = true;
                }
                else
                {
                    zInm.Comodidades.Heladera = false;
                }
                zInm.Comodidades.Baños = Convert.ToInt32(txtBaños.Text);
                zInm.Comodidades.Dormitorios = Convert.ToInt32(txtdormitorios.Text);
                #endregion

                zInm.Titulo = tit;
                fachada = new Fachada();
                zInm.Direccion = dir;
                zInm.Descripcion = desc;
                zInm.Barrio = barrio;

                AgregarFoto(zInm);

                bool rest;
                rest = fachada.AgregarCasa(zInm);

                Session["ResultadoBusquedaApto"] = null;
                Session["ResultadoBusquedaCasa"] = null;
                Session["Busqueda"] = null;
                Session["ListaFotos"] = null;
                Response.Redirect(@"~\Pages\Default.aspx?var=ing" + rest.ToString());
            }
            else if (listCasaOApto.SelectedIndex == 1)
            {
                Apartamento zInm = new Apartamento();
                zInm.Comodidades = new Comodidad();
                string tit = txtTitulo.Text;
                string desc = txtDescripcion.Text;
                string dir = txtDireccion.Text;
                string barrio = (listBarrios.SelectedItem.Text);

                #region Venta y/o alquiler
                if (chkAlquiler.Checked)
                {
                    zInm.Alquila = new Negocio(Convert.ToInt32(txtPrecioAlquiler.Text));
                }
                else
                {
                    zInm.Alquila = null;
                }

                if (chkVenta.Checked)
                {
                    zInm.Vende = new Negocio(Convert.ToInt32(txtPrecioVenta.Text));
                }
                else
                {
                    zInm.Vende = null;
                }
                #endregion

                #region Comodidades Apto
                if (chkAmueblado.Checked)
                {
                    zInm.Comodidades.Amueblado = true;
                }
                else
                {
                    zInm.Comodidades.Amueblado = false;
                }

                if (chkInternet.Checked)
                {
                    zInm.Comodidades.Internet = true;
                }
                else
                {
                    zInm.Comodidades.Internet = false;
                }

                if (chkCocinaEquipada.Checked)
                {
                    zInm.Comodidades.EquipamientoCocina = true;
                }
                else
                {
                    zInm.Comodidades.EquipamientoCocina = false;
                }

                if (chkMicroondas.Checked)
                {
                    zInm.Comodidades.Microondas = true;
                }
                else
                {
                    zInm.Comodidades.Microondas = false;
                }

                if (chkTvCable.Checked)
                {
                    zInm.Comodidades.TvCable = true;
                }
                else
                {
                    zInm.Comodidades.TvCable = false;
                }

                if (chkParrillero.Checked)
                {
                    zInm.Comodidades.Parrillero = true;
                }
                else
                {
                    zInm.Comodidades.Parrillero = false;
                }

                if (chkEstufaALeña.Checked)
                {
                    zInm.Comodidades.EstufaALeña = true;
                }
                else
                {
                    zInm.Comodidades.EstufaALeña = false;
                }

                if (chkEstacionamiento.Checked)
                {
                    zInm.Comodidades.Estacionamiento = true;
                }
                else
                {
                    zInm.Comodidades.Estacionamiento = false;
                }

                if (chkPiscina.Checked)
                {
                    zInm.Comodidades.Piscina = true;
                }
                else
                {
                    zInm.Comodidades.Piscina = false;
                }
                if (chkHeladera.Checked)
                {
                    zInm.Comodidades.Heladera = true;
                }
                else
                {
                    zInm.Comodidades.Heladera = false;
                }
                zInm.Comodidades.Baños = Convert.ToInt32(txtBaños.Text);
                zInm.Comodidades.Dormitorios = Convert.ToInt32(txtdormitorios.Text);
                #endregion

                zInm.Titulo = tit;
                fachada = new Fachada();
                zInm.Direccion = dir;
                zInm.Descripcion = desc;
                zInm.Barrio = barrio;
                zInm.Piso = Convert.ToInt32(txtPiso.Text);

                AgregarFoto(zInm);

                bool rest;
                rest = fachada.AgregarApto(zInm);

                Session["ResultadoBusquedaApto"] = null;
                Session["ResultadoBusquedaCasa"] = null;
                Session["Busqueda"] = null;
                Session["ListaFotos"] = null;
                Response.Redirect(@"~\Pages\Default.aspx?var=ing" + rest.ToString());
            }
        }

        private void AgregarFoto(Apartamento zInm)
        {
            List<FileUpload> zLista = (List<FileUpload>)Session["ListaFotos"];
            foreach (FileUpload zF in zLista)
            {
                string img = "~/Images/" + DateTime.Now.ToBinary() + ".jpg";
                zF.SaveAs(Server.MapPath("~/Images/" + DateTime.Now.ToBinary() + ".jpg"));
                zInm.AgregarFoto(img);
            }
        }

        private void AgregarFoto(Casa zInm)
        {
            List<FileUpload> zLista = (List<FileUpload>)Session["ListaFotos"];
            foreach (FileUpload zF in zLista)
            {
                string img = "~/Images/" + DateTime.Now.ToBinary() + ".jpg";
                zF.SaveAs(Server.MapPath("~/Images/" + DateTime.Now.ToBinary() + ".jpg"));
                zInm.AgregarFoto(img);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (listCasaOApto.SelectedIndex == 2)
            {
                #region Casa
                Casa zInm = new Casa();
                zInm.Comodidades = new Comodidad();
                zInm.Id = Convert.ToInt32(Request.QueryString["id"]);
                string tit = txtTitulo.Text;
                string desc = txtDescripcion.Text;
                string dir = txtDireccion.Text;
                string barrio = (listBarrios.SelectedItem.Text);

                #region Venta y/o alquiler

                if (chkAlquiler.Checked)
                {
                    zInm.Alquila = new Negocio(Convert.ToInt32(txtPrecioAlquiler.Text));
                }
                else
                {
                    zInm.Alquila = null;
                }

                if (chkVenta.Checked)
                {
                    zInm.Vende = new Negocio(Convert.ToInt32(txtPrecioVenta.Text));
                }
                else
                {
                    zInm.Vende = null;
                }
                #endregion

                #region Comodidades Casa

                if (chkAmueblado.Checked)
                {
                    zInm.Comodidades.Amueblado = true;
                }
                else
                {
                    zInm.Comodidades.Amueblado = false;
                }

                if (chkInternet.Checked)
                {
                    zInm.Comodidades.Internet = true;
                }
                else
                {
                    zInm.Comodidades.Internet = false;
                }

                if (chkCocinaEquipada.Checked)
                {
                    zInm.Comodidades.EquipamientoCocina = true;
                }
                else
                {
                    zInm.Comodidades.EquipamientoCocina = false;
                }

                if (chkMicroondas.Checked)
                {
                    zInm.Comodidades.Microondas = true;
                }
                else
                {
                    zInm.Comodidades.Microondas = false;
                }

                if (chkTvCable.Checked)
                {
                    zInm.Comodidades.TvCable = true;
                }
                else
                {
                    zInm.Comodidades.TvCable = false;
                }

                if (chkParrillero.Checked)
                {
                    zInm.Comodidades.Parrillero = true;
                }
                else
                {
                    zInm.Comodidades.Parrillero = false;
                }

                if (chkEstufaALeña.Checked)
                {
                    zInm.Comodidades.EstufaALeña = true;
                }
                else
                {
                    zInm.Comodidades.EstufaALeña = false;
                }

                if (chkEstacionamiento.Checked)
                {
                    zInm.Comodidades.Estacionamiento = true;
                }
                else
                {
                    zInm.Comodidades.Estacionamiento = false;
                }

                if (chkPiscina.Checked)
                {
                    zInm.Comodidades.Piscina = true;
                }
                else
                {
                    zInm.Comodidades.Piscina = false;
                }
                if (chkHeladera.Checked)
                {
                    zInm.Comodidades.Heladera = true;
                }
                else
                {
                    zInm.Comodidades.Heladera = false;
                }
                zInm.Comodidades.Baños = Convert.ToInt32(txtBaños.Text);
                zInm.Comodidades.Dormitorios = Convert.ToInt32(txtdormitorios.Text);
                #endregion

                zInm.Titulo = tit;
                fachada = new Fachada();
                zInm.Direccion = dir;
                zInm.Descripcion = desc;
                zInm.Barrio = barrio;
                AgregarFoto(zInm);
                bool rest;

                int zId = Convert.ToInt32(Request.QueryString["id"]);

                List<Casa> auxCasas = (List<Casa>)Session["ResultadoBusquedaCasa"];
                List<Foto> aux = new List<Foto>();

                foreach (Casa zNodo in auxCasas)
                {
                    if (zNodo.Id == zId)
                    {
                        aux = zNodo.List;
                    }
                }

                rest = fachada.ModificarCasa(zInm);

                if (rest)
                {
                    #region Eliminado de fotos
                    foreach (Foto img in aux)
                    {
                        img.eliminarFoto(path());
                    }
                    #endregion
                }

                Session["ResultadoBusquedaApto"] = null;
                Session["ResultadoBusquedaCasa"] = null;
                Session["Busqueda"] = null;
                Session["ListaFotos"] = null;
                Response.Redirect(@"~\Pages\Default.aspx?var=mod" + rest.ToString());
                #endregion
            }
            else if (listCasaOApto.SelectedIndex == 1)
            {
                #region Apartamento
                Apartamento zInm = new Apartamento();
                zInm.Comodidades = new Comodidad();
                zInm.Id = Convert.ToInt32(Request.QueryString["id"]);
                string tit = txtTitulo.Text;
                string desc = txtDescripcion.Text;
                string dir = txtDireccion.Text;
                string barrio = (listBarrios.SelectedItem.Text);

                #region Venta y/o alquiler
                if (chkAlquiler.Checked)
                {
                    zInm.Alquila = new Negocio(Convert.ToInt32(txtPrecioAlquiler.Text));
                }
                else
                {
                    zInm.Alquila = null;
                }

                if (chkVenta.Checked)
                {
                    zInm.Vende = new Negocio(Convert.ToInt32(txtPrecioVenta.Text));
                }
                else
                {
                    zInm.Vende = null;
                }
                #endregion

                #region Comodidades Apto
                if (chkAmueblado.Checked)
                {
                    zInm.Comodidades.Amueblado = true;
                }
                else
                {
                    zInm.Comodidades.Amueblado = false;
                }

                if (chkInternet.Checked)
                {
                    zInm.Comodidades.Internet = true;
                }
                else
                {
                    zInm.Comodidades.Internet = false;
                }

                if (chkCocinaEquipada.Checked)
                {
                    zInm.Comodidades.EquipamientoCocina = true;
                }
                else
                {
                    zInm.Comodidades.EquipamientoCocina = false;
                }

                if (chkMicroondas.Checked)
                {
                    zInm.Comodidades.Microondas = true;
                }
                else
                {
                    zInm.Comodidades.Microondas = false;
                }

                if (chkTvCable.Checked)
                {
                    zInm.Comodidades.TvCable = true;
                }
                else
                {
                    zInm.Comodidades.TvCable = false;
                }

                if (chkParrillero.Checked)
                {
                    zInm.Comodidades.Parrillero = true;
                }
                else
                {
                    zInm.Comodidades.Parrillero = false;
                }

                if (chkEstufaALeña.Checked)
                {
                    zInm.Comodidades.EstufaALeña = true;
                }
                else
                {
                    zInm.Comodidades.EstufaALeña = false;
                }

                if (chkEstacionamiento.Checked)
                {
                    zInm.Comodidades.Estacionamiento = true;
                }
                else
                {
                    zInm.Comodidades.Estacionamiento = false;
                }

                if (chkPiscina.Checked)
                {
                    zInm.Comodidades.Piscina = true;
                }
                else
                {
                    zInm.Comodidades.Piscina = false;
                }
                if (chkHeladera.Checked)
                {
                    zInm.Comodidades.Heladera = true;
                }
                else
                {
                    zInm.Comodidades.Heladera = false;
                }
                zInm.Comodidades.Baños = Convert.ToInt32(txtBaños.Text);
                zInm.Comodidades.Dormitorios = Convert.ToInt32(txtdormitorios.Text);
                #endregion

                zInm.Titulo = tit;
                fachada = new Fachada();
                zInm.Direccion = dir;
                zInm.Descripcion = desc;
                zInm.Barrio = barrio;
                zInm.Piso = Convert.ToInt32(txtPiso.Text);
                AgregarFoto(zInm);
                bool rest;

                int zId = Convert.ToInt32(Request.QueryString["id"]);

                List<Apartamento> auxApto = (List<Apartamento>)Session["ResultadoBusquedaApto"];
                List<Foto> aux = new List<Foto>();

                foreach (Apartamento zNodo in auxApto)
                {
                    if (zNodo.Id == zId)
                    {
                        aux = zNodo.List;
                    }
                }

                rest = fachada.ModificarApto(zInm);

                if (rest)
                {
                    #region Eliminado de fotos
                    foreach (Foto img in aux)
                    {
                        img.eliminarFoto(path());
                    }
                    #endregion
                }

                Session["ResultadoBusquedaApto"] = null;
                Session["ResultadoBusquedaCasa"] = null;
                Session["Busqueda"] = null;
                Session["ListaFotos"] = null;
                Response.Redirect(@"~\Pages\Default.aspx?var=mod" + rest.ToString());
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