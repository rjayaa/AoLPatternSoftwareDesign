<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="testPOPUP.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <div class="modal fade" id="mymodal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title"> Add New Record</h4>
                        <button type="button" class="close" data-dismiss="modal">&times</button>
                    </div>
                    <div class="modal-body">
                        <label>Name</label>
                        <asp:TextBox ID="txtName" CssClass="form-control" placeholder="Name" runat="server" />

                        <label>Email</label>
                        <asp:TextBox ID="txtmail" CssClass="form-control" placeholder="Name" runat="server" />
                        <label>Contact</label>
                        <asp:TextBox ID="txtcontact" CssClass="form-control" placeholder="Name" runat="server" />
                        <label>Address</label>
                        <asp:TextBox ID="txtaddress" CssClass="form-control" placeholder="Name" runat="server" />


                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnsave" CssClass="btn btn-primary" Text="Save" runat="server" />
                    </div>

                </div>
            </div>
        </div>
    </div>
    <asp:Button Text="Open Modal" ID="modal" CssClass="btn btn-primary" Onclick="modal_Click" runat="server" />
</asp:Content>
