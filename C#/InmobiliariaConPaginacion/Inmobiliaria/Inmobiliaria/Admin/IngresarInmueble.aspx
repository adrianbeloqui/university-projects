<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasters/Site1.Master" AutoEventWireup="true" CodeBehind="IngresarInmueble.aspx.cs" Inherits="Inmobiliaria.Admin.IngresarInmueble" %>
<%@ Register src="../UserControls/FormularioInmueble.ascx" tagname="FormularioInmueble" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/JSFormulario.js" type="text/javascript"></script>
    <script src="../Scripts/jsfotos.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:FormularioInmueble ID="FormularioInmueble1" runat="server"/>

</asp:Content>
