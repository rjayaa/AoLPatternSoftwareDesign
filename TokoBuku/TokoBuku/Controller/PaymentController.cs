using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;

namespace TokoBuku.Controller
{
    public class PaymentController
    {
        public static bool insertPayment(string paymentid, string transactionid, int amount, DateTime date, string paymentmethod)
        {
            try
            {
                using (var db = new TokoBukuEntities())
                {
                    Payment pp = Factory.Factory.createPayment(paymentid, transactionid, amount, date, paymentmethod);
                    db.Payments.Add(pp);
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
