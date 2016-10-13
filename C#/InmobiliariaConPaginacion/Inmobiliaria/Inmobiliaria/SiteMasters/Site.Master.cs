using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inmobiliaria
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Administrador"] == null)
                {
                    //NavigationMenu.Items.Remove(NavigationMenu.Items[5]);
                    //NavigationMenu.Items.Remove(NavigationMenu.Items[4]);
                    //NavigationMenu.Items.Remove(NavigationMenu.Items[3]);
                    PanelAdmin.Visible = false;
                    imgBtnLogin.AlternateText = "Entrar";
                    imgBtnLogin.ToolTip = "Iniciar Sesión";
                    imgBtnLogin.ImageUrl = "~/Design/login1.png";
                }

                else if (Session["Administrador"] != null)
                {
                    imgBtnLogin.AlternateText = "Entrar";
                    imgBtnLogin.ToolTip = "Cerrar Sesión";
                    imgBtnLogin.ImageUrl = "~/Design/logout.png";
                    //if (NavigationMenu.Items.Count <= 4)
                    //{
                    //    MenuItem menu1 = new MenuItem();
                    //    menu1.NavigateUrl = "~/Admin/ListadoDeInmuebles.aspx";
                    //    menu1.Text = "ListadoDeInmuebles";
                    //    NavigationMenu.Items.Add(menu1);
                    //    MenuItem menu2 = new MenuItem();
                    //    menu2.NavigateUrl = "~/Admin/ListaDeMensajes.aspx";
                    //    menu2.Text = "ListadoDeMensajes";
                    //    NavigationMenu.Items.Add(menu2);
                    //    MenuItem menu3 = new MenuItem();
                    //    menu3.NavigateUrl = "~/Admin/IngresarInmueble.aspx";
                    //    menu3.Text = "IngresarInmueble";
                    //    NavigationMenu.Items.Add(menu3);
                    //    //Session["Administrador"] = null;
                    //}
                }
            }

        }

        protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["Administrador"] != null)
            {
                Response.Redirect("~/Account/Salir.aspx");
            }

            else if (Session["Administrador"] == null)
            {
                Response.Redirect("~/Account/Ingresar.aspx");
            }
        }

      
    }
}
