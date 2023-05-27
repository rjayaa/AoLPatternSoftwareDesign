using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
namespace TokoBuku.Controller
{
    public class TransactionDetailController
    {
        static TokoBukuEntities db = new TokoBukuEntities();
        public static Boolean insertTransactionDetail(string transactionDetailID, string transactionID,string bookID, int quantity)
        {
            

            try
            {
                TransactionDetail td = Factory.Factory.createTransactionDetail(transactionDetailID, transactionID, bookID, quantity);
                db.TransactionDetails.Add(td);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                
                // Log the exception using your preferred logging mechanism
                // logger.Error(ex.ToString());
            }

            return true;
        }
    }
}
    
