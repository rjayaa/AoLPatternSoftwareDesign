using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Model;
using LAB_RAMEN.Repository;

namespace LAB_RAMEN.View.Staff
{
    public partial class StaffManageRamen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridViewRamen.DataSource = RamenRepository.GetRamen();
                gridViewRamen.DataBind(); 
            }
        }

        protected void btnInsertRamen_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Staff/StaffInsertRamen.aspx");
        }

        protected void ramenGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void ramenGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}