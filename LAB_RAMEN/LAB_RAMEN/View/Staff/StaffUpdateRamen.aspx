<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/StaffNavigation.Master" AutoEventWireup="true" CodeBehind="StaffUpdateRamen.aspx.cs" Inherits="LAB_RAMEN.View.Staff.StaffUpdateRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
        }

        .container {
            max-width: 400px;
            margin: 0 auto;
            padding: 40px;
            background-color: #fff;
            border-radius: 4px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h1 {
            text-align: center;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-group label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }

        .form-group input[type="text"],
        .form-group input[type="password"],
        .form-group select {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .form-group .btn-container {
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .form-group .btn-container input[type="submit"] {
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            color: #fff;
            font-weight: bold;
            cursor: pointer;
        }

        .form-group .btn-container input[type="submit"]:first-child {
            background-color: #007bff;
        }

        .form-group .btn-container input[type="submit"]:last-child {
            background-color: #dc3545;
        }

        .button {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            cursor: pointer;
            transition-duration: 0.4s;
            margin-left: 5px;
            margin-right: 5px;
            margin-bottom: 5px;
        }

        .button:hover {
            background-color: #45a049;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div class="container">
        <br />
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="button" />
        <br />
        <br />
        <h1>Update Ramen</h1>
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
            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="button" OnClick="btnEdit_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update"  CssClass="button" OnClick="btnInsert_Click" />
        </div>
    </div>
</asp:Content>
