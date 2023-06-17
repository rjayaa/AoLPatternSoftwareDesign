using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Repository;
namespace LAB_RAMEN.View.Admin
{
    public partial class AdminViewAllTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridViewAllTransaction.DataSource = AdminRepository.GetAllTransaction();
                gridViewAllTransaction.DataBind();
            }
        }
    }
}