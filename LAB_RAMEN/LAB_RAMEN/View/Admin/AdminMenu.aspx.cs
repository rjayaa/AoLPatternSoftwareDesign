using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Repository;
namespace LAB_RAMEN.View.Admin
{
    public partial class AdminMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridViewCustomer.DataSource = AdminRepository.GetAllCustomers();
                gridViewCustomer.DataBind();

                gridViewStaff.DataSource = AdminRepository.GetAllStaff();
                gridViewStaff.DataBind();
            }
        }

        protected void btnCust_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMenuCustomer.aspx");
        }

        protected void btnStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminStaffMenu.aspx");
        }
    }
}