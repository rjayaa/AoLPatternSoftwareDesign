using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Repository;
using LAB_RAMEN.Handler;
using LAB_RAMEN.Model;

namespace LAB_RAMEN.View.Customer
{
    public partial class CartPage : System.Web.UI.Page
    {
        static DatabaseRamenEntities1 db = DBSingleton.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ramenid"] != null)
                {
                    List<int> ramenIDs = Session["ramenids"] as List<int>;

                    // Mendapatkan nilai HeaderID dari session
                    int headerID = (int)Session["headerID"];
                    List<int> quantities = Session["quantities"] as List<int>;

                    // Buat DataTable dengan struktur kolom yang sesuai
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

                Session["ramenid"] = null;
                Session["ramenids"] = null;
                Session["headerid"] = null;
                Session["quantities"] = null;
            }
        }
    }
}
