<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/StaffNavigation.Master" AutoEventWireup="true" CodeBehind="StaffViewOrder.aspx.cs" Inherits="LAB_RAMEN.View.Staff.StaffViewOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <h1>Order Queue</h1>
    <div class="gridViewContainer">
        <asp:GridView ID="gridViewQueueOrder" runat="server" AutoGenerateColumns="False"  CssClass="table" OnSelectedIndexChanged="gridViewQueueOrder_SelectedIndexChanged"  >
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
