using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Repository;
namespace WebApplication1
{
    public partial class TransactionDetails : System.Web.UI.Page
    {

        public transaction tran;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            tran = TransactionRepository.GetTransactionById(id);

            if(tran == null)
            {
                Response.Redirect("Transaction.aspx");
            }
        }
    }
}