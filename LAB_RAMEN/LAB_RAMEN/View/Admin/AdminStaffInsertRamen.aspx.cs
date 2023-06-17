using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Repository;
using LAB_RAMEN.Controller;
using LAB_RAMEN.Handler;
namespace LAB_RAMEN.View.Admin
{
    public partial class AdminStaffInsertRamen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMeat.DataSource = RamenRepository.GetMeatData();
                ddlMeat.DataBind();
            }
        }
        protected void clearTxt()
        {
            txtName.Text = "";
            txtBroth.Text = "";
            txtPrice.Text = "";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminStaffManageRamen.aspx");
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            int id = GenerateIDRepository.GenerateID("Ramen");
            if (!RamenController.ValidateName(txtName.Text))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Must contains ‘Ramen’.";
            }
            else if (!RamenController.ValidateMeat(ddlMeat.SelectedValue))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Must Be Selected";
            }
            else if (!RamenController.ValidateBroth(txtBroth.Text))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Cannot Be Empty";
            }
            else if (!decimal.TryParse(txtPrice.Text, out decimal price) || !RamenController.ValidatePrice(price))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Price must be at least 3000.";
            }
            else
            {
                RamenHandler.insertRamen(id, ddlMeat.SelectedValue, txtName.Text, txtBroth.Text, txtPrice.Text);
                lblError.ForeColor = System.Drawing.Color.Green;
                clearTxt();
                lblError.Text = "Insert New Ramen Succeeded";
            }
        }
    }
}