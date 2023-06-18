<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/AdminNavigation.Master" AutoEventWireup="true" CodeBehind="AdminTransactionReport.aspx.cs" Inherits="LAB_RAMEN.View.Admin.AdminTransactionReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CR:CrystalReportViewer ID="crystalReport" runat="server" AutoDataBind="true" />
</asp:Content>
