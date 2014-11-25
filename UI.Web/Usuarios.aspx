<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageConMenu.master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Usuarios" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<asp:Panel ID="gridPanel" runat="server">
    <h2>Usuarios:</h2><br />
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID"  
            onselectedindexchanged="gridView_SelectedIndexChanged" Width="500px">
            <Columns>
                <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:TemplateField HeaderText="Tipo">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTipoPersona" runat="server" Text='<%# Bind("TipoPersona") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTipoPersona" runat="server" Text='<%# Bind("TipoPersona") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <HeaderStyle BackColor="#80A493" BorderColor="Black" 
                Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="White" BorderColor="Black" />
            <SelectedRowStyle BackColor="#80A493" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>
<asp:Panel ID="gridActionsPanel" runat="server">
    <asp:LinkButton ID="lbEditar" runat="server" 
        onclick="editarLinkButton_Click" CausesValidation="False">Editar</asp:LinkButton>
    <asp:LinkButton ID="lbEliminar" runat="server" 
        onclick="eliminarLinkButton_Click" CausesValidation="False">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="lbNuevo" runat="server" 
        onclick="nuevoLinkButton_Click" CausesValidation="False">Nuevo</asp:LinkButton>
    <asp:LinkButton ID="lbAsignarPermisos" runat="server" Visible="False" 
        onclick="lbAsignarPermisos_Click">Asignar Permisos</asp:LinkButton>
</asp:Panel>
<asp:Panel ID="formPanel" Visible="false" runat="server">
    <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado: "></asp:Label>
    <asp:CheckBox ID="chxHabilitado" runat="server"></asp:CheckBox>
    <br />
    <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario: "></asp:Label>
    <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" 
        ControlToValidate="txtNombreUsuario" 
        ErrorMessage="El campo Nombre de Usuario es obligatorio" 
        ForeColor="#FF3300">*</asp:RequiredFieldValidator>
    <br />
     <asp:LinkButton ID="lbSeleccionarPersona" runat="server" 
        onclick="lbSeleccionarPersona_Click" CausesValidation="False">SeleccionarPersona</asp:LinkButton>
    <asp:TextBox ID="txtPersona" runat="server" Enabled="False" Width="173px">--Persona no seleccionada--</asp:TextBox>
    <br />
    <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
    <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvClave" runat="server" 
        ControlToValidate="txtClave" Display="Dynamic" 
        ErrorMessage="El campo Clave es obligatorio" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
    <asp:TextBox ID="txtRepetirClave" runat="server" TextMode="Password"></asp:TextBox> 
    <asp:CompareValidator ID="cvRepetirClave" runat="server" 
        ControlToCompare="txtClave" ControlToValidate="txtRepetirClave" 
        Display="Dynamic" ErrorMessage="Las claves deben coincidir" ForeColor="#FF3300">*</asp:CompareValidator>
    <asp:RequiredFieldValidator ID="rfvRepetirClave" runat="server" 
        ControlToValidate="txtRepetirClave" Display="Dynamic" 
        ErrorMessage="El campo Repetir Clave es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator> 
    </asp:Panel>    
    <br />
<asp:Panel ID="gridPermisosPanel" runat="server" Visible="false">
        <asp:GridView ID="GridViewPermisos" runat="server" AutoGenerateColumns="False" 
            Width="350px" AutoGenerateEditButton="True" 
            onrowupdating="GridViewPermisos_RowUpdating" 
            onrowediting="GridViewPermisos_RowEditing" DataKeyNames="ID" 
            onrowcancelingedit="GridViewPermisos_RowCancelingEdit">
            <Columns>
                <asp:TemplateField HeaderText="Modulo">
                    <ItemTemplate>
                        <asp:Label ID="lblModulo" runat="server" Text='<%# Bind("DescModulo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Alta">
                    <EditItemTemplate>
                        <asp:CheckBox ID="chxAlta" runat="server" 
                            Checked='<%# Bind("PermiteAlta") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" 
                            Checked='<%# Bind("PermiteAlta") %>' Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Baja">
                    <EditItemTemplate>
                        <asp:CheckBox ID="chxBaja" runat="server" 
                            Checked='<%# Bind("PermiteBaja") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" 
                            Checked='<%# Bind("PermiteBaja") %>' Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Modificación">
                    <EditItemTemplate>
                        <asp:CheckBox ID="chxModificacion" runat="server" 
                            Checked='<%# Bind("PermiteModificacion") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox3" runat="server" 
                            Checked='<%# Bind("PermiteModificacion") %>' Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Consulta">
                    <EditItemTemplate>
                        <asp:CheckBox ID="chxConsulta" runat="server" 
                            Checked='<%# Bind("PermiteConsulta") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox4" runat="server" 
                            Checked='<%# Bind("PermiteConsulta") %>' Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
    </asp:Panel>
    <br />
<asp:Panel ID="formActionsPanel" runat="server" Visible="false">
    <asp:LinkButton ID="aceptarLinkButton" runat="server" 
        onclick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
    <asp:LinkButton ID="cancelarLinkButton" runat="server" 
        onclick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
    <asp:ValidationSummary ID="vsValidaciones" runat="server" ForeColor="#FF3300" />
</asp:Panel>
</asp:Content>