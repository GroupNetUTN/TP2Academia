<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageConMenu.master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <h2>Cursos:</h2><br />
        <asp:GridView ID="GridView" AutoGenerateColumns="False" 
            DataKeyNames="ID" SelectedRowStyle-BackColor="Black" 
            SelectedRowStyle-ForeColor="White" 
            onselectedindexchanged="gridView_SelectedIndexChanged" runat="server">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:BoundField DataField="DescComision" HeaderText="Comisión" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="lbEditar" runat="server" CausesValidation="False" 
                onclick="editarLinkButton_Click" Visible="False">Editar</asp:LinkButton>
            <asp:LinkButton ID="lbEliminar" runat="server" CausesValidation="False" 
                onclick="eliminarLinkButton_Click" Visible="False">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="lbNuevo" runat="server" CausesValidation="False" 
                onclick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            <asp:LinkButton ID="lbDocente" runat="server" CausesValidation="False" 
                onclick="lbDocente_Click" Visible="False">Asignar Docente</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="formPanel" runat="server" Visible="False">
                <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
                <asp:DropDownList ID="ddlEspecialidades" runat="server" Width="200px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlEspecialidades_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlEspecialidades" 
                    ErrorMessage="El campo Especialidad es obligatorio" ForeColor="#FF3300">* </asp:RequiredFieldValidator>
                <asp:Label ID="lblPlan" runat="server" Text="Plan: "></asp:Label>
                <asp:DropDownList ID="ddlPlanes" runat="server" Height="22px" Width="150px" 
                    AutoPostBack="True" onselectedindexchanged="ddlPlanes_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="ddlPlanes" ErrorMessage="El campo Plan es obligatorio" 
                    ForeColor="#FF3300">* </asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblMateria" runat="server" Text="Materia: "></asp:Label>
                <asp:DropDownList ID="ddlMaterias" runat="server" Height="22px" Width="200px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddlMaterias" ErrorMessage="El campo Materia es obligatorio" 
                    ForeColor="#FF3300">* </asp:RequiredFieldValidator>
                <asp:Label ID="lblComision" runat="server" Text="Comisión: "></asp:Label>
                <asp:DropDownList ID="ddlComisiones" runat="server" Height="22px" Width="150px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="ddlComisiones" 
                    ErrorMessage="El campo Comisión es obligatorio" ForeColor="#FF3300">* </asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblAnioCalendario" runat="server" Text="Año Calendario: "></asp:Label>
                <asp:TextBox ID="txtAnioCalendario" runat="server" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtAnioCalendario" 
                    ErrorMessage="El campo Año Calendario es obligatorio" ForeColor="#FF3300">* </asp:RequiredFieldValidator>
                <asp:Label ID="lblCupo" runat="server" Text="Cupo: "></asp:Label>
                <asp:TextBox ID="txtCupo" runat="server" Width="50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtCupo" ErrorMessage="El campo Cupo es obligatorio" 
                    ForeColor="#FF3300">* </asp:RequiredFieldValidator>
                <br />
                <asp:Panel ID="formActionsPanel" runat="server">
                    <asp:LinkButton ID="lbAceptar" runat="server" onclick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="lbCancelar" runat="server" CausesValidation="False" 
                        onclick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary" runat="server" 
                        ForeColor="#FF3300" />
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
</asp:Content>
