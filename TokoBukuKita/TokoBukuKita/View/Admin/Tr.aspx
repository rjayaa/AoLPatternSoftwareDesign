<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tr.aspx.cs" Inherits="TokoBukuKita.View.Admin.Tr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:GridView ID="gridViewCustomer" runat="server" AutoGenerateColumns="false" >
    <Columns>
        <asp:BoundField DataField="CustomerID" HeaderText="Customer ID">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Name" HeaderText="Customer Name">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Address" HeaderText="Customer Address">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Phone" HeaderText="Customer Phone">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Email" HeaderText="Customer Email">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnView" runat="server" Text="Create Transaction" OnClick="btnView_Click" data-toggle="modal" data-target="#mymodal" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>



    <div class="container">
        <div class="modal fade" id="mymodal" role="dialog">
            <div class="modal-dialog modal-dialog-centered" style="width: 700px; height: 500px;">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Add New Record</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <label>Customer ID</label>
                        <asp:TextBox ID="txtCustomerID" CssClass="form-control" placeholder="CustomerID" runat="server" Enabled="false" />
                        <label>Name</label>
                        <asp:TextBox ID="txtName" CssClass="form-control" placeholder="Name" runat="server" Enabled="false" />
                        <asp:DropDownList ID="dropDownBook" runat="server" ></asp:DropDownList>
                        <asp:TextBox ID="txtSearch" runat="server" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                    </div>
                    
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnSave" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    s
</asp:Content>
