using AoLWebVersion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AoLWebVersion.Pages
{
    public partial class InsertTransactionDetail : System.Web.UI.Page
    {
        tokoBukuEntitiess db = new tokoBukuEntitiess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["ID"]!= null)
                {
                    string id = Request.QueryString["ID"].ToString();
                    lblError.Text = id;
                }
            }
            //string id = Request.QueryString["ID"];
            //Customer cust = db.Customers.Find(id);

        }
    }
}