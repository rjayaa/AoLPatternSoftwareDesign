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
            return db.Books.ToList();
        }

   
        public Book FindById(string id)
        {
            Console.WriteLine("Querying database for book with ID: " + id);
            var book = db.Books.Find(id);
            if (book != null)
            {
                Console.WriteLine("Book found: " + book.Title);
            }
            else
            {
                Console.WriteLine("Book not found for ID: " + id);
            }
            return book;
        }

    }
}