<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/AdminNavigation.Master" AutoEventWireup="true" CodeBehind="AdminViewAllTransaction.aspx.cs" Inherits="LAB_RAMEN.View.Admin.AdminViewAllTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gridViewAllTransaction" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Transaction ID" SortExpression="id" />
            <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" SortExpression="CustomerID" />
            <asp:BoundField DataField="StaffID" HeaderText="Staff ID" SortExpression="StaffID" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
        </Columns>

    </asp:GridView>
</asp:Content>
