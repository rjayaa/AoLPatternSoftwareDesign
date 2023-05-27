<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="TokoBuku.Roles.Admin.View.PaymentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2>Add Payment</h2>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="lblPaymentID">Payment ID:</label>
                    <asp:TextBox ID="txtPaymentID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="lblTransactionID">TransactionID:</label>
                    <div class="input-group">
                        <asp:DropDownList ID="ddlTransactionID" runat="server" CssClass="form-control dropdown" OnSelectedIndexChanged="ddlTransactionID_SelectedIndexChanged"></asp:DropDownList>
                        <span class="input-group-btn">
                            <asp:Button ID="btnRefreshAmount" runat="server" Text="Select" CssClass="btn btn-primary btn-margin" OnClick="btnRefreshAmount_Click" />
                        </span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="lblAmount">Total Amount:</label>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
              <div class="form-group">
                    <label for="">TransactionID:</label>
                    <div class="input-group">
                        <asp:DropDownList ID="ddlPaymentMethod" runat="server" CssClass="form-control dropdown" >
                            <asp:ListItem>Select Method</asp:ListItem>
                            <asp:ListItem >Transfer</asp:ListItem>
                            <asp:ListItem >Debit</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnBack" runat="server" Text="Back"  CssClass="btn btn-danger" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear"  CssClass="btn btn-primary" />
                    <asp:Button ID="btnAddPayment" runat="server" Text="Add Payment" OnClick="btnAddPayment_Click" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>
