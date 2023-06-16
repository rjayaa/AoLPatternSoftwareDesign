<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/StaffNavigation.Master" AutoEventWireup="true" CodeBehind="StaffViewOrder.aspx.cs" Inherits="LAB_RAMEN.View.Staff.StaffViewOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    h1 {
        text-align: center;
    }

    #contentBody {
        display: flex;
        justify-content: center;
        align-items: center;
        flex-direction: column;
    }

    .gridViewContainer {
        max-width: 800px;
        margin-top: 20px;
        background-color: #fff;
        border-radius: 4px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        overflow-x: auto;
    }

    .gridViewContainer table {
        width: 100%;
        border-collapse: collapse;
    }

    .gridViewContainer th,
    .gridViewContainer td {
        padding: 10px;
        border: 1px solid #ccc;
    }

    .gridViewContainer th {
        background-color: #f0f0f0;
        font-weight: bold;
        text-align: center;
    }

    .gridViewContainer tbody tr:nth-child(even) {
        background-color: #f9f9f9;
    }

    .buttonContainer {
        margin-top: 20px;
        text-align: center;
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
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <h1>Order Queue</h1>
    <div class="gridViewContainer">
        <asp:GridView ID="gridViewQueueOrder" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gridViewQueueOrder_SelectedIndexChanged" CssClass="table">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Transaction ID" SortExpression="id" />
                <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" SortExpression="CustomerID" />
                <asp:BoundField DataField="StaffID" HeaderText="Staff ID " SortExpression="StaffID" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Actions" ShowHeader="True" Text="Service" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="buttonContainer">
        <asp:Button ID="btnViewHandled" runat="server" Text="View Handled Orders" OnClick="btnViewHandled_Click" cssClass="button"/>
    </div>
</asp:Content>
