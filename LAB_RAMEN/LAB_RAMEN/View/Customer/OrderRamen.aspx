<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/CustomerNavigation.Master" AutoEventWireup="true" CodeBehind="OrderRamen.aspx.cs" Inherits="LAB_RAMEN.View.Customer.OrderRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <asp:GridView ID="gridViewRamen" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gridViewRamen_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Ramen ID" SortExpression="id" />
            <asp:BoundField DataField="Name" HeaderText="Ramen Name" SortExpression="Name" />
            <asp:BoundField DataField="Meat.name" HeaderText="Meat Name" SortExpression="Meat.name" />
            <asp:BoundField DataField="Broth" HeaderText="Broth" SortExpression="Broth" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Actions" ShowHeader="True" Text="Order" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnViewCart" runat="server" Text="ViewCart" OnClick="btnViewCart_Click" />
</asp:Content>
