using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
namespace TokoBuku.Controller
{
    public class InvoicesController
    { 
        public static bool insertInvoices(string invoiceid, string transactionid, int amount, DateTime date)
        {
            try
            {
                using (var db = new TokoBukuEntities())
                {
                    Invoice bk = Factory.Factory.createInvoices(invoiceid, transactionid, amount, date);
                    db.Invoices.Add(bk);
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