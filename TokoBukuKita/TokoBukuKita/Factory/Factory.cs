using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBukuKita.Model;
namespace TokoBukuKita.Factory
{
    public class Factory
    {
        public static Book createBook(string id, string title, string author, string publisher, int publicationyear, int price, int stock)
        {
            Book bk = new Book();
            bk.BookID = id;
            bk.Title = title;
            bk.Author = author;
            bk.Publisher = publisher;
            bk.PublicationYear = publicationyear;
            bk.Price = price;
            bk.Stock = stock;
            return bk;
        }

        public static Customer createCustomer(string id, string name, string address, string phone, string email)
        {
            Customer cst = new Customer();
            cst.CustomerID = id;
            cst.Name = name;
            cst.Address = address;
            cst.Phone = phone;
            cst.Email = email;

            return cst;
        }

        public static Transaction_Detail createTransactionDetail(string id , string bookID, int quantity)
        {
            Transaction_Detail td = new Transaction_Detail();
            td.TransactionID = id;
            td.BookID = bookID;
            td.Quantity = quantity;

            return td;
        }

        public static Transaction createTransaction(string id, string customerID, DateTime orderdate)
        {
            Transaction td = new Transaction();
            td.TransactionID = id;
            td.CustomerID = customerID;
            td.OrderDate = orderdate;
            return td;
        }

    }
}