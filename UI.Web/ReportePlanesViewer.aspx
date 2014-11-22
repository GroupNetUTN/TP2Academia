<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageConMenu.master" AutoEventWireup="true" CodeBehind="ReportePlanesViewer.aspx.cs" Inherits="UI.Web.ReportePlanes" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="ReportViewer" runat="server">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="True" GroupTreeImagesFolderUrl="" 
            Height="1202px" ReportSourceID="CRPlanes" ToolbarImagesFolderUrl="" 
            ToolPanelWidth="200px" Width="1104px" EnableDatabaseLogonPrompt="False" 
            EnableParameterPrompt="False" HasToggleGroupTreeButton="False" 
            HasToggleParameterPanelButton="False" ToolPanelView="None" />
        <CR:CrystalReportSource ID="CRPlanes" runat="server">
            <Report FileName="C:\Users\Usuario\Desktop\JuanPablo\UTN\IDE\TP 2\TP2Academia\Util\ReportePlanes.rpt">
            </Report>
        </CR:CrystalReportSource>
    </asp:Panel>
</asp:Content>
