using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
namespace TokoBuku.Controller
{
    public class BookController
    {
        public static bool insertbook(string bookid, string title, string author, string publisher, int publicationyear, int price, int stock)
        {
            try
            {
                using (var db = new TokoBukuEntities())
                {
                    Book bk = Factory.Factory.createBook(bookid, title, author, publisher, publicationyear,price,stock);
                    db.Books.Add(bk);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}