using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Repository;
using LAB_RAMEN.Model;
using LAB_RAMEN.Controller;
namespace LAB_RAMEN.View.Admin
{
    public partial class AdminStaffUpdateRamen : System.Web.UI.Page
    {
        static DatabaseRamenEntities1 db = DBSingleton.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMeat.DataSource = RamenRepository.GetMeatData();
                ddlMeat.DataBind();

                string id = Request["ID"];
                int ramenId = int.Parse(id);
                Raman rm = db.Ramen.Find(ramenId); ;
                txtName.Text = rm.Name;
                ddlMeat.SelectedValue = RamenRepository.GeatMeatNameById(rm.MeatID);
                txtBroth.Text = rm.Broth;
                txtPrice.Text = rm.Price;
                disableTxt();

            }
        }
        protected void enableTxt()
        {
            txtName.Enabled = true;
            txtBroth.Enabled = true;
            txtPrice.Enabled = true;
        }
        protected void disableTxt()
        {
            txtName.Enabled = false;
            txtBroth.Enabled = false;
            txtPrice.Enabled = false;
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminStaffManageRamen.aspx");
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string id = Request["ID"];
            int updateID = int.Parse(id);
            string meatName = ddlMeat.SelectedValue;

            if (!RamenController.ValidateName(txtName.Text))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Must contains ‘Ramen’.";
                return;
            }
            if (!RamenController.ValidateMeat(ddlMeat.SelectedValue))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Must Be Selected";
                return;
            }
            if (!RamenController.ValidateBroth(txtBroth.Text))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Cannot Be Empty";
                return;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || !RamenController.ValidatePrice(price))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Price must be at least 3000.";
                return;
            }

            Raman up = db.Ramen.Find(updateID);
            up.Name = txtName.Text.ToString(); ;
            up.MeatID = RamenRepository.GeatIdByMeatName(meatName);
            up.Broth = txtBroth.Text.ToString();
            up.Price = txtPrice.Text.ToString();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Update Success!";
            db.SaveChanges();

            disableTxt();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            enableTxt();
        }
    }
}