using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AoLWebVersion.Model;

namespace AoLWebVersion.Pages.TransactionPage
{
    public partial class test : System.Web.UI.Page
    {
        tokoBukuEntitiess db = new tokoBukuEntitiess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                List<Customer> cust = db.Customers.ToList();
                CustGridView.DataSource = cust;
                CustGridView.DataBind();
            }
        }



    }
}