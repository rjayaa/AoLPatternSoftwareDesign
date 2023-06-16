<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffHome.aspx.cs" Inherits="LAB_RAMEN.View.Staff.StaffHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
         .button {
            border-style: none;
             border-color: inherit;
             border-width: medium;
             background-color: #4CAF50;
             color: white;
             padding: 10px 20px;
             text-align: center;
             text-decoration: none;
             display: inline-block;
             font-size: 16px;
             cursor: pointer;
             transition-duration: 0.4s;
             margin-left: 5px;
             margin-right: 5px;
             margin-bottom: 5px;
         }

        .button:hover {
            background-color: #45a049;
        }

        
        .gridview {
            border-collapse: collapse;
            width: 100%;
        }

        .gridview th, .gridview td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        .gridview tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .gridview tr:hover {
            background-color: #ddd;
        }

        
        .container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
          <div class="container">
            <h2>Customer Data</h2>
            <asp:GridView ID="gridViewCustomer" runat="server" AutoGenerateColumns="False" 
                Class="gridview">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Customer Name" SortExpression="Customer Name" />
                    <asp:BoundField DataField="Email" HeaderText="Customer Email" SortExpression="Customer Email" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                </Columns>
            </asp:GridView>

            <div>
                <asp:Button ID="btnProfile" runat="server" Text="Profile" CssClass="button" OnClick="btnProfile_Click" />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="button" OnClick="btnLogout_Click" />
            </div>

            <div>
                <asp:Button ID="btnOrderRamen" runat="server" Text="Manage Ramen" CssClass="button" OnClick="btnOrderRamen_Click1"   />
                <asp:Button ID="btnViewOrderQueue" runat="server" Text="View Order Queue" CssClass="button" OnClick="Button1_Click" />
            </div>
        </div>
    </form>
</body>
</html>
