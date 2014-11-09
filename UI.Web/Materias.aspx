<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageConMenu.master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>

<asp:Content ID="Materias" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<asp:Panel ID="gridPanel" runat="server">
    <h2>Materias:</h2><br />    
        <asp:GridView ID="GridView" runat="server" 
            AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" 
            SelectedRowStyle-ForeColor="White" 
            onselectedindexchanged="gridView_SelectedIndexChanged" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="HSSemanales" HeaderText="Horas Semanales" />
                <asp:BoundField DataField="HSTotales" HeaderText="Horas Totales" />
                <asp:BoundField DataField="DescPlan" HeaderText="Plan" />
                <asp:BoundField DataField="DescEspecialidad" HeaderText="Especialidad" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
         </asp:GridView>
</asp:Panel>
<asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="lbEditar" runat="server" onclick="editarLinkButton_Click" 
                CausesValidation="False">Editar</asp:LinkButton>
            <asp:LinkButton ID="lbEliminar" runat="server" 
                onclick="eliminarLinkButton_Click" CausesValidation="False">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="lbNuevo" runat="server" onclick="nuevoLinkButton_Click" 
                CausesValidation="False">Nuevo</asp:LinkButton>
</asp:Panel>
<br />
<asp:Panel ID="formPanel" Visible="false" runat="server">
    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion:"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="El campo Descripcion es obligatorio" ForeColor="Red" 
        ControlToValidate="txtDescripcion">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblHsSemanales" runat="server" Text="Hs Semanales:"></asp:Label>
    <asp:TextBox ID="txtHsSemanales" runat="server" Width="50px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ErrorMessage="El campo Hs Semanales es obligatorio" ForeColor="Red" 
        ControlToValidate="txtHsSemanales">* </asp:RequiredFieldValidator>
    <asp:Label ID="lblHsTotales" runat="server" Text="Hs Totales:"></asp:Label>
    <asp:TextBox ID="txtHsTotales" runat="server" Width="50px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ErrorMessage="El campo Hs Totales es obligatorio" ForeColor="Red" 
        ControlToValidate="txtHsTotales">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:"></asp:Label>
    <asp:DropDownList ID="ddlEspecialidades" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlEspecialidades_SelectedIndexChanged" 
        Height="22px" Width="200px">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="ddlEspecialidades" 
        ErrorMessage="El campo Especialidad es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:Label ID="lblPlan" runat="server" Text="Plan:"></asp:Label>
    <asp:DropDownList ID="ddlPlanes" runat="server" Width="150px">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="ddlPlanes" ErrorMessage="El campo Plan es obligatorio" 
        ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="lbAceptar" runat="server" onclick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="lbCancelar" runat="server" onclick="cancelarLinkButton_Click" 
        CausesValidation="False">Cancelar</asp:LinkButton>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#FF3300" />
    </asp:Panel>
</asp:Panel>
</asp:Content>
