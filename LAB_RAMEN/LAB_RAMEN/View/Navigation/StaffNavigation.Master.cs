using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB_RAMEN.View.Navigation
{
    public partial class StaffNavigation : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void btnManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Staff/StaffManageRamen.aspx");
        }

       

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Staff/StaffHome.aspx");
        }


        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Staff/StaffViewOrder.aspx");
        }
    }
}