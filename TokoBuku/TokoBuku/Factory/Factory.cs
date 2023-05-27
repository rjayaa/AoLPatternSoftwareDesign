using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
namespace TokoBuku.Factory
{
    public class Factory
    {
        public static Transaction createTransaction(string transactionid, string customerid, DateTime orderDate)
        {
            Transaction td = new Transaction();
            td.TransactionID = transactionid;
            td.CustomerID = customerid;
            td.OrderDate = orderDate;
            return td;
        }

        public static TransactionDetail createTransactionDetail(string transactionDetailID,string transactionID,string bookID,int quantity)
        {
            TransactionDetail td = new TransactionDetail();
            td.TransactionDetailID = transactionDetailID;
            td.TransactionID = transactionID;
            td.BookID = bookID;
            td.Quantity = quantity;

            return td;

        }

        public static Payment createPayment(string paymentid, string transactionid, int amount, DateTime date, string paymentmethod)
        {
            Payment pp = new Payment();

            pp.PaymentID = paymentid;
            pp.TransactionID = transactionid;
            pp.Amount = amount;
            pp.PaymentDate = date;
            pp.PaymentMethod = paymentmethod;

            return pp;
        }

        
    }
}