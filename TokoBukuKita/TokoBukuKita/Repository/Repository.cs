using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBukuKita.Model;
namespace TokoBukuKita.Repository
{
    public class Repository
    {
        static TokoBukuEntities db = new TokoBukuEntities();

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