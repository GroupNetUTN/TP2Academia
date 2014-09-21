<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Usuarios" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

<asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" 
            DataKeyNames="ID" SelectedRowStyle-BackColor="Black" 
            SelectedRowStyle-ForeColor="White" 
            onselectedindexchanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="EMail" HeaderText="EMail" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

<asp:Panel ID="gridActionsPanel" runat="server">
    <asp:LinkButton ID="editarLinkButton" runat="server" 
        onclick="editarLinkButton_Click">Editar</asp:LinkButton>
    <asp:LinkButton ID="eliminarLinkButton" runat="server" 
        onclick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="nuevoLinkButton" runat="server" 
        onclick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
</asp:Panel>

<asp:Panel ID="formPanel" Visible="false" runat="server">
    <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblApellido" runat="server" Text="Apellido: " ></asp:Label>
    <asp:TextBox ID="txtApellido" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblEmail" runat="server" Text="EMail: "></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado: "></asp:Label>
    <asp:CheckBox ID="chxHabilitado" runat="server"></asp:CheckBox>
    <br />
    <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario: "></asp:Label>
    <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
    <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
    <asp:TextBox ID="txtRepetirClave" runat="server"></asp:TextBox> 
</asp:Panel>
   
<asp:Panel ID="formActionsPanel" runat="server">
    <asp:LinkButton ID="aceptarLinkButton" runat="server" 
        onclick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
    <asp:LinkButton ID="cancelarLinkButton" runat="server" 
        onclick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
</asp:Panel>

</asp:Content>