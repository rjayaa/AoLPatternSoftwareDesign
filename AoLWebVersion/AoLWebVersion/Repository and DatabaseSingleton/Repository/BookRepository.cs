using AoLWebVersion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoLWebVersion.Repository_and_DatabaseSingleton.Repository
{
    public class BookRepository
    {
        tokoBukuEntitiess db = DatabaseSingleton.GetInstance();

        public List<Book> GetBook()
        {
            return (from x in db.Books select x).ToList();
        }

        public Book FindById(string id)
        {
            return (from x in db.Books
                    where x.BookID == id
                    select x).FirstOrDefault();
        }
    }
}