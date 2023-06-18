﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Model;
using LAB_RAMEN.Repository;
using LAB_RAMEN.Handler;
namespace LAB_RAMEN.View.Admin
{
    public partial class AdminCustomerTransactionHistory : System.Web.UI.Page
    {
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
            GridViewRow selectedRow = gridViewTransaction.SelectedRow;
            int headerId = Convert.ToInt32(selectedRow.Cells[0].Text);
            List<Detail> details = OrderHandler.GetDetailData(headerId);

            gridViewDetail.DataSource = details.Select(d => new
            {
                RamenName = d.Raman.Name,
                Quantity = d.Quantity,
                Price = int.Parse(d.Raman.Price) * d.Quantity
            }).ToList();
            gridViewDetail.DataBind();
        }
    }
}