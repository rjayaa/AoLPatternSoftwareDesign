using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Repository;
using LAB_RAMEN.Handler;
using System.Data;

namespace LAB_RAMEN.View.Admin
{
    public partial class AdminCartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ramenid"] != null)
                {
                    PopulateGridView();
                }

                UpdateBackButtonVisibility();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            List<int> ramenids = Session["ramenids"] as List<int>;
            List<int> quantities = Session["quantities"] as List<int>;

            if (ramenids != null && quantities != null && ramenids.Count == quantities.Count)
            {
                foreach (GridViewRow row in gridViewCart.Rows)
                {
                    int headerid = Convert.ToInt32(row.Cells[0].Text);
                    int ramenid = Convert.ToInt32(row.Cells[1].Text);
                    int quantity = Convert.ToInt32(row.Cells[2].Text);

                    OrderHandler.insertDetail(headerid, ramenid, quantity);
                }

                ClearSessionData();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            OrderHandler.RemoveLastHeaderData();
            Response.Redirect("AdminOrderRamen.aspx");
        }

        protected void gridViewCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataTable dt = GetGridViewData();
            dt.Rows.RemoveAt(rowIndex);
            gridViewCart.DataSource = dt;
            gridViewCart.DataBind();
            UpdateSessionData();
            UpdateBackButtonVisibility();
        }

        private DataTable GetGridViewData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("RamenID", typeof(int));
            dt.Columns.Add("Quantity", typeof(int));

            foreach (GridViewRow row in gridViewCart.Rows)
            {
                int id = Convert.ToInt32(row.Cells[0].Text);
                int ramenID = Convert.ToInt32(row.Cells[1].Text);
                int quantity = Convert.ToInt32(row.Cells[2].Text);

                dt.Rows.Add(id, ramenID, quantity);
            }

            return dt;
        }

        private void PopulateGridView()
        {
            List<int> ramenIDs = Session["ramenids"] as List<int>;
            int headerID = (int)Session["headerID"];
            List<int> quantities = Session["quantities"] as List<int>;

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("RamenID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));

            if (quantities != null && ramenIDs != null)
            {
                foreach (int ramenID in ramenIDs)
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = headerID;
                    dr["RamenID"] = ramenID;

                    string ramenName = RamenRepository.GetRamenNameById(ramenID);
                    dr["Name"] = ramenName;

                    int quantity = quantities[ramenIDs.IndexOf(ramenID)];
                    dr["Quantity"] = quantity;

                    dt.Rows.Add(dr);
                }
            }

            gridViewCart.DataSource = dt;
            gridViewCart.DataBind();
        }

        private void UpdateSessionData()
        {
            DataTable dt = GetGridViewData();
            List<int> ramenIDs = dt.AsEnumerable().Select(row => row.Field<int>("RamenID")).ToList();
            List<int> quantities = dt.AsEnumerable().Select(row => row.Field<int>("Quantity")).ToList();

            Session["ramenids"] = ramenIDs;
            Session["quantities"] = quantities;
        }

        private void ClearSessionData()
        {
            Session["ramenid"] = null;
            Session["ramenids"] = null;
            Session["headerid"] = null;
            Session["quantities"] = null;
        }

        private void UpdateBackButtonVisibility()
        {
            btnBack.Visible = (gridViewCart.Rows.Count == 0);
        }

    }
}