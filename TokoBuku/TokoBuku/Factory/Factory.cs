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

        public static Invoice createInvoices(string invoiceid, string transactionid, int amount, DateTime date)
        {
            Invoice iv = new Invoice();
            iv.InvoiceID = invoiceid;
            iv.TransactionID = transactionid;
            iv.Amount = amount;
            iv.IssuedDate = date;

            return iv;
        }
        public static Book createBook(string bookid, string title, string author, string publisher, int publicationyear, int price, int stock)
        {
            Book bk = new Book();
            bk.BookID = bookid;
            bk.Title = title;
            bk.Author = author;
            bk.Publisher = publisher;
            bk.PublicationYear = publicationyear;
            bk.Price = price;
            bk.Stock = stock;

            return bk;

        }
        
        public static Customer createCustomers(string customerid, string name, string address, string phone, string email)
        {
            Customer cs = new Customer();
            cs.CustomerID = customerid;
            cs.Name = name;
            cs.Address = address;
            cs.Phone = phone;
            cs.Email = email;

            return cs;
        }
    }
}