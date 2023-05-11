using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using TokoBuku.Model;
using TokoBuku.Factory;
namespace TokoBuku.Controller
{
    public class CustomerController
    {
        static TokoBukuDatabaseEntities2 db = new TokoBukuDatabaseEntities2();

        private static bool IsValidEmail(string email)
        {
            // regular expression untuk email yang valid
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // memvalidasi email dengan regular expression
            Match match = Regex.Match(email, pattern);

            // jika match, email valid
            if (match.Success)
            {
                return true;
            }

            // jika tidak match, email tidak valid
            return false;
        }
        public static (string message, System.Drawing.Color color) InsertCustomer(string id, string name,string address,string phone, string email)
        {
            string message = "";
            System.Drawing.Color color = System.Drawing.Color.Red;
            if (string.IsNullOrEmpty(name))
            {
                message = "Please enter the customer name";
            }
            else if (string.IsNullOrEmpty(address))
            {
                message = "Please enter the customer address";
            }
            else if (string.IsNullOrEmpty(phone))
            {
                message = "Please enter the customer phone number";
            }
            else if (string.IsNullOrEmpty(email))
            {
                message = "Please enter the customer email";
            }
            else if (!IsValidEmail(email))
            {
                message = "Please enter a valid email address";
            }
            else
            {
                Customer cst = Factory.Factory.createCustomer(id,name,address,phone,email);
                db.Customers.Add(cst);
                db.SaveChanges();
                message = "Insert customer success!!";
                color = System.Drawing.Color.Green;
            }

            return (message, color);
        }
    }
}