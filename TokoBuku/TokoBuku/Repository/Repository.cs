using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
namespace TokoBuku.Repository
{
    public class Repository
    {
        static TokoBukuDatabaseEntities2 db = new TokoBukuDatabaseEntities2();

        public static User getUser(String Username, String Password)
        {
            return (from x in db.Users where x.username == Username && x.password == Password select x).FirstOrDefault();
        }

        public static List<Customer> getCustomer()
        {
            return db.Customers.ToList();
        }

        public static List<Book> getBook()
        {
            return db.Books.ToList();
        }
    }
}