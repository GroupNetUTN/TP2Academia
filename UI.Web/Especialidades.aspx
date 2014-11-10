<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageConMenu.master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <h2>Especialidades:</h2><br />
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" 
            onselectedindexchanged="gridView_SelectedIndexChanged" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <HeaderStyle BackColor="#80A493" BorderColor="Black" 
                Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="White" BorderColor="Black" />
            <SelectedRowStyle BackColor="#80A493" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server" Height="20px" >
    <asp:LinkButton ID="lbEditar" runat="server" 
        onclick="editarLinkButton_Click" CausesValidation="False">Editar</asp:LinkButton>
    <asp:LinkButton ID="lbEliminar" runat="server" 
        onclick="eliminarLinkButton_Click" CausesValidation="False">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="lbNuevo" runat="server" 
        onclick="nuevoLinkButton_Click" CausesValidation="False">Nuevo</asp:LinkButton>
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

    <asp:Panel ID="formActionsPanel" runat="server">
    <br />
        <asp:LinkButton ID="aceptarLinkButton" runat="server" 
            onclick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" 
            onclick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
            <br />
        <asp:ValidationSummary ID="vsValidaciones" runat="server" ForeColor="#FF3300" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
