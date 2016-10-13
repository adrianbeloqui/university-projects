<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormularioInmueble.ascx.cs" Inherits="Inmobiliaria.FormularioInmueble" %>


   <link rel="stylesheet" type="text/css" href="../Styles/StyleFormularioInm.css" />

<div>  
    <table class="style1">
        <tr>
            <td class="style7">
                Titulo
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtTitulo" runat="server" Width="260px" MaxLength="80"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">
                Descripción
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtDescripcion" runat="server" Width="444px" Height="131px" 
                    MaxLength="300" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">
                Dirección
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtDireccion" runat="server" Width="260px" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">
                Barrio</td>
            <td colspan="3">
                <asp:DropDownList ID="listBarrios" runat="server" Height="27px" Width="130px" 
                    DataSourceID="SqlDataSource1" DataTextField="Nombre" DataValueField="Nombre">
                </asp:DropDownList>
               <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:InmobiliariaConnection %>" 
                    SelectCommand="SELECT [Nombre] FROM [Barrios] ORDER BY [Nombre]" 
                    ProviderName="System.Data.SqlClient">
                </asp:SqlDataSource>
                <span id="validBarrio" style="color: #FF0000; font-size: large; visibility:visible;">*</span>
            </td>
        </tr>
        <tr>
            <td class="style7">
                Tipo de Inmueble
                <span id="validTipoInmueble" style="color: #FF0000; font-size: large; visibility:visible;">*</span>
            </td>
            <td colspan="3">
                    <asp:DropDownList ID="listCasaOApto" runat="server" Height="27px" Width="130px">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <span id="divApto" style="visibility:hidden">
                        <asp:Label ID="lblPiso" runat="server" Text="Piso"></asp:Label>
                        &nbsp;
                        <asp:TextBox ID="txtPiso" runat="server" Width="36px" MaxLength="4"></asp:TextBox>                   
                        &nbsp;&nbsp;&nbsp;
                        <span id="divWarningPiso" style="visibility:hidden; color: #FF0000;">
                            El piso debe ser un numero de 4 digitos maximo
                        </span>
                    </span> 
            </td>
        </tr>
        <tr>
            <td rowspan="2" class="style7">
                Operación
                <span id="validOperacion" style="color: #FF0000; font-size: large; visibility:visible;">*</span>
            </td>
            <td class="style3">
                <asp:CheckBox ID="chkVenta" runat="server" Text="Venta"/>    
            </td>
            <td class="style5">
                <div id="divLblVenta" style="visibility:hidden"><asp:Label ID="lblVenta" runat="server" Text="Precio Venta"></asp:Label>
                &nbsp; </div> 
            </td>
            <td class="style4">
                <div id="divTxtPrecioVenta" style="visibility:hidden"> 
                    <asp:TextBox ID="txtPrecioVenta" runat="server" Width="120px"></asp:TextBox>                    
                    &nbsp;&nbsp;&nbsp;
                    <span id="divWarningVenta" style="visibility:hidden; color: #FF0000;">
                        El precio de la venta debe ser un número
                    </span>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:CheckBox ID="chkAlquiler" runat="server" Text="Alquiler" />
            </td>
            <td class="style6">
                <div id="divLblAlquiler" style="visibility:hidden"><asp:Label ID="lblAlquiler" runat="server" Text="Precio Alquiler"></asp:Label></div>
                </td>
            <td>
                <div id="divTxtPrecioAlquiler" style="visibility:hidden">
                    <asp:TextBox ID="txtPrecioAlquiler" runat="server" Width="120px"></asp:TextBox>                    
                    &nbsp;&nbsp;&nbsp;
                    <span id="divWarningAlquiler" style="visibility:hidden; color: #FF0000;">
                        El precio del alquiler debe ser un número
                    </span>
                </div>
            </td>
        </tr>
    </table>
    
</div>
<hr />
<div>
    <h3>Comodidades: 
    </h3><br />
    Dormitorios &nbsp;
    <span id="validDormitorios" style="color: #FF0000; font-size: large; visibility:visible;">*</span>
    <asp:TextBox ID="txtdormitorios" runat="server" MaxLength="2" Width="18px"></asp:TextBox>
    <br />
    Baños &nbsp;
    <span id="validBaños" style="color: #FF0000; font-size: large; visibility:visible;">*</span>
    <asp:TextBox ID="txtBaños" runat="server" MaxLength="2" Width="18px"></asp:TextBox>
    <br /><br />
    <asp:CheckBox ID="chkAmueblado" runat="server" /> <br />
    <asp:CheckBox ID="chkInternet" runat="server" /> <br />
    <asp:CheckBox ID="chkCocinaEquipada" runat="server" /> <br />
    <asp:CheckBox ID="chkMicroondas" runat="server" /> <br />
    <asp:CheckBox ID="chkTvCable" runat="server" /> <br />
    <asp:CheckBox ID="chkHeladera" runat="server" /> <br />
    <asp:CheckBox ID="chkParrillero" runat="server" /> <br />
    <asp:CheckBox ID="chkEstufaALeña" runat="server" /> <br />
    <asp:CheckBox ID="chkEstacionamiento" runat="server" /> <br />
    <asp:CheckBox ID="chkPiscina" runat="server" /> <br />
</div>
<hr />
<div>
    <table style="width: 100%;">
        <tr>
            <td>
            <h3>Fotos:</h3>
            </td>
        </tr>
        <tr>
            <td>
            <input id="btnFotos" onclick="return btnFotos_onclick()" type="button" 
            value="AgregarFotos" /></td>
            <td>
                <div id=divFotos runat="server">
                </div>
            </td>
        </tr>
    </table>
    &nbsp;</div>
<hr />
<asp:Button ID="btnIngresar"  Enabled="false" runat="server" Text="Ingresar" 
    onclick="btnIngresar_Click"/>
<asp:Button ID="btnModificar" Enabled="false"  runat="server" Text="Modificar" OnClientClick="javascript:if(!confirm('¿Esta seguro que quiere seguir?'))return false"
    onclick="btnModificar_Click" />
