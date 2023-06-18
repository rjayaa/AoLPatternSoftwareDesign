<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMenu.aspx.cs" Inherits="LAB_RAMEN.View.Admin.AdminMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  

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
           <asp:Button ID="btnViewReport" runat="server" Text="View Report SAP"  CssClass="btn" OnClick="btnViewReport_Click"   />
    <asp:Button ID="btnCust" runat="server" Text="Customer Feature" CssClass="button" OnClick="btnCust_Click" />
    <asp:Button ID="btnStaff" runat="server" Text="Staff Feature" CssClass="button" OnClick="btnStaff_Click" />
</div>
        
          
    </form>
</body>
</html>
