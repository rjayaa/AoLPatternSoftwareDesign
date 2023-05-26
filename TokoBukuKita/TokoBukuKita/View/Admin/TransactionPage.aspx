<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransactionPage.aspx.cs" Inherits="TokoBukuKita.View.Admin.TransactionPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">
        $(document).ready(function () {
            // Mendapatkan tombol "Add" dalam modal
            var btnAdd = $("#<%= btnAdd.ClientID %>");

            // Mendapatkan modal berdasarkan ID
            var modal = $("#mymodal");

            // Menambahkan peristiwa klik pada tombol "Add"
            btnAdd.on("click", function (e) {
                e.preventDefault(); // Menghentikan tindakan default tombol "Add"
                // Lakukan tindakan lain yang Anda inginkan di sini
            });

            // Menambahkan peristiwa sebelum modal tertutup
            modal.on("hide.bs.modal", function (e) {
                // Menghentikan modal tertutup jika kondisi tertentu terpenuhi
                if (kondisiTertentu) {
                    e.preventDefault();
                }
            });
        });
    </script>

    <asp:GridView ID="gridViewCustomer" runat="server" AutoGenerateColumns="false">
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
                    <asp:Button ID="button1" runat="server" Text="Create Transaction" OnClick="btnView_Click" data-toggle="modal" data-target="#mymodal" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="container">
        <div class="modal fade" id="mymodal" role="dialog" data-backdrop="static">
            <div class="modal-dialog modal-dialog-centered" style="width: 700px; height: 500px;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button class="close" >&times;</button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Customer ID</label>
                                <asp:TextBox ID="txtCustomerID" CssClass="form-control" placeholder="Customer ID" runat="server" Enabled="false" />
                            </div>
                            <div class="col-md-6">
                                <label>Customer Name</label>
                                <asp:TextBox ID="txtName" CssClass="form-control" placeholder="Customer Name" runat="server" Enabled="false" />
                            </div>
                        </div>
                        <div class="row dropdownBook">
                            <div class="col-md-6">
                                <label>Book Title</label> <br />
                                <asp:DropDownList ID="dropDownList" runat="server" style="height:30px; width: 300px; "></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label>Quantity</label>
                                <asp:TextBox ID="txtQuantity" CssClass="form-control" placeholder="Quantity" runat="server" Enabled="true" />
                            </div>
                        </div>
                    </div>
                    <div class="text-center mx-10">
                        <asp:Button ID="btnClose" CssClass="btn btn-danger btn-add mx-10" Text="Close"  runat="server" />
                        <asp:Button ID="btnAdd" CssClass="btn btn-add " Text="Add" runat="server" onClick="btnAdd_Click"/>
                        <asp:Button ID="btnsave" CssClass="btn btn-primary btn-add mx-10 " Text="Save" OnClick="btnSave_Click" runat="server" />
                    </div>
                    <div class="modal-footer">
                        <asp:Label ID="txtValidate" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
