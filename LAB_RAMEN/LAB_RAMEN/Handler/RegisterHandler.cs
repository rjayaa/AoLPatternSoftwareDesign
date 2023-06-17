using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAB_RAMEN.Model;
using LAB_RAMEN.Repository;
namespace LAB_RAMEN.Handler
{
    public class RegisterHandler
    {

        public static bool insertUser(int id, int roleid, string username, string email, string gender, string password)
        {
            return LoginAndRegisterRepository.RegisterRepository( id, roleid,  username,  email,  gender,  password);
        }


    }
}
