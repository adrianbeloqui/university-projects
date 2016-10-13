<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NodoListado.ascx.cs" Inherits="Inmobiliaria.NodoListado" %>

<link rel="stylesheet" type="text/css" href="../Styles/StyleNodoListado.css" />
  
<table id="nodoListado" style="border: 1px solid #99CCFF; width: 650px; background-color: #F5FFFA" 
 cellpadding="2" cellspacing="2" align="center" 
    frame="box">
    <tr>
        <td class="style1" rowspan="4">
            <asp:ImageButton ID="imgButton" runat="server" Height="100px" Width="160px" 
                onclick="imgButton_Click"/></td>
        
        <td colspan="3" align="left" style="width:410px">
            <asp:Label ID="lblTextoTitulo" runat="server" Font-Bold="True" 
                Font-Size="Large" ForeColor="Black"></asp:Label>
       </td>
        <td>
        <asp:Label ID="lblArt" runat="server" Text="Art: " Font-Bold="True" ForeColor="Black" ></asp:Label>
            <asp:Label ID="lblId" runat="server" Text="" ForeColor="Black"></asp:Label>
        </td>
    </tr>
    
    <tr>
        <td align="left" style="width:150px">
            <asp:Label ID="lblPrecioTit" runat="server" Text="Se Vende: " Font-Bold="True" ForeColor="Black"></asp:Label>&nbsp;

            <asp:Label ID="lblSiNoVen" runat="server" Text="" ForeColor="Black"></asp:Label>
            </td>
        <td colspan="2" style="width:260px">
            <asp:Label ID="lblPrecioVen" runat="server" Text="" ForeColor="Black"></asp:Label></td>
            
        <td>
            <asp:Label ID="lblInmueble" runat="server" Text="" ForeColor="Black"></asp:Label>
        </td>
    </tr>
    
    <tr>
        <td align="left" style="width:150px">
            <asp:Label ID="lblPrecioTit0" runat="server" Text="Se Alquila:  " Font-Bold="True" ForeColor="Black"></asp:Label>&nbsp;
            <asp:Label ID="lblSiNoAlq" runat="server" Text="" ForeColor="Black"></asp:Label>
            </td>
        <td align="left" style="width:220px">
            <asp:Label ID="lblPrecioAlq" runat="server" Text="" ForeColor="Black"></asp:Label>
        </td>
        <td align="right" class="style3">
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Height="23px" 
                Width="80px" OnClientClick="javascript:if(!confirm('¿Desea eliminar este Inmueble?'))return false"
                onclick="btnEliminar_Click1" />
        </td>
        <td align="right" class="style3">
            <asp:Button ID="btnActualizar" runat="server" Text="Modificar" Height="24px" 
                Width="80px" onclick="btnActualizar_Click"  />
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="width:490px">
            <asp:Label ID="lblTitBarrio" runat="server" Text="Barrio:  " Font-Bold="True" ForeColor="Black"></asp:Label>&nbsp;
            <asp:Label ID="lblBarrio" runat="server" Text="" ForeColor="Black"></asp:Label>
        </td>
    </tr>
    </table>