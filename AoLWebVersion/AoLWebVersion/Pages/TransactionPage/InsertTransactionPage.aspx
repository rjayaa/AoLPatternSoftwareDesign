<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="InsertTransactionPage.aspx.cs" Inherits="AoLWebVersion.Pages.InsertTransactionPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.0/themes/base/jquery-ui.css">
    <script src="//code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="//code.jquery.com/ui/1.13.0/jquery-ui.min.js"></script>
    <style>
        .gridview-header-style a {
            text-decoration: none;
            color: black;
        }
    </style>

    <div>
        <asp:Label ID="Label2" runat="server" Text="Search"></asp:Label>
        <asp:TextBox ID="txtSearch" runat="server" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
    </div>
    <div>
        <div style="">

            <asp:Label ID="Label1" runat="server" Text="Create Transaction"></asp:Label>
            <asp:GridView ID="CustGridView" runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowFilteringByColumn="True">


                <HeaderStyle CssClass="gridview-header-style" />
                <Columns>
                    <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" SortExpression="CustomerID" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Customer Name" SortExpression="Name" ReadOnly="True" />
                    <asp:BoundField DataField="Address" HeaderText="Customer Address" SortExpression="Address" ReadOnly="True" />
                    <asp:BoundField DataField="Phone" HeaderText="Customer Phone" SortExpression="Phone" ReadOnly="True" />
                    <asp:BoundField DataField="Email" HeaderText="Customer Email" SortExpression="Email" ReadOnly="True" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnView" runat="server" Text="Create Transaction" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <%-- Isi konten popup  --%>
        <div id="dialog" style="display: none;">
            <asp:GridView ID="BookGridView" runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowFilteringByColumn="True">
                <HeaderStyle CssClass="gridview-header-style" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkselect" runat="server" AutoPostBack="true" onclick="return false;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="BookID" HeaderText="Book ID" SortExpression="BookID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                    <asp:BoundField DataField="Publisher" HeaderText="Publisher" SortExpression="Publisher" />
                    <asp:BoundField DataField="PublicationYear" HeaderText="Publication Year" SortExpression="PublicationYear" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:TemplateField HeaderText="Input Text">
                        <ItemTemplate>
                            <asp:TextBox ID="txtInput" runat="server" Width="100"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div>
        <asp:Button ID="BtnClear" runat="server"  Text="Clear" OnClick="BtnClear_Click" />
        <asp:Button ID="BtnAdd" runat="server" OnClick="BtnAdd_Click" Text="Add" />

                <asp:GridView ID="BookViewSection"  runat="server" AutoGenerateColumns="False">
            <HeaderStyle CssClass="gridview-header-style" />
            <Columns>
                <asp:BoundField DataField="BookID" HeaderText="Book ID" SortExpression="BookID" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                <asp:BoundField DataField="Publisher" HeaderText="Publisher" SortExpression="Publisher" />
                <asp:BoundField DataField="PublicationYear" HeaderText="Publication Year" SortExpression="Publisher" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            </Columns>
        </asp:GridView>

                <asp:Button ID="btnSave" runat="server" Text="Save" Visible="False" OnClick="btnSave_Click" />
                <div>
    <asp:Label ID="txtVerification" runat="server" Text=""></asp:Label>
    </div>
    </div>
        </div>
        <script type="text/javascript">
            $(document).on("click", "[id*=btnView]", function () {

                $("#dialog").dialog({
                    modal: true,
                    title: "Create Transaction",
                    width: 800,
                    buttons: {
                        Close: function () {
                            $(this).dialog('close');
                        }
                    }
                });
                return false;
            });
        </script>
    </div>


</asp:Content>
