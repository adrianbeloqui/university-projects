using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Collections;
namespace Inmobiliaria
{
    public partial class ListaInmuebles : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region CodigoSinPaginacion
            //if (Session["Busqueda"] == "Apartamentos y casas para alquilar" || Session["Busqueda"] == "Apartamentos y casas para vender")
            //{
            //    bool vacio = true;

            //    if (Session["ResultadoBusquedaApto"] != null)
            //    {
            //        List<Apartamento> zlist1 = (List<Apartamento>)Session["ResultadoBusquedaApto"];
            //        if (zlist1.Count != 0)
            //        {
            //            vacio = false;
            //            foreach (Apartamento zNodo in zlist1)
            //            {
            //                NodoListado nodo = new NodoListado();
            //                nodo = LoadControl("NodoListado.ascx") as NodoListado;
            //                nodo.NodoListadoApto(zNodo);
            //                PlaceHolder1.Controls.Add(nodo);
            //            }
            //        }
            //    }

            //    if (Session["ResultadoBusquedaCasa"] != null)
            //    {
            //        List<Casa> zlist2 = (List<Casa>)Session["ResultadoBusquedaCasa"];
            //        if (zlist2.Count != 0)
            //        {
            //            vacio = false;
            //            foreach (Casa zNodo in zlist2)
            //            {
            //                NodoListado nodo = new NodoListado();
            //                nodo = LoadControl("NodoListado.ascx") as NodoListado;
            //                nodo.NodoListadoCasa(zNodo);
            //                PlaceHolder1.Controls.Add(nodo);
            //            }

            //        }
            //    }

            //    if (vacio)
            //    {
            //        Label lbl = new Label();
            //        lbl.Text = "No se encontraron inmuebles de acuerdo a su busqueda";
            //        PlaceHolder1.Controls.Add(lbl);
            //    }

            //    lblCabezal.Text = Session["Busqueda"].ToString();

            //}
            //else if (Session["ResultadoBusquedaApto"] != null)
            //{
            //    List<Apartamento> zlist = (List<Apartamento>)Session["ResultadoBusquedaApto"];
            //    if (zlist.Count != 0)
            //    {
            //        foreach (Apartamento zNodo in zlist)
            //        {
            //            NodoListado nodo = new NodoListado();
            //            nodo = LoadControl("NodoListado.ascx") as NodoListado;
            //            nodo.NodoListadoApto(zNodo);
            //            PlaceHolder1.Controls.Add(nodo);
            //        }
            //    }
            //    else
            //    {
            //        Label lbl = new Label();
            //        lbl.Text = "No se encontraron inmuebles de acuerdo a su busqueda";
            //        PlaceHolder1.Controls.Add(lbl);
            //    }

            //    lblCabezal.Text = Session["Busqueda"].ToString();
            //}
            //else if (Session["ResultadoBusquedaCasa"] != null)
            //{
            //    List<Casa> zlist = (List<Casa>)Session["ResultadoBusquedaCasa"];
            //    if (zlist.Count != 0)
            //    {
            //        foreach (Casa zNodo in zlist)
            //        {
            //            NodoListado nodo = new NodoListado();
            //            nodo = LoadControl("NodoListado.ascx") as NodoListado;
            //            nodo.NodoListadoCasa(zNodo);
            //            PlaceHolder1.Controls.Add(nodo);
            //        }
            //    }
            //    else
            //    {
            //        Label lbl = new Label();
            //        lbl.Text = "No se encontraron inmuebles de acuerdo a su busqueda";
            //        PlaceHolder1.Controls.Add(lbl);
            //    }


            //    lblCabezal.Text = Session["Busqueda"].ToString();
            //}
            //else
            //{
            //    lblCabezal.Text = "Bienvenido a Inmobiliaria Tata";
            //    lblBienvenida.Text = "<p>" + "En nuestro sitio usted podrá encontrar las mejores ofertas que estan disponibles en el mercado. También le aseguramos calidad y seguridad a la hora de hacer la gestion de la compra/venta del inmueble." + "</p>" +
            //        "<p>" + "Mediante nuestro buscador, usted tendra acceso a los apartamentos y casas que estan al venta y/o alquiler en Montevideo." + "</p>" +
            //        "<p>" + "Muchas gracias por elegirnos." + "</p>";
            //}
            #endregion

            #region CodigoTurroPaginacion
            //Int32 nuevaLista = zlist1.Count + zlist2.Count;
            //ArrayList listaInmuebles = new ArrayList();
            //int j = 0;
            //int index = 0;
            //while (index < zlist1.Count && j < zlist2.Count)
            //{
            //    listaInmuebles.Add(zlist1[index]);
            //    listaInmuebles.Add(zlist2[j]);
            //    index++;
            //    j++;
            //}
            //if (index < zlist1.Count)
            //{
            //    for (int a = index; a < zlist1.Count; a++)
            //    {
            //        listaInmuebles.Add(zlist1[a]);
            //    }
            //}
            //if (j < zlist2.Count)
            //{
            //    for (int b = j; b < zlist2.Count; b++)
            //    {
            //        listaInmuebles.Add(zlist2[b]);
            //    }
            //}

            //int c = 5;
            ////if (Session["Cantidad"] != null)
            ////{
            ////    c = Convert.ToInt32(Session["Cantidad"]);

            ////}

            //btnAnterior.Visible = true;
            //btnSiguiente.Visible = true;
            //int div = listaInmuebles.Count / c;
            //int resto = listaInmuebles.Count % c;
            //if (resto > 0)
            //{
            //    div += 1;
            //}
            //int pagina = Convert.ToInt32(Request["pagina"]);
            //if (pagina == 0)
            //{
            //    btnAnterior.Visible = false;
            //}
            //if (pagina == div - 1 || listaInmuebles.Count == 0)
            //{
            //    btnSiguiente.Visible = false;
            //}

            //lblActual.Text = ("Pagina " + (pagina + 1).ToString());
            //lblCantidad.Text = "Mostrando hasta 5 resultados";

            //if (Convert.ToInt32(Session["Cantidad"]) == 10)
            //{
            //    lblCantidad.Text = "Mostrando hasta 10 resultados";
            //}
            //if (Convert.ToInt32(Session["Cantidad"]) == 15)
            //{
            //    lblCantidad.Text = "Mostrando hasta 15 resultados";
            //}

            //j = pagina * c;
            //while (j < (pagina + 1) * c && j < listaInmuebles.Count)
            //{
            //    NodoListado uc = new NodoListado();
            //    nodos = LoadControl("NodoListado.ascx") as NodoListado;
            //    if (listaInmuebles[j].GetType().ToString() == "Entidades.Venta")
            //    {
            //        nodos.NodoListadoCasa(zNodo);
            //        PlaceHolder1.Controls.Add(nodos);
            //        uc.llenarUserControl((Venta)listaInmuebles[j]);
            //    }
            //    else
            //    {
            //        nodos.NodoListadoApto(zNodo);
            //        PlaceHolder1.Controls.Add(nodos);
            //        uc.llenarUserControl((Entidades.Alquiler)listaInmuebles[j]);
            //    }
            //    PlaceHolder1.Controls.Add(uc);

            //    j++;
            #endregion


            if (Session["Busqueda"] == "Apartamentos y casas para alquilar" || Session["Busqueda"] == "Apartamentos y casas para vender")
            {
                bool vacio = true;
                if (Session["ResultadoBusquedaApto"] != null)
                {
                    #region BusquedaAptoYCasa
                    List<Apartamento> zlist1 = (List<Apartamento>)Session["ResultadoBusquedaApto"];
                    if (zlist1.Count != 0)
                    {
                        vacio = false;
                        Int32 nuevaLista = zlist1.Count;
                        ArrayList listaInmuebles = new ArrayList();
                        int j = 0;
                        int index = 0;
                        while (index < zlist1.Count)
                        {
                            listaInmuebles.Add(zlist1[index]);
                            index++;
                            j++;
                        }
                        if (index < zlist1.Count)
                        {
                            for (int a = index; a < zlist1.Count; a++)
                            {
                                listaInmuebles.Add(zlist1[a]);
                            }
                        }

                        int c = 5;
                        //if (Session["Cantidad"] != null)
                        //{
                        //    c = Convert.ToInt32(Session["Cantidad"]);

                        //}

                        btnAnterior.Visible = true;
                        btnSiguiente.Visible = true;
                        int div = listaInmuebles.Count / c;
                        int resto = listaInmuebles.Count % c;
                        if (resto > 0)
                        {
                            div += 1;
                        }
                        int pagina = Convert.ToInt32(Request["pagina"]);
                        if (pagina == 0)
                        {
                            btnAnterior.Visible = false;
                        }
                        if (pagina == div - 1 || listaInmuebles.Count == 0)
                        {
                            btnSiguiente.Visible = false;
                        }

                        lblActual.Text = ("Pagina " + (pagina + 1).ToString());
                        lblCantidad.Text = "Mostrando hasta 5 resultados";

                        if (Convert.ToInt32(Session["Cantidad"]) == 10)
                        {
                            lblCantidad.Text = "Mostrando hasta 10 resultados";
                        }
                        if (Convert.ToInt32(Session["Cantidad"]) == 15)
                        {
                            lblCantidad.Text = "Mostrando hasta 15 resultados";
                        }

                        j = pagina * c;
                        while (j < (pagina + 1) * c && j < listaInmuebles.Count)
                        {

                            foreach (Apartamento zNodo in zlist1)
                            {
                                NodoListado nodo = new NodoListado();
                                nodo = LoadControl("NodoListado.ascx") as NodoListado;
                                nodo.NodoListadoApto(zNodo);
                                PlaceHolder1.Controls.Add(nodo);
                            }

                            j++;
                        }
                    }
                }

                if (Session["ResultadoBusquedaCasa"] != null)
                {
                    List<Casa> zlist2 = (List<Casa>)Session["ResultadoBusquedaCasa"];
                    if (zlist2.Count != 0)
                    {
                        vacio = false;
                        Int32 nuevaLista = zlist2.Count;
                        ArrayList listaInmuebles = new ArrayList();
                        int j = 0;
                        int index = 0;
                        while (index < zlist2.Count)
                        {
                            listaInmuebles.Add(zlist2[index]);
                            index++;
                            j++;
                        }
                        if (index < zlist2.Count)
                        {
                            for (int a = index; a < zlist2.Count; a++)
                            {
                                listaInmuebles.Add(zlist2[a]);
                            }
                        }

                        int c = 5;
                        //if (Session["Cantidad"] != null)
                        //{
                        //    c = Convert.ToInt32(Session["Cantidad"]);

                        //}

                        btnAnterior.Visible = true;
                        btnSiguiente.Visible = true;
                        int div = listaInmuebles.Count / c;
                        int resto = listaInmuebles.Count % c;
                        if (resto > 0)
                        {
                            div += 1;
                        }
                        int pagina = Convert.ToInt32(Request["pagina"]);
                        if (pagina == 0)
                        {
                            btnAnterior.Visible = false;
                        }
                        if (pagina == div - 1 || listaInmuebles.Count == 0)
                        {
                            btnSiguiente.Visible = false;
                        }

                        lblActual.Text = ("Pagina " + (pagina + 1).ToString());
                        lblCantidad.Text = "Mostrando hasta 5 resultados";

                        if (Convert.ToInt32(Session["Cantidad"]) == 10)
                        {
                            lblCantidad.Text = "Mostrando hasta 10 resultados";
                        }
                        if (Convert.ToInt32(Session["Cantidad"]) == 15)
                        {
                            lblCantidad.Text = "Mostrando hasta 15 resultados";
                        }

                        j = pagina * c;
                        while (j < (pagina + 1) * c && j < listaInmuebles.Count)
                        {

                            foreach (Casa zNodo in zlist2)
                            {
                                NodoListado nodo = new NodoListado();
                                nodo = LoadControl("NodoListado.ascx") as NodoListado;
                                nodo.NodoListadoCasa(zNodo);
                                PlaceHolder1.Controls.Add(nodo);
                            }

                            j++;
                        }
                    }
                }

                if (vacio)
                {
                    Label lbl = new Label();
                    lbl.Text = "No se encontraron inmuebles de acuerdo a su busqueda";
                    PlaceHolder1.Controls.Add(lbl);
                }

                lblCabezal.Text = Session["Busqueda"].ToString();
                    #endregion
            }
            else if (Session["ResultadoBusquedaApto"] != null)
            {
                #region BusquedaApto
                List<Apartamento> zlist1 = (List<Apartamento>)Session["ResultadoBusquedaApto"];
                if (zlist1.Count != 0)
                #region Paginacion Apto
                {
                    Int32 nuevaLista = zlist1.Count;
                    ArrayList listaInmuebles = new ArrayList();
                    int j = 0;
                    int index = 0;
                    while (index < zlist1.Count)
                    {
                        listaInmuebles.Add(zlist1[index]);
                        index++;
                        j++;
                    }
                    if (index < zlist1.Count)
                    {
                        for (int a = index; a < zlist1.Count; a++)
                        {
                            listaInmuebles.Add(zlist1[a]);
                        }
                    }

                    int c = 5;
                    //if (Session["Cantidad"] != null)
                    //{
                    //    c = Convert.ToInt32(Session["Cantidad"]);

                    //}

                    btnAnterior.Visible = true;
                    btnSiguiente.Visible = true;
                    int div = listaInmuebles.Count / c;
                    int resto = listaInmuebles.Count % c;
                    if (resto > 0)
                    {
                        div += 1;
                    }
                    int pagina = Convert.ToInt32(Request["pagina"]);
                    if (pagina == 0)
                    {
                        btnAnterior.Visible = false;
                    }
                    if (pagina == div - 1 || listaInmuebles.Count == 0)
                    {
                        btnSiguiente.Visible = false;
                    }

                    lblActual.Text = ("Pagina " + (pagina + 1).ToString());
                    lblCantidad.Text = "Mostrando hasta 5 resultados";

                    if (Convert.ToInt32(Session["Cantidad"]) == 10)
                    {
                        lblCantidad.Text = "Mostrando hasta 10 resultados";
                    }
                    if (Convert.ToInt32(Session["Cantidad"]) == 15)
                    {
                        lblCantidad.Text = "Mostrando hasta 15 resultados";
                    }

                    j = pagina * c;
                    while (j < (pagina + 1) * c && j < listaInmuebles.Count)
                    {

                        foreach (Apartamento zNodo in zlist1)
                        {
                            NodoListado nodo = new NodoListado();
                            nodo = LoadControl("NodoListado.ascx") as NodoListado;
                            nodo.NodoListadoApto(zNodo);
                            PlaceHolder1.Controls.Add(nodo);
                        }
                        j++;
                    }
                }

                #endregion
                else
                {
                    Label lbl = new Label();
                    lbl.Text = "No se encontraron inmuebles de acuerdo a su busqueda";
                    PlaceHolder1.Controls.Add(lbl);
                }

                lblCabezal.Text = Session["Busqueda"].ToString();
                #endregion
            }
            else if (Session["ResultadoBusquedaCasa"] != null)
            {
                #region BusquedaCasa
                List<Casa> zlist = (List<Casa>)Session["ResultadoBusquedaCasa"];
                if (zlist.Count != 0)
                {
                    Int32 nuevaLista = zlist.Count;
                    ArrayList listaInmuebles = new ArrayList();
                    int j = 0;
                    int index = 0;
                    while (index < zlist.Count)
                    {
                        listaInmuebles.Add(zlist[index]);
                        index++;
                        j++;
                    }
                    if (index < zlist.Count)
                    {
                        for (int a = index; a < zlist.Count; a++)
                        {
                            listaInmuebles.Add(zlist[a]);
                        }
                    }

                    int c = 5;
                    //if (Session["Cantidad"] != null)
                    //{
                    //    c = Convert.ToInt32(Session["Cantidad"]);

                    //}

                    btnAnterior.Visible = true;
                    btnSiguiente.Visible = true;
                    int div = listaInmuebles.Count / c;
                    int resto = listaInmuebles.Count % c;
                    if (resto > 0)
                    {
                        div += 1;
                    }
                    int pagina = Convert.ToInt32(Request["pagina"]);
                    if (pagina == 0)
                    {
                        btnAnterior.Visible = false;
                    }
                    if (pagina == div - 1 || listaInmuebles.Count == 0)
                    {
                        btnSiguiente.Visible = false;
                    }

                    lblActual.Text = ("Pagina " + (pagina + 1).ToString());
                    lblCantidad.Text = "Mostrando hasta 5 resultados";

                    if (Convert.ToInt32(Session["Cantidad"]) == 10)
                    {
                        lblCantidad.Text = "Mostrando hasta 10 resultados";
                    }
                    if (Convert.ToInt32(Session["Cantidad"]) == 15)
                    {
                        lblCantidad.Text = "Mostrando hasta 15 resultados";
                    }

                    j = pagina * c;
                    while (j < (pagina + 1) * c && j < listaInmuebles.Count)
                    {

                        foreach (Casa zNodo in zlist)
                        {
                            NodoListado nodo = new NodoListado();
                            nodo = LoadControl("NodoListado.ascx") as NodoListado;
                            nodo.NodoListadoCasa(zNodo);
                            PlaceHolder1.Controls.Add(nodo);
                        }

                        j++;
                    }
                }
                else
                {
                    Label lbl = new Label();
                    lbl.Text = "No se encontraron inmuebles de acuerdo a su busqueda";
                    PlaceHolder1.Controls.Add(lbl);
                }


                lblCabezal.Text = Session["Busqueda"].ToString();
            }
            else
            {
                lblCabezal.Text = "Bienvenido a Inmobiliaria Tata";
                lblBienvenida.Text = "<p>" + "En nuestro sitio usted podrá encontrar las mejores ofertas que estan disponibles en el mercado. También le aseguramos calidad y seguridad a la hora de hacer la gestion de la compra/venta del inmueble." + "</p>" +
                    "<p>" + "Mediante nuestro buscador, usted tendra acceso a los apartamentos y casas que estan al venta y/o alquiler en Montevideo." + "</p>" +
                    "<p>" + "Muchas gracias por elegirnos." + "</p>";
            }
                #endregion
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            int pagina = Convert.ToInt32(Request["pagina"]) + 1;
            Response.Redirect("Default.aspx?pagina=" + pagina.ToString());
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            int pagina = Convert.ToInt32(Request["pagina"]) + 1;
            Response.Redirect("Default.aspx?pagina=" + pagina.ToString());
        }


    }
}