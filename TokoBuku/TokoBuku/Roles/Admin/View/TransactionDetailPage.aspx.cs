using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBuku.Model;
namespace TokoBuku.Roles.Admin.View
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCustomerIDs.Text = Request["ID"];
                bindGridViewBook();
            }
        }

        private void bindGridViewBook()
        {
            var bk = Repository.Repository.getBook();
            gridViewBook.DataSource = bk;
            gridViewBook.DataBind();
        }
        protected void gridViewBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string script = "$('#mymodal').modal('show')";
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script, true);
            }
        }
        protected void btnView_Click(object sender, EventArgs e)
        {

        }
    }
}