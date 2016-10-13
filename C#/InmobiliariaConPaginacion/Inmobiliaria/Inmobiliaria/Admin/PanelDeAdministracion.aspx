<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasters/Site1.Master" AutoEventWireup="true" CodeBehind="PanelDeAdministracion.aspx.cs" Inherits="Inmobiliaria.SiteMasters.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<fieldset class="register">
<legend>Bienvenido/a al panel de Administración</legend>
<br />
    <table style="width:900px; text-align:center;">
        <tr>
            <td>
                <asp:ImageButton ID="imgBtnIngInmuebles" ImageUrl="~/Design/addHouse.png"  Width="80px" Height="80px" runat="server" onclick="imgBtnIngInmuebles_Click"  ToolTip="Ingrese una Casa o Apartamento."  />
            </td>
            <td>
                <asp:ImageButton ID="imgBtnListInmuebles" ImageUrl="~/Design/seeListing.jpg" Width="80px" Height="80px"  runat="server" onclick="imgBtnListInmuebles_Click" ToolTip="Vea las Casas y Apartamentos a la venta y/o alquiler en su sitio."  />
            </td>
            <td>
                <asp:ImageButton ID="imgBtnListMensajes" ImageUrl="~/Design/seeMessages.jpg" Width="80px" Height="80px"  runat="server" onclick="imgBtnListMensajes_Click" ToolTip="Vea los mensajes que los clientes le dejaron en las publicaciones."  />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblIngresoInmuebles" runat="server" Text="Ingresar un Inmueble"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblListadoInmuebles" runat="server" Text="Ver todos los Inmuebles listados"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblListadoMensajes" runat="server" Text="Ver mensajes de clientes"></asp:Label>
            </td>
        </tr>
    </table>
    </fieldset>
</asp:Content>
