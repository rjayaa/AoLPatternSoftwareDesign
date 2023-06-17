using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;

using LAB_RAMEN.Repository;
namespace LAB_RAMEN.Handler
{
    public class LoginHandler
    {
        public static User loginHandler(string username, string password)
        {
            return LoginAndRegisterRepository.LoginRepository(username, password);
        }
    }
}