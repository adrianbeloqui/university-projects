<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasters/Site1.Master" AutoEventWireup="true" CodeBehind="MostrarMensaje.aspx.cs" Inherits="Inmobiliaria.Admin.MostrarMensaje" %>
<%@ Register src="~/UserControls/Mensaje.ascx" tagname="Mensaje" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<link href="Styles/StyleNodoListado.css" rel="stylesheet" type="text/css" />

<div>
</div>
<div>
    
    <table style="width:100%;">
        <tr>
            <td class="style4">
                Nombre</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="157px" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validNombre" runat="server" 
                    ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Telefono</td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server" Width="157px" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validTelefono" runat="server" 
                    ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTelefono"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Mail</td>
            <td>
                <asp:TextBox ID="txtMail" runat="server" Width="157px" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validMail" runat="server" 
                    ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMail"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</div>
<div>
    <hr />
    <span style="font-style: normal; font-size: large; text-decoration: underline">
        Mensaje   
    </span>
    <asp:RequiredFieldValidator ID="valuidMensaje" runat="server" 
            ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMensaje"></asp:RequiredFieldValidator> 
</div>
<div>
    <asp:TextBox ID="txtMensaje" runat="server" Height="156px" TextMode="MultiLine" 
        Width="454px" ReadOnly="True"></asp:TextBox>
    <hr />
</div>
<div>
    <asp:Button ID="btnVolver" runat="server" Text="Volver" 
        onclick="btnVolver_Click" />
</div>

</asp:Content>




  