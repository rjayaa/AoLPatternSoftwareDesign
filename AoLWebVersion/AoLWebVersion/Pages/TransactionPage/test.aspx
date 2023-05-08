<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="AoLWebVersion.Pages.TransactionPage.test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.0/themes/base/jquery-ui.css">
    <script src="//code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="//code.jquery.com/ui/1.13.0/jquery-ui.min.js"></script>

    <div>
        <asp:Label ID="Label1" runat="server" Text="Create Transaction"></asp:Label>
        <asp:GridView ID="CustGridView" runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowFilteringByColumn="True">


            <HeaderStyle CssClass="gridview-header-style" />
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" SortExpression="CustomerID" ReadOnly="True" ItemStyle-CssClass="CustomerID" />
                <asp:BoundField DataField="Name" HeaderText="Customer Name" SortExpression="Name" ReadOnly="True" ItemStyle-CssClass="Name" />
                <asp:BoundField DataField="Address" HeaderText="Customer Address" SortExpression="Address" ReadOnly="True" ItemStyle-CssClass="Address" />
                <asp:BoundField DataField="Phone" HeaderText="Customer Phone" SortExpression="Phone" ReadOnly="True" ItemStyle-CssClass="Phone" />
                <asp:BoundField DataField="Email" HeaderText="Customer Email" SortExpression="Email" ReadOnly="True" ItemStyle-CssClass="Email" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnView" runat="server" Text="Create Transaction" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:ButtonField ButtonType="Button" CommandName="CreateTransaction" HeaderText="Actions" Text="Create Transaction" />--%>
            </Columns>
        </asp:GridView>
    </div>

    <div id="dialog" style="display: none;">
        <h1>Hello</h1>
        <h2><b>tetew</b></h2>
    </div>
    <script type="text/javascript">
        $(document).on("click", "[id*=btnView]", function () 
            $("#dialog").dialog({
                modal: true,
                title: "Create Transaction",
                width: 400,
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                }
            });
            return false;
        });
    </script>


</asp:Content>
