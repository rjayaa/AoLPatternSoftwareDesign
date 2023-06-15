using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Controller;
using LAB_RAMEN.Repository;
using LAB_RAMEN.Handler;
namespace LAB_RAMEN.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../View/Login.aspx");
        }


        protected void btnRegister_Click1(object sender, EventArgs e)
        {
            int id = GenerateIDRepository.GenerateID("User");
            if (!RegisterController.ValidateUsername(txtUsername.Text))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Length must be between 5 and 15 and alphabet with space only.";
            }
            else if (!RegisterController.ValidateEmail(txtEmail.Text))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Must ends with '.com'.";
            }
            else if (!RegisterController.ValidateGender(ddlGender.SelectedValue))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Gender Must be Chosen.";
            }
            else if (!RegisterController.ValidatePassword(txtPassword.Text, txtConfirmPassword.Text))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Must be the same with confirm password.";
            }
            else if (!RegisterController.ValidatePassword(txtConfirmPassword.Text, txtPassword.Text))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Must be the same with password.";
            }
            else
            {
                RegisterHandler.insertUser(id, 3, txtUsername.Text, txtEmail.Text, ddlGender.SelectedValue, txtPassword.Text);
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Registration succeeded";
            }
        }
    }
}