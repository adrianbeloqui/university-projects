<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasters/Site1.Master" AutoEventWireup="true" CodeBehind="ListaDeMensajes.aspx.cs" Inherits="Inmobiliaria.Admin.ListaDeMensajes" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">     

    <h1>Listado De Mensajes</h1>
    <div id="advertencia" runat="server">Seleccione para eliminar mensajes.</div>
    <asp:GridView ID="GridViewMensajes" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
        DataSourceID="SqlDataSource3" OnSelectedIndexChanged="GridViewMensajes_SelectedIndexChanged"
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="919px">
        <AlternatingRowStyle BackColor="White" />
        
  
        <Columns>
            <asp:TemplateField HeaderText="Seleccionar">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSeleccionar" runat ="server" />
                    <asp:HiddenField ID="hdf" runat="server" value='<%# Eval("id")%>'/>
                    <asp:HiddenField ID="hdfInmueble" runat="server" value='<%# Eval("Inmueble")%>'/>
                    <asp:HiddenField ID="hdfContacto" runat="server" value='<%# Eval("Contacto")%>'/>
                    <asp:HiddenField ID="hdfMail" runat="server" value='<%# Eval("Mail")%>'/>
                    <asp:HiddenField ID="hdfTelefono" runat="server" value='<%# Eval("Telefono")%>'/>
                    <asp:HiddenField ID="hdfMensaje" runat="server" value='<%# Eval("Mensaje")%>'/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Inmueble">
                <ItemTemplate>
                    <%# Eval("Inmueble")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Contacto">
                <ItemTemplate>
                    <%# Eval("Contacto")%>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Mail">
                <ItemTemplate>
                    <%# Eval("Mail")%>
                </ItemTemplate>
            </asp:TemplateField>           
            <asp:CommandField SelectText="Detalles" ShowSelectButton="True" />
           

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
        <EmptyDataTemplate>
            <asp:Label ID="lblVacio" runat="server">No hay ningun mensaje</asp:Label>                  
        </EmptyDataTemplate>
    </asp:GridView>            
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
    ConnectionString="<%$ ConnectionStrings:InmobiliariaTATAListadoInmueblesConnectionString %>"
    SelectCommand="SELECT [id], [Inmueble], [Contacto], [Mail], [Telefono], [Mensaje] FROM [Mensaje] ORDER BY [id]">
</asp:SqlDataSource>
<div>

    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
        onclick="btnEliminar_Click" /></div>
</asp:Content>
