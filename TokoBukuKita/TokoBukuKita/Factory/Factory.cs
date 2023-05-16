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
    }
}