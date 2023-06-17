<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/CustomerNavigation.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="LAB_RAMEN.View.Customer.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gridViewCart" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="TransactionID" SortExpression="id" />
            <asp:BoundField DataField="RamenID" HeaderText="Ramen ID" SortExpression="RamenID" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Actions" ShowHeader="True" Text="Remove" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnInsert" runat="server" Text="Order!!!" OnClick="btnInsert_Click" />

</asp:Content>
