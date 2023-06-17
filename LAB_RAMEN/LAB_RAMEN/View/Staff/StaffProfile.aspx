<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation/StaffNavigation.Master" AutoEventWireup="true" CodeBehind="StaffProfile.aspx.cs" Inherits="LAB_RAMEN.View.Staff.StaffProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
     <div class="container">
        <h1>Profile</h1>
        <div class="form-group">
            <label for="txtUsername">Username</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtEmail">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ddlGender">Gender</label>
            <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control" Enabled="false">
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
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary" OnClick="btnEdit_Click"  />
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-danger"  Visible="false" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
