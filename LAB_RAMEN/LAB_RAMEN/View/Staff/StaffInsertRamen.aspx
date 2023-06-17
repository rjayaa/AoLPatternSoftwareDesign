<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/StaffNavigation.Master" AutoEventWireup="true" CodeBehind="StaffInsertRamen.aspx.cs" Inherits="LAB_RAMEN.View.Staff.StaffInsertRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div class="container">
        <br />
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="button" />
        <br />
        <br />
        <h1>Insert Ramen</h1>
        <div class="form-group">
            <label for="txtName">Name</label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ddlMeat">Meat</label>
            <asp:DropDownList ID="ddlMeat" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="txtBroth">Broth</label>
            <asp:TextBox ID="txtBroth" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtPrice">Price</label>
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="lblError" runat="server" Text="" CssClass="error"></asp:Label>
        <div class="form-group btn-container">
            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" CssClass="button" />
        </div>
    </div>
</asp:Content>
