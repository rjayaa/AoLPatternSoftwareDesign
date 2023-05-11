using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBuku.Model;
using TokoBuku.Repository;
namespace TokoBuku.View
{
    public partial class TransactionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Customer> customers = Repository.Repository.getCustomer();
                gridViewCustomer.DataSource = customers;
                gridViewCustomer.DataBind();

                List<Book> bk  = Repository.Repository.getBook();
                gridviewDialog.DataSource = bk;
                gridviewDialog.DataBind();

            }
        }
    }
}