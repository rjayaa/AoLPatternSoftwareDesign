using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Model;
using LAB_RAMEN.Repository;
namespace LAB_RAMEN.View.Customer
{
    public partial class MenuCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = (User)Session["user"];
                gridViewRamen.DataSource = RamenRepository.GetRamen();
                gridViewRamen.DataBind();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../Login.aspx");
        }


        protected void btnOrderRamen_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Customer/OrderRamen.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Customer/TransactionHistory.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Customer/Profile.aspx");
        }
    }
}