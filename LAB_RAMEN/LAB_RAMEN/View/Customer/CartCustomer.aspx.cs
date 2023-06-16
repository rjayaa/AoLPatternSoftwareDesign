using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Model;
using LAB_RAMEN.Repository;

namespace LAB_RAMEN.View.Customer
{
    public partial class CartCustomer : System.Web.UI.Page
    {
        static DatabaseRamenEntities db = new DatabaseRamenEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = (User)Session["user"];
                Header header = (Header)Session["cart"];
                List<Detail> orderDetails = (List<Detail>)Session["order"];

                if (header != null)
                {
                    gridViewCart.Visible = true;
                    btnCheckout.Visible = true;
                    lblStatus.Visible = false;

                    var orderList = orderDetails
                        .GroupBy(d => d.RamenID)
                        .Select(g => new KeyValuePair<int, int>(g.Key, g.Sum(d => d.Quantity)))
                        .ToList();

                    gridViewCart.DataSource = orderList;
                    gridViewCart.DataBind();
                }
                else
                {
                    lblStatus.Visible = true;
                    gridViewCart.Visible = false;
                    btnCheckout.Visible = false;
                }
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Header header = (Header)Session["cart"];
            List<Detail> orderDetails = (List<Detail>)Session["order"];

            db.Headers.Add(header);
            db.SaveChanges();

            int currentId = 1;
            foreach (Detail detail in orderDetails)
            {
                // Set HeaderID dari detail pesanan
                detail.HeaderID = header.id;

                // Atur nilai ID secara manual
                detail.id = currentId++;

                db.Details.Add(detail);
            }
            db.SaveChanges();




            Session.Remove("cart");
            Session.Remove("order");

            Response.Redirect("../Customer/OrderRamen.aspx");
        }

        protected string GetRamenName(object ramenID)
        {
            int id = Convert.ToInt32(ramenID);
            string ramenName = CustomerRepository.GetRamenNameById(id);
            return ramenName;
        }
    }
}
