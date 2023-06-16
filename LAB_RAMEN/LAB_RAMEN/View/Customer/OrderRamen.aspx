<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/CustomerNavigation.Master" AutoEventWireup="true" CodeBehind="OrderRamen.aspx.cs" Inherits="LAB_RAMEN.View.Customer.OrderRamen" %>
<%@ Import Namespace="System.Linq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gridview-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            text-align: center;
        }

        .gridview {
            width: 100%;
            border-collapse: collapse;
        }

        .gridview th, .gridview td {
            padding: 8px;
            text-align: left;
            border: 1px solid #ddd;
        }

        .gridview th {
            background-color: #f2f2f2;
        }

        .gridview tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .gridview tr:hover {
            background-color: #e9e9e9;
        }

        .gridview-button {
            text-align: center;
        }

        .cart-item {
            margin-bottom: 10px;
        }
        
        .shopping-cart-container {
            text-align: center;
            margin-top: 20px;
        }
        
        .shopping-cart-title {
            margin-bottom: 10px;
        }
        
        .view-cart-button {
            margin-bottom: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="gridview-container">
        <asp:GridView ID="gridViewRamen" runat="server" AutoGenerateColumns="False" CssClass="gridview"  OnSelectedIndexChanged="gridViewRamen_SelectedIndexChanged">
            <Columns>
                 <asp:BoundField DataField="id" HeaderText="Ramen ID" SortExpression="RamenID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Meat.name" HeaderText="Meat Variant" SortExpression="MeatID" />
                <asp:BoundField DataField="Broth" HeaderText="Broth" SortExpression="Broth" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                
                 <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Actions" ShowHeader="True" Text="Add To Cart" />
                
            </Columns>
        </asp:GridView>
        

        <div class="shopping-cart-container">
            <h2 class="shopping-cart-title">CheckOut</h2>
            <asp:Button ID="btnViewCart" runat="server" Text="View Cart" CssClass="view-cart-button" OnClick="btnViewCart_Click" />
        </div>
    </div>
</asp:Content>
