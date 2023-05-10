using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBuku.Repository;
namespace TokoBuku.Handler
{
    public class LoginHandler
    {
        public static String checkUserObject(String username , String password)
        {
            return UserRepository.getUser(username, password) != null ?
                "Success Login" : "User Doesnt Exist!";
        }
    }
}