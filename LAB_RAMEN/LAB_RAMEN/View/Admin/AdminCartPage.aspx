<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/AdminNavigation.Master" AutoEventWireup="true" CodeBehind="AdminCartPage.aspx.cs" Inherits="LAB_RAMEN.View.Admin.AdminCartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:GridView ID="gridViewCart" runat="server" AutoGenerateColumns="False" OnRowDeleting="gridViewCart_RowDeleting" >
        <Columns>
            <asp:BoundField DataField="id" HeaderText="TransactionID" SortExpression="id" />
            <asp:BoundField DataField="RamenID" HeaderText="Ramen ID" SortExpression="RamenID" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Actions" ShowHeader="True" Text="Remove" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnInsert" runat="server" Text="Order!!!" OnClick="btnInsert_Click" />
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
</asp:Content>
