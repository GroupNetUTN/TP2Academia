<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" 
            SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" 
            onselectedindexchanged="gridView_SelectedIndexChanged" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server" Height="20px" >
    <asp:LinkButton ID="editarLinkButton" runat="server" 
        onclick="editarLinkButton_Click">Editar</asp:LinkButton>
    <asp:LinkButton ID="eliminarLinkButton" runat="server" 
        onclick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="nuevoLinkButton" runat="server" 
        onclick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
    <br />
        <asp:Label ID="lblDescripcion" runat="server" 
            Text="Descripción de la Especialidad: "></asp:Label>
        <asp:TextBox ID="txtDescEspecialidad" runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDescEspecialidad" runat="server" 
            ControlToValidate="txtDescEspecialidad" 
            ErrorMessage="El campo Descripción es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
    <br />
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server">
    <br />
        <asp:LinkButton ID="aceptarLinkButton" runat="server" 
            onclick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" 
            onclick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            <br />
        <asp:ValidationSummary ID="vsValidaciones" runat="server" ForeColor="#FF3300" />
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
