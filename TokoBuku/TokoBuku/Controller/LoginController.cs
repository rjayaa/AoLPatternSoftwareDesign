using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
using TokoBuku.Handler;
namespace TokoBuku.Controller
{
    public class LoginController
    {
        public static String CheckUsername(String username)
        {
            String message = "";
            if (username.Equals("")) message = "Username cannot be empty";
            else if (username.Length < 3) message = "Username length cannot be less than 3";

            return message;
        }

        public static String CheckPassword(String password)
        {
            String message = "";
            if (password.Equals("")) message = "password cannot be empty";
            else if (password.Length < 3) message = "password length cannot be less than 3";

            return message;
        }

        public static String Login(String username, String password)
        {
            String message = CheckUsername(username);
            if (message.Equals("")) message = CheckPassword(password);

            if(username.Equals("admin") && password.Equals("admin221"))
            {
                HttpContext.Current.Response.Redirect("Home.aspx");
                return string.Empty;
            }
            if (message.Equals("")) message = LoginHandler.checkUserObject(username, password);


            return message;

        }
    }
}
