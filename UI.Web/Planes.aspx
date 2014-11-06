<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="GridView" runat="server" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" 
            SelectedRowStyle-ForeColor="White"
            AutoGenerateColumns="False" 
            onselectedindexchanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="DescEspecialidad" HeaderText="Especialidad" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server" >
    <asp:LinkButton ID="editarLinkButton" runat="server" 
        onclick="editarLinkButton_Click">Editar</asp:LinkButton>
    <asp:LinkButton ID="eliminarLinkButton" runat="server" 
        onclick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="nuevoLinkButton" runat="server" 
        onclick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
    <br />
    <asp:Label ID="lblDescripcionPlan" runat="server" Text="Descripción del Plan: "></asp:Label>
    <asp:TextBox ID="txtDescripcionPlan" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvDescripcionPlan" runat="server" 
        ControlToValidate="txtDescripcionPlan" 
        ErrorMessage="El campo Descripción de Plan es obligatorio" 
        ForeColor="#FF3300">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad: "></asp:Label>   
    <asp:DropDownList ID="ddlEspecialidades" runat="server" Width="200px" 
            DataValueField="ID" DataTextField="Descripcion" AutoPostBack="True">
    </asp:DropDownList>   
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="ddlEspecialidades" 
            ErrorMessage="El campo Especialidad es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
   
    <br />
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server">
    <br />
    <asp:LinkButton ID="aceptarLinkButton" runat="server" 
        onclick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
    <asp:LinkButton ID="cancelarLinkButton" runat="server" 
        onclick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
    <asp:ValidationSummary ID="vsValidaciones" runat="server" ForeColor="#FF3300" />
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
