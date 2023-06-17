<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/AdminNavigation.Master" AutoEventWireup="true" CodeBehind="AdminStaffViewHandled.aspx.cs" Inherits="LAB_RAMEN.View.Admin.AdminStaffViewHandled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>View Handled Transactions</h1>
    <div class="gridViewContainer">
        <asp:GridView ID="gridViewHandled" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Transaction ID" SortExpression="id" />
                <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" SortExpression="CustomerID" />
                <asp:BoundField DataField="StaffID" HeaderText="Staff ID" SortExpression="StaffID" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="buttonContainer">
        <asp:Button ID="btnBack" runat="server" Text="Back" cssClass="button" OnClick="btnBack_Click"/>
    </div>
</asp:Content>
