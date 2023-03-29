<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="AoLWebVersion.View.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu</title>
    <style>
        .CusTrans{
            margin: 15px;
        }
        #btnCustomer,#btnPayment{
            margin-right: 35px;
        }
    </style>
</head>
   
<body>
    <form id="form1" runat="server">
        <h1>Menu</h1>
        <div class="CusTrans" >
            <asp:Button ID="btnCustomer" runat="server" Text="Insert Customer" OnClick="btnCustomer_Click" />
            <asp:Button ID="btnTransactions" runat="server" Text="Insert Transactions" />
        </div>
        <div class="CusTrans">
            <asp:Button ID="btnPayment" runat="server" Text="Choose Payment" />
            <asp:Button ID="Button4" runat="server" Text="View Books" />
        </div>
        <div class="CusTrans">
            <asp:Button ID="Button5" runat="server" Text="Button" />
            <asp:Button ID="Button6" runat="server" Text="Button" />
        </div>
        <div class="CusTrans">
             <asp:Button ID="Button7" runat="server" Text="Button" />
        </div>
    </form>
</body>
</html>
