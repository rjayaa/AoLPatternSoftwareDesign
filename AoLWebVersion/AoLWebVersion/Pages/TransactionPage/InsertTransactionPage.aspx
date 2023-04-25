<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="InsertTransactionPage.aspx.cs" Inherits="AoLWebVersion.Pages.InsertTransactionPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <style>
        .gridview-header-style a{
            text-decoration: none;
            color: black;
        }
    </style>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Search"></asp:Label>
        <asp:TextBox ID="txtSearch" runat="server" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
    </div>
    <div>
         <asp:Label ID="Label1" runat="server" Text="Create Transaction"></asp:Label>
        <asp:GridView ID="CustGridView" runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowFilteringByColumn="True" OnRowCommand="CustGridView_RowCommand">
            <HeaderStyle CssClass="gridview-header-style" />
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" SortExpression="CustomerID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Customer Name" SortExpression="Name" ReadOnly="True"/>
                <asp:BoundField DataField="Address" HeaderText="Customer Address" SortExpression="Address" ReadOnly="True"/>
                <asp:BoundField DataField="Phone" HeaderText="Customer Phone" SortExpression="Phone" ReadOnly="True"/>
                <asp:BoundField DataField="Email" HeaderText="Customer Email" SortExpression="Email" ReadOnly="True" />
                <asp:ButtonField ButtonType="Button" CommandName="CreateTransaction" HeaderText="Actions" Text="Create Transaction" />
            </Columns>
         </asp:GridView>
    </div>
</asp:Content>
