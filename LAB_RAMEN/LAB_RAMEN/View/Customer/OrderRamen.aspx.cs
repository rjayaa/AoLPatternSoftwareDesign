using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Repository;
using LAB_RAMEN.Model;
using System.Data;
using LAB_RAMEN.Factory;

namespace LAB_RAMEN.View.Customer
{
    public partial class OrderRamen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = (User)Session["user"];
                gridViewRamen.DataSource = CustomerRepository.GetRamen();
                gridViewRamen.DataBind();
            }
        }

        protected void gridViewRamen_SelectedIndexChanged(object sender, EventArgs e)
        {
            User u = (User)Session["user"];
            GridViewRow selectedRow = gridViewRamen.SelectedRow;
            int ramenID = Convert.ToInt32(selectedRow.Cells[0].Text);

            Header h = (Header)Session["cart"];

            if (h == null)
            {
                Session["cart"] = FactoryData.AddHeaderFromUser(u.id);
                List<Detail> details = new List<Detail>();
                Session["order"] = details;
                h = (Header)Session["cart"];
            }

            List<Detail> orderDetails = (List<Detail>)Session["order"];

            Detail existingDetail = orderDetails.FirstOrDefault(d => d.RamenID == ramenID);
            if (existingDetail != null)
            {
                existingDetail.Quantity++;
            }
            else
            {
                orderDetails.Add(FactoryData.AddDetail(h.id, ramenID, 1));
            }

            Session["order"] = orderDetails;
        }


        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Customer/CartCustomer.aspx");
        }
    }
}
