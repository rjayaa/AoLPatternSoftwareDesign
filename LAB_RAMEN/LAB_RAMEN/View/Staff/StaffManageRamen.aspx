<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/StaffNavigation.Master" AutoEventWireup="true" CodeBehind="StaffManageRamen.aspx.cs" Inherits="LAB_RAMEN.View.Staff.StaffManageRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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

        .gridview {
            border-collapse: collapse;
            width: 100%;
        }

        .gridview th,
        .gridview td {
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
        }
    </style>
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
