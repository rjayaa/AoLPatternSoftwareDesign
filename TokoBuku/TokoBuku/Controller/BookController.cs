using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
namespace TokoBuku.Controller
{
    public class BookController
    {
        static TokoBukuDatabaseEntities2 db = new TokoBukuDatabaseEntities2();
        
        public static string InsertBook(string id, string title, string author, string publisher, int publicationYear, int price, int stock)
        {
            string message = "";

            if (string.IsNullOrEmpty(title))
            {
                message = "Please enter the title of the book";
            }
            else if (string.IsNullOrEmpty(author))
            {
                message = "Please enter the author of the book";
            }
            else if (string.IsNullOrEmpty(publisher))
            {
                message = "Please enter the publisher of the book";
            }
            else if (publicationYear == 0)
            {
                message = "Please enter the publication year of the book";
            }
            else if (price == 0)
            {
                message = "Please enter the price of the book [cannot be 0]";
            }
            else if (stock == 0)
            {
                message = "Please enter the stock of the book [cannot be 0]";
            }
            else
            {
                Book bk = Factory.Factory.createBook(id,title,author,publisher,publicationYear,price,stock);
                db.Books.Add(bk);
                db.SaveChanges();
                message = "Insert Success!!";
            }

            return message;
        }

    }
}