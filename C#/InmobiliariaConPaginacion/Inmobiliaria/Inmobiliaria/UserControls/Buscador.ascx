<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Buscador.ascx.cs" Inherits="Inmobiliaria.Buscador" %>
<style type="text/css">
    .style1
    {
        width: 180px;
    }
    .style3
    {
        width: 213px;
    }
    .style4
    {
        width: 261px;
    }
</style>
<fieldset class="buscador">
    <h1 style="color: #000000; text-decoration: underline; font-weight: bold">
        Buscador</h1>
    <br />
    <hr />
    <table class="style1">
        <tr>
            <td class="style4">
                <asp:Label ID="lblOperacion" runat="server" Text="Operación: "></asp:Label>
                <span id="validOperacion" style="color: #FF0000; font-size: large; visibility: visible;">
                    *</span>
            </td>
            <td class="style3">
                <asp:DropDownList ID="listOperacion" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Tipo:
            </td>
            <td class="style3">
                <asp:DropDownList ID="listTipo" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Barrio:
            </td>
            <td class="style3">
                <asp:DropDownList ID="ddlBarrios" runat="server" DataSourceID="SqlDataSource1" 
                    DataTextField="Nombre" DataValueField="Nombre">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:InmobiliariaTATAListadoInmueblesConnectionString %>" 
                    SelectCommand="SELECT [Nombre] FROM [Barrios] ORDER BY [Nombre]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Precio min: <span id="validPrecioMin" style="color: #FF0000; font-size: large; visibility: hidden;">
                    *</span>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtPrecioMin" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Precio max: <span id="validPrecioMax" style="color: #FF0000; font-size: large; visibility: hidden;">
                    *</span>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtPrecioMax" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Dormitorios:
            </td>
            <td class="style3">
                <asp:DropDownList ID="listDormitorios" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Baños: <span id="validBaños" style="color: #FF0000; font-size: large; visibility: hidden;">
                    *</span>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtBaños" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                Comodidades:
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <asp:CheckBoxList ID="listComodidades" runat="server" BorderColor="Silver" Width="120px"
                    BorderStyle="Dotted" BorderWidth="1px" RepeatLayout="UnorderedList" TextAlign="Right">
                </asp:CheckBoxList>
            </td>
        </tr>
    </table>
    <hr />
    <div>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
            Enabled="False" />
    </div>
</fieldset>
