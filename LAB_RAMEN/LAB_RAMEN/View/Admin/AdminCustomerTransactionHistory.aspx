<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/AdminNavigation.Master" AutoEventWireup="true" CodeBehind="AdminCustomerTransactionHistory.aspx.cs" Inherits="LAB_RAMEN.View.Admin.AdminCustomerTransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:GridView ID="gridViewTransaction" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gridViewTransaction_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Transaction ID" SortExpression="id" />
            <asp:BoundField DataField="StaffID" HeaderText="Staff ID" SortExpression="StaffID" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Actions" ShowHeader="True" Text="View Detail" />
        </Columns>
    </asp:GridView>

    <asp:GridView ID="gridViewDetail" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="RamenName" HeaderText="Ramen Name" SortExpression="RamenName" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
        </Columns>
    </asp:GridView>
</asp:Content>
