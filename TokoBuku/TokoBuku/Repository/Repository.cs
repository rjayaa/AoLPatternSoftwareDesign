using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
namespace TokoBuku.Repository
{


    public class Repository
    {
        static TokoBukuEntities db = new TokoBukuEntities();

        public static List<Book> getBook()
        {
            return db.Books.ToList();
        }

        public static List<Customer> getCustomer()
        {
            return db.Customers.ToList();
        }

        public static List<TransactionDetail> getTransactionDetails()
        {
            return db.TransactionDetails.ToList();
        }

        public static List<Transaction> getTransactions() {
            return db.Transactions.ToList();

        }
        public static List<Payment> getPayments()
        {
            return db.Payments.ToList();
        }
       
    }
}