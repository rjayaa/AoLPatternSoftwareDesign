using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBukuKita.Handler
{
    public class LoginHandler
    {
        public static String checkUserObject(String username, String password)
        {
            return Repository.Repository.getUser(username, password) != null ?
                "Success Login" : "User Doesnt Exist!";
        }
    }
}