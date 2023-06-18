using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Repository;
namespace LAB_RAMEN.View.Admin
{
    public partial class AdminStaffMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridViewCustomer.DataSource = StaffRepository.GetAllCustomers();
                gridViewCustomer.DataBind();
            }
        }

        protected void btnOrderRamen_Click1(object sender, EventArgs e)
        {
            Response.Redirect("AdminStaffManageRamen.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminStaffViewOrder.aspx");
        }
    }
}