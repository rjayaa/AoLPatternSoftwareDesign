<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/StaffNavigation.Master" AutoEventWireup="true" CodeBehind="StaffManageRamen.aspx.cs" Inherits="LAB_RAMEN.View.Staff.StaffManageRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Manage Ramen</h1>

    <asp:GridView ID="gridViewRamen" runat="server" AutoGenerateColumns="False"  OnRowEditing="ramenGridView_RowEditing" OnRowDeleting="ramenGridView_RowDeleting">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Ramen ID" SortExpression="Id" />
            <asp:BoundField DataField="MeatID" HeaderText="Meat ID" SortExpression="meatID" />
            <asp:BoundField DataField="Name" HeaderText="Ramen Name's" SortExpression="name" />
            <asp:BoundField DataField="Broth" HeaderText="Ramen Broth's" SortExpression="broth" />
            <asp:BoundField DataField="Price" HeaderText="Ramen Price" SortExpression="price" />
            <asp:CommandField HeaderText="Actions" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" ButtonType="Button" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <br />

    <asp:Button ID="btnInsertRamen" runat="server" Text="Insert New Ramen" OnClick="btnInsertRamen_Click" />
</asp:Content>
