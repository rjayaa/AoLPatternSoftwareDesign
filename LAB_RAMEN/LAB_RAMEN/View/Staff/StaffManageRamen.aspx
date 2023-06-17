<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/StaffNavigation.Master" AutoEventWireup="true" CodeBehind="StaffManageRamen.aspx.cs" Inherits="LAB_RAMEN.View.Staff.StaffManageRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div class="container">
        <asp:GridView ID="gridviewRamen" runat="server" CssClass="gridview" AutoGenerateColumns="False"
            OnRowDeleting="gridviewRamen_RowDeleting" OnRowEditing="gridviewRamen_RowEditing">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Ramen ID" SortExpression="id" />
                <asp:BoundField DataField="MeatID" HeaderText="Meat ID" SortExpression="MeatID" />
                <asp:BoundField DataField="Name" HeaderText="Ramen" SortExpression="Name" />
                <asp:BoundField DataField="Broth" HeaderText="Broth" SortExpression="Broth" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:CommandField ButtonType="Button" HeaderText="Actions" ShowCancelButton="False"
                    ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <h2>Insert New Ramen</h2>
        <asp:Button ID="btnInsert" runat="server" Text="Insert" CssClass="button" OnClick="btnInsert_Click" />
    </div>
</asp:Content>
