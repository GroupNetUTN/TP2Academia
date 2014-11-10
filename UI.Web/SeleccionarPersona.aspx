<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarPersona.aspx.cs" MasterPageFile="~/MasterPageConMenu.master" Inherits="UI.Web.SeleccionarPersona" %>

<asp:Content ID="Usuarios" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
 <asp:Panel ID="Panel1" runat="server">
            <asp:GridView ID="dgvPersonas" runat="server" 
            AutoGenerateColumns="False" DataKeyNames="ID" 
            onselectedindexchanged="dgvPersonas_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="TipoPersona" HeaderText="Tipo Persona" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <HeaderStyle BackColor="#80A493" BorderColor="Black" 
                Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="White" BorderColor="Black" />
            <SelectedRowStyle BackColor="#80A493" ForeColor="White" />
            </asp:GridView>
        </asp:Panel>
    <asp:Panel ID="Panel3" runat="server">
        <asp:LinkButton ID="lbSeleccionar" runat="server" onclick="lbSeleccionar_Click">Seleccionar</asp:LinkButton>
        <asp:LinkButton ID="lbCancelar" runat="server" onclick="lbCancelar_Click">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>
