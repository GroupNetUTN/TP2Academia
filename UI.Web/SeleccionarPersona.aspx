<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarPersona.aspx.cs" Inherits="UI.Web.SeleccionarPersona" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
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
                <SelectedRowStyle BackColor="Black" ForeColor="White" />
            </asp:GridView>
        </asp:Panel>
    
    </div>
    <asp:Panel ID="Panel3" runat="server">
        <asp:LinkButton ID="lbSeleccionar" runat="server">Seleccionar</asp:LinkButton>
        <asp:LinkButton ID="lbCancelar" runat="server">Cancelar</asp:LinkButton>
    </asp:Panel>
    </form>
</body>
</html>
