<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMenu.aspx.cs" Inherits="LAB_RAMEN.View.Admin.AdminMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <style>
    .gridview-container {
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        align-items: flex-start;
        gap: 20px;
        margin-top: 50px;
    }

    .gridview {
        width: 300px;
        background-color: #f2f2f2;
        border-radius: 5px;
        padding: 10px;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    }

    .button-container {
        display: flex;
        justify-content: center;
        gap: 20px;
        margin-top: 30px;
    }

    .button-container .button {
        padding: 10px 20px;
        background-color: #4caf50;
        color: white;
        border: none;
        border-radius: 5px;
        font-size: 14px;
        cursor: pointer;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="gridview-container">
             <h2>Customer</h2>
    <asp:GridView ID="gridViewCustomer" runat="server" AutoGenerateColumns="False"
        Class="gridview">
        <Columns>
            <asp:BoundField DataField="Username" HeaderText="Customer Name" SortExpression="Customer Name" />
            <asp:BoundField DataField="Email" HeaderText="Customer Email" SortExpression="Customer Email" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
        </Columns>
    </asp:GridView>

     <asp:GridView ID="gridViewStaff" runat="server" AutoGenerateColumns="False"
        Class="gridview">
        <Columns>
            <asp:BoundField DataField="Username" HeaderText="Customer Name" SortExpression="Customer Name" />
            <asp:BoundField DataField="Email" HeaderText="Customer Email" SortExpression="Customer Email" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
        </Columns>
    </asp:GridView>
       <div class="button-container">
    <asp:Button ID="btnCust" runat="server" Text="Customer Feature" CssClass="button" />
    <asp:Button ID="btnStaff" runat="server" Text="Staff Feature" CssClass="button" />
</div>
        
          
    </form>
</body>
</html>
