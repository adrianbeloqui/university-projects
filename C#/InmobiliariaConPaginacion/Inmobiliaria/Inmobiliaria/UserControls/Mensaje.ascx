<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Mensaje.ascx.cs" Inherits="Inmobiliaria.Mensaje" %>


<link href="../Styles/StyleNodoListado.css" rel="stylesheet" type="text/css" />

<div>
</div>
<div>
    
    <table style="width:100%;">
        <tr>
            <td class="style4">
                Nombre</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="157px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validNombre" runat="server" 
                    ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Telefono</td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server" Width="157px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validTelefono" runat="server" 
                    ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTelefono"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Mail</td>
            <td>
                <asp:TextBox ID="txtMail" runat="server" Width="157px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validMail" runat="server" 
                    ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMail"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                    runat="server" ErrorMessage="Mail incorrecto" ControlToValidate="txtMail" 
                    ForeColor="Red" 
                    ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$"></asp:RegularExpressionValidator>
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
        Width="454px"></asp:TextBox>
    <hr />
</div>
<div>
    <asp:Button ID="btnEnviar" runat="server" Text="Enviar Mensaje" 
        onclick="btnEnviar_Click" />
</div>
