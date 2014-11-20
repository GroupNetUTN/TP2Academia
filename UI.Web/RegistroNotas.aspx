<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageConMenu.master" AutoEventWireup="true" CodeBehind="RegistroNotas.aspx.cs" Inherits="UI.Web.RegistroNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

<asp:Panel ID="gridPanel" runat="server">
        <h2>Cursos asignados:</h2>
        <br />
        <asp:GridView ID="GridViewCursos" runat="server" 
            AutoGenerateColumns="False" DataKeyNames="ID" 
            onselectedindexchanged="GridViewCursos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año" />
                <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <HeaderStyle BackColor="#80A493" BorderColor="Black" 
                Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="White" BorderColor="Black" />
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>
    <br />
    <asp:Panel ID="formPanel" runat="server" Visible="False">
        <asp:Label ID="lblAlumnos" Font-Size="Medium" Font-Bold="true" runat="server">Alumnos:</asp:Label>
        <br runat="server" />
        <asp:GridView ID="GridViewAlumnos" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID" 
            onselectedindexchanged="GridViewAlumnos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <HeaderStyle BackColor="#80A493" BorderColor="Black" 
                Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="White" BorderColor="Black" />
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <br />
            <asp:Label ID="lblNota" runat="server">Nota:</asp:Label>
            <asp:DropDownList ID="ddlNota" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblCondicion" runat="server">Condicion:</asp:Label>
            <asp:DropDownList ID="ddlCondicion" runat="server">
                <asp:ListItem>Aprobado</asp:ListItem>
                <asp:ListItem>Libre</asp:ListItem>
            </asp:DropDownList>
            <br />
         <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="lbAceptar" runat="server" onclick="lbAceptar_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="lbBorrarNota" runat="server" onclick="lbBorrarNota_Click">Borrar Nota</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>

</asp:Content>
