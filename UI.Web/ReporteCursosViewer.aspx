<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageConMenu.master" AutoEventWireup="true" CodeBehind="ReporteCursosViewer.aspx.cs" Inherits="UI.Web.ReporteCursosViewer" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="ReportViewer" runat="server">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="True" DisplayStatusbar="False" EnableDatabaseLogonPrompt="False" 
            EnableParameterPrompt="False" EnableTheming="True" GroupTreeImagesFolderUrl="" 
            HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" 
            Height="1170px" ReportSourceID="ReporteCursos" ToolbarImagesFolderUrl="" 
            ToolPanelView="None" ToolPanelWidth="200px" Width="1104px" />
        <CR:CrystalReportSource ID="ReporteCursos" runat="server">
            <Report FileName="C:\Users\Usuario\Desktop\JuanPablo\UTN\IDE\TP 2\TP2Academia\Util\ReporteCursos.rpt">
            </Report>
        </CR:CrystalReportSource>
    </asp:Panel>

</asp:Content>
