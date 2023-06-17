﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuCustomer.aspx.cs" Inherits="LAB_RAMEN.View.Customer.MenuCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Welcome to RAAMEN</h2>
            

            <asp:GridView ID="gridViewRamen" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Meat.name" HeaderText="Meat Variant" SortExpression="MeatID" />
                    <asp:BoundField DataField="Broth" HeaderText="Broth" SortExpression="Broth" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                </Columns>
            </asp:GridView>

            <div>
                <asp:Button ID="btnProfile" runat="server" Text="Profile" CssClass="button" OnClick="btnProfile_Click" />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="button" OnClick="btnLogout_Click" />
            </div>

            <div>
                <asp:Button ID="btnOrderRamen" runat="server" Text="Order Ramen" CssClass="button" OnClick="btnOrderRamen_Click" />
                <asp:Button ID="Button1" runat="server" Text="Transaction History" CssClass="button" OnClick="Button1_Click" />
            </div>
        </div>
    </form>
</body>
</html>
