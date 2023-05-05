using AoLWebVersion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AoLWebVersion.Pages
{
    public partial class InsertCustomerPage : System.Web.UI.Page
    {
        tokoBukuEntitiess db = new tokoBukuEntitiess();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string generateID(string prefix)
        {
            string newId = "";
            string lastId = (from x in db.Customers select x.CustomerID).ToList().LastOrDefault();

            if (lastId == null)
            {
                newId = prefix + "001";
            }
            else if (lastId.Length != 6 || !lastId.StartsWith(prefix))
            {
                throw new Exception("Invalid customer ID format");
            }
            else
            {
                int idNumber = Convert.ToInt32(lastId.Substring(3));
                idNumber++;
                newId = String.Format("{0}{1:000}", prefix, idNumber);
            }

            return newId;
        }

        private bool IsValidEmail(string email)
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
        protected void ClearInput()
        {
            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerEmail.Text = "";
            txtCustomerPhone.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            txtLblError.ForeColor = System.Drawing.Color.Red;

            if (txtCustomerName.Text == "")
            {
                txtLblError.Text = "Please enter the customer name";
            }else if (txtCustomerAddress.Text == "") 
            {
                txtLblError.Text = "Please enter the customer address";
            }else if (txtCustomerPhone.Text == "")
            {
                txtLblError.Text = "Please enter the customer phone number";
            }else if(txtCustomerEmail.Text == "")
            {
                txtLblError.Text = "Please enter the customer email";   
            }else if (!IsValidEmail(txtCustomerEmail.Text))
            {
                txtLblError.Text = "Please enter a valid email address";
            }
            else
            {
                Customer cus = Factory.Factory.CreateCustomer(generateID("CUS"), txtCustomerName.Text,
                txtCustomerAddress.Text, txtCustomerPhone.Text, txtCustomerEmail.Text);
                db.Customers.Add(cus);
                db.SaveChanges();
                txtLblError.ForeColor = System.Drawing.Color.Green;
                txtLblError.Text = "Insert Success!!";
                ClearInput();
            }
            
        }
    }
}