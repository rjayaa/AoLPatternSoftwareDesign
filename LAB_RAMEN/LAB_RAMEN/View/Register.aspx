<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LAB_RAMEN.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Register</h1>
            <div class="form-group">
                <label for="txtUsername">Username</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ddlGender">Gender</label>
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtPassword">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtConfirmPassword">Confirm Password</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
           
            <div>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div class="form-group">
                <div class="btn-container">
                    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-danger" OnClick="btnRegister_Click1" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
