using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokoBuku.Roles.Admin.View
{
    public partial class InsertCustomerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string id = Controller.GenerateID.generateID("CUS", "Customers", "CustomerID");
            Controller.CustomerController.insertCustomer(id, txtName.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text);
        }
    }
}