<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/SiteMasters/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Inmobiliaria._Default" %>

<%@ Register src="~/UserControls/Buscador.ascx" tagname="Buscador" tagprefix="uc1" %>

<%@ Register src="../UserControls/ListaInmuebles.ascx" tagname="ListaInmuebles" tagprefix="uc3" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 88px;
        }
    </style>
    <script src="../Scripts/javascript.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="ColumnContent" runat="server" ContentPlaceHolderID="LeftColumnContent">
    
    <uc1:Buscador ID="Buscador1" runat="server" />
    
</asp:Content>
<asp:Content ID= "BodyContent" runat="server" ContentPlaceHolderID= "MainContent">
    <asp:Label ID="lblEncabezado" runat="server"  Text="" Font-Bold="True" 
        Font-Overline="False" Font-Size="X-Large" Font-Underline="True"></asp:Label>
        <br />
        <br />

    <uc3:ListaInmuebles ID="ListaInmuebles1" runat="server" />
</asp:Content>
