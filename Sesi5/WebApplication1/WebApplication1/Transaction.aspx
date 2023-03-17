<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="WebApplication1.Transaction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="500px" border ="1">
                
                <tr>
                    <td>Date</td>
                    <td>Name</td>
                    <td>Total Product</td>
                    <td>Details</td>
                </tr>
                // buat SSR = Server Side Rendering

                <%-- C# Logic untuk looping isi table --%>
             <%foreach (var x in transactions)
                 {%>
                <tr>
                    <td><%= x.transaction_date %></td>
                    <td><%= x.user.name %></td>
                    <td><%= x.transaction_details.Count() %></td>
                    <td><a href="TransactionDetails.aspx?id=<%=x.Id %>">Here</a></td>
                </tr>
                <%} %>
            </table>
        </div>
    </form>
</body>
</html>
