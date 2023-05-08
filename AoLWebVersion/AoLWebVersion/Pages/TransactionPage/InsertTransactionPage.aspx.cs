using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AoLWebVersion.Model;
namespace AoLWebVersion.Pages
{
    public partial class InsertTransactionPage : System.Web.UI.Page
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



        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string temp = txtSearch.Text.ToLower();

            var cust = (from c in db.Customers
                        where c.Name.ToLower().Contains(temp)
                        select c);

            CustGridView.DataSource = cust.ToList();
            CustGridView.DataBind();
        }

        protected void CustGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CreateTransaction")
            {
                //{
                //    GridViewRow row = CustGridView.Rows[Convert.ToInt32(e.CommandArgument)];
                //    string id = row.Cells[0].Text;

                //    Response.Redirect("~/Pages/TransactionPage/InsertTransactionDetail.aspx?ID=" + id);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLoginModal();", true);
            }
        }




    }
}