<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modal-popup.aspx.cs" Inherits="TokoBukuKita.View.modal_popup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
    <div class="modal fade" id="mymodal" role="dialog">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Add New Record</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <label for="txtName">Name</label>
                    <input id="txtName" class="form-control" type="text" placeholder="Name" />

                    <label for="txtmail">Email</label>
                    <input id="txtmail" class="form-control" type="email" placeholder="Email" />

                    <label for="txtcontact">Contact</label>
                    <input id="txtcontact" class="form-control" type="tel" placeholder="Contact" />

                    <label for="txtaddress">Address</label>
                    <input id="txtaddress" class="form-control" type="text" placeholder="Address" />
                </div>
                <div class="modal-footer">
                    <button id="btnSave" class="btn btn-primary" type="button">Save</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
