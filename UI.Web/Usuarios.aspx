<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Usuarios" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

<asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" 
            DataKeyNames="ID" SelectedRowStyle-BackColor="Black" 
            SelectedRowStyle-ForeColor="White">
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
    <asp:LinkButton ID="editarLinkButton" runat="server">Editar</asp:LinkButton>
    <asp:LinkButton ID="eliminarLinkButton" runat="server">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="nuevoLinkButton" runat="server">Nuevo</asp:LinkButton>
</asp:Panel>

<asp:Panel ID="formPanel" Visible="false" runat="server">
    <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: " ></asp:Label>
    <asp:TextBox ID="apellidoTextBox" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
    <asp:TextBox ID="emailTextBox" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
    <asp:TextBox ID="habilitadoTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Nombre de Usuario: "></asp:Label>
    <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
    <asp:TextBox ID="claveTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
    <asp:TextBox ID="repetirClaveTextBox" runat="server"></asp:TextBox> 
</asp:Panel>
   
<asp:Panel ID="formActionsPanel" runat="server">
    <asp:LinkButton ID="aceptarLinkButton" runat="server">Aceptar</asp:LinkButton>
    <asp:LinkButton ID="cancelarLinkButton" runat="server">Cancelar</asp:LinkButton>
</asp:Panel>

</asp:Content>