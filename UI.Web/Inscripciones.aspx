<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageConMenu.master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="UI.Web.Inscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="gridPanel" runat="server">
        <h2>Inscripciones a Cursos:</h2>
        <asp:GridView ID="GridViewInscripciones" runat="server" 
            AutoGenerateColumns="False" DataKeyNames="ID" 
            onselectedindexchanged="GridViewInscripciones_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                <asp:BoundField DataField="AnioCurso" HeaderText="Año de Cursado" />
                <asp:BoundField DataField="Condicion" HeaderText="Condición" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <HeaderStyle BackColor="#80A493" BorderColor="Black" 
                Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="White" BorderColor="Black" />
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="lbNuevo" runat="server" onclick="lbNuevo_Click">Nuevo</asp:LinkButton>
        <asp:LinkButton ID="lbEliminar" runat="server" onclick="lbEliminar_Click">Eliminar</asp:LinkButton>
    </asp:Panel>
    <br />
    <asp:Panel ID="formPanel" runat="server" Visible="False">
        <asp:Label ID="lblMaterias" Font-Size="Medium" Font-Bold="true" runat="server">Materias:</asp:Label>
        <br runat="server" />
        <asp:GridView ID="GridViewMaterias" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID" 
            onselectedindexchanged="GridViewMaterias_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Materia" />
                <asp:BoundField DataField="HsSemanales" HeaderText="Hs Semanales" />
                <asp:BoundField DataField="HsTotales" HeaderText="Hs Totales" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <HeaderStyle BackColor="#80A493" BorderColor="Black" 
                Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="White" BorderColor="Black" />
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblComisiones" Font-Size="Medium" Font-Bold="true" runat="server" Visible="false">Comisiones:</asp:Label>
        <br runat="server" />
        <asp:GridView ID="GridViewComisiones" runat="server" 
            AutoGenerateColumns="False" DataKeyNames="ID" 
            onselectedindexchanged="GridViewComisiones_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año" />
                <asp:BoundField DataField="Descripcion" HeaderText="Comision" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <HeaderStyle BackColor="#80A493" BorderColor="Black" 
                Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="White" BorderColor="Black" />
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="lbAceptar" runat="server" onclick="lbAceptar_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="lbCancelar" runat="server" onclick="lbCancelar_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>

</asp:Content>
