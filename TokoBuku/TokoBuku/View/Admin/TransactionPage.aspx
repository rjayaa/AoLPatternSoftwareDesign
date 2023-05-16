<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionPage.aspx.cs" Inherits="TokoBuku.View.TransactionPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.0/themes/base/jquery-ui.css">
    <script src="//code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="//code.jquery.com/ui/1.13.0/jquery-ui.min.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <script type="text/javascript">
        $(document).on("click", "[id*=btnView]", function () {

            $("#dialog").dialog({
                modal: true,
                title: "Create Transaction",
                width: 600,
                buttons: false
            });
            return false;
        });

        $(document).on("click", "[id*=btnViewQuantity]", function () {

            $("#addQuantity").dialog({
                modal: true,
                title: "Input Quantity",
                width: 400,
                closeOnEscape: false,
                button: false

            });
            return false;
        });

        function closeDialog() {
            $("#addQuantity").dialog("close");
        }
        function enableGridView() {
            // Membuat permintaan AJAX ke server
            $.ajax({
                type: "POST",
                url: "TokoBuku/View/Admin/TransactionPage.aspx/ServerFunction",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Permintaan selesai dan berhasil, lakukan tindakan setelah itu
                    // Misalnya, tangkap respons dari server dan tindakan berikutnya
                    var result = response.d;
                    if (result === "success") {
                        // Ubah properti Visible dari GridView menjadi true
                        var gridView = document.getElementById('<%= gridviewTransaction.ClientID %>');
                gridView.style.display = "block";
            }
        },
        error: function (xhr, status, error) {
            // Tangani kesalahan jika terjadi
            alert("Error: " + error);
        }
    });
        }

    </script>

    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="gridViewCustomer" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" />
                <asp:BoundField DataField="Name" HeaderText="Customer Name" />
                <asp:BoundField DataField="Address" HeaderText="Customer Address" />
                <asp:BoundField DataField="Phone" HeaderText="Customer Phone" />
                <asp:BoundField DataField="Email" HeaderText="Customer Email" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnView" runat="server" Text="Create Transaction" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </asp:Panel>

    <div id="addQuantity" style="display: none;">
        <asp:Label ID="Label1" runat="server" Text="Insert Quantity :"></asp:Label>
        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="closeDialog();" />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="enableGridView()" />
        <asp:GridView ID="gridviewTransaction" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="BookID" HeaderText="BookID" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" />
                <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
                <asp:BoundField DataField="PublicationYear" HeaderText="Publication Year" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" />
            </Columns>

        </asp:GridView>
    </div>




    <div id="dialog" style="display: none;">
        <asp:GridView ID="gridviewDialog" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="BookID" HeaderText="BookID" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" />
                <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
                <asp:BoundField DataField="PublicationYear" HeaderText="Publication Year" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnViewQuantity" runat="server" Text="Add" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>



</asp:Content>
