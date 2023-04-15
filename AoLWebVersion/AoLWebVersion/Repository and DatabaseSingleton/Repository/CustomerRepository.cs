using AoLWebVersion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AoLWebVersion.Repository_and_DatabaseSingleton.Repository
{
    public class CustomerRepository
    {
        tokoBukuEntitiess db =  DatabaseSingleton.GetInstance();

        public List<Customer> GetCustomers()
        {
            return (from x in db.Customers select x).ToList();
        }

        public Customer FindById(string id)
        {
            return (from x in db.Customers where x.CustomerID == id
                    select x).FirstOrDefault();
        }
    }
}