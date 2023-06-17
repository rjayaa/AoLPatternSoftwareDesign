using LAB_RAMEN.Model;
using LAB_RAMEN.Handler;
using LAB_RAMEN.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB_RAMEN.View
{
    public partial class Login : System.Web.UI.Page
    {
        static DatabaseRamenEntities1 db = DBSingleton.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["user_cookie"];
                if (cookie != null)
                {
                    txtUsername.Text = cookie.Values["username"];
                    txtPassword.Text = cookie.Values["password"];
                }
            }
        }

        protected void btnRegister_Click1(object sender, EventArgs e)
        {
            Response.Redirect("../View/Register.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = LoginHandler.loginHandler(txtUsername.Text,txtPassword.Text);
            if(user == null)
            {
                lblError.Text = "Username or Password Incorrect";
            }
            else
            {
                if (chkRemember.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Values["username"] = txtUsername.Text;
                    cookie.Values["password"] = txtPassword.Text;
                    cookie.Expires.AddMinutes(0);
                    Response.Cookies.Add(cookie);
                }

                Session["user"] = user;
                if (user.RoleID == 1) Response.Redirect("../View/Admin/AdminMenu.aspx");
                else if (user.RoleID == 2) Response.Redirect("../View/Staff/StaffHome.aspx");
                else if (user.RoleID == 3) Response.Redirect("../View/Customer/MenuCustomer.aspx");
            }
        }
    }
}