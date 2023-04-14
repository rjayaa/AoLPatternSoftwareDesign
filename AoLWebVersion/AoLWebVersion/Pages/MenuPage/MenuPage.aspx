<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="MenuPage.aspx.cs" Inherits="AoLWebVersion.Pages.MenuPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <style>
        .CusTrans{
            margin: 15px;
        }
        #btnCustomer,#btnPayment{
            margin-right: 35px;
        }
    </style>

    <h1>Menu</h1>
        <div class="CusTrans" >
            <asp:Button ID="btnCustomer" runat="server" Text="Insert Customer" OnClick="btnCustomer_Click" />
            <asp:Button ID="btnTransactions" runat="server" Text="Insert Transactions" />
        </div>
        <div class="CusTrans">
            <asp:Button ID="btnPayment" runat="server" Text="Choose Payment" />
            <asp:Button ID="Button4" runat="server" Text="View Books" />
        </div>
        <div class="CusTrans">
            <asp:Button ID="Button5" runat="server" Text="Button" />
            <asp:Button ID="Button6" runat="server" Text="Button" />
        </div>
        <div class="CusTrans">
             <asp:Button ID="Button7" runat="server" Text="Button" />
        </div>
</asp:Content>
