<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertCustomerPage.aspx.cs" Inherits="TokoBukuKita.View.Admin.InsertCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function validNumeric() {
            var charcode = (event.which) ? event.which : event.keyCode;
            if (charcode >= 48 && charcode <= 57) {
                return true;
            }
            else {
                return false;
            }
        }
       
    </script>
    <h1>InserCustomer</h1>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Customer Name"></asp:Label>
            <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Customer Address"></asp:Label>
            <asp:TextBox ID="txtCustomerAddress" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Customer Phone"></asp:Label>
            <asp:TextBox ID="txtCustomerPhone" runat="server" onkeypress="return validNumeric()"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Customer Email"></asp:Label>
            <asp:TextBox ID="txtCustomerEmail" runat="server"></asp:TextBox>
        </div>
        <div>
        <asp:Label ID="txtLblError" runat="server" Text=""></asp:Label>
        </div>

        <div>
            <asp:Button ID="btnBack" runat="server" Text="Back" />
            <asp:Button ID="btnInsert" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
</asp:Content>
