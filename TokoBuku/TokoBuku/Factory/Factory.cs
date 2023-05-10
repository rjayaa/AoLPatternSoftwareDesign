using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
namespace TokoBuku.Factory
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
    }
}