<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TokoBuku.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-right:10px">

    <asp:Button ID="btnCustomer" runat="server" Text="Insert Customer" OnClick="btnCustomer_Click" />
    <asp:Button ID="btnBook" runat="server" Text="Insert Book" />
        <br />
        <asp:Button ID="btnCreateTransaction" runat="server" Text="Create Transaction" />
        <asp:Button ID="btnViewTransaction" runat="server" Text="View Transaction" />
    </div>
</asp:Content>
