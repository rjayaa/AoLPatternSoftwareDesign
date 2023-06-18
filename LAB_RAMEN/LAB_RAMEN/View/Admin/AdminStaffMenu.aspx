﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/AdminNavigation.Master" AutoEventWireup="true" CodeBehind="AdminStaffMenu.aspx.cs" Inherits="LAB_RAMEN.View.Admin.AdminStaffMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
            <h2>Customer Data</h2>
            <asp:GridView ID="gridViewCustomer" runat="server" AutoGenerateColumns="False" 
                Class="gridview">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Customer Name" SortExpression="Customer Name" />
                    <asp:BoundField DataField="Email" HeaderText="Customer Email" SortExpression="Customer Email" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                </Columns>
            </asp:GridView>

            

            <div>
                <asp:Button ID="btnOrderRamen" runat="server" Text="Manage Ramen" CssClass="button" OnClick="btnOrderRamen_Click1"   />
                <asp:Button ID="btnViewOrderQueue" runat="server" Text="View Order Queue" CssClass="button" OnClick="Button1_Click" />
            </div>
        </div>
</asp:Content>