using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Repository;
using LAB_RAMEN.Model;
namespace LAB_RAMEN.View.Staff
{
    public partial class StaffManageRamen : System.Web.UI.Page
    {
        static DatabaseRamenEntities1 db = DBSingleton.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridviewRamen.DataSource = db.Ramen.ToList();
                gridviewRamen.DataBind();
            }

        }

        protected void gridviewRamen_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = gridviewRamen.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("../Staff/StaffUpdateRamen.aspx?ID=" + id);
        }

        protected void gridviewRamen_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            try
            {
                GridViewRow row = gridviewRamen.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells[0].Text); ;
                Raman rm = db.Ramen.Find(id);
                db.Ramen.Remove(rm);
                db.SaveChanges();

                gridviewRamen.DataSource = RamenRepository.GetRamen();
                gridviewRamen.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "Could Not Delete This Data!";
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Staff/StaffInsertRamen.aspx");
        }
    }
}