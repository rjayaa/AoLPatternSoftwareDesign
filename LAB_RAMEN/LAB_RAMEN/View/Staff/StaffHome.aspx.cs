using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Repository;
namespace LAB_RAMEN.View.Staff
{
    public partial class StaffHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridViewCustomer.DataSource = StaffRepository.GetAllCustomers();
                gridViewCustomer.DataBind();
            }
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Staff/StaffProfile.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../Login.aspx");
        }

        protected void btnOrderRamen_Click1(object sender, EventArgs e)
        {
            Response.Redirect("../Staff/StaffManageRamen.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Staff/StaffViewOrder.aspx");
        }
    }
}