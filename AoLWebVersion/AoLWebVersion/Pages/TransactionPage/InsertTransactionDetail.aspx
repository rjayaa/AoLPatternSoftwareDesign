<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="InsertTransactionDetail.aspx.cs" Inherits="AoLWebVersion.Pages.InsertTransactionDetail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <style>
         .gridview-header-style a{
            text-decoration: none;
            color: black;
        }
    </style>
    <div>
    <asp:Label ID="Label1" runat="server" Text="Customer ID"></asp:Label>
    <asp:TextBox ID="txtCustID" runat="server" Enabled="False"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Customer Name"></asp:Label>
        <asp:TextBox ID="txtCustName" runat="server" Enabled="False"></asp:TextBox>
    </div>
    <div>
        <asp:GridView ID="BookGridView"  runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowFilteringByColumn="True" >
            <HeaderStyle CssClass="gridview-header-style" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkselect" runat="server"  AutoPostBack="true"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="BookID" HeaderText="Book ID" SortExpression="BookID" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                <asp:BoundField DataField="Publisher" HeaderText="Publisher" SortExpression="Publisher" />
                <asp:BoundField DataField="PublicationYear" HeaderText="Publication Year" SortExpression="PublicationYear" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            </Columns>
        </asp:GridView>

    </div>
    <br />
    <div>
        <asp:Button ID="Button1" runat="server" Text="Back To Menu" />
    </div>
    <div>
        <asp:Button ID="BtnClear" runat="server"  Text="Clear" OnClick="BtnClear_Click" />
        <asp:Button ID="BtnAdd" runat="server" OnClick="BtnAdd_Click" Text="Add" />
    </div>

    <br />
    <div>
        <asp:GridView ID="BookViewSection"  runat="server" AutoGenerateColumns="False">
            <HeaderStyle CssClass="gridview-header-style" />
            <Columns>
                <asp:BoundField DataField="BookID" HeaderText="Book ID" SortExpression="BookID" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                <asp:BoundField DataField="Publisher" HeaderText="Publisher" SortExpression="Publisher" />
                <asp:BoundField DataField="PublicationYear" HeaderText="Publication Year" SortExpression="Publisher" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            </Columns>
        </asp:GridView>
    </div>
    
    <asp:Button ID="btnSave" runat="server" Text="Save" Visible="False" OnClick="btnSave_Click" />

    <div>
    <asp:Label ID="txtVerification" runat="server" Text=""></asp:Label>
    </div>
    
</asp:Content>
