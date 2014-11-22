<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageConMenu.master" AutoEventWireup="true" CodeBehind="ReporteCursosViewer.aspx.cs" Inherits="UI.Web.ReporteCursosViewer" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="ReportViewerPanel" runat="server">
        <CR:CrystalReportViewer ID="CRViewerCursos" runat="server" AutoDataBind="true" 
            EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" 
            HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" 
            ToolPanelView="None" />
    </asp:Panel>
</asp:Content>
