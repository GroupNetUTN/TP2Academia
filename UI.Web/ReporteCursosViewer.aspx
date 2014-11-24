<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageConMenu.master" AutoEventWireup="true" CodeBehind="ReporteCursosViewer.aspx.cs" Inherits="UI.Web.ReporteCursosViewer" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
        <asp:Panel ID="formPanel" runat="server" style="text-align: center">
            <asp:DropDownList ID="ddlEspecialidades" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlEspecialidades_SelectedIndexChanged" 
                Width="200px">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlPlanes_SelectedIndexChanged" Width="140px">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlMaterias" runat="server" AutoPostBack="True" 
                Width="170px">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlComisiones" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlComisiones_SelectedIndexChanged" Width="170px">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlAnios_SelectedIndexChanged" Width="150px">
            </asp:DropDownList>
            <br />
            <asp:LinkButton ID="lbGenerarInforme" runat="server" 
                onclick="lbGenerarInforme_Click" Visible="False">Generar Informe</asp:LinkButton>
        </asp:Panel>
        <br />
        <asp:Panel ID="ReportViewerPanel" runat="server" Visible="false">
        <CR:CrystalReportViewer ID="CRViewerCursos" runat="server" AutoDataBind="true" 
            EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" 
            HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" 
            ToolPanelView="None" />
    </asp:Panel>
</asp:Content>
