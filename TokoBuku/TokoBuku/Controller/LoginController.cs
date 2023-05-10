using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Model;
namespace TokoBuku.Controller
{
    public class LoginController
    {

        public static void SetCookie(string username, string password)
        {
            HttpCookie cookie = new HttpCookie("user_cookie");
            cookie.Values["username"] = username;
            cookie.Values["password"] = password;
            cookie.Expires = DateTime.Now.AddMinutes(2);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static HttpCookie GetCookie()
        {
            return HttpContext.Current.Request.Cookies["user_cookie"];
        }

        public static bool RememberChecked()
        {
            return HttpContext.Current.Request.Form["chkBox"] != null;
        }

        public static void IncreaseUserCount()
        {
            if (HttpContext.Current.Application["user_count"] == null)
            {
                HttpContext.Current.Application["user_count"] = 1;
            }
            else
            {
                HttpContext.Current.Application["user_count"] = (int)HttpContext.Current.Application["user_count"] + 1;
            }
        }

        public static void SetSession(User user)
        {
            HttpContext.Current.Session["user_session"] = user;
        }
    }
}
