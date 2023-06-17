using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Handler;
using LAB_RAMEN.Model;
using LAB_RAMEN.Repository;
namespace LAB_RAMEN.View.Admin
{
    public partial class AdminOrderRamen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridViewRamen.DataSource = RamenRepository.GetRamen();
                gridViewRamen.DataBind();

            }
        }

        protected void gridViewRamen_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = gridViewRamen.SelectedRow;

            int headerID = GenerateIDRepository.GenerateID("Header");
            int ramenid = int.Parse(selectedRow.Cells[0].Text);

            List<int> quantities = Session["quantities"] as List<int>;
            List<int> ramenIDs = Session["ramenids"] as List<int>;

            if (quantities == null || ramenIDs == null)
            {
                quantities = new List<int>();
                ramenIDs = new List<int>();
            }

            int index = ramenIDs.IndexOf(ramenid);
            if (index != -1)
            {
                quantities[index]++;
            }
            else
            {
                ramenIDs.Add(ramenid);
                quantities.Add(1);
            }


            Session["ramenid"] = ramenid;
            Session["headerID"] = headerID;
            Session["quantities"] = quantities;
            Session["ramenids"] = ramenIDs;
        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            User us = (User)Session["user"];
            int headerID = GenerateIDRepository.GenerateID("Header");
            OrderHandler.insertHeader(headerID, us.id);


            Response.Redirect("AdminCartPage.aspx");
        }
    }
}