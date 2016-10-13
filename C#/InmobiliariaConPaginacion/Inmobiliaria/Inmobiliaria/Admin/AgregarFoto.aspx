<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarFoto.aspx.cs" Inherits="Inmobiliaria.Admin.AgregarFoto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function closeFotos() {
            window.close();
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="FUFoto" runat="server" />
        <br />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
            onclick="btnAgregar_Click" />
        <hr />
        <asp:ListBox ID="lstFotos" runat="server" Height="163px" Width="476px">
        </asp:ListBox>
        <br />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
            onclick="btnEliminar_Click" />
        <hr />
    </div>
    <div>
        <button type="button" onclick="closeFotos()">Listo</button>
        <hr />
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>    
</body>
</html>
