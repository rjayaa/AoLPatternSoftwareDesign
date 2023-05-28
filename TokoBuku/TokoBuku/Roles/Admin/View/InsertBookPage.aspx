<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertBookPage.aspx.cs" Inherits="TokoBuku.Roles.Admin.View.InsertBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="script.js"></script>
    <div>
        <h2>Insert Book</h2>
        <hr />

        <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
        <br />

        <div class="form-group">
            <asp:Label ID="lblTitle" runat="server" Text="Title:" AssociatedControlID="txtTitle"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblAuthor" runat="server" Text="Author:" AssociatedControlID="txtAuthor"></asp:Label>
            <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblPublisher" runat="server" Text="Publisher:" AssociatedControlID="txtPublisher"></asp:Label>
            <asp:TextBox ID="txtPublisher" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblPublicationYear" runat="server" Text="Publication Year:" AssociatedControlID="txtPublicationYear"></asp:Label>
            <asp:TextBox ID="txtPublicationYear" runat="server" CssClass="form-control" onkeypress="return validNumericAndLength()"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblPrice" runat="server" Text="Price:" AssociatedControlID="txtPrice"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" onkeypress="return validNumeric()"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblStock" runat="server" Text="Stock:" AssociatedControlID="txtStock"></asp:Label>
            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" onkeypress="return validNumeric()"></asp:TextBox>
        </div>
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-danger"  />
        <asp:Button ID="btnAddBook" runat="server" Text="Add Book" CssClass="btn btn-primary" OnClick="btnAddBook_Click"  />
    </div>

    
</asp:Content>
