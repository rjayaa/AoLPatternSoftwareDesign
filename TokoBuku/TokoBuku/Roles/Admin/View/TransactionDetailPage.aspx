<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="TokoBuku.Roles.Admin.View.TransactionDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       

    <asp:Label ID="txtCustomerIDs" runat="server" Text=""></asp:Label>
    <asp:Label ID="txtTransactionID" runat="server" Text="" Visible ="false"></asp:Label>
    <asp:GridView ID="gridViewBook" runat="server" AutoGenerateColumns="false" OnRowCommand="gridViewBook_RowCommand"  >
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
                    <asp:Button ID="btnSelect" runat="server" Text="Select"  CommandName="Select" CommandArgument='<%# Container.DataItemIndex %>'  />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView> 

    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-danger" onClick="btnBack_Click"/>
    <div class="container">
        <div class="modal fade" id="mymodal" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-dialog-centered" style="width: 400px; height: 400px;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="Label1" runat="server" Text="Quantity"></asp:Label>
                       <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                        <br />
                        <div style="text-align: right;">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" />
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" OnClientClick="moveSelected" />
                        </div>

                    </div>

                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="txtlblerror" runat="server" Text=""></asp:Label>
    <div class="container">
        <div class="modal fade" id="ValidationModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered" style="width: 300px;">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:Label ID="txtPopup" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="txtValidation" runat="server" Text="Quantity"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">OK</button>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
