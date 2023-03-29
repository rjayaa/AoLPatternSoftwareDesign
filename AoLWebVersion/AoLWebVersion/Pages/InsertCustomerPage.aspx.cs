using AoLWebVersion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AoLWebVersion.Pages
{
    public partial class InsertCustomerPage : System.Web.UI.Page
    {
        tokoBukuEntities db = new tokoBukuEntities();
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
            else
            {
                int idNumber = Convert.ToInt32(lastId.Substring(2));
                idNumber++;
                newId = String.Format("{0}{0:000}",prefix , idNumber);
            }
            return newId;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Customer cus = Factory.Factory.CreateCustomer(generateID("CUS"), txtCustomerName.Text,
                txtCustomerAddress.Text, txtCustomerPhone.Text, txtCustomerEmail.Text);
            db.Customers.Add(cus);
            db.SaveChanges();
        }
    }
}