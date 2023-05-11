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
        
       
        public static (string message, System.Drawing.Color color) InsertBook(string id, string title, string author, string publisher, string publicationYear, string price, string stock)
        {
            string message = "";
            System.Drawing.Color color = System.Drawing.Color.Red;

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
            else if (string.IsNullOrEmpty(publicationYear))
            {
                message = "Please enter the publication year of the book";
            }
            else if (string.IsNullOrEmpty(price))
            {
                message = "Please enter the price of the book [cannot be 0]";
            }
            else if (string.IsNullOrEmpty(stock))
            {
                message = "Please enter the stock of the book [cannot be 0]";
            }
            else
            {
                Book bk = Factory.Factory.createBook(id,title,author,publisher,Convert.ToInt32( publicationYear),Convert.ToInt32(price),Convert.ToInt32(stock));
                db.Books.Add(bk);
                db.SaveChanges();
                message = "Insert Success!!";
                color = System.Drawing.Color.Green;
            }

            return (message, color);
        }

    }
}