<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/CustomerNavigation.Master" AutoEventWireup="true" CodeBehind="CartCustomer.aspx.cs" Inherits="LAB_RAMEN.View.Customer.CartCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblStatus" runat="server" Text="There is No Order Yet!"></asp:Label>
   <asp:GridView ID="gridViewCart" runat="server" AutoGenerateColumns="false">
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
        <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Actions" ShowHeader="True" Text="Remove" />
    </Columns>
</asp:GridView>
    <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
</asp:Content>
