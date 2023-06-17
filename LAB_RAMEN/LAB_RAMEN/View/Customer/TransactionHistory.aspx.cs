﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Repository;
using LAB_RAMEN.Model;
using LAB_RAMEN.Handler;
namespace LAB_RAMEN.View.Customer
{
    public partial class TransactionHistory : System.Web.UI.Page
    {

        public List<Detail> dt = new List<Detail>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = (User)Session["user"];
                gridViewTransaction.DataSource = OrderRepository.GetUserHistoryTransaction(user.id);
                gridViewTransaction.DataBind();
            }
        }

        protected void gridViewTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow sRow = gridViewTransaction.SelectedRow;
            int headerid = int.Parse(sRow.Cells[0].Text);
            dt = OrderHandler.GetDetailData(headerid);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}