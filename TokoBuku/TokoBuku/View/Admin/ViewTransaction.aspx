<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewTransaction.aspx.cs" Inherits="TokoBuku.View.ViewTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function validNumericandLength() {
            var charcode = (event.which) ? event.which : event.keyCode;
            if (charcode >= 48 && charcode <= 57) {
                if (event.target.value.length >= 4) {
                    return false;
                }
                return true;
            }
            else {
                return false;
            }
        }

        function validNumeric() {
            var charcode = (event.which) ? event.which : event.keyCode;
            if (charcode >= 48 && charcode <= 57) {
                return true
            } else {
                return false
            }
        }
    </script>
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
            <asp:TextBox ID="txtPublicationYear"  runat="server" onkeypress="return validNumericandLength()" ></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Book Price"></asp:Label>
            <asp:TextBox ID="txtPriceBook" runat="server" onkeypress="return validNumeric()"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label6" runat="server" Text="Book Stock"></asp:Label>
            <asp:TextBox ID="txtStockBook" runat="server" onkeypress="return validNumeric()"></asp:TextBox>
        </div>
        <div>
        <asp:Label ID="txtLblError" runat="server" Text=""></asp:Label>
        </div>

        <div>
            <asp:Button ID="btnInsert" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
</asp:Content>
