using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBuku.Model;
using TokoBuku.Repository;
namespace TokoBuku.Roles.Admin.View
{
    public partial class TransactionPage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGridViewCustomer();
            }
        }

        private void bindGridViewCustomer()
        {
            var bk = Repository.Repository.getCustomer();
            gridViewCustomer.DataSource = bk;
            gridViewCustomer.DataBind();

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btnView = (Button)sender;
            GridViewRow row = (GridViewRow)btnView.NamingContainer;
            string customerID = row.Cells[0].Text;
            string transactionid = Controller.GenerateID.generateID("TRD", "Transactions", "TransactionID");
            DateTime currentTime = DateTime.Now;
            var result = Controller.TransactionController.insertTransaction(transactionid, customerID, currentTime);
            Response.Redirect("TransactionDetailPage.aspx?customerid=" + customerID + "&transactionid=" + transactionid);
        }
    }
}