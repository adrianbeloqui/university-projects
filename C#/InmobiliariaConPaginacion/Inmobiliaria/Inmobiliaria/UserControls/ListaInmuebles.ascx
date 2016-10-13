<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListaInmuebles.ascx.cs" Inherits="Inmobiliaria.ListaInmuebles" %>
<style type="text/css">
    .style1
    {
        text-align:left;
    }
    .style2
    {
        text-align:right;
    }
    .style3
    {
        text-align:center;
    }
</style>

<asp:Label ID="lblCabezal" runat="server" Text="" 
    Font-Bold="True" Font-Size="X-Large"></asp:Label>
<br />
<asp:Label ID="lblBienvenida" runat="server" Text=""></asp:Label>
<br />
<asp:PlaceHolder ID="PlaceHolder1" runat="server">

</asp:PlaceHolder>
<br />
<asp:Button ID="btnAnterior" runat="server" Text="Anterior" OnClick="btnAnterior_Click"  CssClass="style1"/>

<asp:Label ID="lblActual" runat="server" Text="" CssClass="style3" ></asp:Label>
<asp:Label ID="lblCantidad" runat="server" Text="" CssClass="style3" ></asp:Label>

<asp:Button ID="btnSiguiente" runat="server" Text="Siguiente"  OnClick="btnSiguiente_Click" CssClass="style2"/>