<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoicesPage.aspx.cs" Inherits="TokoBuku.Roles.Admin.View.InvoicesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2>Invoices Form</h2>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="lblPaymentID">Invoices ID:</label>
                    <asp:TextBox ID="txtInvoiceID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="lblTransactionID">TransactionID:</label>
                    <div class="input-group">
                        <asp:DropDownList ID="ddlTransactionID" runat="server" CssClass="form-control dropdown" OnSelectedIndexChanged="ddlTransactionID_SelectedIndexChanged"></asp:DropDownList>
                        <span class="input-group-btn">
                            <asp:Button ID="btnRefreshAmount" runat="server" Text="Select" CssClass="btn btn-primary btn-margin" />
                        </span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtAmount">Amount:</label>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <asp:Button ID="btnInvoice" runat="server" Text="Create Invoice" class="btn btn-success" OnClick="btnInvoice_Click" />
                <br />
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
