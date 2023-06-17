<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/AdminNavigation.Master" AutoEventWireup="true" CodeBehind="AdminMenuCustomer.aspx.cs" Inherits="LAB_RAMEN.View.Admin.MenuCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <asp:Button ID="btnOrderRamen" runat="server" Text="Order Ramen" CssClass="button" OnClick="btnOrderRamen_Click" />
                <asp:Button ID="btnTransaction" runat="server" Text="Transaction History" CssClass="button" OnClick="Button1_Click" />
            </div>
        </div>
</asp:Content>
