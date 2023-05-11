using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBuku.Controller;
using TokoBuku.Model;
using TokoBuku.Repository;
namespace TokoBuku.View
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            lblValidate.Text = LoginController.Login(username, password);
            if (lblValidate.Text.Equals("Success Login")) Response.Redirect("Home.aspx");
        }


    }
}
