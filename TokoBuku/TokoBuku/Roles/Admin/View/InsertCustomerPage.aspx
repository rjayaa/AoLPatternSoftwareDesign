<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertCustomerPage.aspx.cs" Inherits="TokoBuku.Roles.Admin.View.InsertCustomerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="script.js"></script>
    <div>
        <h2>Insert Customer</h2>
        <hr />

        <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
        <br />

        <div class="form-group">
            <asp:Label ID="lblName" runat="server" Text="Name:" AssociatedControlID="txtName"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblAddress" runat="server" Text="Address:" AssociatedControlID="txtAddress"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblPhone" runat="server" Text="Phone:" AssociatedControlID="txtPhone"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" onkeypress="return validNumeric()"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-danger"  />
        <asp:Button ID="btnAddCustomer" runat="server" Text="Add Customer" CssClass="btn btn-primary" OnClick="btnAddCustomer_Click" />
    </div>
</asp:Content>
