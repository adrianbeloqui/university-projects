<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasters/Site1.Master" AutoEventWireup="true"
    CodeBehind="Ingresar.aspx.cs" Inherits="Inmobiliaria.SiteMasters.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset class="login" style="width:350px;">
        <legend>Ingreso de Usuarios</legend>
        <p>
            <asp:Label ID="lblWarning" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblUser" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server" ValidationGroup="login"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="login"
                Font-Bold="True" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblPassword" runat="server" Text="Contraseña: "></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ValidationGroup="login"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Font-Bold="True"
                ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
        </p>
        <p class="submitButton">
            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click"
                ValidationGroup="login" />
        </p>
    </fieldset>
</asp:Content>
