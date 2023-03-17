<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetails.aspx.cs" Inherits="WebApplication1.TransactionDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="500px" border="1">
                // bikin semua data dalam transaksi tersebut

                <tr>
                    <td>Date</td>
                    <td><%= tran.transaction_date %></td>
                </tr>
                 <tr>
                    <td>Buyer</td>
                    <td><%= tran.user.name %></td>
                </tr>
                 <tr>
                    <td>Total Product</td>
                    <td><%= tran.transaction_details.Count() %></td>
                </tr>
                 <tr>
                    <td>Total Quantity</td>
                    <td><%= tran.transaction_details.Sum(x => x.quantity) %></td>
                </tr>
                 <tr>
                    <td>Total Type</td>
                    <td><%=tran.transaction_details.GroupBy(x => x.guitar.guitar_type_id).Count() %></td>
                </tr>
                 <tr>
                    <td>Total Money Spent</td>
                    <td><%=tran.user.transactions.Sum(x => x.transaction_details.Sum(y=>y.quantity*int.Parse(y.guitar.price))) %></td>
                </tr>
                 <tr>
                    <td>Max Spending</td>
                    <td><%=tran.user.transactions.Sum(x => x.transaction_details.Max(y=>y.quantity*int.Parse(y.guitar.price))) %></td>
                </tr>
                 <tr>
                    <td>Min Spending</td>
                    <td><%=tran.user.transactions.Sum(x => x.transaction_details.Min(y=>y.quantity*int.Parse(y.guitar.price))) %></td>
                </tr>
                 <tr>
                    <td>Average Spending</td>
                    <td><%=tran.user.transactions.Sum(x => x.transaction_details.Average(y=>y.quantity*int.Parse(y.guitar.price))) %></td>
                </tr>

                <tr>
                    <td>Guitar Brand</td>
                    <td>Guitar Type</td>
                    <td>Quantity</td>
                    <td>Subtotal</td>
                </tr>

                <%foreach (var x in tran.transaction_details)
                    { %>
                <tr>
                    <td><%=x.guitar.brand %></td>
                    <td><%=x.guitar.guitar_types.name %></td>
                    <td><%=x.quantity %></td>
                    <td><%=x.quantity*int.Parse(x.guitar.price) %></td>
                </tr>    

                
                <%} %>
                <tr>
                    <td colspan="3">Total</td>
                    <td colspan="3"><%=tran.transaction_details.Sum(x => x.quantity *int.Parse(x.guitar.price)) %></td>
                </tr>


                <%--
                    Domain Driven Design
                    1. View
                        Label1.Text = "Hello
                    2. Service
                        Bussiness Logic
                    3. Controller
                        Logic code behind (Validation, session, cookie, dll)
                    4. Handler
                        Menyatukan atribut menjadi sebuah objek
                    5. Factory
                        Membuat Constructor untuk model
                        x.name = from x in db.user
                    6. Repository
                        Menyambungkan database dengan application
                    --%>
            </table>
        </div>
    </form>
</body>
</html>
