using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AoLWebVersion.Model;
namespace AoLWebVersion.Factory
{
    public class Factory
    {
        public static Customer CreateCustomer(string id, string name,string address,string phone,string email)
        {
            Customer c = new Customer();
            c.CustomerID = id;
            c.Name = name;
            c.Address = address;
            c.Phone = phone;
            c.Email = email;
            return c;
        }

        public static Book CreateBook(string id, string title, string author, string publisher, DateTime publicationYear , int price, int stock )
        {
            Book b = new Book();
            b.BookID = id;
            b.Title = title;
            b.Author = author;
            b.Publisher = publisher;
            b.PublicationYear = publicationYear;
            b.Price = price;
            b.Stock = stock;
            return b;

        }

        public static Invoice createInvoice(string invoiceid, string transactionid, int amount, DateTime issueddate)
        {
            Invoice i = new Invoice();
            i.InvoiceID = invoiceid;
            i.TransactionID = transactionid;
            i.Amount = amount;
            i.IssuedDate = issueddate;
            return i;
        }

        public static Payment createPayment(string paymentid, string transactionid, int amount, DateTime paymentdate, string paymentmethod)
        {
            Payment p = new Payment();
            p.PaymentID = paymentid;
            p.TransactionID = transactionid;
            p.Amount = amount;
            p.PaymentDate = paymentdate;
            p.PaymentMethod = paymentmethod;

            return p;
        }

        public static Transaction createTransaction(string transactionid, string customerid,DateTime orderdate)
        {
            Transaction t = new Transaction();
            t.TransactionID = transactionid;
            t.CustomerID = customerid;
            t.OrderDate = orderdate;

            return t;
        }

        public static Transaction_Detail createTransactionDetail(string transactionid, string bookid, int quantity)
        {
            Transaction_Detail td = new Transaction_Detail();
            td.TransactionID = transactionid;
            td.BookID = bookid;
            td.Quantity = quantity;
            return td;
        }
    }
}