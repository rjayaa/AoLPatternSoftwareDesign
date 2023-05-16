using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokoBukuKita.View.Admin
{
    public partial class InsertCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void clearInsert()
        {
            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerPhone.Text = "";
            txtCustomerEmail.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Controller.GenerateID.generateID("CST", "Customers", "CustomerID");
            var result = Controller.CustomerController.InsertCustomer(id, txtCustomerName.Text, txtCustomerAddress.Text, txtCustomerPhone.Text, txtCustomerEmail.Text);
            txtLblError.Text = result.message;
            txtLblError.ForeColor = result.color;
            if (txtLblError.Text.Equals("Insert customer success!!!")) clearInsert();

        }
    }
}