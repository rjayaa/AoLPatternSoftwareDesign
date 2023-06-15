using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB_RAMEN.View.Navigation
{
    public partial class CustomerNavigation : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOrderRamen_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Customer/MenuCustomer.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Customer/Profile.aspx");
        }

        protected void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Customer/TransactionHistory.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../Login.aspx");
        }
    }
}