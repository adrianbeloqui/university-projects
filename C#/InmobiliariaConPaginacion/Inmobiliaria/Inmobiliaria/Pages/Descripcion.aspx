<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasters/Site1.Master" AutoEventWireup="true" CodeBehind="Descripcion.aspx.cs" Inherits="Inmobiliaria.Descripcion" %>

<%@ Register src="../UserControls/Mensaje.ascx" tagname="Mensaje" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link href="../Styles/StyleDescripcion.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Galeria.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.js" type="text/javascript"></script>    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<br />
<hr />
<table>
    <tr>
        <td class="style5" rowspan="5" valign="top">
        <div style="position:relative; top: 0px; left: 0px; height: 301px;">
           
            
           
            
 
 <ul id="gallery" runat="server">
 </ul>


 </div>
        </td>
        <td class="style14" valign="top" align="left">
            <asp:Label ID="lblTitulo" runat="server" Text="TITULO" Font-Bold="True" 
                Font-Size="X-Large"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style15" valign="baseline" align="left">
            <asp:Label ID="txtAlquilaTit" runat="server" Text="Se Alquila: "></asp:Label>&nbsp&nbsp
            <asp:Label ID="lblSiNoAlq" runat="server" Text=""></asp:Label>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Label ID="lblPrecioAlq" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style8" valign="top" align="left">
            <asp:Label ID="txtVendeTit" runat="server" Text="Se Vende: "></asp:Label>&nbsp&nbsp
            <asp:Label ID="lblSiNoVen" runat="server" Text=""></asp:Label>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Label ID="lblPrecioVen" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style16" bgcolor="#CCCCCC" valign="top" align="left">
        <h6 style="color: #000000; font-weight: bold; vertical-align: top;">Comodidades:</h6>
        <hr />
        <asp:Label ID="lblComodidades" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style14" bgcolor="White" valign="top" align="left">
            &nbsp;</td>
    </tr>
</table>
<hr />
        <h4 style="font-weight: bold; color: #000000">Descripción:</h4><br />
        <asp:Label ID="lblDescripcion" runat="server" Text="ACA VA LA DESCRIPCION DEL ARTICULO"></asp:Label>
<br />
<br />
<hr />
    <h4 style="font-weight: bold; color: #000000">Información Adicional:</h4><br />
    <asp:Label ID="lblInfoAdi" runat="server" Text="ACA VA LA DESCRIPCION DEL ARTICULO"></asp:Label>
<br />
<br />
<hr />
<table>
<tr>
<td class="style10">
<span style="font-weight: bold; color: #000000; font-size: large;">Deja un mensaje:</span> &nbsp;&nbsp;&nbsp; 
    <input type="button" value="Mostrar/Ocultar" id="mostrarOcultar" />
</td>
    <td class="style11">
        &nbsp;</td>
</tr>
</table>

<br />
<hr />
<div id="divMsj">
    <br />
    <uc1:Mensaje ID="Mensaje1" runat="server" />
    <br /> 
</div>
<hr />


    
<script>
        $("#divMsj").hide();
        $(document).ready(function() {
            $("#mostrarOcultar").click(function () {
                $("#divMsj").toggle("slow");
            });
        });
</script>


</asp:Content>