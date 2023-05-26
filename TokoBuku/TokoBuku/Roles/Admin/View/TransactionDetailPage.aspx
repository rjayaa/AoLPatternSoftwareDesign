<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="TokoBuku.Roles.Admin.View.TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

    <asp:Label ID="txtCustomerIDs" runat="server" Text=""></asp:Label>
    <asp:GridView ID="gridViewBook" runat="server" AutoGenerateColumns="false" OnRowCommand="gridViewBook_RowCommand">
        <Columns>
            <asp:BoundField DataField="BookID" HeaderText="Book ID">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="Book Title">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Author" HeaderText="Book Author">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Publisher" HeaderText="Book Publisher">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="PublicationYear" HeaderText="Publication Year">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="Price">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Stock" HeaderText="Stock">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnSelect" runat="server" Text="Select" CommandName="Select" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="container">
        <div class="modal fade" id="mymodal" role="dialog" data-backdrop="static">
            <div class="modal-dialog modal-dialog-centered" style="width: 700px; height: 500px;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <h4>HELLO</h4>
                    </div>
                    <div class="modal-footer">
                        <asp:Label ID="txtValidate" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
