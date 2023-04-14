<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="InsertBookPage.aspx.cs" Inherits="AoLWebVersion.Pages.BookPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <h1>InserBook</h1>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Book Title"></asp:Label>
            <asp:TextBox ID="txtTitleBook" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Book Author"></asp:Label>
            <asp:TextBox ID="txtAuthorBook" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Book Publisher"></asp:Label>
            <asp:TextBox ID="txtPublisherBook" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Book Publication Year"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
             <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Assets/calendar.png" ImageAlign="AbsBottom" Width="20px" Height="20px" OnClick="ImageButton1_Click"  />
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Book Price"></asp:Label>
            <asp:TextBox ID="txtPriceBook" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label6" runat="server" Text="Book Stock"></asp:Label>
            <asp:TextBox ID="txtStockBook" runat="server"></asp:TextBox>
        </div>
        <div>
        <asp:Label ID="txtLblError" runat="server" Text=""></asp:Label>
        </div>

        <div>
            <asp:Button ID="btnInsert" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
</asp:Content>
