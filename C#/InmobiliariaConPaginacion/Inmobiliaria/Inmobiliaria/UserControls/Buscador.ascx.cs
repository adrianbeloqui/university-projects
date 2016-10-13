using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocios;
using Entidades;

namespace Inmobiliaria
{
    public partial class Buscador : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listOperacion.Items.Add("---Seleccionar---");
                listOperacion.Items.Add("Alquiler");
                listOperacion.Items.Add("Venta");

                listTipo.Items.Add("---Seleccionar---");
                listTipo.Items.Add("Casa");
                listTipo.Items.Add("Apartamento");

                listDormitorios.Items.Add("---Seleccionar---");
                listDormitorios.Items.Add("1");
                listDormitorios.Items.Add("2");
                listDormitorios.Items.Add("3");
                listDormitorios.Items.Add("4");
                listDormitorios.Items.Add("5");
                listDormitorios.Items.Add("6 o más");

                listComodidades.Items.Add("Amueblado");
                listComodidades.Items.Add("Internet");
                listComodidades.Items.Add("Cocina Equipada");
                listComodidades.Items.Add("Microondas");
                listComodidades.Items.Add("Tv Cable");
                listComodidades.Items.Add("Parrillero");
                listComodidades.Items.Add("Estufa a Leña");
                listComodidades.Items.Add("Estacionamiento");
                listComodidades.Items.Add("Piscina");
                listComodidades.Items.Add("Heladera");

                txtBaños.Attributes.Add("onChange", "myFunction()");
                txtPrecioMax.Attributes.Add("onChange", "myFunction()");
                txtPrecioMin.Attributes.Add("onChange", "myFunction()");
                listOperacion.Attributes.Add("onChange", "myFunction()");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Fachada f = new Fachada();
            Session["ResultadoBusquedaApto"] = null;
            Session["ResultadoBusquedaCasa"] = null;
            Session["Busqueda"] = null;

            #region Comodidades
            Comodidad zComodidad = new Comodidad();
            if (listDormitorios.SelectedIndex != 0)
            {
                zComodidad.Dormitorios = listDormitorios.SelectedIndex;
            }
            foreach (ListItem zItem in this.listComodidades.Items)
            {
                switch (zItem.Value)
                {
                    case "Amueblado":
                        zComodidad.Amueblado = zItem.Selected;
                        break;
                    case "Heladera":
                        zComodidad.Heladera = zItem.Selected;
                        break;
                    case "Internet":
                        zComodidad.Internet = zItem.Selected;
                        break;
                    case "Cocina Equipada":
                        zComodidad.EquipamientoCocina = zItem.Selected;
                        break;
                    case "Microondas":
                        zComodidad.Microondas = zItem.Selected;
                        break;
                    case "Tv Cable":
                        zComodidad.TvCable = zItem.Selected;
                        break;
                    case "Parrillero":
                        zComodidad.Parrillero = zItem.Selected;
                        break;
                    case "Estufa a Leña":
                        zComodidad.EstufaALeña = zItem.Selected;
                        break;
                    case "Estacionamiento":
                        zComodidad.Estacionamiento = zItem.Selected;
                        break;
                    case "Piscina":
                        zComodidad.Piscina = zItem.Selected;
                        break;
                }
            }
            #endregion


            if (listTipo.SelectedValue == "Apartamento")
            {
                #region Busqueda Apto

                BusquedaApto zBusquedaApto;
                int precioMin = 0;
                int precioMax = 0;
                if (txtPrecioMin.Text != "")
                {
                    precioMin = Convert.ToInt32(txtPrecioMin.Text);
                }
                if (txtPrecioMax.Text != "")
                {
                    precioMax = Convert.ToInt32(txtPrecioMax.Text);
                }
                string barrio = null;
                if (ddlBarrios.SelectedValue != "---Seleccionar---")
                {
                    barrio = ddlBarrios.SelectedValue;
                }
                if (listOperacion.SelectedValue == "Venta")
                {
                    zBusquedaApto = new BusquedaApto("Venta", precioMin,
                        precioMax, zComodidad,
                        listTipo.SelectedValue, barrio);
                    Session["Busqueda"] = "Apartamentos para vender";
                }
                else
                {
                    zBusquedaApto = new BusquedaApto("Alquiler", precioMin,
                        precioMax, zComodidad,
                        listTipo.SelectedValue, barrio);
                    Session["Busqueda"] = "Apartamentos para alquilar";
                }

                if (txtBaños.Text != "")
                {
                    zBusquedaApto.aComodidad.Baños = Convert.ToInt32(txtBaños.Text);
                }
                else
                {
                    zBusquedaApto.aComodidad.Baños = 0;
                }

                List<Apartamento> resultadoBusqueda = f.BuscarApto(zBusquedaApto);
                Session["ResultadoBusquedaApto"] = resultadoBusqueda;

                #endregion
            }
            else if (listTipo.SelectedValue == "Casa")
            {
                #region Busqueda Casa

                BusquedaCasa zBusquedaCasa;
                int precioMin = 0;
                int precioMax = 0;
                if (txtPrecioMin.Text != "")
                {
                    precioMin = Convert.ToInt32(txtPrecioMin.Text);
                }
                if (txtPrecioMax.Text != "")
                {
                    precioMax = Convert.ToInt32(txtPrecioMax.Text);
                }

                string barrio = null;
                if (ddlBarrios.SelectedValue != "---Seleccionar---")
                {
                    barrio = ddlBarrios.SelectedValue;
                }

                if (listOperacion.SelectedValue == "Venta")
                {
                    zBusquedaCasa = new BusquedaCasa("Venta", precioMin,
                        precioMax, zComodidad,
                        listTipo.SelectedValue, barrio);
                    Session["Busqueda"] = "Casas para vender";
                }
                else
                {
                    zBusquedaCasa = new BusquedaCasa("Alquiler", precioMin,
                        precioMax, zComodidad,
                        listTipo.SelectedValue, barrio);
                    Session["Busqueda"] = "Casas para alquilar";
                }
                if (txtBaños.Text != "")
                {
                    zBusquedaCasa.aComodidad.Baños = Convert.ToInt32(txtBaños.Text);
                }
                else
                {
                    zBusquedaCasa.aComodidad.Baños = 0;
                }
                List<Casa> resultadoBusqueda = f.BuscarCasa(zBusquedaCasa);
                Session["ResultadoBusquedaCasa"] = resultadoBusqueda;

                #endregion
            }
            else
            {
                #region Busqueda Apto y Casa

                BusquedaApto zBusquedaApto;
                BusquedaCasa zBusquedaCasa;
                int precioMin = 0;
                int precioMax = 0;
                if (txtPrecioMin.Text != "")
                {
                    precioMin = Convert.ToInt32(txtPrecioMin.Text);
                }
                if (txtPrecioMax.Text != "")
                {
                    precioMax = Convert.ToInt32(txtPrecioMax.Text);
                }

                string barrio = null;
                if (ddlBarrios.SelectedValue != "---Seleccionar---")
                {
                    barrio = ddlBarrios.SelectedValue; ;
                }

                if (listOperacion.SelectedValue == "Venta")
                {
                    zBusquedaApto = new BusquedaApto("Venta", precioMin,
                        precioMax, zComodidad,
                        listTipo.SelectedValue, barrio);
                    zBusquedaCasa = new BusquedaCasa("Venta", precioMin,
                        precioMax, zComodidad,
                        listTipo.SelectedValue, barrio);
                    Session["Busqueda"] = "Apartamentos y casas para vender";
                }
                else
                {
                    zBusquedaApto = new BusquedaApto("Alquiler", precioMin,
                        precioMax, zComodidad,
                        listTipo.SelectedValue, barrio);
                    zBusquedaCasa = new BusquedaCasa("Alquiler", precioMin,
                        precioMax, zComodidad,
                        listTipo.SelectedValue, barrio);
                    Session["Busqueda"] = "Apartamentos y casas para alquilar";
                }
                if (txtBaños.Text != "")
                {
                    zBusquedaApto.aComodidad.Baños = Convert.ToInt32(txtBaños.Text);
                }
                else
                {
                    zBusquedaApto.aComodidad.Baños = 0;
                }

                List<Casa> resultadoBusquedaCasas = f.BuscarCasa(zBusquedaCasa);
                Session["ResultadoBusquedaCasa"] = resultadoBusquedaCasas;
                List<Apartamento> resultadoBusquedaAptos = f.BuscarApto(zBusquedaApto);
                Session["ResultadoBusquedaApto"] = resultadoBusquedaAptos;

                #endregion
            }

            listOperacion.SelectedIndex = 0;
            listTipo.SelectedIndex = 0;
            listDormitorios.SelectedIndex = 0;
            txtPrecioMax.Text = "";
            txtPrecioMin.Text = "";
            txtBaños.Text = "";
            ddlBarrios.SelectedIndex = 0;

            Response.Redirect("~/Pages/Default.aspx");
        }
    }
}

