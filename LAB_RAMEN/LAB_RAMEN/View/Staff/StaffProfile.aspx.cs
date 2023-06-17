using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Model;
using LAB_RAMEN.Repository;
namespace LAB_RAMEN.View.Staff
{
    public partial class StaffProfile : System.Web.UI.Page
    {

        static DatabaseRamenEntities1 db = DBSingleton.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = (User)Session["user"];
                disableTxt();
                fetchDataToTxt(user);
            }
        }

        private void fetchDataToTxt(User user)
        {
            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            ddlGender.SelectedValue = user.Gender;
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void disableTxt()
        {
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            ddlGender.Enabled = false;
            txtEmail.Enabled = false;
            txtConfirmPassword.Enabled = false;
        }

        private void enableTxt()
        {
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            ddlGender.Enabled = true;
            txtEmail.Enabled = true;
            txtConfirmPassword.Enabled = true;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            enableTxt();
            btnSave.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            User userid = (User)Session["user"];
            User user = db.Users.Find(userid.id);
            user.Username = txtUsername.Text;
            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;
            user.Gender = ddlGender.SelectedValue;
            DataBind();
            db.SaveChanges();
            fetchDataToTxt(user);
            disableTxt();
            btnSave.Enabled = false;
        }
    }
}