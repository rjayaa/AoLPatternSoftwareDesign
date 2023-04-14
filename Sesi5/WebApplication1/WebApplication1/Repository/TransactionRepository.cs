using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Repository
{
    public class TransactionRepository
    {
        static DatabaseGuitarEntities db = DatabaseSingleton.GetInstance();
        // Create 2 function
        // 1. Return semua transaction
        // 2. return transaction object berdasarkan ID

        // static = Kita gausah ngebuat instance baru lagi
        // Example :
        // User u = new User(); -> gaperlu buat gini lagi
        // User.Function -> jadi gini
        public static List<transaction> GetTransactions()
        {
            return db.transactions.ToList();
        }

        public static transaction GetTransactionById(string id)
        {
            return (from x in db.transactions
                    where x.Id == id
                    select x).FirstOrDefault();
            // kalo kayak gini dia return object
        }
    }
}