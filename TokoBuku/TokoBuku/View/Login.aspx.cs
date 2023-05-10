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
            HttpCookie cookie = Request.Cookies["user_cookie"];
            if(cookie != null)
            {
                txtUsername.Text = cookie.Values["username"];
                txtPassword.Text = cookie.Values["password"];
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User user = UserRepository.getUser(username, password);

            bool remember = LoginController.RememberChecked();

            if(user == null)
            {
                lblValidate.Text = "User Not Found!";
                lblValidate.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LoginController.IncreaseUserCount();
                if (remember) LoginController.SetCookie(username, password);

                LoginController.SetSession(user);
                Response.Redirect("Home.aspx");
            }
            }
        }


    }
