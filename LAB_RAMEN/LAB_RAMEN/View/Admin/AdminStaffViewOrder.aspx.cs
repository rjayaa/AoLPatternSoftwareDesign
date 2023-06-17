using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Repository;
using LAB_RAMEN.Model;
namespace LAB_RAMEN.View.Admin
{
    public partial class AdminStaffViewOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = (User)Session["user"];
                gridViewQueueOrder.DataSource = OrderRepository.GetQueueOrder();
                gridViewQueueOrder.DataBind();
            }
        }

        protected void gridViewQueueOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            int staffid = user.id;
            GridViewRow sRow = gridViewQueueOrder.SelectedRow;
            TableCell staffidcell = sRow.Cells[2];

            staffidcell.Text = staffid.ToString();

            int headerID = Convert.ToInt32(sRow.Cells[0].Text);
            OrderRepository.HandleOrderByStaff(headerID, staffid);


            gridViewQueueOrder.DataBind();

            Response.Redirect("AdminStaffViewHandled.aspx");
        }

        protected void btnViewHandled_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminStaffViewHandled.aspx");
        }
    }
}