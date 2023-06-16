<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/CustomerNavigation.Master" AutoEventWireup="true" CodeBehind="CartCustomer.aspx.cs" Inherits="LAB_RAMEN.View.Customer.CartCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
        .button {
            background-color: #4CAF50;
            border: none;
            color: white;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 5px;
            cursor: pointer;
            transition-duration: 0.4s;
        }

        .button:hover {
            background-color: #45a049;
        }

        
        .gridview {
            border-collapse: collapse;
            width: 100%;
        }

        .gridview th, .gridview td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        .gridview tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .gridview tr:hover {
            background-color: #ddd;
        }

        
        .container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100vh;
            margin-top: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Label ID="lblStatus" runat="server" Text="There is No Order Yet!"></asp:Label>
        <br />
        <asp:GridView ID="gridViewCart" runat="server" AutoGenerateColumns="false" CssClass="gridview">
            <Columns>
                <asp:TemplateField HeaderText="Ramen ID">
                    <ItemTemplate>
                        <asp:Label ID="lblRamenID" runat="server" Text='<%# Eval("Key") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ramen Name">
                    <ItemTemplate>
                        <asp:Label ID="lblRamenName" runat="server" Text='<%# GetRamenName(Eval("Key")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Value" HeaderText="Quantity" SortExpression="Value" />
            </Columns>
        </asp:GridView>
        <div class="btn-group">
            <asp:Button ID="btnBack" runat="server" Text="Back"  CssClass="button" OnClick="btnBack_Click" />
            <asp:Button ID="btnClearCart" runat="server" Text="Clear Cart" OnClick="btnClearCart_Click" CssClass="button" />
            <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" CssClass="button" />
        </div>
    </div>
</asp:Content>
