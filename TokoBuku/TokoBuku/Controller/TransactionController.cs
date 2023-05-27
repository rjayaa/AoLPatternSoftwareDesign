using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
namespace TokoBuku.Controller
{
    public class TransactionController
    {
        static TokoBukuEntities db = new TokoBukuEntities();
        public static string insertTransaction(string id, string customerid, DateTime orderdate)
        {
            string message = "";
            Transaction trd = Factory.Factory.createTransaction(id, customerid, orderdate);
            db.Transactions.Add(trd);
            db.SaveChanges();
            return message;
        }
    }
}