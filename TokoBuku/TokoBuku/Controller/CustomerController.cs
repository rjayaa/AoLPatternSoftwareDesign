using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
namespace TokoBuku.Controller
{
    public class CustomerController
    {
        public static bool insertCustomer(string customerid, string name, string address, string phone, string email)
        {
            try
            {
                using (var db = new TokoBukuEntities())
                {
                    Customer bk = Factory.Factory.createCustomers(customerid, name, address, phone, email);
                    db.Customers.Add(bk);
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
