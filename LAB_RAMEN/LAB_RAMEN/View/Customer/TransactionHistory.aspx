<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/CustomerNavigation.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="LAB_RAMEN.View.Customer.TransactionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gridViewTransaction" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gridViewTransaction_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Transaction ID" SortExpression="id" />
            <asp:BoundField DataField="StaffID" HeaderText="Staff ID" SortExpression="StaffID" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Actions" ShowHeader="True" Text="View Detail" />
        </Columns>
    </asp:GridView>

    <h2>Transaction Details</h2>

    <table>
        <tr>
            <th>Ramen Name's</th>
            <th>Quantity</th>
            <th>Price</th>
        </tr>
        <%foreach (var d in dt)
        {%>
        <tr>
            <td><%= d.Raman.Name %></td>
            <td><%= d.Quantity %></td>
            <td><%= int.Parse(d.Raman.Price)*d.Quantity %></td>
        </tr>
        <%} %>
    </table>
</asp:Content>
