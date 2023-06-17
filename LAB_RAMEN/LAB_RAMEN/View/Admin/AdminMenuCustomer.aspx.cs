using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB_RAMEN.View.Admin
{
    public partial class MenuCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminProfile.aspx");
        }

        protected void btnOrderRamen_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminOrderRamen.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCustomerTransactionHistory.aspx");
        }
    }
}