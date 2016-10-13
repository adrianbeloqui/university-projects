<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasters/Site1.Master" AutoEventWireup="true" CodeBehind="ListadoDeInmuebles.aspx.cs" Inherits="Inmobiliaria.Admin.ListadoDeInmuebles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div> Seleccione el tipo de inmueble que quiere ver.
        <asp:RadioButtonList ID="RadioInmueble" runat="server" 
            onselectedindexchanged="RadioInmueble_SelectedIndexChanged" 
            AutoPostBack="True">
            <asp:ListItem>Apartamento</asp:ListItem>      
            <asp:ListItem>Casa</asp:ListItem>        
        </asp:RadioButtonList>
    </div>
    </br>
    </br>
    <asp:GridView ID="GridViewCasa" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" DataSourceID="SqlDataSource1" 
    onselectedindexchanged="GridViewCasa_SelectedIndexChanged" 
    Width="917px" CellPadding="4" ForeColor="#333333" GridLines="None" 
    HorizontalAlign="Center" Visible="False">
        
        <AlternatingRowStyle BackColor="White" />
        
        <Columns>
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False"
                ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" 
                SortExpression="Titulo" />
            <asp:BoundField DataField="Barrio" HeaderText="Barrio" 
                SortExpression="Barrio" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" 
                SortExpression="Direccion" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                SortExpression="Descripcion" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <div>

    </div>
     <asp:GridView ID="GridViewApto" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" DataSourceID="SqlDataSource2" 
    onselectedindexchanged="GridViewApto_SelectedIndexChanged" 
    Width="917px" CellPadding="4" ForeColor="#333333" GridLines="None" 
    HorizontalAlign="Center" Visible="False">
        
        <AlternatingRowStyle BackColor="White" />
        
        <Columns>
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False"
                ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="Barrio" HeaderText="Barrio" 
                SortExpression="Barrio" />
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" 
                SortExpression="Titulo" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" 
                SortExpression="Direccion" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                SortExpression="Descripcion" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:InmobiliariaTATAListadoInmueblesConnectionString %>" 
        
    
        SelectCommand="SELECT [id], [Barrio], [Titulo], [Direccion], [Descripcion] FROM [Inmueble] inner join [Casa] on [Inmueble].id= [Casa].idInmueble">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:InmobiliariaTATAListadoInmueblesConnectionString %>" 
        
    SelectCommand="SELECT [id], [Barrio], [Titulo], [Direccion], [Descripcion] FROM [Inmueble] inner join [Apto] on [Inmueble].id= [Apto].idInmueble">
    </asp:SqlDataSource>
    <div > <asp:Button id="btnEliminar" runat="server" Text="Eliminar" 
            onclick="btnEliminar_Click" Width="86px"/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button id="btnModificar" runat="server" Text="Modificar" Width="86px"
            onclick="btnModificar_Click"/></div>
    </asp:Content>
