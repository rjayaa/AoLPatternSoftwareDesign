<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LAB_RAMEN.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
   
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Welcome to RAAMEN!!!</h1>
            <div class="form-group">
                <label for="txtUsername">Username</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtPassword">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div>
                <asp:CheckBox ID="chkRemember" runat="server" Text="Remember Me"/>
            </div>
            <br />
            <div>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div class="form-group">
                <div class="btn-container">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="btnRegister_Click1" />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
